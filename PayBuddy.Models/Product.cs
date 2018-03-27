namespace PayBuddy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public byte[] ProductImage { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public string Comment { get; set; }

        public int DiscountId { get; set; }

        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
