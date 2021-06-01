using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatCategoriasProducto
    {
        private static CatCategoriasProducto instancia;
        private List<Entidades.Sistema.CategoriaProducto> categoriaProducto; 

        public static CatCategoriasProducto ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatCategoriasProducto();
            return instancia; 
        }

        private CatCategoriasProducto()
        {
            this.categoriaProducto = new List<Entidades.Sistema.CategoriaProducto>();
            this.categoriaProducto = Mapping.Sistema.MappingCategoriasProductos.ObtenerInstancia().Recuperar();
        }

        public List<Entidades.Sistema.CategoriaProducto> ConsultarCategoriaProducto()
        {
            return this.categoriaProducto.OrderBy(x => x.Nombre).ToList();
        }

        public Entidades.Sistema.CategoriaProducto BuscarCategoriaProducto(string nombre)
        {
            return this.categoriaProducto.Find(oProducto => oProducto.Nombre.ToLower() == nombre.ToLower()); 
        }

        public bool AgregarCategoriaProducto(Entidades.Sistema.CategoriaProducto catProducto)
        {
            Mapping.Sistema.MappingCategoriasProductos.AgregarCategoriaProducto(catProducto);
            if (!categoriaProducto.Contains(catProducto))
            {
                categoriaProducto.Add(catProducto);
                return true;
            }
            else return false;
        }

        public bool EliminarCategoriaProducto(Entidades.Sistema.CategoriaProducto oCategoriaProducto)
        {
            bool resultado;
            resultado = Mapping.Sistema.MappingCategoriasProductos.EliminarCategoriaProducto(oCategoriaProducto);
            return resultado; 
        }
    }
}
