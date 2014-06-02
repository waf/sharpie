using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sharpie.Plugins.Simple
{
    public class TriggerAttribute : Attribute
    {
        public Regex Regex { get; set; }
        public TriggerAttribute(String regex)
        {
            this.Regex = new Regex(regex);
        }
    }
}
