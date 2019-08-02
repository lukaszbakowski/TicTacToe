using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.ViewModels.Base;
using System.Windows.Input;
using SharedLibraryTTT.Json;
using SharedLibraryTTT.Json.Base;
using TicTacToe.Core;



namespace TicTacToe.ViewModels
{
    public class SlotViewModel : BaseViewModel
    {
        private BaseJson<SlotViewJson> JSON = new BaseJson<SlotViewJson>();
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
                if(_slotJson != value)
                {
                    _slotJson = value;
                    OnSlotJsonChanged(EventArgs.Empty);
                    MenuViewJson MenuJSON = new MenuViewJson();
                    if(SlotJson.Left.Button == false && SlotJson.Right.Button == false)
                    {
                        MenuJSON.Start = true;
                        MenuViewModel.MainMenu = MenuJSON;
                    }
                    else
                    {
                        MenuJSON.Start = false;
                        MenuViewModel.MainMenu = MenuJSON;
                    }
                }
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
                return new BaseViewRelay(LeftJoin_cmd);
            }
        }
        internal void LeftJoin_cmd()
        {

            SlotJson.Left.Nick = MainWindow.PlayerName;
            SlotJson.Left.Button = false;

            string StringSon = JSON.Serializer(SlotJson);

            CoreClientConnect.ConnCommand(3, StringSon);
        }
        public ICommand RightJoin
        {
            get
            {
                return new BaseViewRelay(RightJoin_cmd);
            }
        }
        internal void RightJoin_cmd()
        {

 
            SlotJson.Right.Nick = MainWindow.PlayerName;
            SlotJson.Right.Button = false;

            string StringSon = JSON.Serializer(SlotJson);

            CoreClientConnect.ConnCommand(3, StringSon);
        }

        public ICommand RightLeave
        {
            get
            {
                return new BaseViewRelay(RightLeave_cmd);
            }
        }
        internal void RightLeave_cmd()
        {

            SlotJson.Right.Nick = "O";
            SlotJson.Right.Button = true;

            string StringSon = JSON.Serializer(SlotJson);

            CoreClientConnect.ConnCommand(3, StringSon);

        }
        public ICommand LeftLeave
        {
            get
            {
                return new BaseViewRelay(LeftLeave_cmd);
            }
        }
        internal void LeftLeave_cmd()
        {

            SlotJson.Left.Nick = "X";
            SlotJson.Left.Button = true;

            string StringSon = JSON.Serializer(SlotJson);

            CoreClientConnect.ConnCommand(3, StringSon);

        }

        #endregion

    }
}
