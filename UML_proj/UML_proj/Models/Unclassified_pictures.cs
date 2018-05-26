namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Unclassified_pictures
    {
        [Column(TypeName = "date")]
        public DateTime? Creation_Date { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Unclassified_pictures { get; set; }

        public int fk_Search_parametersid_Search_parameters { get; set; }

        public virtual Search_parameters Search_parameters { get; set; }
    }
}
