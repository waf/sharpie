using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Plugins.Simple
{
    class Echo : ISimplePlugin
    {
        [Trigger("([^ ]*) (.*)")]
        public static string Repeat(String first, String second)
        {
            return first + " and " + second;
        }
    }
}
