using ISAD251_DatabaseApp.Data.Interfaces;
using ISAD251_DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISAD251_JHarrisonContext _DbContext;

        public CustomerRepository(ISAD251_JHarrisonContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpPost]
        public CafeCustomers CreateCustomer(CafeCustomers customer)
        {
            //Gets last customers ID and adds by 1
            CafeCustomers lastCustomer = _DbContext.CafeCustomers.LastOrDefault(c => c.CustId == c.CustId);

            if (lastCustomer != null)
            {
                customer.CustId = lastCustomer.CustId + 1;
            }
            else
            {
                customer.CustId = 1;
            }

            _DbContext.CafeCustomers.Add(customer);
            _DbContext.SaveChanges();
            return customer;
        }
    }
}
