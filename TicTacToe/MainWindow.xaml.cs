using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TicTacToe.Connections;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private TcpClient tcp;
        //private StreamWriter SwSender;
        //private StreamReader SrReciever;
        //private Thread thrMessaging;
        //private delegate void UpdateLogCallBack(string strMessage);

   
        public MainWindow()
        {
            InitializeComponent();
            //tcp = new TcpClient();
            //// txt_Log.AppendText("connecting");
            //tcp.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            //// txt_Log.AppendText("Connected");
            //thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            //thrMessaging.Start();

        }
        
        
    }
}
