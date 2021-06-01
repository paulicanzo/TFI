using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class CategoriaIVA
    {
        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        private int codigo; 
        public int Codigo { get => codigo; set => codigo = value; }

        public override string ToString()
        {
            return nombre; 
        }
    }
}

