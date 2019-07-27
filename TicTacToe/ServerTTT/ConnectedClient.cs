using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ServerTTT
{
    class ConnectedClient : ServerCommands
    {
        public TcpClient Client { get; set; }
        public NetworkStream stream;
        public string Name { get; set;}

        public Thread thread;
        public ConnectedClient(TcpClient _client)
        {
            Client = _client;
            stream = Client.GetStream();
            thread = new Thread (ClientListening);
            thread.Start();
        }

        private void ClientListening()
        {
            
            string data = null;
            byte[] bytes = new byte[256];

            int i;

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    if (data == Command_1)
                    {
                        SwitchCommand(1, stream);
                        Name = Thread.CurrentThread.Name;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.Name);
                        data = Thread.CurrentThread.Name + ": " + data;
                        ResponseHandler.SendMessage(data);
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Thread ERROR: {0}", e.ToString());
                ResponseHandler.ConnClientList.Remove(this);
                stream.Close();
                Client.Close();
                Thread.CurrentThread.Abort();
            }
        }
    }
}
