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
    /// Interaction logic for ServicosAdd.xaml
    /// </summary>
    public partial class ServicosAdd : Window
    {
        ListernerServicos listerner;
        bool isAdm;
        public ServicosAdd(bool isAdm)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listerner = ListernerServicos.getInstance();
            listerner.getServicosBD();
            listerner.nServicos = listerner.servicos.Count;
            this.isAdm = isAdm;
        }
  
        private void imgSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            if (!dlg.FileName.Equals(null))
            {
                MessageBox.Show(dlg.FileName);
            }
        }

        private void cadastrarBtn_Click(object sender, RoutedEventArgs e)
        {
            string nome = servicoNome.Text;
            listerner.addServicos(nome);
            MessageBox.Show("Cadastrado com sucesso!");
            servicoNome.Text = "";
        }

        private void proximoBtn_Click(object sender, RoutedEventArgs e)
        {

            servicoNome.Text = (listerner.getServicos().Nome);
            listerner.index++;
            listerner.indexBD = listerner.index - 1;
            if (listerner.index >= listerner.nServicos)
            {
                MessageBox.Show("Todos os elementos listados");
                listerner.index = 0;
            }
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            listerner.editServicos(servicoNome.Text);
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
                listerner.deleteServicos(servicoNome.Text);
                servicoNome.Text = "";
                MessageBox.Show("Item excluido com sucesso!");
            }
        }
    }
}
