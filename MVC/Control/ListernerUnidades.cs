using Projeto_Google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Control
{
    class ListernerUnidades
    {
        public static ListernerUnidades sinstance;
        public List<Unidades> unidades = new List<Unidades>();
        public int index = 0;
        public int nUnidades = 0;
        UnidadesDAO unidadeDAO = new UnidadesDAO();

        public static ListernerUnidades getInstance()
        {
            if (sinstance == null) sinstance = new ListernerUnidades();
            return sinstance;
            throw new NotImplementedException();
        }
        
        public void addUnidade(String nome, String cidade, String estado, String pais)
        {
            Unidades unidade = new Unidades(nome, cidade, estado, pais);
            unidadeDAO.Cadastrar(nome);
            unidades.Add(unidade);
            nUnidades++;
        }

        public Unidades getUnidade()
        {
            return unidades.ElementAt(index);
        }

        public void editUnidade(String nome, String cidade, String estado, String pais)
        {
            if (index - 1 > 0) {
                string nomeAntigo = unidades.ElementAt(index - 1).Nome;
                unidades.ElementAt(index - 1).Nome = nome;
                unidades.ElementAt(index - 1).Cidade = cidade;
                unidades.ElementAt(index - 1).Estado = estado;
                unidades.ElementAt(index - 1).Pais = pais;
                unidadeDAO.Editar(nomeAntigo, nome);
            }else
            {
                string nomeAntigo = unidades.ElementAt(0).Nome;
                unidades.ElementAt(0).Nome = nome;
                unidades.ElementAt(0).Cidade = cidade;
                unidades.ElementAt(0).Estado = estado;
                unidades.ElementAt(0).Pais = pais;
                unidadeDAO.Editar(nomeAntigo, nome);
            }
        }

        public void deleteUnidade(string nome)
        {

            unidadeDAO.Excluir(nome);
            if (index - 1 > 0) { unidades.Remove(unidades.ElementAt(index - 1)); }
            else unidades.Remove(unidades.ElementAt(0));
            
            index = 0;
            nUnidades--;
        }

        public void getServicosBD()
        {
            unidadeDAO.Listar();
        }
    }
}
