namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Search_parameters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Search_parameters()
        {
            Unclassified_pictures = new HashSet<Unclassified_pictures>();
        }

        public double? Apsimokymo_greitis { get; set; }

        [StringLength(220)]
        public string Svoriai { get; set; }

        [StringLength(220)]
        public string Optimizavimo_metodas { get; set; }

        public bool? Yra_pagrindinis { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Search_parameters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unclassified_pictures> Unclassified_pictures { get; set; }
    }
}
