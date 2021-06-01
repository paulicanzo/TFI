using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatListadoProductos
    {
        private static CatListadoProductos instancia;
        private List<Entidades.Sistema.ListadoProductos> listadoProductos;

        public static CatListadoProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatListadoProductos();
            return instancia; 
        }

        private CatListadoProductos()
        {
            this.listadoProductos = new List<Entidades.Sistema.ListadoProductos>(); 
        }

        public List<Entidades.Sistema.ListadoProductos> ConsultarListadoProductos(DateTime desde, DateTime hasta)
        {
            this.listadoProductos = Mapping.Sistema.MappingListadoProductos.RecuperarListadoProductos(desde, hasta);
            return this.listadoProductos.OrderBy(x => x.NombreProducto).ToList();
        }
    }
}

