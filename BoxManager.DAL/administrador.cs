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
    
    public partial class administrador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public int idTenant { get; set; }
    
        public virtual tenant tenant { get; set; }
    }
}
