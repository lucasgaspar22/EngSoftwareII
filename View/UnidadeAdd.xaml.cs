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
    /// Interaction logic for UnidadeAdd.xaml
    /// </summary>
    public partial class UnidadeAdd : Window
    {

        ListernerUnidades listerner;
        bool isAdm;
        public UnidadeAdd(bool isAdm)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listerner = ListernerUnidades.getInstance();
            this.isAdm = isAdm;
        }

        
        private void CadastrarBtn_Click(object sender, RoutedEventArgs e)
        {
            string nome = unidadeNome.Text;
            listerner.addUnidade(nome, "", "", "");
            MessageBox.Show("Cadastrado com sucesso!");
            unidadeNome.Text = "";

        }

        private void proximoBtn_Click(object sender, RoutedEventArgs e)
        {
            unidadeNome.Text = (listerner.getUnidade().Nome);
            listerner.index++;
            if (listerner.index >= listerner.nUnidades)
            {
                MessageBox.Show("Todos os elementos listados");
                listerner.index = 0;
            }
            
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            listerner.editUnidade( unidadeNome.Text,"","","");
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
                listerner.deleteUnidade();
                unidadeNome.Text = "";
                MessageBox.Show("Item excluido com sucesso!");
            }
        }
    }
}
