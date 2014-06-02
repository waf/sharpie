using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class JoinMessage : IrcMessage
    {
        public JoinMessage()
        {
        }

        public JoinMessage(params String[] channels)
        {
            this.Command = MessageType.Join;
            this.Channels = channels;
        }

        public IList<String> Channels
        {
            get
            {
                return this.Params[0].Split(',');
            }
            private set
            {
                this.Params[0] = String.Join(",", value);
            }
        }

        public String Target
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
