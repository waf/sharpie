using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc
{
    public class TextEffect
    {
        public const string Bold = "\x02";
        public const string Italic = "\x1D";
        public const string Reset = "\x0F";
        public const string Reverse = "\x16";
        public const string Underline = "\x1F";
    }
}
