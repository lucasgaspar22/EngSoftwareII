using Projeto_Google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Control
{
    class ListernerUsuarios
    {
        public static ListernerUsuarios sinstance;
        public static ListernerUsuarios getInstance()
        {
            if (sinstance == null) sinstance = new ListernerUsuarios();
            return sinstance;
        }


        public List<Usuario> usuarios = new List<Usuario>();
        public  int index = 0;
        public int nUsuarios = 0;
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        public void addUsuario(String nome, String email, String senha, String idade, String celular)
        {
            Usuario usuario = new Usuario(nome, email, senha, idade, celular);
            usuarioDAO.Cadastrar(nome, email, idade, senha, celular);
            usuarios.Add(usuario);
            nUsuarios++;
        }

        public Usuario getUsuario()
        {
            return usuarios.ElementAt(index);
        }

        public void editUsuario(String nome, String email, String idade, String senha, String celular)
        {
            if (index - 1 > 0)
            {
                string nomeAntigo = (usuarios.ElementAt(index - 1).Nome);
                string emailAntigo = (usuarios.ElementAt(index - 1).Email);
                usuarioDAO.Editar(nomeAntigo, nome, emailAntigo, email, idade, senha, celular);
                (usuarios.ElementAt(index - 1).Nome) = nome;
                (usuarios.ElementAt(index - 1).Email) = email;
                (usuarios.ElementAt(index - 1).Idade) = idade;
                (usuarios.ElementAt(index - 1).Senha) = senha;
                (usuarios.ElementAt(index - 1).Celular) = celular;
            }
            else
            {
                string nomeAntigo = (usuarios.ElementAt(0).Nome);
                string emailAntigo = (usuarios.ElementAt(0).Email);
                usuarioDAO.Editar(nomeAntigo, nome, emailAntigo, email, idade, senha, celular);
                (usuarios.ElementAt(0).Nome) = nome;
                (usuarios.ElementAt(0).Email) = email;
                (usuarios.ElementAt(0).Idade) = idade;
                (usuarios.ElementAt(0).Senha) = senha;
                (usuarios.ElementAt(0).Celular) = celular;
            }

        }

        public void deleteUsuario(string nome, string email)
        {

            usuarioDAO.Excluir(nome, email);
            if (index - 1 > 0)
            {
                usuarios.Remove(usuarios.ElementAt(index - 1));
            } else { 
            usuarios.Remove(usuarios.ElementAt(0));
            }
            index = 0;
            nUsuarios--;
        }

        public void getUsuariosBD()
        {
            usuarioDAO.Listar();
        }

    }
}
