using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatProveedores
    {
        private static CatProveedores instancia;
        private List<Entidades.Sistema.Proveedor> proveedor; 

        public static CatProveedores ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatProveedores();
            return instancia; 
        }

        private CatProveedores()
        {
            this.proveedor = new List<Entidades.Sistema.Proveedor>();
            this.proveedor = Mapping.Sistema.MappingProveedores.ObtenerInstancia().Recuperar(); 
        }

        public List<Entidades.Sistema.Proveedor> RecuperarProveedores()
        {
            return this.proveedor.OrderBy(x => x.DenominacionLegal).ToList();
        }

        public Entidades.Sistema.Proveedor BuscarProveedor(int oCuit)
        {
            return this.proveedor.Find(oProveedor => oProveedor.Cuit == oCuit); 
        }

        public bool AgregarProveedor(Entidades.Sistema.Proveedor oProveedor)
        {
            Mapping.Sistema.MappingProveedores.AgregarProveedor(oProveedor);
            if (!proveedor.Contains(oProveedor))
            {
                proveedor.Add(oProveedor);
                return true;
            }
            else return false; 
        }

        public bool ModificarProveedor (Entidades.Sistema.Proveedor oProveedor)
        {
            Mapping.Sistema.MappingProveedores.ModificarProveedor(oProveedor);
            proveedor.Remove(BuscarProveedor(oProveedor.Cuit));
            proveedor.Add(oProveedor);
            return true;
        }

        public List<Entidades.Sistema.Proveedor> Filtrar(string criterio)
        {
            return this.proveedor.FindAll(oProveedor => oProveedor.DenominacionLegal.ToString().ToLower().Contains(criterio.ToLower()));
        }

    }
}
