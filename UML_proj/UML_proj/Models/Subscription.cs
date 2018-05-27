namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Subscription")]
    public partial class Subscription
    {
        ITProjektasDB db = new ITProjektasDB();
        public bool? receit_discord { get; set; }

        public bool? receit_email { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Subscription { get; set; }

        public int fk_Personid_Person { get; set; }

        public int fk_Newsletterid_Newsletter { get; set; }

        public virtual Newsletter Newsletter { get; set; }

        public virtual Person Person { get; set; }

        public List<Subscription> select_personal_subs()
        {
            var subscriptions = db.Subscriptions.Where(x => x.fk_Personid_Person==fk_Personid_Person).Include(s => s.Newsletter).Include(s => s.Person);
            return subscriptions.ToList();
        }

        public List<Subscription> select_subscribers()
        {
            var subscriptions = db.Subscriptions.Where(x => x.fk_Newsletterid_Newsletter==fk_Newsletterid_Newsletter).Include(s => s.Newsletter).Include(s => s.Person);
            return subscriptions.ToList();
        }
    }
}
