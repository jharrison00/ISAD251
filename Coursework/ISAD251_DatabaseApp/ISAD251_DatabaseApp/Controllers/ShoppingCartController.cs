using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISAD251_DatabaseApp.Data.Models;
using ISAD251_DatabaseApp.Models;
using ISAD251_DatabaseApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISAD251_DatabaseApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly ISAD251_JHarrisonContext _context;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart, ISAD251_JHarrisonContext context)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
            _context = context;
        }

        //Returns data to view model
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var cartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = Convert.ToDecimal(_shoppingCart.GetShoppingCartTotal())
            };
            return View(cartViewModel);
        }

        //Adds specified item to cart
        public RedirectToActionResult AddToShoppingCart(int productID)
        {
            CafeProducts selectedProduct = new CafeProducts();
            selectedProduct = _productRepository.GetProductById(productID);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
                _shoppingCart.GetShoppingCartItems();
            }        
            return RedirectToAction("Menu", "CafeProducts");
        }

        //Adds to quantity (Specfiic for quantity bar)
        public RedirectToActionResult AddToQuantity(int productID)
        {
            CafeProducts selectedProduct = new CafeProducts();
            selectedProduct = _productRepository.GetProductById(productID);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }

        //Removes specified item from cart
        public RedirectToActionResult RemoveFromShoppingCart(int productID)
        {
            var selectedProduct = _productRepository.GetProductById(productID);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            //If shopping cart is empty return to menu
            if (_shoppingCart.GetShoppingCartItems().Count() == 0)
            {
                _shoppingCart.ClearCart();
                return RedirectToAction("Menu", "CafeProducts");
            }     
            return RedirectToAction("Index");
        }

        //Clears all item in cart
        public RedirectToActionResult EmptyCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Menu", "CafeProducts");
        }
    }
}