using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class Cargos
    {

        private string nome;
        private string salario;
        private string hierarquia;

        public Cargos(string nome, string salario, string hierarquia)
        {
            this.nome = nome;
            this.salario = salario;
            this.hierarquia = hierarquia;
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

        public string Salario
        {
            get
            {
                return salario;
            }

            set
            {
                salario = value;
            }
        }

        public string Hierarquia
        {
            get
            {
                return hierarquia;
            }

            set
            {
                hierarquia = value;
            }
        }
    }
}
