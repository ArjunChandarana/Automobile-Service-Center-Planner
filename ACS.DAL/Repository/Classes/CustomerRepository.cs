using ACS.DAL.Repository.Interfaces;
using ASC.Common;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public CustomerRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        public string CreateCustomer(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var res = _DbContext.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Customer entity = new Database.Customer();
                    entity = AutoMapperConfig.CustomerMapper.Map<Database.Customer>(customer);

                    _DbContext.Customers.Add(entity);
                    _DbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteCustomer(int id)
        {
            var entity = _DbContext.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                if (entity.IsActive == true)
                {
                    entity.IsActive = false;
                }
                else
                {
                    entity.IsActive = true;
                }
                _DbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        public string EditCustomer(Customer customer)
        {
            try
            {
                var entity = _DbContext.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = customer.Name;
                    entity.PhoneNumber = customer.PhoneNumber;
                    entity.Email = customer.Email;
                    entity.Address = customer.Address;
                    entity.DealerId = customer.DealerId;
                    entity.IsActive = customer.IsActive;
                    entity.UserId = entity.UserId;

                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Customer GetCustomer(int id)
        {
            Customer customer;
            Database.Customer entity = _DbContext.Customers.Find(id);

            if (entity != null)
            {
                customer = AutoMapperConfig.CustomerMapper.Map<Customer>(entity);
            }
            else
            {
                customer = new Customer();
            }
            return customer;
        }

        public CustomerVehicles GetCustomer(string input)
        {
            CustomerVehicles customerVehicles;
            Customer customer;
            List<Vehicle> vehicles = new List<Vehicle>();

            Database.Customer entity = _DbContext.Customers.Where(x => x.Email.Equals(input) || x.PhoneNumber.Equals(input)).FirstOrDefault();
            
            if (entity != null)
            {
                customer = AutoMapperConfig.CustomerMapper.Map<Customer>(entity);

                var entities = _DbContext.Vehicles.Where(x => x.CustomerId == customer.Id).ToList();
                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(item);
                        vehicles.Add(vehicle);
                    }
                }
                customerVehicles = new CustomerVehicles
                {
                    Customer = customer,
                    Vehicles = vehicles
                };
            }
            else
            {
                customerVehicles = null;
            }
            return customerVehicles;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            var entities = _DbContext.Customers.Include("Dealer").ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Customer customer = new Customer();
                    customer = AutoMapperConfig.CustomerMapper.Map<Customer>(item);
                    customers.Add(customer);
                }
            }
            return customers;
        }

        public Customer GetUserId(string userId)
        {
            Database.Customer entity = _DbContext.Customers.Include("Dealer").Where(x => x.UserId == userId).FirstOrDefault();
            Customer customer;
            
            if (entity != null)
            {
                customer = AutoMapperConfig.CustomerMapper.Map<Customer>(entity);
            }
            else
            {
                customer = new Customer();
            }
            return customer;
        }
    }
}
