using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class NoticeMessage : IrcMessage
    {
        public NoticeMessage()
        {

        }

        public NoticeMessage(String nick, String text)
        {
            this.Command = MessageType.Notice;
            this.Nick = nick;
            this.Text = text;
        }

        public String Nick
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

        public String Text
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
