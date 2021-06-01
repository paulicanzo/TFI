﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Sistema
{
    [Serializable]
    public class CategoriaProducto
    {
        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        private string descripcion; 
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public override string ToString()
        {
            return nombre; 
        }
    }
}

