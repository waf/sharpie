using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class PongMessage : IrcMessage
    {
        public PongMessage(String server)
        {
            this.Command = MessageType.Pong;
            this.Server = server;
        }

        public string Server
        {
            get
            {
                return this.Trailing;
            }
            private set
            {
                this.Trailing = value;
            }
        }
    }
}
