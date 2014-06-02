using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc.Messages
{
    public class IrcMessage
    {
        public String Command { get; internal set; }
        internal String Prefix { get; set; }
        internal string[] Params { get; set; }
        internal string Trailing { get; set; }

        public IrcMessage()
        {
            this.Params = new string[14];
        }
    }
}
