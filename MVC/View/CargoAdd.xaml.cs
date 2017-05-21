using Projeto_Google.Control;
using Projeto_Google.Model;
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
    /// Interaction logic for CargoAdd.xaml
    /// </summary>
    public partial class CargoAdd : Window
    {
        ListernerCargos listerner;
        bool isAdm;
        public CargoAdd(bool isAdm)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listerner = ListernerCargos.getInstance();
            this.isAdm = isAdm;
        }


        private void cadastrarBtn_Click(object sender, RoutedEventArgs e)
        {
            string nome = cargoNome.Text;
            string hierarquia = cargoHierarquia.Text;
            string salario = cargoSalario.Text;

            listerner.addCargo(nome, hierarquia, salario);

            MessageBox.Show("Cargo cadastrado com sucesso");
        }

        private void proximoBtn_Click(object sender, RoutedEventArgs e)
        {
            cargoNome.Text = (listerner.getCargos().Nome);
            cargoHierarquia.Text = (listerner.getCargos().Hierarquia);
            cargoSalario.Text = (listerner.getCargos().Salario);
            listerner.index++;
            if (listerner.index >= listerner.nCargos)
            {
                MessageBox.Show("Todos os elementos listados");
                listerner.index = 0;
            }
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
           listerner.editCargo( cargoNome.Text, cargoHierarquia.Text, cargoSalario.Text);
            MessageBox.Show("Editado com sucesso!");
        }

        private void excluirBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdm)
            {
                MessageBox.Show("Você não pode excluir");
            }
            else
            {
                listerner.deleteCargo();
                cargoNome.Text = "";
                cargoHierarquia.Text = "";
                cargoHierarquia.Text = "";
                MessageBox.Show("Item excluido com sucesso!");
            }
            
        }
    }
}
