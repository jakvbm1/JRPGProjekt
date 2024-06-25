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
    using DAL.Encje;
    using JRPG.DAL.Repozytoria;

    /// <summary>
    /// Logika interakcji dla klasy UserScreen.xaml
    /// </summary>
    public partial class UserScreen : Window
    {
        public UserScreen()
        {
            //Console.WriteLine(GlobalVariables.current_user.CharId);
            InitializeComponent();
        }

        private void Shop_Button_Click(object sender, RoutedEventArgs e)
        {
            ShopScreen shopScreen = new ShopScreen();
            this.Visibility = Visibility.Hidden;
            shopScreen.Show();
            this.Close();
        }
        private void Enter_Walka(object sender, RoutedEventArgs e)
        {
            SelectEnemy selectEnemy = new SelectEnemy();    

            this.Visibility = Visibility.Hidden;
            selectEnemy.Show();
            this.Close();
        }

        private void Admin_enter(object sender, RoutedEventArgs e)
        {


            AdminPanel adminPanel = new AdminPanel();
            this.Visibility = Visibility.Hidden;
           adminPanel.Show();
            this.Close();


        }
    }
}
