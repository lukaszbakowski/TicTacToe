using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SharedLibraryTTT
{
    public static class SharedCommands
    {
        static SharedCommands()
        {

        }

        #region "set options"
        public static string Command_0 = GetBase64(0xFFFF00); //reserve or disconnecting?
        public static string Command_1 = GetBase64(0xFFFF01); //nick name and player list
        public static string Command_2 = GetBase64(0xFFFF02); //normal message
        public static string Command_3 = GetBase64(0xFFFF03); //left join
        public static string Command_4 = GetBase64(0xFFFF04); //rght join
        public static string Command_5 = GetBase64(0xFFFF05); //game handler
        #endregion
        public static string GetBase64(int _hex)
        {
            byte[] Bytes = new byte[256];
            Bytes = BitConverter.GetBytes(_hex);
            return Convert.ToBase64String(Bytes);
        }
 
        public static bool SendCommandHandler(NetworkStream _stream, string _command, string _msg)
        {
            try
            {
                if(_stream.CanWrite)
                {
                    byte[] data = new byte[256];
                    data = System.Text.Encoding.ASCII.GetBytes(_command);
                    _stream.Write(data, 0, data.Length);
                    data = System.Text.Encoding.ASCII.GetBytes(_msg);
                    _stream.Write(data, 0, data.Length);
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
