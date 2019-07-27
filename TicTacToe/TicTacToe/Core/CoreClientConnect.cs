using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace TicTacToe.Core
{
    static class CoreClientConnect
    {
        private static readonly TcpClient TcpClient = new TcpClient();
        public static NetworkStream Stream { get; set; }
        public static Thread thrMessaging;
        static CoreClientConnect()
        {
            TcpClient.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            
            Stream = TcpClient.GetStream();
            thrMessaging = new Thread(CoreClientListening.ReceiveMessages);
            thrMessaging.Start();
        }

        public static void ConnStop()
        {
            Stream.Close();
            TcpClient.Close();
        }
        public static void ConnCommand(int _i = -1, string _msg = "")
        {
            switch (_i)
            {
                case 0://disconnecting
                    ConnSend(GetBase64(0xFFFF00));
                    break;
                case 1://define client nick name
                    ConnSend(GetBase64(0xFFFF01));
                    ConnSend(_msg);
                    break;
                case 2://join left slot of game
                    ConnSend(GetBase64(0xFFFF02));
                    break;
                case 3://join right slot of game
                    ConnSend(GetBase64(0xFFFF03));
                    break;
                case 4://
                    ConnSend(GetBase64(0xFFFF04));
                    break;
                case 5://
                    ConnSend(GetBase64(0xFFFF05));
                    break;
                default://send msg only
                    ConnSend(_msg);
                    break;
            }
        }
        #region "private ENCODING"
        private static void ConnSend(string _msg)
        {

            byte[] data = System.Text.Encoding.ASCII.GetBytes(_msg);
            Stream.Write(data, 0, data.Length);
        }

        private static string GetBase64(int _hex)
        {
            byte[] bytes = new byte[256];
            bytes = BitConverter.GetBytes(_hex);
            return Convert.ToBase64String(bytes);
        }
        #endregion
    }
}
