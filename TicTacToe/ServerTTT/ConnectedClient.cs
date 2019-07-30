using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using SharedLibraryTTT;
using SharedLibraryTTT.Json;
using SharedLibraryTTT.Json.Base;

namespace ServerTTT
{
    class ConnectedClient
    {
        public TcpClient Client;
        public NetworkStream stream;

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

            string data;
            byte[] bytes = new byte[256];
            int i;
            NetworkStream test = Client.GetStream();
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {

                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    if (data == SharedCommands.Command_1)
                    {
                  
                        DoCommand1();
                        Console.WriteLine("IS THAT WORKING OR RETURNING?");

                    }
                    else if (data == SharedCommands.Command_2)
                    {
                        DoCommand2();
                    }
                    else if(data == SharedCommands.Command_3)
                    {
                        DoCommand3();
                        DataSend("SlotViewJson");
                    }
                    else if (data == SharedCommands.Command_4)
                    {
                        DoCommand4();
                    }
                    else if (data == SharedCommands.Command_5)
                    {
                      
                        DoCommand5();
                    }
                    else
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
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("{1}: Nickname: {0}", data, Thread.CurrentThread.ManagedThreadId);
                Thread.CurrentThread.Name = data;
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
            string data;
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
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);

                Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.Name);
                BaseJson<SlotViewJson> JSON = new BaseJson<SlotViewJson>();
                SlotViewJson NewSlot = JSON.Deserializer(data);

                

                Server.GameBoard.SlotSon = NewSlot;
                //string test = JSON.Serializer(Server.GameBoard.SlotSon);
                //Console.WriteLine("TEST: " + test);
                return;
            }
        }
        private void DoCommand4()
        {
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);

                DataSend(data);
                return;
            }
        }
        private void DoCommand5()
        {

        }
        private void DataSend(string _choice)
        {
            switch(_choice)
            {
                case "SlotViewJson":
                    BaseJson<SlotViewJson> JSON = new BaseJson<SlotViewJson>();
                    //string test = JSON.Serializer(Server.GameBoard.SlotSon);
                    //Console.WriteLine("RESPONSE TEST: " + test);
                    ResponseHandler.SendMessage(SharedCommands.Command_3, JSON.Serializer(Server.GameBoard.SlotSon));
                    
                    break;
            }
        }
    }
}
