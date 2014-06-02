using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class PingMessage : IrcMessage
    {
        public PingMessage()
        {
        }

        public PingMessage(String server)
        {
            this.Command = MessageType.Ping;
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
