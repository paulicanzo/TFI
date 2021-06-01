using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Seguridad
{
    public class Perfil
    {
        private Formulario formulario; 
        public Formulario Formulario { get => formulario; set => formulario = value; }

        private Permiso permiso; 
        public Permiso Permiso { get => permiso; set => permiso = value; }

        private Grupo grupo; 
        public Grupo Grupo { get => grupo; set => grupo = value; }

        private string operacion; 
        public string Operacion { get => operacion; set => operacion = value; }

        private string usuario; 
        public string Usuario { get => usuario; set => usuario = value; }

        private DateTime fecha; 
        public DateTime Fecha { get => fecha; set => fecha = value; }

        private string equipo; 
        public string Equipo { get => equipo; set => equipo = value; }
    }
}
