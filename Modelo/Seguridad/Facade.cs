using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Seguridad
{
    public static class Facade
    {
        public static void Agregar(Entidades.Seguridad.Usuario usuario)
        {
            Modelo.Seguridad.CatUsuarios.ObtenerInstancia().AgregarUsuario(usuario); 
        }

        public static bool Agregar(Entidades.Seguridad.Grupo grupo)
        {
            Modelo.Seguridad.CatGrupos.ObtenerInstancia().AgregarGrupo(grupo);
            return true; 
        }

        public static void Agregar (Entidades.Seguridad.Perfil perfil)
        {
            Modelo.Seguridad.CatPerfiles.ObtenerInstancia().AgregarPerfil(perfil);
        }

        public static bool Modificar(Entidades.Seguridad.Grupo grupo)
        {
            Modelo.Seguridad.CatGrupos.ObtenerInstancia().ModificarGrupo(grupo);
            return true;
        }

        public static bool Modificar(Entidades.Seguridad.Usuario usuario)
        {
            Modelo.Seguridad.CatUsuarios.ObtenerInstancia().ModificarUsuario(usuario);
            return true;
        }

        public static bool Eliminar (Entidades.Seguridad.Grupo grupo)
        {
            Modelo.Seguridad.CatGrupos.ObtenerInstancia().EliminarGrupo(grupo);
            return true; 
        }

        public static bool Eliminar (Entidades.Seguridad.Perfil perfil)
        {
            Modelo.Seguridad.CatPerfiles.ObtenerInstancia().EliminarPerfil(perfil);
            return true;
        }

        public static void Eliminar(Entidades.Seguridad.Usuario usuario)
        {
            Modelo.Seguridad.CatUsuarios.ObtenerInstancia().EliminarUsuario(usuario); 
        }

        public static object Filtrar (string eleccion, string str)
        {
            if(str == "Grupos")
            {
                return Modelo.Seguridad.CatGrupos.ObtenerInstancia().FiltrarGrupos(eleccion); 
            }

            if (str == "Usuarios")
            {
                return Modelo.Seguridad.CatUsuarios.ObtenerInstancia().FiltrarUsuarios(eleccion);
            }

            else return null; 
        }

        public static object Consultar (string eleccion)
        {
            if(eleccion == "Formularios")
            {
                return Modelo.Seguridad.CatFormulario.ObtenerInstancia().ConsultarFormularios(); 
            }
            if(eleccion == "Grupos")
            {
                return Modelo.Seguridad.CatGrupos.ObtenerInstancia().ConsultarGrupo(); 
            }
            if(eleccion == "Perfiles")
            {
                return Modelo.Seguridad.CatPerfiles.ObtenerInstancia().ConsultarPerfiles();
            }
            if(eleccion == "Permisos")
            {
                return Modelo.Seguridad.CatPermisos.ObtenerInstancia().ConsultarPermiso();
            }
            if(eleccion == "Usuarios")
            {
                return Modelo.Seguridad.CatUsuarios.ObtenerInstancia().ConsultarUsuarios();
            }
            if (eleccion == "Menu")
            {
                return Modelo.Seguridad.CatUsuarios.ObtenerInstancia().ConsultarUsuarios();
            }
            else return null; 
        }

        public static object Buscar(string criterio, string eleccion)
        {
            if (eleccion == "Grupos")
            {
                return Modelo.Seguridad.CatGrupos.ObtenerInstancia().BuscarGrupo(criterio);
            }
            if (eleccion == "Usuarios")
            {
                return Modelo.Seguridad.CatUsuarios.ObtenerInstancia().BuscarUsuario(criterio);
            }
            else return null;
        }
        public static object Buscar(string grupo, string formulario, string permiso)
        {
            return Modelo.Seguridad.CatPerfiles.ObtenerInstancia().BuscarPerfil(grupo, formulario, permiso); 
        }
    }
}
