using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Seguridad
{
    public class Menu
    {

        private Int32 idMenu; 
        public Int32 IdMenu { get => idMenu; set => idMenu = value; }

        private string descripcion; 
        public string Descripcion { get => descripcion; set => descripcion = value; }

        private Int32 idParentMenu; 
        public Int32 IdParentMenu { get => idParentMenu; set => idParentMenu = value; }

        private string url; 
        public string Url { get => url; set => url = value; }
    }
}
