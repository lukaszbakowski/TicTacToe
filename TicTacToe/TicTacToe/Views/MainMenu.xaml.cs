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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe.ViewModels;
using TicTacToe.Dialogs;
using SharedLibraryTTT.Json.Base;
using SharedLibraryTTT.Json;
using System.ComponentModel;
using TicTacToe.Core;

namespace TicTacToe.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : BaseUserControl, INotifyPropertyChanged
    {
        
        public MainMenu()
        {
            InitializeComponent();
           
        }



        private void Click_Start(object sender, RoutedEventArgs e)
        {

            MenuViewJson MenuCopy = MenuViewModel.MainMenu;
            
            if(MainWindow.PlayerName == SlotViewModel.SlotJson.Left.Nick)
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
        }

        private void Click_Surrender(object sender, RoutedEventArgs e)
        {
            
        }



        private void GetDataOnLoad(object sender, RoutedEventArgs e)
        {

        }
        #region "INotifyPropertyChanged"
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
