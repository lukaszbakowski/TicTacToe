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
        TcpListener server = null;
        List<TcpClient> clients = new List<TcpClient>();
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
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                    clients.Add(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }
        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
           
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);
                    SendDevice(data);
                    //string str = "Hey Device!";
                    //Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    //stream.Write(reply, 0, reply.Length);
                    //Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
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
                for (int j = 0; j < clients.Count; j++)
                {
                    NetworkStream stream = clients[j].GetStream();
                    string str = msg;
                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    stream.Write(reply, 0, reply.Length);
                    
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