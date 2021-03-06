namespace UML_proj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Product")]
    public partial class Product
    {
        ITProjektasDB db = new ITProjektasDB();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Product_in_shop = new HashSet<Product_in_shop>();
        }

        public List<Product> select_personal_products(int id)
        {
            var shops = db.Shops.Where(x => x.fk_Personid_Person == id);
            List<Product> products = new List<Product>();
            foreach (Shop shop in shops)
            {
                var products1 = db.Products.Where(x => x.fk_Shopid_Shop == shop.id_Shop);
                products.AddRange(products1);
            }
            return products;
        }

        [StringLength(255)]
        public string name { get; set; }

        public double? price { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string barcode { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Product { get; set; }

        public int fk_Shopid_Shop { get; set; }

        public virtual Shop Shop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_in_shop> Product_in_shop { get; set; }
    }
}
