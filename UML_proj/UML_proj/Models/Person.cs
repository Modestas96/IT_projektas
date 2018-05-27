namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Newsletters = new HashSet<Newsletter>();
            Owner_person_adapter = new HashSet<Owner_person_adapter>();
            Subscriptions = new HashSet<Subscription>();
            Shops = new HashSet<Shop>();
        }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string discord_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? last_login_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? registration_date { get; set; }

        [StringLength(255)]
        public string user_name { get; set; }

        public int? state { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Person { get; set; }

        public virtual Admin Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Newsletter> Newsletters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owner_person_adapter> Owner_person_adapter { get; set; }

        public virtual Person_state Person_state { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Seller Seller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
