using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class NickMessage : IrcMessage
    {
        public NickMessage(String nick)
        {
            this.Command = MessageType.Nick;
            this.Nick = nick;
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
    }
}
