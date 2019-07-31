using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryTTT.Json;
using TicTacToe.ViewModels.Base;

namespace TicTacToe.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
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
                _mainMenu = value;
                OnMainMenuChanged(EventArgs.Empty);
            }
        }
        public static event EventHandler MainMenuChanged;

        protected static void OnMainMenuChanged(EventArgs e)
        {
            MainMenuChanged?.Invoke(null, e);
        }
    }
}
