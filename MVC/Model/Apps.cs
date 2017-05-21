using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class Apps
    {
        private string nome;
        private string tamanho;
        private string numDownloads;
        private string avaliacao;

        public Apps(string nome, string tamanho, string numDownloads, string avaliacao)
        {
            this.nome = nome;
            this.tamanho = tamanho;
            this.numDownloads = numDownloads;
            this.avaliacao = avaliacao;
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Tamanho
        {
            get
            {
                return tamanho;
            }

            set
            {
                tamanho = value;
            }
        }

        public string NumDownloads
        {
            get
            {
                return numDownloads;
            }

            set
            {
                numDownloads = value;
            }
        }

        public string Avaliacao
        {
            get
            {
                return avaliacao;
            }

            set
            {
                avaliacao = value;
            }
        }
    }
}
