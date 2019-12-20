﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoxManager.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BoxManagerEntities : DbContext
    {
        public BoxManagerEntities()
            : base("name=BoxManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administrador> administradors { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<nivel> nivels { get; set; }
        public virtual DbSet<tenant> tenants { get; set; }
        public virtual DbSet<tipoConteo> tipoConteos { get; set; }
        public virtual DbSet<wod> wods { get; set; }
        public virtual DbSet<wodCliente> wodClientes { get; set; }
    
        public virtual ObjectResult<wods1_Result> wods1(Nullable<int> idTenant)
        {
            var idTenantParameter = idTenant.HasValue ?
                new ObjectParameter("idTenant", idTenant) :
                new ObjectParameter("idTenant", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<wods1_Result>("wods1", idTenantParameter);
        }
    
        public virtual ObjectResult<wodsCliente_Result> wodsCliente(Nullable<int> idTenant)
        {
            var idTenantParameter = idTenant.HasValue ?
                new ObjectParameter("idTenant", idTenant) :
                new ObjectParameter("idTenant", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<wodsCliente_Result>("wodsCliente", idTenantParameter);
        }
    }
}
