using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Seguridad
{
    class CatMenu
    {
        private static CatMenu instancia;
        private List<Entidades.Seguridad.Menu> menu; 

        public static CatMenu ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatMenu();
            return instancia; 
        }

        private CatMenu()
        {
            if (menu == null) menu = Mapping.Seguridad.MappingMenu.RecuperarMenu(); 
        }

        public IReadOnlyCollection<Entidades.Seguridad.Menu> RecuperarMenu()
        {
            return menu.AsReadOnly();
        }
    }
}
