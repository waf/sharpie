using Sharpie.Irc;
using Sharpie.Irc.Messages;
using Sharpie.Plugins.Simple;
using Sharpie.Plugins.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sharpie.Bot
{
    class Dataflows
    {
        internal static void InstallComplexPluginSystem(ISourceBlock<IrcMessage> source, ITargetBlock<IrcMessage> destination)
        {
            // find all plugins implementing our complex iplugin interface, and create instances of them
            var plugins = Assembly.GetAssembly(typeof(IComplexPlugin))
                .GetTypes()
                .Where(t => typeof(IComplexPlugin).IsAssignableFrom(t) && !t.IsInterface)
                .Select(t => (IComplexPlugin)Activator.CreateInstance(t));

            // create a dataflow block for each plugin, and hook them up to the source/destination
            foreach (var plugin in plugins)
            {
                var pluginBlock = new TransformManyBlock<IrcMessage, IrcMessage>(msg => plugin.Respond(msg));
                source.LinkTo(pluginBlock, msg => plugin.Accepts(msg));
                pluginBlock.LinkTo(destination);
            }
        }

        internal static void InstallSimplePluginSystem(ISourceBlock<IrcMessage> source, ITargetBlock<IrcMessage> destination)
        {
            // find all classes that have methods adorned with the TriggerAttribute
            var triggerType = typeof(TriggerAttribute);
            Func<MethodInfo, bool> hasTrigger = method => method.CustomAttributes.Any(ca => ca.AttributeType == triggerType);
            var plugins = Assembly.GetAssembly(triggerType)
                .GetTypes()
                .Where(t => t.GetMethods().Any(hasTrigger))
                .ToDictionary(t => Activator.CreateInstance(t), //key is an instance of the class
                              t => t.GetMethods().Where(hasTrigger)); //value is all the methods adorned with TriggerAttribute


            // create a dataflow block for each trigger method
            foreach (var plugin in plugins)
            {
                var instance = plugin.Key;
                var triggers = plugin.Value;
                // a plugin can have multiple trigger methods
                foreach (var triggerMethod in triggers)
                {
                    var regex = triggerMethod.GetCustomAttribute<TriggerAttribute>().Regex;
                    var pluginBlock = new TransformBlock<IrcMessage, IrcMessage>(msg =>
                    {
                        var privmsg = (PrivateMessage)msg;
                        // get regex captures from text. the first element is the full string, so skip it
                        var matches = regex.Match(privmsg.Text).Groups.OfType<Capture>().Select(c => c.Value).Skip(1);
                        // call plugin with matched values
                        var response = (String)triggerMethod.Invoke(instance, matches.ToArray());
                        return new PrivateMessage(privmsg.Target, response);
                    });
                    // filter our link to private messages matching the regex
                    source.LinkTo(pluginBlock, msg => msg is PrivateMessage && regex.Match(((PrivateMessage)msg).Text).Success);
                    pluginBlock.LinkTo(destination);
                }
            }

        }

        private static IList<Type> DiscoverPluginImplementations<T>()
        {
            return Assembly.GetAssembly(typeof(ISimplePlugin))
                .GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface)
                .ToList();
        }

    }
}
