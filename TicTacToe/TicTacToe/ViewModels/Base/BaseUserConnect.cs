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
using TicTacToe.Core;
using TicTacToe.Service;


namespace TicTacToe.ViewModels.Base
{
    public class BaseUserConnect : BaseUserControl
    {




        
        
        public BaseUserConnect()
        {

        }


        public void SendMessages(string _msg)
        {
            try
            {
                NetworkStream stream = CoreClientConnect.Stream;
                byte[] data = Encoding.ASCII.GetBytes(_msg);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageHelper.MsgErrorOk("Connection Error", "ERROR corrupted while sending msg to server: " + ex);
                
            }
            
        }
    }
}
