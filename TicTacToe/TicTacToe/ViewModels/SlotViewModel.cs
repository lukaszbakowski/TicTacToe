using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.ViewModels.Base;
using System.Windows.Input;



namespace TicTacToe.ViewModels
{
    public class SlotViewModel : BaseUserConnect
    {

        public SlotViewModel()
        {

        }

        #region"settery i gettery"
        private string _Oo = "O";
        public string Oo
        {
            get { return _Oo; }
            set { this._Oo = value; OnPropertyChanged(Oo); }
        }
        private string _Xx = "X";
        public string Xx
        {
            get { return _Xx; }
            set { this._Xx = value; OnPropertyChanged(Xx); }
        }
        #endregion

        #region "UI Commands"
        public ICommand LeftJoin
        {
            get
            {
                return new BaseUserRelay(LeftJoin_cmd);
            }
        }
        internal void LeftJoin_cmd()
        {

        }
        public ICommand RightJoin
        {
            get
            {
                return new BaseUserRelay(RightJoin_cmd);
            }
        }
        internal void RightJoin_cmd()
        {

        }
        #endregion
    }
}
