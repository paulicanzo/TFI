using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class OrdenCompra
    {
        public OrdenCompra() { lineaOrdenCompra = new List<LineaOrdenCompra>(); }

        private int nroOrdenCompra; 
        public int NroOrdenCompra { get => nroOrdenCompra; set => nroOrdenCompra = value; }

        private Proveedor proveedor; 
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }

        private CondicionesPago condicionesPago; 
        public CondicionesPago CondicionesPago { get => condicionesPago; set => condicionesPago = value; }

        private DateTime fechaEmision; 
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }

        private DateTime fechaRecepcionMercaderia; 
        public DateTime FechaRecepcionMercaderia { get => fechaRecepcionMercaderia; set => fechaRecepcionMercaderia = value; }

        private decimal precioTotal;
        public decimal PrecioTotal { get => precioTotal; set => precioTotal = value; }

        private string estado; 
        public string Estado { get => estado; set => estado = value; }

        private string operacion; 
        public string Operacion { get => operacion; set => operacion = value; }

        private string usuario; 
        public string Usuario { get => usuario; set => usuario = value; }

        private DateTime fecha; 
        public DateTime Fecha { get => fecha; set => fecha = value; }

        private string equipo; 
        public string Equipo { get => equipo; set => equipo = value; }

        private List<LineaOrdenCompra> lineaOrdenCompra;
        public List<LineaOrdenCompra> LineaOrdenCompra { get => lineaOrdenCompra; }

        public bool AgregarLineaOrdenCompra(Entidades.Sistema.LineaOrdenCompra LOC)
        {
            if (lineaOrdenCompra.Find(x => x.Producto == LOC.Producto) == null)
            {
                precioTotal = precioTotal + LOC.Subtotal;
                lineaOrdenCompra.Add(LOC);
                return true;
            }
            else return false; 
        }
        public void QuitarLineaOrdenCompra(Entidades.Sistema.LineaOrdenCompra LOC)
        {
            precioTotal = precioTotal - LOC.Subtotal;
            lineaOrdenCompra.Remove(LOC); 
        }
        public override string ToString()
        {
            return nroOrdenCompra.ToString();
        }
    }
}

