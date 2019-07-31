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

namespace TicTacToe.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : BaseUserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Click_Start(object sender, RoutedEventArgs e)
        {
            if(SlotViewModel.SlotJson.Left.Button == false && SlotViewModel.SlotJson.Right.Button == false)
            {

            }
        }

        private void Click_Surrender(object sender, RoutedEventArgs e)
        {

        }

        private void GetDataOnLoad(object sender, RoutedEventArgs e)
        {

        }
    }
}
