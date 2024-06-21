using JRPG.Model;
using JRPG.ViewModel;
using Org.BouncyCastle.Tls;
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

namespace JRPG.View
{
    /// <summary>
    /// Logika interakcji dla klasy BattleScreen.xaml
    /// </summary>
    public partial class BattleScreen : Window
    {
        public BattleScreen()
        {
            InitializeComponent();
            
           
        }

        
        private void Opusc(object sender, RoutedEventArgs e)
        {
           
            UserScreen userScreen = new UserScreen();
            
            this.Visibility = Visibility.Hidden;
            userScreen.Show();
            
        }

    }
}
