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
            SlotViewJson TEST = new SlotViewJson();
            TEST.RightJoin.Nick = "kupa";
            TEST.RightJoin.Button = false;

            string test = Serializer(TEST);

            CoreClientConnect.ConnCommand(3, test);
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

            SlotViewJson TEST = new SlotViewJson();
            TEST.RightJoin.Nick = MainWindow.PlayerName;
            TEST.RightJoin.Button = false;

            string test = Serializer(TEST);

            CoreClientConnect.ConnCommand(3, test);
        }
        #endregion

    }
}
