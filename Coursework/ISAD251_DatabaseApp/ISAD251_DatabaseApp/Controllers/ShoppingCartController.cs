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

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
        }

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

        public RedirectToActionResult AddToShoppingCart(int productID)
        {
            CafeProducts selectedProduct = new CafeProducts();
            selectedProduct = _productRepository.GetProductById(productID);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");   
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productID)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productID);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}