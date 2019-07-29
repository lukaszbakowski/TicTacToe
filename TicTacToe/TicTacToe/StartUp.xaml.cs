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
using TicTacToe.Core;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for StartUp.xaml
    /// </summary>
    public partial class StartUp : Window
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void cmdAccept_Click(object sender, RoutedEventArgs e)
        {
            
            if (tbNick.Text.Length != 0) {
                NewWindow(tbNick.Text);

            } else
            {
                MessageBox.Show("Please type your nick name", " Nick Name", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cmdEnter_Click(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // DO YOUR WORK HERE and then set e.Handled to true on condition if you want to stop going to next line//

                
                if (tbNick.Text.Length != 0)
                {
                    NewWindow(tbNick.Text);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void NewWindow(string _nick)
        {
            MainWindow mainWindow = new MainWindow(_nick);
            mainWindow.Show();
            Close();
        }
    }
}
