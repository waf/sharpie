using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class PartMessage : IrcMessage
    {
        public PartMessage()
        {
        }

        public PartMessage(String partingText, params String[] channels)
        {
            this.Command = MessageType.Part;
            this.Channels = channels;
            this.PartingText = partingText;
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
                return this.Prefix;
            }
            private set
            {
                this.Prefix = value;
            }
        }

        public String PartingText
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
