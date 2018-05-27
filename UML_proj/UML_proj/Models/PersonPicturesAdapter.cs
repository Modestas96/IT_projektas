namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonPicturesAdapter")]
    public partial class PersonPicturesAdapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_PersonPicturesAdapter { get; set; }
    }
}
