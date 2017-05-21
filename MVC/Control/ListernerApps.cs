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

        public static ListernerApps getInstance()
        {
            if (sinstance == null) sinstance = new ListernerApps();
            return sinstance;
            throw new NotImplementedException();
        }

        public List<Apps> apps = new List<Apps>();
        public int index = 0;
        public int nApps = 0;

        public void addApp( String nome, String tamanho, String downloads, String avaliacao)
        {
            Apps app = new Apps(nome, tamanho, downloads, avaliacao);
            apps.Add(app);
            nApps++;
        }

        public Apps getApp()
        {
            return apps.ElementAt(index);
        }

        public void editApp(String nome, String tamanho, String downloads, String avaliacao)
        {
            (apps.ElementAt(index - 1).Nome) = nome;
            (apps.ElementAt(index - 1).Tamanho) = tamanho;
            (apps.ElementAt(index - 1).NumDownloads) = downloads;
            (apps.ElementAt(index - 1).Avaliacao) = avaliacao;

        }

        public void deleteApp()
        {
            apps.Remove(apps.ElementAt(index - 1));
            index = 0;
            nApps--;
        }
    }
}
