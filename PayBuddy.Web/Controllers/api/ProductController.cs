using PayBuddy.Domain.AdminDomain.Interface;
using PayBuddy.Infrastructure.UnitofWork.Interface;
using PayBuddy.Domain.Models;
using System.Collections.Generic;
using System.Web.Http;
using PayBuddy.Models;
using PayBuddy.Web.Controllers.MVC;
using Rx.Infrastructure.Extentions;

namespace PayBuddy.Web.Controllers.api
{
    public class ProductController : ApiBaseController
    {
        public ProductController(IUow Uow, IAdminDomain adminDomain)
        {
            this.Uow = Uow;
            AdminDomain = adminDomain;

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = AdminDomain.GetProduct();
            List<ProductModel> productList = new List<ProductModel>();

            foreach (var item in products)
            {
                ProductModel productTemp = new ProductModel();
                productTemp.ProductId = item.ProductId;
                productTemp.ProductName = item.ProductName;
                productTemp.ProductDescription = item.ProductDescription;
                productTemp.Quantity = item.Quantity;
                var newSubCategory = Uow.Repository<SubCategory>().FirstOrDefault(c => c.SubCategoryId == item.SubCategoryId);
                productTemp.SubCategory = newSubCategory.SubCategoryName;
                var newDiscount = Uow.Repository<Discount>().FirstOrDefault(c => c.DiscountId == item.DiscountId);
                productTemp.Discount = newDiscount.Percentage;
                var newBrand = Uow.Repository<Brand>().FirstOrDefault(c => c.BrandId == item.BrandId);
                productTemp.Brand = newBrand.BrandName;
                productTemp.Cost = item.Cost;
                productTemp.Comment = item.Comment;
                var fileUpload = new FileCollection() { url = (item.ProductImage).BaseStringJpeg() };
                productTemp.productImageBaseString = fileUpload.url;
                productList.Add(productTemp);
            }

            return Ok(productList);
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            return Ok(AdminDomain.PostProduct(product));
        }

        [HttpPut]
        public IHttpActionResult Put(ProductModel product)
        {
            Product productTemp = AdminDomain.GetBy(product.ProductId);
            productTemp.ProductName = product.ProductName;
            productTemp.ProductDescription = product.ProductDescription;
            productTemp.Quantity = product.Quantity;
            productTemp.Cost = product.Cost;
            productTemp.Comment = product.Comment;
            var newSubCategoryId = Uow.Repository<SubCategory>().FirstOrDefault(c => c.SubCategoryName == product.SubCategory);
            productTemp.SubCategoryId = newSubCategoryId.SubCategoryId;
            var newDiscountId = Uow.Repository<Discount>().FirstOrDefault(c => c.Percentage == product.Discount);
            productTemp.DiscountId = newDiscountId.DiscountId;
            var newBrandId = Uow.Repository<Brand>().FirstOrDefault(c => c.BrandName == product.Brand);
            productTemp.BrandId = newBrandId.BrandId;
            productTemp.ProductImage = product.ProductImage;


            return Ok(AdminDomain.PutProduct(productTemp));
        }

        [HttpDelete]
        public IHttpActionResult Delete(Product product)
        {
            var newProduct = Uow.Repository<Product>().FirstOrDefault(c => c.ProductId == product.ProductId);
            return Ok(AdminDomain.DeleteProduct(newProduct));
        }

        [HttpGet]
        [ActionName("getProduct")]
        public IHttpActionResult Get(int id)
        {
            var product = AdminDomain.GetBy(id);
            ProductModel productTemp = new ProductModel();

            productTemp.ProductId = product.ProductId;
            productTemp.ProductName = product.ProductName;
            productTemp.ProductDescription = product.ProductDescription;
            productTemp.Quantity = product.Quantity;
            var newSubCategory = Uow.Repository<SubCategory>().FirstOrDefault(c => c.SubCategoryId == product.SubCategoryId);
            productTemp.SubCategory = newSubCategory.SubCategoryName;
            var newDiscount = Uow.Repository<Discount>().FirstOrDefault(c => c.DiscountId == product.DiscountId);
            productTemp.Discount = newDiscount.Percentage;
            var newBrand = Uow.Repository<Brand>().FirstOrDefault(c => c.BrandId == product.BrandId);
            productTemp.Brand = newBrand.BrandName;
            productTemp.Cost = product.Cost;
            productTemp.Comment = product.Comment;
            var fil = new FileCollection() { url = (product.ProductImage).BaseStringJpeg() };
            productTemp.productImageBaseString = fil.url;

            return Ok(productTemp);
        }
    }
}
