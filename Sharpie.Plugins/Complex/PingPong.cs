using Sharpie.Irc.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Plugins.Complex
{
    class PingPong : IComplexPlugin
    {
        public bool Accepts(IrcMessage msg)
        {
            return msg is PingMessage;
        }

        public IEnumerable<IrcMessage> Respond(IrcMessage pingMsg)
        {
            var ping = (PingMessage)pingMsg;
            yield return new PongMessage(ping.Server);
        }
    }
}
