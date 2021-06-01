using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Auditoria
{
    public class AuditoriaOrdenCompra 
    {
        public AuditoriaOrdenCompra() {auditoriaLineaOrdenCompra = new List<AuditoriaLineaOrdenCompra>(); }

        private string usuario; 
        public string Usuario { get => usuario; set => usuario = value; }

        private string operacion; 
        public string Operacion { get => operacion; set => operacion = value;  }

        private DateTime fecha; 
        public DateTime Fecha { get => fecha; set => fecha = value; }

        private string equipo; 
        public string Equipo { get => equipo; set => equipo = value; }

        private int nroOrdenCompra; 
        public int NroOrdenCompra { get => nroOrdenCompra; set => nroOrdenCompra = value; }

        private string proveedor; 
        public string Proveedor { get => proveedor; set => proveedor = value; }

        private string condicionesPago; 
        public string CondicionesPago { get => condicionesPago; set => condicionesPago = value; }

        private DateTime fechaEmision; 
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }

        private DateTime fechaRecepcionMercaderia; 
        public DateTime FechaRecepcionMercaderia { get => fechaRecepcionMercaderia; set => fechaRecepcionMercaderia = value; }

        private decimal precioTotal; 
        public decimal PrecioTotal { get => precioTotal; set => precioTotal = value; }

        private string estado; 
        public string Estado { get => estado; set => estado = value; }

        private List<AuditoriaLineaOrdenCompra> auditoriaLineaOrdenCompra; 
        public List<AuditoriaLineaOrdenCompra> AuditoriaLineaOrdenCompra { get => auditoriaLineaOrdenCompra; set => auditoriaLineaOrdenCompra = value; }

        public bool AgregarLineaOrdenCompra (Entidades.Auditoria.AuditoriaLineaOrdenCompra LOC)
        {
            if (auditoriaLineaOrdenCompra.Find(x => x.Producto == LOC.Producto) == null)
            {
                precioTotal = precioTotal + LOC.Subtotal;
                auditoriaLineaOrdenCompra.Add(LOC);
                return true;
            }
            else return false; 
        }
    }
}
