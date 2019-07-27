﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;




namespace ServerTTT
{
    static class ResponseHandler
    {

        public static List<ConnectedClient> ConnClientList = new List<ConnectedClient>();

        public static void SendMessage(string _msg)
        {
            byte[] reply = Encoding.ASCII.GetBytes(_msg);
            foreach (ConnectedClient cntClnt in ConnClientList)
            {
                try
                {
                    cntClnt.stream.Write(reply, 0, reply.Length);
                    Console.WriteLine("Sent: {0} to {1}", _msg, cntClnt.Name);
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