using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TicTacToe.ViewModels;


namespace TicTacToe.ViewModels.Base
{
    public class BaseSocketConn : BaseUserControl
    {

        
        public virtual string RcvMsg { get; set; }

        private readonly Thread thrMessaging;
 
        public BaseSocketConn()
        {
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();

        }
        ~BaseSocketConn()
        {
            thrMessaging.Abort();
        }

        public void ReceiveMessages()
        {
            NetworkStream stream = BaseClientConnect.Stream;
            Byte[] bytes = new Byte[256];
            //string responseData = String.Empty;

            int i;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {

                string responseData = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                RcvMsg += responseData + "\n";

            }
        }

        public void SendMessages(string _msg)
        {
            string msg = _msg;
            NetworkStream stream = BaseClientConnect.Stream;
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }
    }
}
