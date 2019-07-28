using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SharedLibraryTTT;


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
                case 0://unset
                    SharedCommands.SendCommandHandler(Stream, SharedCommands.Command_0, _msg);
                    break;
                case 1://define client nick name
                    SharedCommands.SendCommandHandler(Stream, SharedCommands.Command_1, _msg);
                    break;
                case 2://join left slot of game
                    SharedCommands.SendCommandHandler(Stream, SharedCommands.Command_2, _msg);
                    break;
                case 3://join right slot of game
                    SharedCommands.SendCommandHandler(Stream, SharedCommands.Command_3, _msg);
                    break;
                case 4://players list
                    SharedCommands.SendCommandHandler(Stream, SharedCommands.Command_4, _msg);
                    break;
                case 5://
                    SharedCommands.SendCommandHandler(Stream, SharedCommands.Command_5, _msg);
                    break;

            }
        }
    }
}
