using ASC.Common;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.BAL.Repository.Interfaces
{
    public interface ICustomerManager
    {
        Customer GetUserId(string userId);
        CustomerVehicles GetCustomer(string input);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        string CreateCustomer(Customer customer);
        string EditCustomer(Customer customer);
        string DeleteCustomer(int id);
    }
}
