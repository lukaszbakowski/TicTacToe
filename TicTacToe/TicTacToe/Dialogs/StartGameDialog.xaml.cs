using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using SharedLibraryTTT.Json;
using SharedLibraryTTT.Json.Base;
using TicTacToe.ViewModels;
using TicTacToe.Core;

namespace TicTacToe.Dialogs
{
    /// <summary>
    /// Interaction logic for StartGameDialog.xaml
    /// </summary>
    public partial class StartGameDialog : Window, INotifyPropertyChanged
    {
        private int Timer = 10;
        private MenuViewJson _MenuMain;
        public StartGameDialog(MenuViewJson _menuMain)
        {
            _MenuMain = _menuMain;
            InitializeComponent();
            TimeOutMethod();
        }
        private string _communicate = "";
        public string Communicate
        {
            get
            {
                return _communicate;
            }
            set
            {
                _communicate = value;
                OnPropertyChanged("Communicate");
            }
        }

        private string _outputMessage = "10";
        public string OutputMessage
        {
            get
            {
                return _outputMessage;
            }
            set
            {
                _outputMessage = value;
                OnPropertyChanged("OutputMessage");
            }
        }
        private async void TimeOutMethod()
        {
            await Task.Delay(1000);
            Timer--;
            OutputMessage = Timer.ToString();
            if(Timer == -1)
            {
                BtnCancel_Click(btnCancel, new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                return;
            }
            TimeOutMethod();
        }

        public void DialogResultTrue()
        {
            BtnStart_Click(btnCancel, new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent), true);
        }
        public void DialogResultFalse()
        {
            BtnCancel_Click(btnCancel, new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }

        #region "INotifyPropertyChanged"
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            MenuViewJson MenuCopy = MenuViewModel.MainMenu;

            if (MainWindow.PlayerName == SlotViewModel.SlotJson.Left.Nick)
            {
                MenuCopy.LeftPlayer.Accept = true;
            }
            else if (MainWindow.PlayerName == SlotViewModel.SlotJson.Right.Nick)
            {
                MenuCopy.RightPlayer.Accept = true;
            }
            MenuViewModel.MainMenu = MenuCopy;

            BaseJson<MenuViewJson> JSON = new BaseJson<MenuViewJson>();

            string msg = JSON.Serializer(MenuViewModel.MainMenu);

            CoreClientConnect.ConnCommand(5, msg);
            DialogResult = true;
        }
        private void BtnStart_Click(object sender, RoutedEventArgs e, bool _virtualClick)
        {
            if(_virtualClick)
            {
                DialogResult = true;
            }
        }
    }
}
