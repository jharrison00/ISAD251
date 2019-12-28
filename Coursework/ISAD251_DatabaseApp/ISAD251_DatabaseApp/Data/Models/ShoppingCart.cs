using ISAD251_DatabaseApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Models
{
    public class ShoppingCart
    {
        private readonly ISAD251_JHarrisonContext _DbContext;

        private ShoppingCart(ISAD251_JHarrisonContext DbContext)
        {
            _DbContext = DbContext;
        }

        public string ShoppingCartID { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        //Get Cart
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<ISAD251_JHarrisonContext>();
            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", cartID);

            return new ShoppingCart(context) { ShoppingCartID = cartID };
        }

        //Add to Cart
        public void AddToCart(CafeProducts product, int amount)
        {
            //Gets product from cart
            var shoppingCartItem = 
                _DbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Products.ProductId == product.ProductId && s.ShoppingCartID == ShoppingCartID);

            //If no items are in cart
            if (shoppingCartItem == null) 
            {
                //Create new object of cart
                shoppingCartItem = new ShoppingCartItem     
                {
                    ShoppingCartID = ShoppingCartID,
                    Products = product,
                    Amount = 1
                };
                //Add to database 
                _DbContext.ShoppingCartItems.Add(shoppingCartItem); 
            }
            else
            {
                //Increment item amount of existing cart
                shoppingCartItem.Amount++;
            }
            _DbContext.SaveChanges();
        }

        //Remove from cart
        public int RemoveFromCart(CafeProducts product)
        {
            //Gets product from cart
            var shoppingCartItem =
                _DbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Products.ProductId == product.ProductId && s.ShoppingCartID == ShoppingCartID);

            //Define local amount of items in cart
            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    //Reduce items in cart by 1
                    shoppingCartItem.Amount--;
                    //Update variable
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    //Remove shoppingCart object
                    _DbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _DbContext.SaveChanges();

            return localAmount;
        }

        //View cart
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                _DbContext.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartID)
                .Include(s => s.Products).ToList());
        }

        //Empty Cart
        public void ClearCart()
        {
            //Gets all
            var cartItems = _DbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartID == ShoppingCartID);
            //Removes all
            _DbContext.ShoppingCartItems.RemoveRange(cartItems);
            //Saves
            _DbContext.SaveChanges();
        }

        //Get cart total price
        public decimal? GetShoppingCartTotal()
        {
            decimal? total;
            if (_DbContext.ShoppingCartItems.Count() != 0)
            {
                //Gets all products and multiplies by each quantity
                total = _DbContext.ShoppingCartItems.Where(
                    c => c.ShoppingCartID == ShoppingCartID)
                    .Select(c => c.Products.ProductPrice * c.Amount).Sum();
            }
            else
            {
                total = 0;
            }
            //Return decimal value
            return total;
        }

    }
}
