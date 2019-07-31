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
using TicTacToe.ViewModels.Base;
using TicTacToe.Core;

namespace TicTacToe.Views
{

    /// <summary>
    /// Interaction logic for MsgView.xaml
    /// </summary>
    public partial class MsgView : BaseUserControl
    {
          
        public MsgView()
        {
            InitializeComponent();

        }


        private void btChat_Click(object sender, RoutedEventArgs e)
        {
            btPlayer.IsEnabled = true;
            btChat.IsEnabled = false;
            lbPlayer.Visibility = Visibility.Hidden;
            tbChat.Visibility = Visibility.Visible;
        }

        private void btPlayer_Click(object sender, RoutedEventArgs e)
        {
            btChat.IsEnabled = true;
            btPlayer.IsEnabled = false;
            tbChat.Visibility = Visibility.Hidden;
            lbPlayer.Visibility = Visibility.Visible;
        }
        private void cmdEnter_Click(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // DO YOUR WORK HERE and then set e.Handled to true on condition if you want to stop going to next line//



                    e.Handled = true;
                
            }
        }
        //public void BtSend_Click(object sender, RoutedEventArgs e)
        //{
        //    string hello = tbSend.Text;
        //    conn.SendMessages(hello);
        //    tbSend.Text = "";
        //}
    }
}
