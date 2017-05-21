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
        
        public void addUsuario(String nome, String email, String senha, String idade, String celular)
        {
            Usuario usuario = new Usuario(nome, email, senha, idade, celular);
            usuarios.Add(usuario);
            nUsuarios++;
        }

        public Usuario getUsuario()
        {
            return usuarios.ElementAt(index);
        }

        public void editUsuario(String nome, String email, String idade, String senha, String celular)
        {
            (usuarios.ElementAt(index - 1).Nome) = nome; 
            (usuarios.ElementAt(index - 1).Email) = email;
            (usuarios.ElementAt(index - 1).Idade) = idade;
            (usuarios.ElementAt(index - 1).Senha) = senha;
            (usuarios.ElementAt(index - 1).Celular) = celular;

        }

        public void deleteUsuario()
        {
            usuarios.Remove(usuarios.ElementAt(index - 1));
            index = 0;
            nUsuarios--;
        }

    }
}
