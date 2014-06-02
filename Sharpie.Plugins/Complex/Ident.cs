using Sharpie.Irc.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sharpie.Plugins.Complex
{
    class Ident : IComplexPlugin
    {
        private int identCount = 0;
        private string nick;
        private string user;
        private string realname;

        public Ident()
        {
            this.nick = ConfigurationManager.AppSettings["nick"];
            this.user = ConfigurationManager.AppSettings["user"];
            this.realname = ConfigurationManager.AppSettings["realname"];
        }

        public bool Accepts(Irc.Messages.IrcMessage msg)
        {
            return Interlocked.Increment(ref identCount) == 1;
        }

        public IEnumerable<IrcMessage> Respond(IrcMessage msg)
        {
            yield return new UserMessage(user, realname);
            yield return new NickMessage(nick);
        }
    }
}
