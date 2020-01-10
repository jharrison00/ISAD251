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
        public void CreateOrder(CafeOrders order, int customerId)
        {
            //Gets last order ID and adds by 1
            CafeOrders lastOrder = _DbContext.CafeOrders.LastOrDefault(o => o.OrderId == o.OrderId);

            if (lastOrder != null)
            {
                order.OrderId = lastOrder.OrderId + 1;
            }
            else
            {
                order.OrderId = 1;
            }

            //Gets order Date
            order.OrderDate = DateTime.Now;

            //Gets order customer ID
            order.CustId = customerId;

            order.OrderTotalPrice = _shoppingCart.GetShoppingCartTotal();
         
            _DbContext.CafeOrders.Add(order);
            _DbContext.SaveChanges();

            //Adds each product to order details table
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new CafeOrderDetails()
                {
                    OrderId = order.OrderId,
                    ProductId = item.Products.ProductId,
                    Quantity = item.Amount,
                    ProductOrderPrice = (item.Products.ProductPrice)*(item.Amount)
                };
                _DbContext.CafeOrderDetails.Add(orderDetail);
            }
            _DbContext.SaveChanges();
        }
    }
}



