namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Newsletter")]
    public partial class Newsletter
    {
        ITProjektasDB db = new ITProjektasDB();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Newsletter()
        {
            Newsletter_entry = new HashSet<Newsletter_entry>();
            Subscriptions = new HashSet<Subscription>();
        }


        [StringLength(255)]
        public string newest_message { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Newsletter { get; set; }

        public void insert()
        {
            db.Newsletters.Add(this);
            db.SaveChanges();       
        }

        public int update()
        {
            var result = db.Newsletters.SingleOrDefault(b => b.fk_Personid_Person == fk_Personid_Person);
            if (result != null)
            {
                result.newest_message = newest_message;
                db.SaveChanges();
                return result.id_Newsletter;
            }
            else
            {
                return -1;
            }
        }

        public int fk_Personid_Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Newsletter_entry> Newsletter_entry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual Person Person { get; set; }
    }
}
