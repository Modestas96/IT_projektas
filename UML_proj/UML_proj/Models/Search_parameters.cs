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

        public double? learning_speed { get; set; }

        [StringLength(225)]
        public string optimization_method { get; set; }

        public bool? isPrimary { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Search_parameters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unclassified_pictures> Unclassified_pictures { get; set; }


        public void create()
        {
            ITProjektasDB db = new ITProjektasDB();
            if (this != null)
            {
                id_Search_parameters = new Random((int)DateTime.Now.Ticks).Next(1, 2000000000);
                db.Search_parameters.Add(this);
                db.SaveChanges();
            }
        }
    }
}
