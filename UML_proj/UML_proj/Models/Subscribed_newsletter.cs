//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscribed_newsletter
    {
        public string receit_form { get; set; }
        public int id { get; set; }
        public int fk_subscriber_id { get; set; }
        public int fk_newsletter_id { get; set; }
    
        public virtual Newsletter Newsletter { get; set; }
        public virtual Person Person { get; set; }
    }
}
