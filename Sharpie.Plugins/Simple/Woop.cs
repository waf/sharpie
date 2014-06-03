using Sharpie.Irc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Plugins.Simple
{
    class Woop
    {
        private const int MaxWoops = 20;
        private const String WOOP = "WOOP";
        private readonly IEnumerable<String> woops = Enumerable.Repeat(WOOP, MaxWoops).ToImmutableList();

        [Trigger(@"^#woo([o]*)p ?([0-9]*\.?[0-9]*)?",
                "#woop - woop 10 times",
                "#woop n - woop n times",
                "#wooooop - woop for each 'o'")]
        public string WoopItUp(String os, String n)
        {
            float num = os.Length > 0 ? os.Length + 2 :
                        String.IsNullOrEmpty(n) ? 10 :
                        float.Parse(n);

            int integer = (int)num;
            int fraction = (int)Math.Round(4 * (num - integer));

            var woopList = woops.Take(integer)
                .ToImmutableList()
                .Add(WOOP.Substring(0, fraction));

            return Color.Red + String.Join(" ", woopList);
        }
    }
}
