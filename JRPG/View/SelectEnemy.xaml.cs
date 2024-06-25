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
    /// Interaction logic for SelectEnemy.xaml
    /// </summary>
    public partial class SelectEnemy : Window
    {
        public SelectEnemy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           BattleScreen battleScreen = new BattleScreen();
            this.Visibility = Visibility.Hidden;
            battleScreen.Show();
            this.Close();
        }
       
    }
}
