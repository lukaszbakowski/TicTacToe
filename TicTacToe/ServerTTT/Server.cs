using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SharedLibraryTTT;


using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace ServerTTT
{

    class Server
    {
        private TcpListener server = null;
        public static ClientStructures GameBoard { get; set; }

        public Server(string ip, int port)
        {
            GameBoard = new ClientStructures();
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            Thread t = new Thread(StartListener);
            t.Start();

        }
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a new connection...");
                    TcpClient client_acpt = server.AcceptTcpClient();
                    ConnectedClient ConnClient = new ConnectedClient(client_acpt);
                    ResponseHandler.ConnClientList.Add(ConnClient); 
                    Console.WriteLine("Connected!");

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SERVER CORRUPTED ERROR: {0}, clossing all process...", e.ToString());
            } finally
            {
                Thread.CurrentThread.Abort();
                server.Stop();
            }
        }

    }
    
}