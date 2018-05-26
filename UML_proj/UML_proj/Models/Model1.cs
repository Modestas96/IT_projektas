namespace UML_proj.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Admin_level> Admin_level { get; set; }
        public virtual DbSet<Newsletter_entry> Newsletter_entry { get; set; }
        public virtual DbSet<Newsletter_entry_state> Newsletter_entry_state { get; set; }
        public virtual DbSet<NullObjectOwner> NullObjectOwners { get; set; }
        public virtual DbSet<Owner_person_adapter> Owner_person_adapter { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Person_state> Person_state { get; set; }
        public virtual DbSet<PersonPicturesAdapter> PersonPicturesAdapters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_in_shop> Product_in_shop { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public virtual DbSet<Search_parameters> Search_parameters { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Unclassified_pictures> Unclassified_pictures { get; set; }
        public virtual DbSet<User_type> User_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_vardas)
                .IsUnicode(false);

            modelBuilder.Entity<Admin_level>()
                .Property(e => e.name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Admin_level>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Admin_level)
                .HasForeignKey(e => e.Teises);

            modelBuilder.Entity<Newsletter_entry_state>()
                .Property(e => e.name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Newsletter_entry_state>()
                .HasMany(e => e.Newsletter_entry)
                .WithOptional(e => e.Newsletter_entry_state)
                .HasForeignKey(e => e.state);

            modelBuilder.Entity<Person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.discord_id)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Admin)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Owner_person_adapter)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.fk_Personid_Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.RegisteredUser)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Seller)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.fk_Personid_Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Shops)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.fk_Personid_Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person_state>()
                .Property(e => e.name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person_state>()
                .HasMany(e => e.People)
                .WithOptional(e => e.Person_state)
                .HasForeignKey(e => e.state);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.barcode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_in_shop)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.fk_Productid_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<RegisteredUser>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<RegisteredUser>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<RegisteredUser>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<RegisteredUser>()
                .Property(e => e.room_number)
                .IsUnicode(false);

            modelBuilder.Entity<RegisteredUser>()
                .Property(e => e.birth_month)
                .IsUnicode(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.Newsletter_entry)
                .WithRequired(e => e.RegisteredUser)
                .HasForeignKey(e => e.fk_RegisteredUserid_Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Search_parameters>()
                .Property(e => e.Svoriai)
                .IsUnicode(false);

            modelBuilder.Entity<Search_parameters>()
                .Property(e => e.Optimizavimo_metodas)
                .IsUnicode(false);

            modelBuilder.Entity<Search_parameters>()
                .HasMany(e => e.Unclassified_pictures)
                .WithRequired(e => e.Search_parameters)
                .HasForeignKey(e => e.fk_Search_parametersid_Search_parameters)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.imones_kodas)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Pavadinimas)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Shop)
                .HasForeignKey(e => e.fk_Shopid_Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Product_in_shop)
                .WithRequired(e => e.Shop)
                .HasForeignKey(e => e.fk_Shopid_Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_type>()
                .Property(e => e.name)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
