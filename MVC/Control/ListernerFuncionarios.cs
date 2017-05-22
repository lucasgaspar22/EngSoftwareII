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
        FuncioinarioDAO funcionarioDAO = new FuncioinarioDAO();

        public static ListernerFuncionarios getInstance()
        {
            if (sinstance == null) sinstance = new ListernerFuncionarios();
            return sinstance;
            throw new NotImplementedException();
        }

        public void addFuncionario(String nome, String email,String  idade,String cargo, String unidade)
        {
            Funcionario funcionario = new Funcionario(nome, email, idade, cargo, unidade);
            funcionarioDAO.Cadastrar(nome, email, idade, cargo, unidade); 
            funcionarios.Add(funcionario);
            nFuncionarios++;
        }

        public Funcionario getFuncionario()
        {
            return funcionarios.ElementAt(index);
        }
        
        public void editFuncionario(String nome, String email,String idade, String cargo, String unidade)
        {
            if (index - 1 > 0)
            {
                string nomeAntigo = (funcionarios.ElementAt(index - 1).Nome);
                string emailAntigo = (funcionarios.ElementAt(index - 1).Email);
                funcionarioDAO.Editar(nomeAntigo, nome, emailAntigo, email, idade, cargo, unidade);
                (funcionarios.ElementAt(index - 1).Nome) = nome;
                (funcionarios.ElementAt(index - 1).Email) = email;
                (funcionarios.ElementAt(index - 1).Idade) = idade;
                (funcionarios.ElementAt(index - 1).Cargo) = cargo;
                (funcionarios.ElementAt(index - 1).Unidade) = unidade;
            }
            else
            {
                string nomeAntigo = (funcionarios.ElementAt(0).Nome);
                string emailAntigo = (funcionarios.ElementAt(0).Email);
                funcionarioDAO.Editar(nomeAntigo, nome, emailAntigo, email, idade, cargo, unidade);
                (funcionarios.ElementAt(0).Nome) = nome;
                (funcionarios.ElementAt(0).Email) = email;
                (funcionarios.ElementAt(0).Idade) = idade;
                (funcionarios.ElementAt(0).Cargo) = cargo;
                (funcionarios.ElementAt(0).Unidade) = unidade;
            }
        }

        public void deleteFuncionario(string nome,string email)
        {
            funcionarioDAO.Excluir(nome, email);
            if(index-1>0)funcionarios.Remove(funcionarios.ElementAt(index - 1));
            else funcionarios.Remove(funcionarios.ElementAt(0));
            index = 0;
            nFuncionarios--;
        }

        public void getFuncionariosBD()
        {
            funcionarioDAO.Listar();
        }

    }
}
