using System.Collections.Generic;

namespace Entidades.Sistema
{
    public class Provinicia
    {
        public Provinicia() 
        { 
            localidad = new List<Localidad>(); 
        }

        private string nombre; 
        public string Nombre { get => nombre; set => nombre = value; }

        private List<Localidad> localidad;
        public List<Localidad> Localidad { get => localidad; set => localidad = value; }

        public override string ToString()
        {
            return nombre;
        }

        public void AgregarLocalidad(Entidades.Sistema.Localidad loc)
        {
            loc.Provincia = this;
            localidad.Add(loc); 
        }
    }
}
