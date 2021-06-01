using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraNotaVenta
    {
        private static ControladoraNotaVenta instancia; 
        public static ControladoraNotaVenta ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraNotaVenta();
            return instancia;
        }

        public ControladoraNotaVenta() { }

        public List<Entidades.Sistema.NotaVenta> RecuperarNotaVenta()
        {
            List<Entidades.Sistema.NotaVenta> notaVenta = new List<Entidades.Sistema.NotaVenta>();
            try
            {
                notaVenta = Modelo.Sistema.CatNotaVenta.ObtenerInstancia().ConsultarNotaVenta();
                foreach (Entidades.Sistema.NotaVenta item in notaVenta)
                {
                    if(item.Fecha.Date < DateTime.Now.Date)
                    {
                        if(item.Estado != "Anulada")
                        {
                            if(item.Estado != "Finalizada")
                            {
                                item.Estado = "Pendiente";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return notaVenta;
        }

        public bool AgregarNotaVenta(Entidades.Sistema.NotaVenta notaVenta)
        {
            try
            {
                Modelo.Sistema.CatNotaVenta.ObtenerInstancia().AgregarNotaVenta(notaVenta);
                List<Entidades.Sistema.CuentaCorriente> cuentaCorriente = Modelo.Sistema.CatCuentasCorrientes.ObtenerInstancia().ConsultarCuentaCorriente();
                foreach (var item in cuentaCorriente)
                {
                    if(item.Cliente.Codigo == notaVenta.Cliente.Codigo)
                    {
                        Entidades.Sistema.Movimiento movimiento = new Entidades.Sistema.Movimiento();
                        movimiento.Concepto = "Generacion de Nota de Venta";
                        movimiento.Fecha = DateTime.Now;
                        movimiento.Tipo = Entidades.Sistema.Movimiento.MovimientoTipo.Egreso;
                        movimiento.Monto = notaVenta.PrecioTotal;
                        item.AgregarMovimiento(movimiento);
                        Modelo.Sistema.CatCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(item);
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return false;
        }

        public bool AnularNotaVenta(Entidades.Sistema.NotaVenta notaVenta)
        {
            try
            {
                Modelo.Sistema.CatNotaVenta.ObtenerInstancia().AnularNotaVenta(notaVenta);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public bool FinalizarNotaVenta(Entidades.Sistema.NotaVenta notaVenta)
        {
            try
            {
                Modelo.Sistema.CatNotaVenta.ObtenerInstancia().FinalizarNotaVenta(notaVenta);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public List<Entidades.Sistema.Producto> RecuperarProductos(Entidades.Sistema.NotaVenta notaVenta)
        {
            try
            {
                return Modelo.Sistema.CatProductos.ObtenerInstancia().ConsultarProductos();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return null;
        }

        public List<Entidades.Sistema.NotaVenta> FiltrarNotaVenta(string criterio)
        {
            List<Entidades.Sistema.NotaVenta> oNotaVenta = new List<Entidades.Sistema.NotaVenta>();
            try
            {
                oNotaVenta = Modelo.Sistema.CatNotaVenta.ObtenerInstancia().FiltrarNotaVenta(criterio); 
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return oNotaVenta;
        }
    }
}
