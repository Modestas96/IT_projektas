using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SNDTO
    {
        public string receit_form { get; set; }
        public int id { get; set; }
        public int fk_subscriber_id { get; set; }
        public int fk_newsletter_id { get; set; }

    }
}
