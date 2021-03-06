using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Common;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.BAL.Repository.Classes
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }

        public string CreateCustomer(Customer customer)
        {
            return _customerRepository.CreateCustomer(customer);
        }

        public string DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public string EditCustomer(Customer customer)
        {
            return _customerRepository.EditCustomer(customer);
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        public CustomerVehicles GetCustomer(string input)
        {
            return _customerRepository.GetCustomer(input);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public Customer GetUserId(string userId)
        {
            return _customerRepository.GetUserId(userId);
        }
    }
}
