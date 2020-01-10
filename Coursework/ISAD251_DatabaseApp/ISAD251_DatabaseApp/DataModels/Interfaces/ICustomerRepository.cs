using ISAD251_DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Interfaces
{
    public interface ICustomerRepository
    {
        CafeCustomers CreateCustomer(CafeCustomers customer);
    }
}
