using Projeto_Google.Control;
using Projeto_Google.Model;
using System;
using System.Collections;
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
    /// Interaction logic for UsuariosAdd.xaml
    /// </summary>
    public partial class UsuariosAdd : Window
    {

        ListernerUsuarios listerner;
        bool isAdm;
        public UsuariosAdd(bool isAdm)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listerner = ListernerUsuarios.getInstance();
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
            string nome = usuarioNome.Text;
            string email = usuarioEmail.Text;
            string idade = usuarioIdade.Text;
            string senha = usuarioSenha.Text;
            string celular = usuarioCelular.Text;
            listerner.addUsuario(nome, email, senha, idade, celular);
            MessageBox.Show("Usuário Cadastrado com sucesso!");
            usuarioNome.Text = "";
            usuarioEmail.Text = "";
            usuarioIdade.Text = "";
            usuarioCelular.Text = "";
            usuarioSenha.Text = "";
            
        }

        private void proximoBtn_Click(object sender, RoutedEventArgs e)
        {

           
            usuarioNome.Text=(listerner.getUsuario().Nome);
            usuarioEmail.Text= (listerner.getUsuario().Email);
            usuarioIdade.Text= (listerner.getUsuario().Idade);
            usuarioSenha.Text= (listerner.getUsuario().Senha);
            usuarioCelular.Text = (listerner.getUsuario().Celular);
            listerner.index++;
            if (listerner.index >= listerner.nUsuarios)
            {
                MessageBox.Show("Todos os elementos listados");
                listerner.index = 0;
            }
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            listerner.editUsuario(usuarioNome.Text, usuarioEmail.Text, usuarioIdade.Text, usuarioSenha.Text, usuarioCelular.Text); 
           
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
                listerner.deleteUsuario();
                usuarioNome.Text = "";
                usuarioEmail.Text = "";
                usuarioIdade.Text = "";
                usuarioCelular.Text = "";
                usuarioSenha.Text = "";
                MessageBox.Show("Item excluido com sucesso ");
            }
        }
    }
}
