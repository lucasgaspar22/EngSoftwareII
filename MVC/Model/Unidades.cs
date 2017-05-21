using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class Unidades
    {
        private string nome;
        private string pais;
        private string cidade;
        private string estado;

        public Unidades(string nome, string pais, string cidade, string estado)
        {
            this.Nome = nome;
            this.Pais = pais;
            this.Cidade = cidade;
            this.Estado = estado;
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

        public string Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                cidade = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        
    }
}
