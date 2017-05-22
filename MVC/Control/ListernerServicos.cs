using Projeto_Google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projeto_Google.Control
{
    class ListernerServicos
    {
        public static ListernerServicos sinstance;
        ServicosDAO servicoDAO = new ServicosDAO();
        public List<Servicos> servicos = new List<Servicos>();
        public  int index = 0;
        public int indexBD = 0;
        public int nServicos = 0;

        public static ListernerServicos getInstance()
        {
            if (sinstance == null)
            {
                sinstance = new ListernerServicos(); 
            }
            return sinstance;
                
            throw new NotImplementedException();
        }

        public void addServicos(String nome)
        {
            Servicos servico = new Servicos(nome);
            servicoDAO.Cadastrar(nome);
            servicos.Add(servico);
            nServicos++;
        }
        
        public Servicos getServicos()
        {
           return servicos.ElementAt(index);    
        }

        public void editServicos(String nome)
        {
            string nomeAntigo = servicos.ElementAt(index - 1).Nome;
            servicoDAO.Editar(nomeAntigo, nome);
            servicos.ElementAt(index-1).Nome = nome;

        }

        public void deleteServicos(String nome)
        {
            servicoDAO.Excluir(nome);
            if (index - 1 > 0) { servicos.Remove(servicos.ElementAt(index - 1)); }
            else servicos.Remove(servicos.ElementAt(0));

            index = 0;
            nServicos--;
        }

        public void getServicosBD()
        {
            servicoDAO.Listar();
        }
    }
}
