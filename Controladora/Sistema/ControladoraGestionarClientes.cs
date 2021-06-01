using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Controladora.Sistema
{
    public class ControladoraGestionarClientes
    {
        private static ControladoraGestionarClientes instancia; 
        public static ControladoraGestionarClientes ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraGestionarClientes();
            return instancia;
        }
        private ControladoraGestionarClientes() { }

        public List<Entidades.Sistema.Cliente> RecuperarClientes()
        {
            List<Entidades.Sistema.Cliente> clientes = new List<Entidades.Sistema.Cliente>();
            try
            {
                clientes = Modelo.Sistema.CatClientes.ObtenerInstancia().RecuperarClientes();
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return clientes;
        }

        public bool AgregarCliente (Entidades.Sistema.Cliente Cliente)
        {
            try
            {
                Entidades.Sistema.Cliente oCliente = Modelo.Sistema.CatClientes.ObtenerInstancia().BuscarCliente(Cliente.Cuit); 
                if(oCliente == null)
                {
                    Modelo.Sistema.CatClientes.ObtenerInstancia().AgregarCliente(Cliente);
                    return true; 
                }
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
            return false;
        }

        public bool ModificarCliente (Entidades.Sistema.Cliente Cliente)
        {
            try
            {
                Modelo.Sistema.CatClientes.ObtenerInstancia().ModificarCliente(Cliente);
                return true; 
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public void CambiarEstado (Entidades.Sistema.Cliente Cliente)
        {
            try
            {
                Cliente.CambiarEstado();
                Modelo.Sistema.CatClientes.ObtenerInstancia().ModificarCliente(Cliente);
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

        public List<Entidades.Sistema.CategoriaIVA> RecuperarCategoriasIVA()
        {
            return Modelo.Sistema.CatCategoriasIVA.ObtenerInstancia().RecuperarCategoriaIVA(); 
        }

        public List<Entidades.Sistema.Cliente> FiltrarClientes(string criterio)
        {
            List<Entidades.Sistema.Cliente> oCliente = new List<Entidades.Sistema.Cliente>();
            try
            {
                oCliente = Modelo.Sistema.CatClientes.ObtenerInstancia().FiltrarClientes(criterio); 
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oCliente;
        }
    }
}
