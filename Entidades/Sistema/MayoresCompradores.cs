using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class MayoresCompradores
    {
        private int cuit; 
        public int Cuit { get => cuit; set => cuit = value; }

        private string razonSocial; 
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }

        private decimal total; 
        public decimal Total { get => total; set => total = value;  }

        private int cantidad; 
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
