using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryTTT.Json;
using SharedLibraryTTT.Json.Base;
using TicTacToe.ViewModels.Base;
using TicTacToe.Core;
using System.Windows.Input;
using TicTacToe.Service;
using TicTacToe.ViewModels;
using TicTacToe.Dialogs;
using System.ComponentModel;

namespace TicTacToe.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public static StartGameDialog StartDialog { get; set; }
        public MenuViewModel()
        {
            _mainMenu = new MenuViewJson();
        }
        private static MenuViewJson _mainMenu;
        public static MenuViewJson MainMenu
        {
            get
            {
                return _mainMenu;
            }
            set
            {
                if(_mainMenu != value)
                {
                    _mainMenu = value;
                    OnMainMenuChanged(EventArgs.Empty);
                    
                }
            }
        }
        public static event EventHandler MainMenuChanged;

        protected static void OnMainMenuChanged(EventArgs e)
        {
            MainMenuChanged?.Invoke(null, e);
        }
        public ICommand StartGame
        {
            get
            {
                return new BaseViewRelay(GameStart);
            }
        }
        internal void GameStart()
        {
            StaticGameStart();
        }
        public static void StaticGameStart()
        {
            StartDialog = new StartGameDialog(MainMenu);
            StartDialog.btnStart.IsEnabled = false;
            StartDialog.Communicate = "Waiting for all players to accept";
            StartDialog.ShowDialog();

            if (StartDialog.DialogResult.HasValue && StartDialog.DialogResult.Value)
            {
                MessageHelper.MsgErrorOk("Dialog Result", "Both accepted");
            }
            else
            {
                MessageHelper.MsgErrorOk("Dialog Result", "not accepted");
            }
        }
    }
}
