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
using TicTacToe.ViewModels;
using SharedLibraryTTT;
using SharedLibraryTTT.Json;
using SharedLibraryTTT.Json.Base;
using System.Runtime.Serialization.Json;
using System.IO;

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
            
            byte[] bytes = new byte[8];
            string responseData;
            int i;
            try
            {
                while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) > 0)
                {

                    responseData = Encoding.ASCII.GetString(bytes, 0, i);
                    
                    if(responseData == SharedCommands.Command_1)
                    {
                        DoCommand1();
                    }
                    else if(responseData == SharedCommands.Command_2)
                    {
                        DoCommand2();
                    }
                    else if (responseData == SharedCommands.Command_3)
                    {
                        DoCommand3();
                    }
                    else if (responseData == SharedCommands.Command_4)
                    {
                        DoCommand4();
                    }
                    else if (responseData == SharedCommands.Command_5)
                    {
                        DoCommand5();
                    }
                    else
                    {
                        throw new Exception("CONNECTION CORRUPTED - command error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.MsgErrorOk("Listening ERROR", "Listening ERROR: " + ex.ToString());
            }

        }
        private static void DoCommand1()
        {
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                BaseJson<MsgViewJson> JSON = new BaseJson<MsgViewJson>();
                MsgViewJson _CopySon = MsgViewModel.MsgSon;
                MsgViewJson _MsgSon = JSON.Deserializer(data);
                _CopySon.Nick = _MsgSon.Nick;
                MsgViewModel.MsgSon = _CopySon;
                return;
            }
        }
        private static void DoCommand2()
        {
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                MsgViewJson _MsgSon = MsgViewModel.MsgSon;
                _MsgSon.Message += data + "\n";
                MsgViewModel.MsgSon = _MsgSon;

                return;
            }
        }
        private static void DoCommand3()
        {
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);

                BaseJson<SlotViewJson> JSON = new BaseJson<SlotViewJson>();
                SlotViewModel.SlotJson = JSON.Deserializer(data);
                return;
            }
        }
        private static void DoCommand4()
        {
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                

                return;
            }
        }
        private static void DoCommand5()
        {
            string data;
            byte[] bytes = new byte[256];
            int i;
            while ((i = ListeningStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                

                return;
            }
        }

    }
}
