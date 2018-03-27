using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBuddy.Domain.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string productImageBaseString { get; set; }

        public byte[] ProductImage { get; set; }

        public string ProductDescription { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public string Comment { get; set; }

        public decimal Discount { get; set; }

        public string SubCategory { get; set; }

        public string Brand { get; set; }

    }
}
