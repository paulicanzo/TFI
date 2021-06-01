using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Controladora.Seguridad
{
    public class ControladoraMenu
    {
        private static ControladoraMenu instancia;
        public static ControladoraMenu ObtenerInstancia()
        {
            if (instancia == null) instancia = new ControladoraMenu();
            return instancia;
        }

        public ReadOnlyCollection<Entidades.Seguridad.Menu> RecuperarMenu()
        {
            return ((ReadOnlyCollection<Entidades.Seguridad.Menu>)Modelo.Seguridad.Facade.Consultar("Menu"));
        }
    }
}
