//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWingsAir.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aeropuertos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aeropuertos()
        {
            this.Vuelos = new HashSet<Vuelos>();
            this.Vuelos1 = new HashSet<Vuelos>();
        }
    
        public int IdAeropuerto { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public byte[] Pais { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelos> Vuelos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelos> Vuelos1 { get; set; }
    }
}
