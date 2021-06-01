using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatCategoriasIVA
    {
        private List<Entidades.Sistema.CategoriaIVA> categoriaIVA;
        private static CatCategoriasIVA instancia; 

        public static CatCategoriasIVA ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatCategoriasIVA();
            return instancia; 
        }

        private CatCategoriasIVA()
        {
            this.categoriaIVA = new List<Entidades.Sistema.CategoriaIVA>();
            this.categoriaIVA = Mapping.Sistema.MappingCategoriasIVA.RecuperarCategoriaIVA(); 
        }

        public List<Entidades.Sistema.CategoriaIVA> RecuperarCategoriaIVA()
        { 
            return categoriaIVA;
        }
    }
}

