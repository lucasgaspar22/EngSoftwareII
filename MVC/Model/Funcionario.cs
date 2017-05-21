using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class Funcionario
    {
        private string nome;
        private string email;
        private string idade;
        private string cargo;
        private string unidade;

        public Funcionario(string nome, string email, string idade, string cargo, string unidade)
        {
            this.nome = nome;
            this.email = email;
            this.idade = idade;
            this.cargo = cargo;
            this.unidade = unidade;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Idade
        {
            get
            {
                return idade;
            }

            set
            {
                idade = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        internal string Unidade
        {
            get
            {
                return unidade;
            }

            set
            {
                unidade = value;
            }
        }
    }
}
