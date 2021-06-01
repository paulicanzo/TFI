using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Sistema;

namespace Controladora.Sistema
{
    public class ControladoraRegistrarPago
    {
        private static ControladoraRegistrarPago instancia; 
        public static ControladoraRegistrarPago ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraRegistrarPago();
            return instancia;
        }

        private ControladoraRegistrarPago() { }

        public List<Entidades.Sistema.CuentaCorriente> RecuperarCuentaCorriente()
        {
            List<Entidades.Sistema.CuentaCorriente> cuentaCorriente = new List<CuentaCorriente>();
            try
            {
                cuentaCorriente = Modelo.Sistema.CatCuentasCorrientes.ObtenerInstancia().ConsultarCuentaCorriente();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return cuentaCorriente;
        }

        public List<Entidades.Sistema.Cliente> RecuperarCliente()
        {
            List<Entidades.Sistema.Cliente> clientes = new List<Cliente>();
            try
            {
                clientes = Modelo.Sistema.CatClientes.ObtenerInstancia().RecuperarClientes();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return clientes;
        }

        public List<Entidades.Sistema.NotaVenta> RecuperarNotasVentas()
        {
            List<Entidades.Sistema.NotaVenta> notaVentas = new List<NotaVenta>();
            try
            {
                notaVentas = Modelo.Sistema.CatNotaVenta.ObtenerInstancia().ConsultarNotaVenta(); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return notaVentas;
        }

        public List<Entidades.Sistema.OrdenCompra> RecuperarOrdenesCompra()
        {
            List<Entidades.Sistema.OrdenCompra> OrdenCompra = new List<OrdenCompra>();
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
    }

}
