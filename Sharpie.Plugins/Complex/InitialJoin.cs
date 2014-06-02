using Sharpie.Irc;
using Sharpie.Irc.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Plugins.Complex
{
    class InitialJoin : IComplexPlugin
    {
        private readonly String[] channels;

        public InitialJoin()
        {
            channels = ConfigurationManager.AppSettings["channels"].Split(',').ToArray();
        }

        public bool Accepts(IrcMessage msg)
        {
            return msg.Command == MessageType.RplMotdEnd;
        }

        public IEnumerable<IrcMessage> Respond(IrcMessage msg)
        {
            yield return new JoinMessage(channels);
        }
    }
}
