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
    /// Interaction logic for FuncionariosAdd.xaml
    /// </summary>
    public partial class FuncionariosAdd : Window
    {
        ListernerFuncionarios listerner;
        bool isAdm;
        public FuncionariosAdd(bool isAdm)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listerner = ListernerFuncionarios.getInstance();
            this.isAdm = isAdm;
        }
        
        private void imgSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            if (!dlg.FileName.Equals(null)){
                MessageBox.Show(dlg.FileName);
            }
        }

        private void cadastrarBtn_Click(object sender, RoutedEventArgs e)
        {
            string nome = funcionarioNome.Text;
            string email = funcionarioEmail.Text;
            string idade = funcionarioIdade.Text;
            string cargo = funcionarioCargo.Text;
            string unidade = funcionarioUnidade.Text;
            listerner.addFuncionario(nome, email, idade, cargo, unidade);
            MessageBox.Show("Funcionário Cadastrado com sucesso!");
            funcionarioNome.Text = "";
            funcionarioEmail.Text = "";
            funcionarioIdade.Text = "";
            funcionarioCargo.Text = "";
            funcionarioUnidade.Text = "";
        }

        private void proximoBtn_Click(object sender, RoutedEventArgs e)
        {

            funcionarioNome.Text = (listerner.getFuncionario().Nome);
            funcionarioEmail.Text = (listerner.getFuncionario().Email);
            funcionarioIdade.Text = (listerner.getFuncionario().Idade);
            funcionarioCargo.Text = (listerner.getFuncionario().Cargo);
            funcionarioUnidade.Text = (listerner.getFuncionario().Unidade);
            listerner.index++;
            if (listerner.index >= listerner.nFuncionarios)
            {
                MessageBox.Show("Todos os elementos listados");
                listerner.index = 0;
            }
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            listerner.editFuncionario(funcionarioNome.Text, funcionarioEmail.Text, funcionarioIdade.Text, funcionarioCargo.Text, funcionarioUnidade.Text);
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
                listerner.deleteFuncionario();
                funcionarioNome.Text = "";
                funcionarioEmail.Text = "";
                funcionarioIdade.Text = "";
                funcionarioCargo.Text = "";
                funcionarioUnidade.Text = "";
                MessageBox.Show("Item excluido com sucesso ");
            }
        }
    }
}
