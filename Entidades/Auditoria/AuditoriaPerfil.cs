using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Auditoria
{
    public class AuditoriaPerfil
    {
        private string formulario; 
        public string Formulario { get => formulario; set => formulario = value; }

        private string grupo; 
        public string Grupo { get => grupo; set => grupo = value; }

        private string permiso; 
        public string Permiso { get => permiso; set => permiso = value; }

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
