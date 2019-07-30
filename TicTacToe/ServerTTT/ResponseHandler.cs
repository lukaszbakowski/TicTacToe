using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using SharedLibraryTTT;



namespace ServerTTT
{
    static class ResponseHandler
    {

        public static List<ConnectedClient> ConnClientList = new List<ConnectedClient>();

        static ResponseHandler()
        {

        }

        public static void SendMessage(string _command, string _msg)
        {
            foreach (ConnectedClient cntClnt in ConnClientList)
            {
                try
                {
                    if (SharedCommands.SendCommandHandler(cntClnt.stream, _command, _msg))
                    {
                        Console.WriteLine("Succesfully send msg to {0}", cntClnt.thread.Name);
                    } else
                    {
                        Console.WriteLine("Msg send failed to {0}", cntClnt.thread.Name);
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("cant write to the client... disconnecting...");
                    cntClnt.thread.Abort();
                    cntClnt.stream.Close();
                    cntClnt.Client.Close();
                    ConnClientList.Remove(cntClnt);
                    Console.WriteLine("RESPONSE ERROR: " + ex);
                }
                
            }

        }
    }
}
