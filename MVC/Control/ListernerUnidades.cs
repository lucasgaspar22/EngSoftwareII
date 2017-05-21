﻿using Projeto_Google.Model;
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

        public static ListernerUnidades getInstance()
        {
            if (sinstance == null) sinstance = new ListernerUnidades();
            return sinstance;
            throw new NotImplementedException();
        }
        
        public void addUnidade(String nome, String cidade, String estado, String pais)
        {
            Unidades unidade = new Unidades(nome, cidade, estado, pais);
            unidades.Add(unidade);
            nUnidades++;
        }

        public Unidades getUnidade()
        {
            return unidades.ElementAt(index);
        }

        public void editUnidade(String nome, String cidade, String estado, String pais)
        {
            unidades.ElementAt(index - 1).Nome = nome;
            unidades.ElementAt(index - 1).Cidade = cidade;
            unidades.ElementAt(index - 1).Estado = estado;
            unidades.ElementAt(index - 1).Pais = pais;
        }

        public void deleteUnidade()
        {
            unidades.Remove(unidades.ElementAt(index - 1));
            index = 0;
            nUnidades--;
        }
    }
}
