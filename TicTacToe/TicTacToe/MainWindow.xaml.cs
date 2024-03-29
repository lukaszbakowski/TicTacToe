﻿using System;
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
using TicTacToe.Core;
using SharedLibraryTTT;
using System.ComponentModel;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    public partial class MainWindow : Window
    {

        public static string PlayerName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CoreClientConnect.ConnStart();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if(MessageBox.Show("hej, jestes pewny, ze chcesz wyjsc?", "Game Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
                
            } else
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
    }
}
