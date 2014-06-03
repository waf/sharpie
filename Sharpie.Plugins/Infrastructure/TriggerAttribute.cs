using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sharpie.Plugins.Simple
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TriggerAttribute : Attribute
    {
        public Regex Regex { get; private set; }
        public String[] Documentation { get; private set; }
        public TriggerAttribute(String regex, params String[] documentation)
        {
            this.Regex = new Regex(regex);
            this.Documentation = documentation;
        }
    }
}
