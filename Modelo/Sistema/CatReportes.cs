using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Sistema
{
    public class CatReportes
    {
        private static CatReportes instancia;
        private List<Entidades.Sistema.CompraMensual> compraMensual;
        private List<Entidades.Sistema.ProductosMasVendidos> productosMasVendidos;
        private List<Entidades.Sistema.MayoresCompradores> mayoresCompradores;
        private List<Entidades.Sistema.MayoresDeudores> mayoresDeudores; 

        public static CatReportes ObtenerInstancia()
        {
            if (instancia == null) instancia = new CatReportes();
            return instancia;
        }

        private CatReportes()
        {
            this.compraMensual = new List<Entidades.Sistema.CompraMensual>(); 
        }

        public List<Entidades.Sistema.CompraMensual> ConsultarCompraMensual(DateTime desde, DateTime hasta)
        {
            this.compraMensual = Mapping.Sistema.MappingCompras.RecuperarComprasMensual(desde, hasta);
            return this.compraMensual.OrderBy(x => x.DenominacionLegal).ToList();
        }

        public List<Entidades.Sistema.ProductosMasVendidos> RecuperarProductos(Entidades.Sistema.CategoriaProducto oCategoria)
        {
            this.productosMasVendidos = Mapping.Sistema.MappingProductosMasVendidos.RecuperarProductosMasVendidos(oCategoria.Nombre);
            return this.productosMasVendidos.OrderBy(x => x.Cantidad).ToList();
        }

        public List<Entidades.Sistema.MayoresCompradores> RecuperarMayoresCompradores()
        {
            this.mayoresCompradores = Mapping.Sistema.MappingMayoresCompradores.RecuperarMayoresCompradores();
            return this.mayoresCompradores.OrderBy(x => x.RazonSocial).ToList();
        }

        public List<Entidades.Sistema.MayoresDeudores> RecuperarMayoresDeudores()
        {
            this.mayoresDeudores = Mapping.Sistema.MappingMayoresDeudores.RecuperarMayoresDeudores();
            return this.mayoresDeudores.OrderBy(x => x.Cliente).ToList(); 
        }
    }
}
