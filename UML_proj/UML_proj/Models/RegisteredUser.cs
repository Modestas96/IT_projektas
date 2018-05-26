namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegisteredUser")]
    public partial class RegisteredUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegisteredUser()
        {
            Newsletter_entry = new HashSet<Newsletter_entry>();
        }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        [StringLength(255)]
        public string region { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(255)]
        public string room_number { get; set; }

        public int? birth_year { get; set; }

        [StringLength(255)]
        public string birth_month { get; set; }

        public int? birth_day { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Newsletter_entry> Newsletter_entry { get; set; }

        public virtual Person Person { get; set; }
    }
}
