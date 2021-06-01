using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class ProductosMasVendidos
    {
        private string categoria; 
        public string Categoria { get => categoria; set => categoria = value; }

        private int cantidad; 
        public int Cantidad { get => cantidad; set => cantidad = value; }

        private string producto;
        public string Producto { get => producto; set => producto = value;  }

    }
}
