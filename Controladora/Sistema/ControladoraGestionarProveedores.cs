using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraGestionarProveedores
    {
        private static ControladoraGestionarProveedores instancia; 
        public static ControladoraGestionarProveedores ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarProveedores();
            return instancia;
        }

        private ControladoraGestionarProveedores() { }

        public List<Entidades.Sistema.Proveedor> RecuperarProveedores()
        {
            List<Entidades.Sistema.Proveedor> oProveedores = new List<Entidades.Sistema.Proveedor>();
            try
            {
                oProveedores = Modelo.Sistema.CatProveedores.ObtenerInstancia().RecuperarProveedores();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return oProveedores;
        }

        public bool AgregarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            try
            {
                Entidades.Sistema.Proveedor oProveedor = Modelo.Sistema.CatProveedores.ObtenerInstancia().BuscarProveedor(Proveedor.Cuit); 
                if(oProveedor == null)
                {
                    Modelo.Sistema.CatProveedores.ObtenerInstancia().AgregarProveedor(Proveedor);
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

        public bool ModificarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            try
            {
                Modelo.Sistema.CatProveedores.ObtenerInstancia().ModificarProveedor(Proveedor);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public void CambiarEstado(Entidades.Sistema.Proveedor Proveedor)
        {
            try
            {
                Proveedor.CambiarEstado();
                Modelo.Sistema.CatProveedores.ObtenerInstancia().ModificarProveedor(Proveedor);
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }

        public List<Entidades.Sistema.Provinicia> RecuperarProvincias()
        {
            return Modelo.Sistema.CatProvincias.ObtenerInstancia().RecuperarProvincias();
        }

        public List<Entidades.Sistema.CategoriaIVA> RecuperarCategoriaIVA()
        {
            return Modelo.Sistema.CatCategoriasIVA.ObtenerInstancia().RecuperarCategoriaIVA();
        }

        public List<Entidades.Sistema.Proveedor> FiltrarProveedores(string criterio)
        {
            List<Entidades.Sistema.Proveedor> oProveedor = new List<Entidades.Sistema.Proveedor>();
            try
            {
                oProveedor = Modelo.Sistema.CatProveedores.ObtenerInstancia().Filtrar(criterio);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oProveedor;
        }

        public List<Entidades.Sistema.CondicionesPago> RecuperarCondicionesPago()
        {
            List<Entidades.Sistema.CondicionesPago> oCondiciones = new List<Entidades.Sistema.CondicionesPago>();
            try
            {
                oCondiciones = Modelo.Sistema.CatCondicionesPago.ObtenerInstancia().ConsultarCondicionesPago();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oCondiciones;
        }
    }
}

