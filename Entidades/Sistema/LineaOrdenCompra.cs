using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class LineaOrdenCompra
    {
        public LineaOrdenCompra() { }

        private Producto producto; 
        public Producto Producto { get => producto; }

        private decimal precioUnitario; 
        public decimal PrecioUnitario { get => precioUnitario; }

        private decimal subtotal; 
        public decimal Subtotal { get => subtotal; set => subtotal = value; }

        private int cantidad; 
        public int Cantidad { get => cantidad; }

        public void CargarDatos(Entidades.Sistema.Producto prod, decimal precio, int cant)
        {
            this.producto = prod;
            this.cantidad = cant;
            this.precioUnitario = precio;
            this.subtotal = precioUnitario * cantidad; 
        }

    }
}

