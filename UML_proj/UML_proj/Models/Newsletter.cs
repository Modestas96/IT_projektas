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
    
    public partial class Newsletter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Newsletter()
        {
            this.Newsletter_entry = new HashSet<Newsletter_entry>();
            this.Newsletter_entry1 = new HashSet<Newsletter_entry>();
            this.Subscribed_newsletter = new HashSet<Subscribed_newsletter>();
        }
    
        public string content { get; set; }
        public int pk_id { get; set; }
        public int fk_person_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Newsletter_entry> Newsletter_entry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Newsletter_entry> Newsletter_entry1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribed_newsletter> Subscribed_newsletter { get; set; }
        public virtual Person Person { get; set; }
    }
}
