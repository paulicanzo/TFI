using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraListadoProductos
    {
        private static ControladoraListadoProductos instancia; 
        public static ControladoraListadoProductos ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraListadoProductos();
            return instancia;
        }

        private ControladoraListadoProductos() { }

        public List<Entidades.Sistema.ListadoProductos> RecuperarListadoProductos(DateTime desde, DateTime hasta)
        {
            List<Entidades.Sistema.ListadoProductos> listadoProductos = new List<Entidades.Sistema.ListadoProductos>();
            try
            {
                listadoProductos = Modelo.Sistema.CatListadoProductos.ObtenerInstancia().ConsultarListadoProductos(desde, hasta); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return listadoProductos;
        }
    }
}
