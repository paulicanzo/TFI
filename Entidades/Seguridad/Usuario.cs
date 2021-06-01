using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Seguridad
{
    public class Usuario
    {
        public Usuario()
        {
            grupos = new List<Grupo>();
            estado = true; 
        }
        private List<Grupo> grupos; 
        public List<Grupo> Grupos { get => grupos; set => grupos = value; }

        private string nombreUsuario;
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }

        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        private string apellido; 
        public string Apellido { get => apellido; set => apellido = value; }

        private string clave; 
        public string Clave { get => clave; }

        private bool estado; 
        public bool Estado { get => estado; }

        private string correoElectronico; 
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }

        public bool CambiarClave(string claveactual, string clavenueva)
        {
            if (this.clave == claveactual)
            {
                this.clave = clavenueva;
                return true;
            }
            else return false; 
        }
        public void CambiarEstado()
        {
            if (estado) estado = false;
            else estado = true; 
        }
        public bool AgregarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            if (!grupos.Contains(oGrupo))
            {
                grupos.Add(oGrupo);
                return true;
            }
            else return false; 
        }
        public void EliminarGrupo(Entidades.Seguridad.Grupo oGrupo)
        {
            grupos.Remove(oGrupo);
        }
    }
}
