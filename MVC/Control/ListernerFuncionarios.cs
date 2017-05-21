using Projeto_Google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Control
{
    class ListernerFuncionarios
    {
        public static ListernerFuncionarios sinstance;
        public List<Funcionario> funcionarios = new List<Funcionario>();
        public int index = 0;
        public int nFuncionarios = 0;

        public static ListernerFuncionarios getInstance()
        {
            if (sinstance == null) sinstance = new ListernerFuncionarios();
            return sinstance;
            throw new NotImplementedException();
        }

        public void addFuncionario(String nome, String email,String  idade,String cargo, String unidade)
        {
            Funcionario funcionario = new Funcionario(nome, email, idade, cargo, unidade);
            funcionarios.Add(funcionario);
            nFuncionarios++;
        }

        public Funcionario getFuncionario()
        {
            return funcionarios.ElementAt(index);
        }
        
        public void editFuncionario(String nome, String email,String idade, String cargo, String unidade)
        {
            (funcionarios.ElementAt(index - 1).Nome) = nome;
            (funcionarios.ElementAt(index - 1).Email) = email;
            (funcionarios.ElementAt(index - 1).Idade) = idade;
            (funcionarios.ElementAt(index - 1).Cargo) = cargo;
            (funcionarios.ElementAt(index - 1).Unidade) = unidade;
        }

        public void deleteFuncionario()
        {
            funcionarios.Remove(funcionarios.ElementAt(index - 1));
            index = 0;
            nFuncionarios--;
        }


    }
}
