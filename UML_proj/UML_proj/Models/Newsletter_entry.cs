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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Newsletter_entry { get; set; }

        public int fk_Newsletterid_Newsletter { get; set; }

        [StringLength(255)]
        public string receit_forms { get; set; }

        public int fk_RegisteredUserid_Person { get; set; }

        public virtual Newsletter Newsletter { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Newsletter_entry_state Newsletter_entry_state { get; set; }

        public int insert(Newsletter newsletter,List<Subscription> subs_temp, List<string> receit_forms)
        {
            int news_id = newsletter.id_Newsletter;
            string msg = newsletter.newest_message;
            int entry_count = 0;
            Random random = new Random();
            for (int i = 0; i < subs_temp.Count(); i++)
            {
                Newsletter_entry entry = new Newsletter_entry();
                entry.fk_Newsletterid_Newsletter = news_id;
                entry.fk_RegisteredUserid_Person = subs_temp[i].fk_Personid_Person;         
                int randomNumber = random.Next(0, 1000000000);
                entry.id_Newsletter_entry = randomNumber;
                entry.state = 3; // is being sent
                entry.receit_forms = receit_forms[i];
                db.Newsletter_entry.Add(entry);
                entry_count += 1;
            }
            db.SaveChanges();



            return entry_count;
        }

        public List<Newsletter_entry> select(int sub_id)
        {
            var entries = db.Newsletter_entry.Where(x => x.state == 3).Where(x => x.receit_forms != "").Where(x=> x.fk_Newsletterid_Newsletter == sub_id);
            return entries.ToList();
        }

        public bool update_to_failed_to_deliver()
        {
            // update failure
            var result = db.Newsletter_entry.SingleOrDefault(b => b.id_Newsletter_entry == id_Newsletter_entry);
            if (result != null)
            {
                result.state = 1;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool update_to_delivered()
        {

            // update failure
            var result = db.Newsletter_entry.SingleOrDefault(b => b.id_Newsletter_entry == id_Newsletter_entry);
            if (result != null)
            {
                result.state = 2;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
