using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerTTT
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                Server myserver = new Server("127.0.0.1", 13000);
            });
            t.Start();

            Console.WriteLine("Server Started...!");

            //////////////////////////////////////////////////////
            TcpClient Admin = new TcpClient();
            Admin.Connect("127.0.0.1",13000);
            NetworkStream streamAdmin = Admin.GetStream();
        HERE:
            string consoleCommand = "exit";
            string read = Console.ReadLine();

            if (read == consoleCommand)
            {
                t.Abort();
                Environment.Exit(0);
            } else
            {

                string str = "Admin: " + read;
                Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                streamAdmin.Write(reply, 0, reply.Length);
                Console.WriteLine("Sent: {0}", str);
                goto HERE;
            }

          
        }
    }
}
