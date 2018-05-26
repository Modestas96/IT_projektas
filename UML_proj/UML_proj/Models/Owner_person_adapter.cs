namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Owner_person_adapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Owner_person_adapter { get; set; }

        public int fk_Personid_Person { get; set; }

        public virtual Person Person { get; set; }
    }
}
