using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryTTT;
using System.Windows.Input;
using TicTacToe.ViewModels.Base;
using TicTacToe.Core;
using System.Net.Sockets;
using TicTacToe.Views;

namespace TicTacToe.ViewModels
{
    public class MsgViewModel : BaseUserConnect
    {
        public MsgView _viewMsg = new MsgView();
        public MsgView ViewMsg { get {
                return _viewMsg;
            } set { _viewMsg = value;
                OnPropertyChanged("ViewMsg");
            } }
        public MsgViewModel()
        {
          
        }


        #region "settery i gettery"
        private string textSend;
        public string TextSend
        {
            get { return textSend; }

            set
            {
                textSend = value;
                OnPropertyChanged("TextSend");
            }
        }
        #endregion

        #region "UI Commands"
        public ICommand SendCommand
        {
            get
            {
                return new BaseUserRelay(MsgSend_cmd);
            }
        }

        internal void MsgSend_cmd()
        {
            CoreClientConnect.ConnCommand(2, TextSend);
            TextSend = "";
        }

        #endregion
    }
}
