using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class Usuario
    {
        private string nome;
        private string email;
        private string senha;
        private string idade;
        private string celuar;

        public Usuario(string nome, string email, string senha, string idade, string celuar)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.idade = idade;
            this.celuar = celuar;
        }

       /* public string toString(Usuario usuario)
        {
            return usuario.nome + " " + usuario.email + " " + usuario.senha + " " + usuario.idade + " " + usuario.celuar;
        }*/

        public Usuario()
        {
        }

        public string Celular
        {
            get
            {
                return celuar;
            }

            set
            {
                celuar = value;
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

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
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
    }
}
