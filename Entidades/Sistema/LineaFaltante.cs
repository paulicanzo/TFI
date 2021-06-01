using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    public class LineaFaltante
    {
        public LineaFaltante() { }

        private Producto producto; 
        public Producto Producto { get => producto; set => producto = value; }

        private int cantidadFaltante; 
        public int CantidadFaltante { get => cantidadFaltante; set => cantidadFaltante = value; }

        public override string ToString()
        {
            return Producto.Nombre.ToString(); 
        }
    }
}

