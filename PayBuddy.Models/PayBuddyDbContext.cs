namespace PayBuddy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PayBuddyDbContext : DbContext
    {
        public PayBuddyDbContext()
            : base("name=PayBuddyDbContext")
        {
        }

        public virtual DbSet<ApplicationObject> ApplicationObjects { get; set; }
        public virtual DbSet<ApplicationObjectType> ApplicationObjectTypes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<vCartProduct> vCartProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationObject>()
                .Property(e => e.ApplicationObjectName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationObjectType>()
                .Property(e => e.ApplicationObjectTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationObjectType>()
                .HasMany(e => e.ApplicationObjects)
                .WithRequired(e => e.ApplicationObjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.SubTotal)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Percentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Discount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Cost)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.SubCategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vCartProduct>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<vCartProduct>()
                .Property(e => e.Cost)
                .HasPrecision(8, 2);

            modelBuilder.Entity<vCartProduct>()
                .Property(e => e.SubTotal)
                .HasPrecision(9, 2);

            modelBuilder.Entity<vCartProduct>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);
        }
    }
}
