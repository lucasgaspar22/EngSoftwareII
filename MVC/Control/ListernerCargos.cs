using Projeto_Google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Control
{
    class ListernerCargos
    {
        public static ListernerCargos sinstance;
        public List<Cargos> cargos = new List<Cargos>();
        public int index = 0;
        public int nCargos = 0;

        public static ListernerCargos getInstance()
        {
            if (sinstance == null) sinstance = new ListernerCargos();
            return sinstance;
            throw new NotImplementedException();
        }

        public void addCargo(String nome, String hierarquia, String salario)
        {
            Cargos cargo = new Cargos(nome, salario, hierarquia);
            cargos.Add(cargo);
            nCargos++;
        }

        public Cargos getCargos()
        {
            return cargos.ElementAt(index);
        }

        public void editCargo(String nome, String hierarquia, String salario)
        {
            cargos.ElementAt(index - 1).Nome = nome;
            cargos.ElementAt(index - 1).Hierarquia = hierarquia;
            cargos.ElementAt(index - 1).Salario = salario;
        }

        public void deleteCargo()
        {
            cargos.Remove(cargos.ElementAt(index - 1));
            index = 0;
            nCargos--;
        }
    }
   
}
