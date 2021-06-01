using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Seguridad
{

    public enum TipoAutenticacion
    {
        PrimerLogin,
        PasswordErroneo,
        UsuarioYaLogueado,
        UsuarioNoHabilitado,
        UsuarioDesconocido,
    }

}
