namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Newsletter_entry
    {
        public int? state { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Newsletter_entry { get; set; }

        public int fk_Newsletterid_Newsletter { get; set; }

        public int fk_RegisteredUserid_Person { get; set; }

        public virtual Newsletter Newsletter { get; set; }

        [StringLength(255)]
        public string receit_forms { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Newsletter_entry_state Newsletter_entry_state { get; set; }
    }
}
