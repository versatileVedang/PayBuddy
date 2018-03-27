namespace PayBuddy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vCartProduct")]
    public partial class vCartProduct
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ProductName { get; set; }

        public byte[] ProductImageBaseString { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Cost { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal SubTotal { get; set; }

        [Key]
        [Column(Order = 7)]
        public string ProductDescription { get; set; }
    }
}
