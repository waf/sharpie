using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class ModeMessage : IrcMessage
    {
        public ModeMessage()
        {

        }
        public ModeMessage(String target, String modeChange)
        {
            this.Command = MessageType.Mode;
            this.Target = target;
            this.ModeChange = modeChange;
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

        public string ModeChange
        {
            get
            {
                return this.Params[1];
            }
            private set
            {
                this.Params[1] = value;
            }
        }
    }
}
