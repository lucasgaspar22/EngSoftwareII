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

namespace Projeto_Google
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {

        MainWindow main;
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            string username = user.Text;
            string pass = password.Password.ToString();
           
            
             if(username.Equals("adm") && pass.Equals("adm"))
             {
                main = new MainWindow(true);
                main.Show();
                Close();
             }else if (username.Equals("user") && pass.Equals("user"))
             {
                 main = new MainWindow(false);
                 main.Show();
                 Close();
             }
             else
             {
                 MessageBox.Show("Login inválido");
             }



        }

        private void sairBtn_Click(object sender, RoutedEventArgs e)
        {
            
           
        }
    }
}
