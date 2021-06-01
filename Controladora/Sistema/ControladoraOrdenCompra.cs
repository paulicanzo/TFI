using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.Sistema
{
    public class ControladoraOrdenCompra
    {
        private static ControladoraOrdenCompra instancia; 
        public static ControladoraOrdenCompra ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraOrdenCompra();
            return instancia; 
        }

        private ControladoraOrdenCompra() { }

        public List<Entidades.Sistema.OrdenCompra> RecuperarOrdenCompra()
        {
            List<Entidades.Sistema.OrdenCompra> ordenCompra = new List<Entidades.Sistema.OrdenCompra>();
            try
            {
                ordenCompra = Modelo.Sistema.CatOrdenCompra.ObtenerInstancia().ConsultarOrdenCompra();
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return ordenCompra;
        }

        public bool AgregarOrdenCompra(Entidades.Sistema.OrdenCompra ordenCompra, Entidades.Seguridad.Usuario Usuario)
        {
            try
            {
                ordenCompra.Usuario = Usuario.NombreUsuario;
                ordenCompra.Equipo = Environment.MachineName;
                ordenCompra.Fecha = DateTime.Now;
                ordenCompra.Operacion = "Agregar";
                Modelo.Sistema.CatOrdenCompra.ObtenerInstancia().AgregarOrdenCompra(ordenCompra);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return false;
        }

        public bool AnularOrdenCompra(Entidades.Sistema.OrdenCompra ordenCompra, Entidades.Seguridad.Usuario Usuario)
        {
            try
            {
                Modelo.Sistema.CatOrdenCompra.ObtenerInstancia().AnularOrdenCompra(ordenCompra);
                Entidades.Auditoria.AuditoriaOrdenCompra AOC = new Entidades.Auditoria.AuditoriaOrdenCompra();
                AOC.Usuario = ordenCompra.Usuario;
                AOC.Equipo = ordenCompra.Equipo;
                AOC.Fecha = ordenCompra.Fecha;
                AOC.Operacion = ordenCompra.Operacion;
                AOC.NroOrdenCompra = ordenCompra.NroOrdenCompra;
                AOC.CondicionesPago = ordenCompra.CondicionesPago.Nombre;
                AOC.Estado = ordenCompra.Estado;
                AOC.FechaEmision = ordenCompra.FechaEmision;
                AOC.FechaRecepcionMercaderia = ordenCompra.FechaRecepcionMercaderia;
                AOC.PrecioTotal = ordenCompra.PrecioTotal;
                AOC.Proveedor = ordenCompra.Proveedor.DenominacionLegal;

                foreach (Entidades.Sistema.LineaOrdenCompra LOC in ordenCompra.LineaOrdenCompra)
                {
                    Entidades.Auditoria.AuditoriaLineaOrdenCompra auditoriaLinea = new Entidades.Auditoria.AuditoriaLineaOrdenCompra();
                    auditoriaLinea.Producto = LOC.Producto.Nombre;
                    auditoriaLinea.Cantidad = LOC.Cantidad;
                    auditoriaLinea.PrecioUnitario = LOC.PrecioUnitario;
                    auditoriaLinea.Subtotal = LOC.Subtotal;
                    AOC.AgregarLineaOrdenCompra(auditoriaLinea);
                }

                Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregarAuditoriaOrdenCompra(AOC);
                
                Entidades.Auditoria.AuditoriaOrdenCompra anularOC = new Entidades.Auditoria.AuditoriaOrdenCompra();
                anularOC.Usuario = Usuario.NombreUsuario;
                anularOC.Equipo = Environment.MachineName;
                anularOC.Fecha = DateTime.Now;
                anularOC.Operacion = "Anular";
                anularOC.NroOrdenCompra = ordenCompra.NroOrdenCompra;
                anularOC.CondicionesPago = ordenCompra.CondicionesPago.Nombre;
                anularOC.Estado = "Anulada";
                anularOC.FechaEmision = ordenCompra.FechaEmision;
                anularOC.FechaRecepcionMercaderia = ordenCompra.FechaRecepcionMercaderia;
                anularOC.PrecioTotal = ordenCompra.PrecioTotal;
                anularOC.Proveedor = ordenCompra.Proveedor.DenominacionLegal;

                foreach (Entidades.Sistema.LineaOrdenCompra LOC in ordenCompra.LineaOrdenCompra)
                {
                    Entidades.Auditoria.AuditoriaLineaOrdenCompra auditoriaLinea = new Entidades.Auditoria.AuditoriaLineaOrdenCompra();
                    auditoriaLinea.Producto = LOC.Producto.Nombre;
                    auditoriaLinea.Cantidad = LOC.Cantidad;
                    auditoriaLinea.PrecioUnitario = LOC.PrecioUnitario;
                    auditoriaLinea.Subtotal = LOC.Subtotal;
                    anularOC.AgregarLineaOrdenCompra(auditoriaLinea);
                }
                Modelo.Auditoria.catAuditoria.ObtenerInstancia().AgregarAuditoriaOrdenCompra(anularOC);
                return true;
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
                return false;
            }
        }

        public List<Entidades.Sistema.Producto> RecuperarProductosProveedor(Entidades.Sistema.Proveedor proveedor)
        {
            List<Entidades.Sistema.Producto> Productos = new List<Entidades.Sistema.Producto>();
            try
            {
                Productos = Modelo.Sistema.CatProductos.ObtenerInstancia().ConsultarProductos().FindAll(x => x.Proveedor.Cuit == proveedor.Cuit);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return Productos;
        }

        public List<Entidades.Sistema.OrdenCompra> FiltrarOrdenes(string criterio)
        {
            List<Entidades.Sistema.OrdenCompra> OC = new List<Entidades.Sistema.OrdenCompra>();
            try
            {
                OC = Modelo.Sistema.CatOrdenCompra.ObtenerInstancia().FiltrarUsuarios(criterio);
            }
            catch (Exception ex)
            {
                Servicios.EventManager.RegistrarErrores(ex);
            }
            return OC;
        }
    }
}
