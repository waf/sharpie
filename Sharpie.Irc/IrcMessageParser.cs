using Sharpie.Irc.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc
{
    public class IrcMessageParser
    {
        static IDictionary<String, Type> messageTypes = new Dictionary<String, Type>() {
            { MessageType.Ping, typeof(PingMessage) },
            { MessageType.Notice, typeof(NoticeMessage) },
            { MessageType.Mode, typeof(ModeMessage) },
            { MessageType.Join, typeof(JoinMessage) },
            { MessageType.Part, typeof(PartMessage) },
            { MessageType.PrivateMessage, typeof(PrivateMessage) },
        };

        public static IrcMessage Deserialize(String line)
        {
            // the main 4 parts of a message, defined by RFC2812
            String prefix = null;
            String command;
            String[] parameters;
            String trailing;

            int current = 0;
            // parse prefix
            if (line[0] == ':')
            {
                prefix = String.Concat(line.Substring(1).TakeWhile(c => c != ' '));
                current = prefix.Count() + 2;
            }

            // parse command
            command = String.Concat(line.Substring(current).TakeWhile(c => c != ' '));
            current += command.Count();

            // parse params
            var p = parseParams(line.Substring(current));
            trailing = p.Last();
            parameters = p.Take(p.Count() - 1).ToArray();

            IrcMessage message;
            if (messageTypes.ContainsKey(command))
            {
                message = (IrcMessage)Activator.CreateInstance(messageTypes[command]);
            }
            else
            {
                message = new IrcMessage();
                int code = -1;
                if (!int.TryParse(command, out code))
                {
                    Console.Error.WriteLine("ERROR: Not mapping message for command: " + command);
                }
            }

            message.Prefix = prefix;
            message.Command = command;
            message.Params = parameters;
            message.Trailing = trailing;

            return message;
        }

        private static IEnumerable<String> parseParams(string paramline)
        {
            var trailing = paramline.Split(new[] { ':' }, 2);
            var list = trailing[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (trailing.Count() > 1)
            {
                list = list.Concat(new[] { trailing[1] }).ToArray();
            }
            return list.Select(s => s.Trim());
        }

        public static String Serialize(IrcMessage msg)
        {
            var parts = new List<String>();
            if (msg.Prefix != null)
            {
                parts.Add(":" + msg.Prefix);
            }
            parts.Add(msg.Command);
            parts.AddRange(msg.Params.Where(p => !String.IsNullOrEmpty(p)));
            if (!String.IsNullOrEmpty(msg.Trailing))
            {
                parts.Add(":" + msg.Trailing);
            }
            return String.Join(" ", parts);
        }
    }
}
