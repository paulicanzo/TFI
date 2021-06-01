using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Auditoria
{
    public class catAuditoria
    {
        private static catAuditoria instancia;
        public static catAuditoria ObtenerInstancia()
        {
            if (instancia == null) instancia = new catAuditoria();
            return instancia;
        }

        private List<Entidades.Auditoria.Auditoria> auditorias;
        private List<Entidades.Auditoria.AuditoriaPerfil> auditoriaPerfil;
        private List<Entidades.Auditoria.AuditoriaOrdenCompra> auditoriaOrdenCompra;

        private catAuditoria()
        {
            this.auditorias = new List<Entidades.Auditoria.Auditoria>();
            this.auditoriaPerfil = new List<Entidades.Auditoria.AuditoriaPerfil>();
            this.auditoriaOrdenCompra = new List<Entidades.Auditoria.AuditoriaOrdenCompra>();
        }

        public void AgregrarAuditoria(Entidades.Auditoria.Auditoria oAuditoria)
        {
            Mapping.Auditoria.MappingAuditoria.AgregarAuditoria(oAuditoria);
            auditorias.Add(oAuditoria);
        }

        public void AgregarAuditoriaPerfil(Entidades.Auditoria.AuditoriaPerfil oAuditoriaPerfil)
        {
            Mapping.Auditoria.MappingAuditoria.AgregarAuditoriaPerfil(oAuditoriaPerfil);
            auditoriaPerfil.Add(oAuditoriaPerfil);
        }

        public void AgregarAuditoriaOrdenCompra(Entidades.Auditoria.AuditoriaOrdenCompra oAuditoriaOC)
        {
            Mapping.Auditoria.MappingAuditoria.AgregarAuditoriaOrdenCompra(oAuditoriaOC);
            auditoriaOrdenCompra.Add(oAuditoriaOC);
        }

        public List<Entidades.Auditoria.Auditoria> ConsultarAuditoriaLog()
        {
            auditorias = Mapping.Auditoria.MappingAuditoria.RecuperarAuditoriaLog();
            return auditorias.OrderBy(x => x.Fecha).ToList(); 
        }

        public List<Entidades.Auditoria.AuditoriaPerfil> ConsultarAuditoriaPerfiles()
        {
            auditoriaPerfil = Mapping.Auditoria.MappingAuditoria.RecuperarAuditoriaPerfil();
            return auditoriaPerfil.OrderBy(x => x.Grupo).ToList(); 
        }

        public List<Entidades.Auditoria.AuditoriaOrdenCompra> ConsultarAuditoriaOrdenesCompra()
        {
            auditoriaOrdenCompra = Mapping.Auditoria.MappingAuditoria.RecuperarAuditoriaOrdenCompra(); 
            return auditoriaOrdenCompra.OrderBy(x => x.NroOrdenCompra).ToList(); 
        }
    }
}
