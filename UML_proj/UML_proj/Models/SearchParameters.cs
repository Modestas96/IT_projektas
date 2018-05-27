namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SearchParameters
    {
        [Display(Name = "Text query")]
        public string TextQuery { get; set; }
        [Display(Name = "Image URL :D")]
        public string ImageQuery { get; set; }

    }
}
