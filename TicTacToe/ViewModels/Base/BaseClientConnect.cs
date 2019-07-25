using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TicTacToe.ViewModels.Base
{
    static class BaseClientConnect
    {
        private static readonly TcpClient TcpClient;
        public static readonly NetworkStream Stream;
        static BaseClientConnect()
        {
            TcpClient = new TcpClient();
            TcpClient.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            Stream = TcpClient.GetStream();
        }
        public static void ConnStop()
        {
            Stream.Close();
            TcpClient.Close();
        }
        public static void ConnSend(string _msg)
        {
            string msg = _msg;
            NetworkStream stream = Stream;
            int test = 0x1;
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(_msg);
             data = BitConverter.GetBytes(test);
            stream.Write(data, 0, data.Length);
        }
    }
}
