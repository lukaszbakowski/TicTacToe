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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TicTacToe.ViewModels.Base;

using System.ComponentModel;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    public partial class MainWindow : Window
    {

       

        public MainWindow()
        {
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("sdfds","hej", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                e.Cancel = false;
            } else
            {

                BaseClientConnect.ConnCommand(0,"im clossing the window..");
                BaseClientConnect.ConnStop();
                
            }
        }

        

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            MessageBox.Show("hej hej", "hej hej", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
    }
}
