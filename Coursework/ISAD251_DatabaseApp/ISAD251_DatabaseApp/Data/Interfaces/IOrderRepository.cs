using ISAD251_DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(CafeOrders order, int id);
    }
}
