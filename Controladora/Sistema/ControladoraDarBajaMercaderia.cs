using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Controladora.Sistema
{
    public class ControladoraDarBajaMercaderia
    {
        private static ControladoraDarBajaMercaderia instancia;
        public static ControladoraDarBajaMercaderia ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraDarBajaMercaderia();
            return instancia;
        }

        private ControladoraDarBajaMercaderia() { }

        public List<Entidades.Sistema.NotaVenta> RecuperarNotaVenta()
        {
            List<Entidades.Sistema.NotaVenta> notaVenta = new List<Entidades.Sistema.NotaVenta>();
            try
            {
                notaVenta = Modelo.Sistema.CatNotaVenta.ObtenerInstancia().ConsultarNotaVenta();
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return notaVenta;
        }

        public void ModificarProducto(Entidades.Sistema.Producto oProducto)
        {
            try
            {
                Modelo.Sistema.CatProductos.ObtenerInstancia().ModificarProducto(oProducto);
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }
    }
}
