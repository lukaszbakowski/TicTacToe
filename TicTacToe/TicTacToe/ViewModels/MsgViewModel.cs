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
using SharedLibraryTTT.Json;
using SharedLibraryTTT.Json.Base;


namespace TicTacToe.ViewModels
{
    public class MsgViewModel : BaseViewModel
    {

        public MsgViewModel()
        {
            _msgSon = new MsgViewJson();
        }
        #region "settery i gettery"
        private static MsgViewJson _msgSon;
        public static MsgViewJson MsgSon
        {
            get
            {
                return _msgSon;
            }
            set
            {
                _msgSon = value;
                OnMsgSonChanged(EventArgs.Empty);
            }
        }
        public static event EventHandler MsgSonChanged;

        protected static void OnMsgSonChanged(EventArgs e)
        {
            MsgSonChanged?.Invoke(null, e);
        }
        
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
                return new BaseViewRelay(MsgSend_cmd);
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
