//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Search_parameters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Search_parameters()
        {
            this.Unclassified_pictures = new HashSet<Unclassified_pictures>();
        }
    
        public Nullable<double> Apsimokymo_greitis { get; set; }
        public string Svoriai { get; set; }
        public string Optimizavimo_metodas { get; set; }
        public Nullable<bool> Yra_pagrindinis { get; set; }
        public int id_Search_parameters { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unclassified_pictures> Unclassified_pictures { get; set; }
    }
}
