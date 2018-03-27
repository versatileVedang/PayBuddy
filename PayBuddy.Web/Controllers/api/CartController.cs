using PayBuddy.Domain.AdminDomain.Interface;
using PayBuddy.Infrastructure.UnitofWork.Interface;
using System.Web.Http;
using PayBuddy.Domain.AdminDomain;
using PayBuddy.Domain.CartDomain.Interface;
using PayBuddy.Domain.Models;
using System.Collections.Generic;
using PayBuddy.Models;
using System.Linq;
using PayBuddy.Web.Controllers.MVC;
using Rx.Infrastructure.Extentions;
using System;

namespace PayBuddy.Web.Controllers.api
{
    public class CartController : ApiBaseController
    {
        public CartController(ICartDomain CartDomain, IUow Uow)
        {
            this.Uow = Uow;
            this.CartDomain = CartDomain;

        }
        [HttpGet]
        [ActionName("getItem")]
        public IHttpActionResult Get(int id)
        {
            //var items = CartDomain.GetItem().Where(x=>x.UserId == id).ToList(); 
            var cartList = new List<CartModel>();
            var product = Uow.Repository<vCartProduct>().All().Where(c => c.UserId == id).ToList();
            //try
            //{
            foreach (var item in product)
            {
                var cart = new CartModel();
                cart.CartId = item.CartId;
                cart.ProductId = item.ProductId;
                cart.ProductName = item.ProductName;
                cart.ProductDescription = item.ProductDescription;
                var fil = new FileCollection() { url = (item.ProductImageBaseString).BaseStringJpeg() };
                cart.ProductImageBaseString = fil.url;
                cart.Cost = item.Cost;
                cart.Quantity = item.Quantity;
                cart.SubTotal = item.SubTotal;
                cartList.Add(cart);
            }
            return Ok(product);
            //}
            //catch (Exception ex)
            //{
            //    return Ok(ex.Message);
            //}
        }

      [HttpPost]
      public IHttpActionResult Post(Cart item)
        {

            return Ok(CartDomain.Post(item));
        }

       [HttpDelete]
       public IHttpActionResult Delete(vCartProduct item)
        {
            var delCart = Uow.Repository<Cart>().FirstOrDefault(c => c.CartId == item.CartId);
            return Ok(CartDomain.Delete(delCart));
        }

    }
}
