namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_User_type { get; set; }

        [Required]
        [StringLength(22)]
        public string name { get; set; }
    }
}
