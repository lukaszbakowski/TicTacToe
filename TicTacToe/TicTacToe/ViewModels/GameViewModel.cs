using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryTTT.Json;
using TicTacToe.ViewModels.Base;

namespace TicTacToe.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        public GameViewModel()
        {
            _mainBoard = new GameViewJson();
        }
        private static GameViewJson _mainBoard;
        public static GameViewJson MainBoard
        {
            get
            {
                return _mainBoard;
            }
            set
            {
                _mainBoard = value;
                OnMainBoardChanged(EventArgs.Empty);
            }
        }
        public static event EventHandler MainBoardChanged;

        protected static void OnMainBoardChanged(EventArgs e)
        {
            MainBoardChanged?.Invoke(null, e);
        }
    }
}
