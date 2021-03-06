using MultiAuthDemo.Models;
using MultiAuthDemo.Validation.Data;
using MultiAuthDemo.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MultiAuthDemo.Validation.Classes
{
    public class CustomerMapRepository : ICustomerMapRepository
    {
        private readonly SampleDBEntities _dbContext = new SampleDBEntities();
        public bool MapCustomer(RegisterViewModel model, string Id)
        {
            var customer = _dbContext.Customers.Where(x => x.Email == model.Email).SingleOrDefault();
            if (customer != null)
            {
                if (customer.UserId == null)
                {
                    customer.UserId = Id;
                }
                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                Validation.Data.Customer customer1 = new Validation.Data.Customer();
                customer1.Email = model.Email;
                customer1.UserId = Id;
                _dbContext.Customers.Add(customer1);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}