using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerTTT
{
    class ServerCommands
    {
        public ServerCommands()
        {
            Initializer();
        }

        #region "set options"
        public string Command_1;
        public string Command_2;
        public string Command_3;
        public string Command_4;
        public string Command_5;
        public void Initializer()
        {
            Command_1 = GetBase64(0xFFFF01);
            Command_2 = GetBase64(0xFFFF02);
            Command_3 = GetBase64(0xFFFF03);
            Command_4 = GetBase64(0xFFFF04);
            Command_5 = GetBase64(0xFFFF05);
        }
        
        public string GetBase64(int _hex)
        {
            byte[] bbytes = new byte[256];
            bbytes = BitConverter.GetBytes(_hex);
            return Convert.ToBase64String(bbytes);
        }
        #endregion

        public void SwitchCommand(int _choice, NetworkStream _stream)
        {
            switch(_choice)
            {
                case 1:
                    int i;
                    byte[] bytes = new byte[256];
                    string data;
                    while ((i = _stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("{1}: Nickname: {0}", data, Thread.CurrentThread.ManagedThreadId);
                        Thread.CurrentThread.Name = data;
                        return;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
