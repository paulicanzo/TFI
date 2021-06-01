using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatProductos
    {
        private static CatProductos instancia;
        private List<Entidades.Sistema.Producto> productos;

        public static CatProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatProductos();
            return instancia;
        }

        private CatProductos()
        {
            this.productos = new List<Entidades.Sistema.Producto>();
            this.productos = Mapping.Sistema.MappingProductos.ObtenerInstancia().Recuperar();
        }

        public List<Entidades.Sistema.Producto> ConsultarProductos()
        {
            return this.productos.OrderBy(x => x.Nombre).ToList();
        }

        public Entidades.Sistema.Producto BuscarProductos(string nombre)
        {
            return this.productos.Find(oProducto => oProducto.Nombre.ToLower() == nombre.ToLower());
        }

        public Entidades.Sistema.Producto BuscarCategoriaProducto(string catNombre)
        {
            return this.productos.Find(oProducto => oProducto.CategoriaProducto.Nombre.ToLower() == catNombre.ToLower());
        }

        public bool AgregarProducto(Entidades.Sistema.Producto oProducto)
        {
            Mapping.Sistema.MappingProductos.AgregarProducto(oProducto);
            if (!productos.Contains(oProducto))
            {
                productos.Add(oProducto);
                return true;
            }
            else return false;
        }

        public bool ModificarProducto(Entidades.Sistema.Producto oProducto)
        {
            Mapping.Sistema.MappingProductos.ModificarProducto(oProducto);
            productos.Remove(oProducto);
            productos.Add(oProducto);
            if (productos.Contains(oProducto)) return true;
            else return false;
        }

        public List<Entidades.Sistema.Producto> FiltrarProductos(string criterio)
        {
            return this.productos.FindAll(OC => OC.Nombre.ToString().ToLower().Contains(criterio.ToLower()));
        }
    }
}

