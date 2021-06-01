using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Modelo.Sistema
{
    public class CatCuentasCorrientes
    {
        private static CatCuentasCorrientes instancia;
        private List<Entidades.Sistema.CuentaCorriente> cuentaCorriente; 

        public static CatCuentasCorrientes ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatCuentasCorrientes();
            return instancia; 
        }

        private CatCuentasCorrientes()
        {
            this.cuentaCorriente = new List<Entidades.Sistema.CuentaCorriente>();
            this.cuentaCorriente = Mapping.Sistema.MappingCuentaCorriente.RecuperarCuentaCorriente();
        }

        public List<Entidades.Sistema.CuentaCorriente> ConsultarCuentaCorriente()
        {
            return this.cuentaCorriente.OrderBy(x => x.Cliente.RazonSocial).ToList();
        }

        public Entidades.Sistema.CuentaCorriente BuscarCuentaCorriente(Entidades.Sistema.Cliente oCliente)
        {
            return this.cuentaCorriente.Find(cuenta => cuenta.Cliente.RazonSocial == oCliente.RazonSocial);
        }

        public List<Entidades.Sistema.CuentaCorriente> FiltrarCuentaCorriente(string criterio)
        {
            return this.cuentaCorriente.FindAll(oCuentaCorriente => oCuentaCorriente.Cliente.RazonSocial.ToString().ToLower().Contains(criterio.ToLower()));
        }

        public List<Entidades.Sistema.CuentaCorriente> FiltrarCuentaCorrientexCliente(string criterio)
        {
            return this.cuentaCorriente.FindAll(oCuentaCorriente => oCuentaCorriente.Cliente.RazonSocial.ToString().ToLower().Contains(criterio.ToLower()));
        }

        public void ModificarCuentaCorriente(Entidades.Sistema.CuentaCorriente oCuentaCorriente)
        {
            Mapping.Sistema.MappingCuentaCorriente.ModificarCuentaCorriente(oCuentaCorriente);
            cuentaCorriente.Remove(oCuentaCorriente);
            cuentaCorriente.Add(oCuentaCorriente);
        }

    }
}
