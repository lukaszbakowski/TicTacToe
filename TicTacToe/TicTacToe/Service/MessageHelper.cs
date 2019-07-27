using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe.Service
{
    static class MessageHelper
    {
        public static void MsgErrorOk(string _title, string _msg)
        {
            MessageBox.Show(_msg, _title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
