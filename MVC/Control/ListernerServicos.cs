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
        List<Servicos> servicos = new List<Servicos>();
        public  int index = 0;
        public int nServicos = 0;

        public static ListernerServicos getInstance()
        {
            if (sinstance == null) sinstance = new ListernerServicos();
            return sinstance;
            throw new NotImplementedException();
        }

        public void addServicos(String nome)
        {
            Servicos servico = new Servicos(nome);
            servicos.Add(servico);
            nServicos++;
        }
        
        public Servicos getServicos()
        {
           return servicos.ElementAt(index);    
        }

        public void editServicos(String nome)
        {
            servicos.ElementAt(index-1).Nome = nome;
        }

        public void deleteServicos()
        {
            servicos.Remove(servicos.ElementAt(index - 1));
            index = 0;
            nServicos--;
        }
    }
}
