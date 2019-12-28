using ISAD251_DatabaseApp.Data.Interfaces;
using ISAD251_DatabaseApp.Data.Models;
using ISAD251_DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISAD251_JHarrisonContext _DbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ISAD251_JHarrisonContext DbContext, ShoppingCart shoppingCart)
        {
            _DbContext = DbContext;
            _shoppingCart = shoppingCart;
        }

        [HttpPost]
        public void CreateOrder(CafeOrders order)
        {
            order.OrderDate = DateTime.Now;
            _DbContext.CafeOrders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new CafeOrderDetails()
                {
                    OrderId = order.OrderId,
                    ProductId = item.Products.ProductId,
                    Quantity = item.Amount
                };
                _DbContext.CafeOrderDetails.Add(orderDetail);
            }
            _DbContext.SaveChanges();
        }
    }
}



