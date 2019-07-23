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


        private Thread thrMessaging;
        private TcpClient tcpClient;
        private NetworkStream stream;
        public BaseSocketConn()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            stream = tcpClient.GetStream();
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();

        }


        public void ReceiveMessages()
        {
            stream = tcpClient.GetStream();
            Byte[] bytes = new Byte[256];
            String responseData = String.Empty;


            int i;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {

                responseData = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                RcvMsg += responseData + "\n";



                //MessageBox.Show(this.receivedMsg, "incoming msg recived", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void SendMessages(string _msg)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(_msg);
            stream.Write(data, 0, data.Length);
        }
    }
}
