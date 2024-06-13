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
            Console.WriteLine(GlobalVariables.current_user.CharId);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            this.Visibility = Visibility.Hidden;
            loginScreen.Show();
        }
    }
}
