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
using System.Runtime.Serialization.Json;
using TicTacToe.Core;

namespace TicTacToe.Views
{
    /// <summary>
    /// Interaction logic for SlotView.xaml
    /// </summary>
    public partial class SlotView : BaseUserView
    {

        public SlotView()
        {
            InitializeComponent();

        }

        private void Click_RightJoin(object sender, RoutedEventArgs e)
        {
            btn_RightJoin.Visibility = Visibility.Hidden;
            btn_RightLeave.Visibility = Visibility.Visible;

            btn_LeftJoin.Visibility = Visibility.Hidden;
        }
        private void Click_RightLeave(object sender, RoutedEventArgs e)
        {
            btn_RightJoin.Visibility = Visibility.Visible;
            btn_RightLeave.Visibility = Visibility.Hidden;

            btn_LeftJoin.Visibility = Visibility.Visible;
        }
        private void Click_LeftJoin(object sender, RoutedEventArgs e)
        {
            btn_LeftJoin.Visibility = Visibility.Hidden;
            btn_LeftLeave.Visibility = Visibility.Visible;

            btn_RightJoin.Visibility = Visibility.Hidden;
        }
        private void Click_LeftLeave(object sender, RoutedEventArgs e)
        {
            btn_LeftJoin.Visibility = Visibility.Visible;
            btn_LeftLeave.Visibility = Visibility.Hidden;

            btn_RightJoin.Visibility = Visibility.Visible;
        }
 
        private void GetDataOnLoad(object sender, RoutedEventArgs e)
        {
            CoreClientConnect.ConnCommand(4, "SlotViewJson");
        }
    }
}
