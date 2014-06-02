using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class PrivateMessage : IrcMessage
    {
        public PrivateMessage()
        {
        }

        public PrivateMessage(String target, String text)
        {
            this.Command = MessageType.PrivateMessage;
            this.Target = target;
            this.Text = text;
        }

        public string Target
        {
            get
            {
                return this.Params[0];
            }
            private set
            {
                this.Params[0] = value;
            }
        }

        public string Text
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
