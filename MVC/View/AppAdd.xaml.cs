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
    /// Interaction logic for AppAdd.xaml
    /// </summary>
    public partial class AppAdd : Window
    {
        ListernerApps listerner;
        bool isAdm;
        public AppAdd(bool isAdm)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listerner = ListernerApps.getInstance();
            listerner.getAppsBD();
            listerner.nApps = listerner.apps.Count;
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
            string nome = appNome.Text;
            string tamanho = appTamanho.Text;
            string downloads = appNDownload.Text;
            string avaliacao = appAvaliacao.Text;

            listerner.addApp(nome,tamanho, downloads, avaliacao);
            MessageBox.Show("Aplicativo Cadastrado com sucesso!");

            appNome.Text = "";
            appTamanho.Text = "";
            appNDownload.Text = "";
            appAvaliacao.Text = "";
        }

        private void proximoBtn_Click(object sender, RoutedEventArgs e)
        {
            appNome.Text = (listerner.getApp().Nome);
            appTamanho.Text = (listerner.getApp().Tamanho);
            appNDownload.Text = (listerner.getApp().NumDownloads);
            appAvaliacao.Text = (listerner.getApp().Avaliacao);
            
            listerner.index++;
            if (listerner.index >= listerner.nApps)
            {
                MessageBox.Show("Todos os elementos listados");
                listerner.index = 0;
            }
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            listerner.editApp(appNome.Text, appTamanho.Text, appNDownload.Text, appAvaliacao.Text);
            
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

                listerner.deleteApp(appNome.Text);
                appNome.Text = "";
                appTamanho.Text = "";
                appNDownload.Text = "";
                appAvaliacao.Text = "";
                MessageBox.Show("Item excluido com sucesso ");
            }
        }
    }
}
