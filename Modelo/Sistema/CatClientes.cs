using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatClientes
    {
        private static CatClientes instancia;
        private List<Entidades.Sistema.Cliente> cliente; 

        public static CatClientes ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatClientes();
            return instancia;
        }

        private CatClientes()
        {
            this.cliente = new List<Entidades.Sistema.Cliente>();
            this.cliente = Mapping.Sistema.MappingClientes.RecuperarCliente(); 
        }

        public List<Entidades.Sistema.Cliente> RecuperarClientes()
        {
            return this.cliente.OrderBy(x => x.RazonSocial).ToList();
        }

        public Entidades.Sistema.Cliente BuscarCliente(int Cuit)
        {
            return this.cliente.Find(oCliente => oCliente.Cuit == Cuit); 
        }

        public bool AgregarCliente(Entidades.Sistema.Cliente oCliente)
        {
            Mapping.Sistema.MappingClientes.AgregarCliente(oCliente);
            if (!cliente.Contains(oCliente))
            {
                cliente.Add(oCliente);
                return true;
            }
            else return false;
        }

        public bool ModificarCliente(Entidades.Sistema.Cliente oCliente)
        {
            Mapping.Sistema.MappingClientes.ModificarCliente(oCliente);
            cliente.Remove(BuscarCliente(oCliente.Cuit));
            cliente.Add(oCliente);
            return true;
        }

        public List<Entidades.Sistema.Cliente> FiltrarClientes(string razonSocial)
        {
            return this.cliente.FindAll(oCliente => oCliente.RazonSocial.ToString().ToLower().Contains(razonSocial.ToLower()));
        }
    }
}
