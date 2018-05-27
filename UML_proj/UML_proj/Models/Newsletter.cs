namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Newsletter")]
    public partial class Newsletter
    {
        IT_PROJEKTASEntities db = new IT_PROJEKTASEntities();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Newsletter()
        {
            Newsletter_entry = new HashSet<Newsletter_entry>();
            Subscriptions = new HashSet<Subscription>();
        }

<<<<<<< HEAD
        [StringLength(255)]
        public string newest_message { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Newsletter { get; set; }
=======
        public void insert()
        {
            db.Newsletters.Add(this);
            db.SaveChanges();       
        }

        public bool update_newest_entry()
        {
            var result = db.Newsletters.SingleOrDefault(b => b.fk_person_id == fk_person_id);
            if (result != null)
            {
                result.content = content;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public string toString1()
        {
            return content + " " + fk_person_id.ToString();
        }
>>>>>>> master

        public int fk_Personid_Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Newsletter_entry> Newsletter_entry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual Person Person { get; set; }
    }
}
