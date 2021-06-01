using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class Localidad
    {
        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value;  }

        private Provinicia provincia; 
        public Provinicia Provincia { get => provincia; set => provincia = value; }

        public override string ToString()
        {
            return nombre; 
        }
    }
}

