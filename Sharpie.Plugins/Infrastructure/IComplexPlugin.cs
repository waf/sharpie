﻿using Sharpie.Irc.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Plugins.Complex
{
    public interface IComplexPlugin
    {
        bool Accepts(IrcMessage msg);
        IEnumerable<IrcMessage> Respond(IrcMessage msg);
    }
}
