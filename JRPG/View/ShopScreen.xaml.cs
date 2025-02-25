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
using System.Windows.Shapes;

namespace JRPG.View
{
    /// <summary>
    /// Logika interakcji dla klasy ShopScreen.xaml
    /// </summary>
    public partial class ShopScreen : Window
    {
        public ShopScreen()
        {
            InitializeComponent();
        }

        private void Leave(object sender, RoutedEventArgs e)
        {
            UserScreen userScreen = new UserScreen();
            Visibility = Visibility.Hidden;
            userScreen.Show();
            this.Close();
        }
    }
}
