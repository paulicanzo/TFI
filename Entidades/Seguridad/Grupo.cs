using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Seguridad
{
    public class Grupo
    {
        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        public override string ToString()
        {
            return nombre; 
        }
        private string descripcion; 
        public string Descripcion { get => descripcion; set => descripcion = value; }

        private bool estado = true; 
        public bool Estado { get => estado; }

        public void CambiarEstado()
        {
            if (estado) estado = false;
            else estado = true; 
        }
    }
}
