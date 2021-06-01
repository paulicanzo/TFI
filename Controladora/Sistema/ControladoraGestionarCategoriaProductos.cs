using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Sistema;

namespace Controladora.Sistema
{
    public class ControladoraGestionarCategoriaProductos
    {
        private static ControladoraGestionarCategoriaProductos instancia; 
        public static ControladoraGestionarCategoriaProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarCategoriaProductos();
            return instancia;
        }
        private ControladoraGestionarCategoriaProductos() { }

        public List<Entidades.Sistema.CategoriaProducto> RecuperarCategoriaProducto()
        {
            List<Entidades.Sistema.CategoriaProducto> categoriaProducto = new List<Entidades.Sistema.CategoriaProducto>();
            try
            {
                categoriaProducto = Modelo.Sistema.CatCategoriasProducto.ObtenerInstancia().ConsultarCategoriaProducto(); 
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return categoriaProducto;
        }

        public bool AgregarCategoriaProducto(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            try
            {
                Entidades.Sistema.CategoriaProducto oCategoriaProducto = Modelo.Sistema.CatCategoriasProducto.ObtenerInstancia().BuscarCategoriaProducto(CategoriaProducto.Nombre);
                if(oCategoriaProducto == null)
                {
                    Modelo.Sistema.CatCategoriasProducto.ObtenerInstancia().AgregarCategoriaProducto(CategoriaProducto);
                    return true;
                }
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return false;
        }

        public List<Proveedor> RecuperarProveedores()
        {
            List<Entidades.Sistema.Proveedor> Proveedores = new List<Entidades.Sistema.Proveedor>();
            try
            {
                Proveedores = Modelo.Sistema.CatProveedores.ObtenerInstancia().RecuperarProveedores();
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return Proveedores;
        }

        public bool EliminarCategoriaProducto(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            bool resultado = false;
            try
            {
                foreach (Entidades.Sistema.Producto item in Modelo.Sistema.CatProductos.ObtenerInstancia().ConsultarProductos())
                {
                    if (item.CategoriaProducto.Nombre == CategoriaProducto.Nombre) return false;
                }
                resultado = Modelo.Sistema.CatCategoriasProducto.ObtenerInstancia().EliminarCategoriaProducto(CategoriaProducto);
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return resultado;
        }

        public List<Entidades.Sistema.Producto> RecuperarProducto(string nombre)
        {
            return Modelo.Sistema.CatProductos.ObtenerInstancia().ConsultarProductos();
        }
    }
}

