using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using TicTacToe.ViewModels.Base;

namespace TicTacToe.ViewModels
{
    public class MsgViewModel : BaseSocketConn
    {

        public override string RcvMsg { get => base.RcvMsg; set { base.RcvMsg = value; OnPropertyChanged("RcvMsg"); } }
        
        public MsgViewModel()
        {
            
        }

        #region "settery i gettery"
        private string textSend;
        public string TextSend
        {
            get { return this.textSend; }

            set
            {
                this.textSend = value;
                OnPropertyChanged("TextSend");
            }
        }
        #endregion

        #region "UI Commands"
        public ICommand SendCommand
        {
            get
            {
                return new BaseRelayCommands(msgSend);
            }
        }

        internal void msgSend()
        {

            SendMessages(TextSend);
            TextSend = "";
            
        }

        #endregion
    }
}
