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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Product_in_shop = new HashSet<Product_in_shop>();
        }
    
        public string Pavadinimas { get; set; }
        public Nullable<double> Kaina { get; set; }
        public string Aprašymas { get; set; }
        public string Busena { get; set; }
        public string BarKodas { get; set; }
        public string Nuotrauka { get; set; }
        public int id_Product { get; set; }
        public int fk_Shopid_Shop { get; set; }
    
        public virtual Shop Shop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_in_shop> Product_in_shop { get; set; }
    }
}
