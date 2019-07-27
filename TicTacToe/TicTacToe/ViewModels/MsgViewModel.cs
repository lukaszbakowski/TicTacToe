using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using TicTacToe.ViewModels.Base;

namespace TicTacToe.ViewModels
{
    public class MsgViewModel : BaseUserConnect
    {
        
     
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

            SendMessages(TextSend);
            TextSend = "";
            
        }

        #endregion
    }
}
