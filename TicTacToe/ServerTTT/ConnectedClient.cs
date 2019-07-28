using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using SharedLibraryTTT;

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
                    if (data == SharedCommands.Command_1)
                    {
                        DoCommand1();
                    }
                    else if (data == SharedCommands.Command_2)
                    {
                        DoCommand2();
                    }
                    else if(data == SharedCommands.Command_3)
                    {
                        DoCommand3();
                    }
                    else if (data == SharedCommands.Command_4)
                    {
                        DoCommand4();
                    }
                    else if (data == SharedCommands.Command_5)
                    {
                        DoCommand5();
                    } else
                    {
                        throw new Exception("CONNECTION CORRUPTED - no command.. disconecting..");
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
        private void DoCommand1()
        {
            string data = null;
            byte[] bytes = new byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("{1}: Nickname: {0}", data, Thread.CurrentThread.ManagedThreadId);
                Thread.CurrentThread.Name = data;
                Name = Thread.CurrentThread.Name;
                data = string.Empty;
                foreach(ConnectedClient cntClnt in ResponseHandler.ConnClientList)
                {
                    data += cntClnt.thread.Name + "\n";
                }
                ResponseHandler.SendMessage(SharedCommands.Command_1, data);
                return;
            }
        }
        private void DoCommand2()
        {
            string data = null;
            byte[] bytes = new byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.Name);
                data = Thread.CurrentThread.Name + ": " + data;
                ResponseHandler.SendMessage(SharedCommands.Command_2, data);
                return;
            }
        }
        private void DoCommand3()
        {

        }
        private void DoCommand4()
        {

        }
        private void DoCommand5()
        {

        }
    }
}
