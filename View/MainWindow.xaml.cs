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

namespace Projeto_Google
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        FuncionariosAdd funcionariosWindow;
        UsuariosAdd usuariosWindow;
        AppAdd appWindow;
        CargoAdd cargoWindow;
        ServicosAdd servicosWindow;
        UnidadeAdd unidadeWindow;

        bool isAdm;

        public MainWindow(bool isAdm)
        {
            this.isAdm = isAdm;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void funcionariosBtn_Click(object sender, RoutedEventArgs e)
        {
            funcionariosWindow = new FuncionariosAdd(isAdm);
            funcionariosWindow.Show();
        }

        private void usuariosBtn_Click(object sender, RoutedEventArgs e)
        {
            usuariosWindow = new UsuariosAdd(isAdm);
            usuariosWindow.Show();
        }

        private void appBtn_Click(object sender, RoutedEventArgs e)
        {
            appWindow = new AppAdd(isAdm);
            appWindow.Show();
        }

        private void cargoBtn_Click(object sender, RoutedEventArgs e)
        {
            cargoWindow = new CargoAdd(isAdm);
            cargoWindow.Show();
        }

        private void servicosBtn_Click(object sender, RoutedEventArgs e)
        {
            servicosWindow = new ServicosAdd(isAdm);
            servicosWindow.Show();
        }

        private void unidadeBtn_Click(object sender, RoutedEventArgs e)
        {
            unidadeWindow = new UnidadeAdd(isAdm);
            unidadeWindow.Show();
        }
    }
}
