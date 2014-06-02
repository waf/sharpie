using Sharpie.Irc;
using Sharpie.Irc.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sharpie.Bot
{
    public class Sharpie
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Starting Sharpie");
            Sharpie.RunBot("irc.freenode.net", 6667, "#rhwaftest");
            Console.WriteLine("Shutting down");
        }

        private static void RunBot(String ircServer, int ircPort, String initialChannel)
        {
            using (var conn = new ServerConnection(ircServer, ircPort))
            {
                var endpoints = SetupIrcDataflow(initialChannel);
                ITargetBlock<string> messageReceiver = endpoints.Item1;
                ISourceBlock<string> messageSender = endpoints.Item2;

                conn.SendServerMessagesToBlock(messageReceiver);
                conn.SendBlockMessagesToServer(messageSender);

                AdminConsole();
            }
        }

        private static Tuple<ITargetBlock<string>, ISourceBlock<string>> SetupIrcDataflow(String initialChannel)
        {
            var startpoint = new TransformBlock<String, IrcMessage>(str => IrcMessageParser.Deserialize(str));
            var broadcaster = new BroadcastBlock<IrcMessage>(null);
            startpoint.LinkTo(broadcaster);
            var endpoint = new TransformBlock<IrcMessage, String>(msg => IrcMessageParser.Serialize(msg));

            Dataflows.InstallComplexPluginSystem(broadcaster, endpoint);
            Dataflows.InstallSimplePluginSystem(broadcaster, endpoint);

            return Tuple.Create((ITargetBlock<string>)startpoint, (ISourceBlock<string>)endpoint);
        }

        private static void AdminConsole()
        {
            Console.WriteLine("Available admin commands: quit");
            String command = null;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
            } while (command != "quit");
        }
    }
}
