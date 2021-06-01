using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraGestionarProductos
    {
        private static ControladoraGestionarProductos instancia; 

        public static ControladoraGestionarProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarProductos();
            return instancia; 
        }

        private ControladoraGestionarProductos() { }

        public List<Entidades.Sistema.Producto> RecuperarProducto()
        {
            List<Entidades.Sistema.Producto> oProducto = new List<Entidades.Sistema.Producto>();
            try
            {
                oProducto = Modelo.Sistema.CatProductos.ObtenerInstancia().ConsultarProductos();
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oProducto; 
        }

        public bool AgregarProducto(Entidades.Sistema.Producto Producto)
        {
            try
            {
                Entidades.Sistema.Producto oProducto = Modelo.Sistema.CatProductos.ObtenerInstancia().BuscarProductos(Producto.Nombre); 
                if(oProducto == null)
                {
                    Modelo.Sistema.CatProductos.ObtenerInstancia().AgregarProducto(Producto);
                    return true;
                }
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return false;
        }

        public void ModificarProducto(Entidades.Sistema.Producto Producto)
        {
            try
            {
                Modelo.Sistema.CatProductos.ObtenerInstancia().ModificarProducto(Producto);
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public void CambiarEstado(Entidades.Sistema.Producto Producto)
        {
            try
            {
                Producto.CambiarEstado();
                Modelo.Sistema.CatProductos.ObtenerInstancia().ModificarProducto(Producto);
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public List<Entidades.Sistema.Producto> FiltrarProductos(string criterio)
        {
            List<Entidades.Sistema.Producto> oProducto = new List<Entidades.Sistema.Producto>();
            try
            {
                oProducto = Modelo.Sistema.CatProductos.ObtenerInstancia().FiltrarProductos(criterio);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oProducto;
        }
    }
}

