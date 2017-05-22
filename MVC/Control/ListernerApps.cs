using Projeto_Google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Control
{
    class ListernerApps
    {

        public static ListernerApps sinstance;
        public List<Apps> apps = new List<Apps>();
        public int index = 0;
        public int nApps = 0;
        AppsDAO appsDao = new AppsDAO();

        public static ListernerApps getInstance()
        {
            if (sinstance == null) sinstance = new ListernerApps();
            return sinstance;
            throw new NotImplementedException();
        }


        public void addApp( String nome, String tamanho, String downloads, String avaliacao)
        {
            Apps app = new Apps(nome, tamanho, downloads, avaliacao); //Int32.Parse(downloads)
            appsDao.Cadastrar(nome, tamanho,downloads , avaliacao);
            apps.Add(app);
            nApps++;
        }

        public Apps getApp()
        {
            return apps.ElementAt(index);
        }

        public void editApp(String nome, String tamanho, String downloads, String avaliacao)
        {
            if (index - 1 > 0)
            { 
                string nomeAntigo = (apps.ElementAt(index - 1).Nome);
                string tamanhoAntigo = (apps.ElementAt(index - 1).Tamanho);
                string downloadAntigo = (apps.ElementAt(index - 1).NumDownloads);
                string avaliacaAntigo = (apps.ElementAt(index - 1).Avaliacao);
                (apps.ElementAt(index - 1).Nome) = nome;
                (apps.ElementAt(index - 1).Tamanho) = tamanho;
                (apps.ElementAt(index - 1).NumDownloads) = downloads;
                (apps.ElementAt(index - 1).Avaliacao) = avaliacao;
                appsDao.Editar(nomeAntigo, nome, tamanhoAntigo, tamanho,downloadAntigo,downloads,avaliacaAntigo,avaliacao);
            }
        else
            {
                string nomeAntigo = (apps.ElementAt(0).Nome);
                string tamanhoAntigo = (apps.ElementAt(0).Tamanho);
                string downloadAntigo = (apps.ElementAt(0).NumDownloads);
                string avaliacaAntigo = (apps.ElementAt(0).Avaliacao);
                (apps.ElementAt(0).Nome) = nome;
                (apps.ElementAt(0).Tamanho) = tamanho;
                (apps.ElementAt(0).NumDownloads) = downloads;
                (apps.ElementAt(0).Avaliacao) = avaliacao;
                appsDao.Editar(nomeAntigo, nome, tamanhoAntigo, tamanho, downloadAntigo, downloads, avaliacaAntigo, avaliacao);
            }
        }

        public void deleteApp(String nome)
        {
           appsDao.Excluir(nome);
            if (index - 1 > 0) { apps.Remove(apps.ElementAt(index - 1)); }
            else apps.Remove(apps.ElementAt(0));
            index = 0;
            nApps--;
        }

        public void getAppsBD()
        {
            appsDao.Listar();
        }
    }
}
