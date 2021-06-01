using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraGestionarCondicionesPago
    {
        private static ControladoraGestionarCondicionesPago instancia; 
        public static ControladoraGestionarCondicionesPago ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarCondicionesPago();
            return instancia;
        }

        private ControladoraGestionarCondicionesPago() { }

        public List<Entidades.Sistema.CondicionesPago> RecuperarCondicionesPago()
        {
            List<Entidades.Sistema.CondicionesPago> condicionesPago = new List<Entidades.Sistema.CondicionesPago>();
            try
            {
                condicionesPago = Modelo.Sistema.CatCondicionesPago.ObtenerInstancia().ConsultarCondicionesPago(); 
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return condicionesPago;
        }

        public bool AgregarCondicionesPago(Entidades.Sistema.CondicionesPago condicionesPago)
        {
            try
            {
                Entidades.Sistema.CondicionesPago oCondicionesPago = Modelo.Sistema.CatCondicionesPago.ObtenerInstancia().BuscarCondicionPago(condicionesPago.Nombre);
                return true;
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return false;
        }

        public bool EliminarCondicionPago(Entidades.Sistema.CondicionesPago CondicionesPago)
        {
            try
            {
                foreach (Entidades.Sistema.Proveedor item in Modelo.Sistema.CatProveedores.ObtenerInstancia().RecuperarProveedores())
                {
                    foreach (Entidades.Sistema.CondicionesPago itemCondicion in item.CondicionesPago)
                        if (itemCondicion.Nombre == CondicionesPago.Nombre) return false;
                }
                return Modelo.Sistema.CatCondicionesPago.ObtenerInstancia().EliminarCondicionesPago(CondicionesPago);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }
    }
}
