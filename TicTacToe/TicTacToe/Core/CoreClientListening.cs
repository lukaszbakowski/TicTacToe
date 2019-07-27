using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TicTacToe.Service;

namespace TicTacToe.Core
{
    public static class CoreClientListening
    {
        private static readonly NetworkStream ListeningStream;
        static CoreClientListening()
        {
            ListeningStream = CoreClientConnect.Stream;
        }
        public static void ReceiveMessages()
        {
            
            byte[] bytes = new byte[256];
            string responseData;
            int i;
            try
            {
                while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) != 0)
                {

                    responseData = Encoding.ASCII.GetString(bytes, 0, i) + "\n";

                    CoreClientParams.MessageReceived = responseData;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.MsgErrorOk("Listening ERROR: " + ex, "Listening ERROR");
            }

        }

    }
}
