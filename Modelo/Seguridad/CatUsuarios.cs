using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Seguridad
{
    class CatUsuarios
    {
        private static CatUsuarios instancia; 
        public static CatUsuarios ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatUsuarios();
            return instancia; 
        }

        private List<Entidades.Seguridad.Usuario> usuarios; 
        private CatUsuarios()
        {
            this.usuarios = new List<Entidades.Seguridad.Usuario>();
            this.usuarios = Mapping.Seguridad.MappingUsuarios.RecuperarUsuarios();
        }

        public void AgregarUsuario (Entidades.Seguridad.Usuario oUsuario)
        {
            bool resultado = Mapping.Seguridad.MappingUsuarios.AgregarUsuario(oUsuario);
            if (resultado) usuarios.Add(oUsuario); 
        }

        public void EliminarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            Mapping.Seguridad.MappingUsuarios.EliminarUsuario(oUsuario);
            usuarios.Remove(oUsuario); 
        }

        public Entidades.Seguridad.Usuario BuscarUsuario(string nombreUsuario)
        {
            Entidades.Seguridad.Usuario usr = usuarios.Find(oUsuario => oUsuario.NombreUsuario.ToLower() == nombreUsuario.ToLower());
            return usr; 
        }

        public bool ModificarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            Mapping.Seguridad.MappingUsuarios.ModificarUsuario(oUsuario);
            usuarios.Remove(oUsuario);
            usuarios.Add(oUsuario);
            if (usuarios.Contains(oUsuario)) return true;
            else return false; 
        }

        public List<Entidades.Seguridad.Usuario> ConsultarUsuarios()
        {
            return usuarios.OrderBy(x => x.NombreUsuario).ToList();
        }

        public List<Entidades.Seguridad.Usuario> FiltrarUsuarios(string str)
        {
            return this.usuarios.FindAll(oUsuario => oUsuario.NombreUsuario.ToLower().Contains(str.ToLower()) ||
                                                       oUsuario.Nombre.ToLower().Contains(str.ToLower()) ||
                                                       oUsuario.Apellido.ToLower().Contains(str.ToLower()));
        }
    }
}
