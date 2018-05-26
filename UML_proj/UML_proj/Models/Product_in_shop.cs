namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_in_shop
    {
        public double? price { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Product_in_shop { get; set; }

        public int fk_Shopid_Shop { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fk_Productid_Product { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
