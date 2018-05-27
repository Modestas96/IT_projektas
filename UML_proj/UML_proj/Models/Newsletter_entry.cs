namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    public partial class Newsletter_entry
    {
        public int? state { get; set; }
        ITProjektasDB db = new ITProjektasDB();
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Newsletter_entry { get; set; }

        public int fk_Newsletterid_Newsletter { get; set; }

        public int fk_RegisteredUserid_Person { get; set; }

        public virtual Newsletter Newsletter { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Newsletter_entry_state Newsletter_entry_state { get; set; }

        public int insert(Newsletter newsletter,List<Subscription> subs_temp)
        {
            int news_id = newsletter.id_Newsletter;
            string msg = newsletter.newest_message;
            int entry_count = 0;
            for (int i = 0; i < subs_temp.Count(); i++)
            {
                Newsletter_entry entry = new Newsletter_entry();
                entry.fk_Newsletterid_Newsletter = news_id;
                entry.fk_RegisteredUserid_Person = subs_temp[i].fk_Personid_Person;
                //entry.state = 3; // is being sent
                db.Newsletter_entry.Add(entry);
                entry_count += 1;
            }
            db.SaveChanges();



            return entry_count;
        }
    }
}
