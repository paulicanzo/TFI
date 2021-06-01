using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraIngresarMercaderia
    {
        private static ControladoraIngresarMercaderia instancia; 
        public static ControladoraIngresarMercaderia ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraIngresarMercaderia();
            return instancia; 
        }

        private ControladoraIngresarMercaderia() { }

        public Entidades.Sistema.Faltante RecuperarFaltante(int nro)
        {
            Entidades.Sistema.Faltante oFaltante = null;
            try
            {
                oFaltante = Modelo.Sistema.CatFaltante.ObtenerInstancia().ConsultarFaltante(nro); 
                if(oFaltante == null)
                {
                    oFaltante = new Entidades.Sistema.Faltante();
                    return oFaltante;
                }
                else
                {
                    return oFaltante;
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return oFaltante;
        }

        public List<Entidades.Sistema.OrdenCompra> RecuperarOrdenCompra()
        {
            List<Entidades.Sistema.OrdenCompra> OrdenCompra = new List<Entidades.Sistema.OrdenCompra>();
            try
            {
                OrdenCompra = Modelo.Sistema.CatOrdenCompra.ObtenerInstancia().ConsultarOrdenCompra();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return OrdenCompra;
        }

        public void ModificarProducto(Entidades.Sistema.Producto oProducto)
        {
            try
            {
                Modelo.Sistema.CatProductos.ObtenerInstancia().ModificarProducto(oProducto);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public bool AgregarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            try
            {
                Entidades.Sistema.Faltante faltante = Modelo.Sistema.CatFaltante.ObtenerInstancia().BuscarFaltante(oFaltante);
                if(faltante == null)
                {
                    Modelo.Sistema.CatFaltante.ObtenerInstancia().AgregarFaltante(oFaltante);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
            return false;
        }

        public void ModificarFaltante(Entidades.Sistema.Faltante oFaltante)
        {
            try
            {
                Modelo.Sistema.CatFaltante.ObtenerInstancia().ModificarFaltante(oFaltante);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }
    }
}
