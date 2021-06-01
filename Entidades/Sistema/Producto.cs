using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class Producto
    {
        public Producto() { estado = true;  }

        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        private CategoriaProducto categoriaProducto; 
        public CategoriaProducto CategoriaProducto { get => categoriaProducto; set => categoriaProducto = value; }

        private Proveedor proveedor; 
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }

        private decimal precio; 
        public decimal Precio { get => precio; set => precio = value; }

        private int codigo; 
        public int Codigo { get => codigo; set => codigo = value; }

        private int cantidad; 
        public int Cantidad { get => cantidad; set => cantidad = value; }

        private bool estado; 
        public bool Estado { get => estado;  }

        public void CambiarEstado()
        {
            if (estado) estado = false;
            else estado = true; 
        }
        private int puntoPedido; 
        public int PuntoPedido { get => puntoPedido; set => puntoPedido = value; }

        public override string ToString()
        {
            return Nombre.ToString();
        }

    }
}
