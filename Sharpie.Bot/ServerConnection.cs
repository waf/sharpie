using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sharpie.Bot
{
    class ServerConnection : IDisposable
    {
        private TcpClient client;

        public ServerConnection(string server, int port)
        {
            this.client = new TcpClient(server, port);
        }

        /// <summary>
        /// asynchronously send messages from the connected server to the specified block
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public async void SendServerMessagesToBlock(ITargetBlock<String> block)
        {
            using (var stream = client.GetStream())
            using (var reader = new StreamReader(stream, Encoding.UTF7))
            {
                while (true)
                {
                    String message = await reader.ReadLineAsync();
                    Console.WriteLine("Received from server: " + message);
                    if (message != null)
                    {
                        block.Post(message);
                    }
                    else
                    {
                        block.Complete();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Asynchronously pull messages from a block, and send it to the connected server
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public async void SendBlockMessagesToServer(ISourceBlock<String> block)
        {
            using (var stream = client.GetStream())
            using (var writer = new StreamWriter(stream, Encoding.ASCII))
            {
                while (await block.OutputAvailableAsync())
                {
                    var message = await block.ReceiveAsync();
                    writer.WriteLine(message);
                    writer.Flush();
                    Console.WriteLine("Sent to server: " + message);
                }
            }
        }

        public void Dispose()
        {
            this.client.Close();
        }
    }
}
