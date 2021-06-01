using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Seguridad
{
    public class Formulario
    {
        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        public override string ToString()
        {
            return nombre; 
        }
    }
}

