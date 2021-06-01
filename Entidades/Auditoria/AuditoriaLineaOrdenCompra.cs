using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Auditoria
{
    [Serializable]
    public class AuditoriaLineaOrdenCompra
    {
       public AuditoriaLineaOrdenCompra() { }

        private string producto; 
        public string Producto { get => producto; set => producto = value; }

        private decimal precioUnitario; 
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }

        private decimal subtotal; 
        public decimal Subtotal { get => subtotal; set => subtotal = value; }

        private int cantidad; 
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public void CargarDatos(string prod, decimal precio, int cant)
        {
            this.producto = prod;
            this.cantidad = cant;
            this.precioUnitario = precio;
            this.subtotal = precioUnitario * cantidad;
        }
    }
}
