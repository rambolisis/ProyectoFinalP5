//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.wodClientes = new HashSet<wodCliente>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> nivel { get; set; }
        public int idTenant { get; set; }
    
        public virtual tenant tenant { get; set; }
        public virtual nivel nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wodCliente> wodClientes { get; set; }
    }
}