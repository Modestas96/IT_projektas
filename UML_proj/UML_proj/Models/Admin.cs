namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(255)]
        public string Admin_vardas { get; set; }

        public int? Teises { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Person { get; set; }

        public virtual Person Person { get; set; }

        public virtual Admin_level Admin_level { get; set; }
    }
}
