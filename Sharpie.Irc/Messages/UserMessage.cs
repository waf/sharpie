using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    [Flags]
    public enum Modes
    {
        None = 0,
        Wallops = 4,
        Invisible = 8
    }

    public class UserMessage : IrcMessage
    {
        public UserMessage(String user, String realname, Modes mode = Modes.Invisible)
        {
            this.Command = MessageType.User;
            this.User = user;
            this.Mode = mode;
            this.Params[2] = "*"; //unused
            this.Realname = realname;
        }

        public String User
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
        public Modes Mode
        {
            get
            {
                return (Modes)int.Parse(this.Params[1]);
            }
            private set
            {
                this.Params[1] = ((int)value).ToString();
            }
        }

        public string Realname
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
