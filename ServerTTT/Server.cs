using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;



using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace ServerTTT
{

    class Server
    {
 
        private int MethodToDo = -1;

        TcpListener server = null;
        List<TcpClient> clients = new List<TcpClient>();
        List<NetworkStream> streams = new List<NetworkStream>();

        public Server(string ip, int port)
        {
 
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a new connection...");
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                    clients.Add(client);
                    streams.Add(stream);
                    
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }
        public string GetBase64(int _hex)
        {
            byte[] bbytes = new byte[256];
            bbytes = BitConverter.GetBytes(_hex);
            return Convert.ToBase64String(bbytes);
        }
        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
           
            string data = null;
            byte[] bytes = new byte[256];

            int i;


            


            try
            {
            OMG:
                switch (MethodToDo)
                {
                    case -1:
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {

                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        if (data == GetBase64(0xFFFF01))
                        {
                            Console.WriteLine("ojej przyslano nam bita :O");
                            MethodToDo = 1;
                            goto OMG;
                        }
                        else
                        {

                            Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.Name);
                            string snd = Thread.CurrentThread.Name + ": " + data;
                            SendDevice(snd);
                        }
                    }
                        break;
                    case 1:
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            data = Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("{1}: Nickname: {0}", data, Thread.CurrentThread.ManagedThreadId);
                            MethodToDo = -1;
                            Thread.CurrentThread.Name = data;
                            goto OMG;

                        }
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                clients.Remove(client);
                stream.Close();
                client.Close();
                
            }

        }
        public void SendDevice(string msg)
        {
            try
            {
                
                for (int j = 0; j < streams.Count; j++)
                {
                    if(streams[j].CanWrite)
                    {
                        string str = msg;
                        Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                        streams[j].Write(reply, 0, reply.Length);
                    } else
                    {
                        Console.WriteLine("cant write to the client... disconnecting...");
                        streams[j].Close();
                        clients[j].Close();
                        clients.Remove(clients[j]);
                        streams.Remove(streams[j]);
                    }
                }
            } catch(Exception ex)
            {
                
                Console.WriteLine("Wyjatek: " + ex);
            } finally
            {
                Console.WriteLine("Sent: {0}", msg);
            }
        }
    }
}