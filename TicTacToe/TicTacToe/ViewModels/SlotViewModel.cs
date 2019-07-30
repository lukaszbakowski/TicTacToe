using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.ViewModels.Base;
using System.Windows.Input;
using SharedLibraryTTT.Json;
using TicTacToe.Core;



namespace TicTacToe.ViewModels
{
    public class SlotViewModel : BaseUserConnect<SlotViewJson>
    {

        public SlotViewModel()
        {
            _slotJson = new SlotViewJson();
        }

        #region"settery i gettery"

        private static SlotViewJson _slotJson;
        public static SlotViewJson SlotJson
        {
            get
            {
                return _slotJson;
            }
            set
            {
                _slotJson = value;
                OnSlotJsonChanged(EventArgs.Empty);
            }
        }

        public static event EventHandler SlotJsonChanged;

        protected static void OnSlotJsonChanged(EventArgs e)
        {
            SlotJsonChanged?.Invoke(null, e);
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
            SlotViewJson JSON = SlotJson;
            JSON.Left.Nick = MainWindow.PlayerName;
            JSON.Left.Button = false;

            string StringSon = Serializer(JSON);

            CoreClientConnect.ConnCommand(3, StringSon);
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

            SlotViewJson JSON = SlotJson;
            JSON.Right.Nick = MainWindow.PlayerName;
            JSON.Right.Button = false;

            string StringSon = Serializer(JSON);

            CoreClientConnect.ConnCommand(3, StringSon);
        }

        public ICommand RightLeave
        {
            get
            {
                return new BaseUserRelay(RightLeave_cmd);
            }
        }
        internal void RightLeave_cmd()
        {
            SlotViewJson JSON = SlotJson;
            JSON.Right.Nick = "O";
            JSON.Right.Button = true;

            string StringSon = Serializer(JSON);

            CoreClientConnect.ConnCommand(3, StringSon);

        }
        public ICommand LeftLeave
        {
            get
            {
                return new BaseUserRelay(LeftLeave_cmd);
            }
        }
        internal void LeftLeave_cmd()
        {
            SlotViewJson JSON = SlotJson;
            JSON.Left.Nick = "X";
            JSON.Left.Button = true;

            string StringSon = Serializer(JSON);

            CoreClientConnect.ConnCommand(3, StringSon);

        }

        #endregion

    }
}
