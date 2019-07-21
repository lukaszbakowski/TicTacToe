using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using TicTacToe.Views;
using TicTacToe.Commands.Generic;

namespace TicTacToe.Connections
{
    class ClientSocketConnection : ViewModelBase
    {
       
        private Thread thrMessaging;
        private delegate void UpdateLogCallBack(string strMessage);
        public string textSend = "";
        public string textReceived = "";
        Byte[] bytes = new Byte[256];
        String data = null;
        TcpClient tcpClient;
        NetworkStream stream;

        public ClientSocketConnection()
        {
            tcpClient = new TcpClient();

            tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            stream = tcpClient.GetStream();
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }

        ~ClientSocketConnection()
        {
            stream.Close();
            tcpClient.Close();
        }
        public void ReceiveMessages()
        {
           
                String responseData = String.Empty;

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                   
                    responseData = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                    TextReceived += responseData + "\n";
                }

        }

        public string TextSend {
            get
            {
                return this.textSend;
            }
            
            
            set
            {
                this.textSend = value;
                OnPropertyChanged("TextSend");
            }
        }
        public string TextReceived
        {
            get { return this.textReceived; }
            set
            {
                this.textReceived = value;
                OnPropertyChanged("TextReceived");
            }
        }

        public ICommand SendCommand
        {
            get
            {
                return new connCommand(msgSend);
            }
        }
        internal void msgSend()
        {

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(TextSend);
            stream.Write(data, 0, data.Length);
            TextSend = "";
            
 
        }


    }
}
