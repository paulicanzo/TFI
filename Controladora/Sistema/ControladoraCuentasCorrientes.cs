using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraCuentasCorrientes
    {
        private static ControladoraCuentasCorrientes instancia; 
        public static ControladoraCuentasCorrientes ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraCuentasCorrientes();
            return instancia;
        }
        private ControladoraCuentasCorrientes() { }

        public List<Entidades.Sistema.CuentaCorriente> RecuperarCuentaCorriente()
        {
            List<Entidades.Sistema.CuentaCorriente> cuentaCorriente = new List<Entidades.Sistema.CuentaCorriente>();
            try
            {
                cuentaCorriente = Modelo.Sistema.CatCuentasCorrientes.ObtenerInstancia().ConsultarCuentaCorriente();
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return cuentaCorriente;
        }

        public List<Entidades.Sistema.CuentaCorriente> FiltrarCuentaCorriente(string criterio)
        {
            List<Entidades.Sistema.CuentaCorriente> cuentaCorriente = new List<Entidades.Sistema.CuentaCorriente>();
            try
            {
                cuentaCorriente = Modelo.Sistema.CatCuentasCorrientes.ObtenerInstancia().FiltrarCuentaCorriente(criterio); 
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex); 
            }
            return cuentaCorriente;
        }

        public List<Entidades.Sistema.CategoriaIVA> RecuperarCategoriasIVA()
        {
            return Modelo.Sistema.CatCategoriasIVA.ObtenerInstancia().RecuperarCategoriaIVA();
        }

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

        public void ModificarCuentaCorriente(Entidades.Sistema.CuentaCorriente ctaCte)
        {
            try
            {
                Modelo.Sistema.CatCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(ctaCte);
            }
            catch(Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
        }
    }
}
