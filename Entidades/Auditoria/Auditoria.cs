using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Auditoria
{
    public class Auditoria
    {
        private string usuario; 
        public string Usuario { get => usuario; set => usuario = value; }

        private string operacion; 
        public string Operacion { get => operacion; set => operacion = value; }

        private DateTime fecha; 
        public DateTime Fecha { get => fecha; set => fecha = value; }

        private string equipo; 
        public string Equipo { get => equipo; set => equipo = value;  }

    }
}

