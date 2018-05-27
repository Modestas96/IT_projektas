namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscription")]
    public partial class Subscription
    {
        public bool? receit_discord { get; set; }

        public bool? receit_email { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Subscription { get; set; }

        public int fk_Personid_Person { get; set; }

        public int fk_Newsletterid_Newsletter { get; set; }

        public virtual Newsletter Newsletter { get; set; }

        public virtual Person Person { get; set; }
    }
}
