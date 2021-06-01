using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    public class ListadoProductos
    {
        private string nombreProducto; 
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }

        private int cantidad; 
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}

