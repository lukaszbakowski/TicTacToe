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

    class Server : ServerCommands
    {
 

        TcpListener server = null;

        public Server(string ip, int port)
        {
 
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
                    continue;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                Thread.CurrentThread.Abort();
            }
        }

    }
    
}