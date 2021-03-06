using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Classes
{
    public class DealerRepository : IDealerRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public DealerRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }
        public string CreateDealer(Dealer dealer)
        {
            try
            {
                if (dealer != null)
                {
                    var res = _DbContext.Dealers.Where(x => x.Email == dealer.Email).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Dealer entity = new Database.Dealer();
                    entity = AutoMapperConfig.DealerMapper.Map<Database.Dealer>(dealer);

                    _DbContext.Dealers.Add(entity);
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

        public string DeleteDealer(int id)
        {
            var entity = _DbContext.Dealers.Where(x => x.Id == id).FirstOrDefault();
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

        public string EditDealer(Dealer dealer)
        {
            try
            {
                var entity = _DbContext.Dealers.Where(x => x.Id == dealer.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = dealer.Name;
                    entity.PhoneNumber = dealer.PhoneNumber;
                    entity.Email = dealer.Email;
                    entity.Address = dealer.Address;
                    entity.IsActive = dealer.IsActive;
                    entity.UserId = dealer.UserId;

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

        

        public Dealer GetDealer(int id)
        {
            Dealer dealer;
            Database.Dealer entity = _DbContext.Dealers.Find(id);

            if (entity != null)
            {
                dealer = AutoMapperConfig.DealerMapper.Map<Dealer>(entity);
            }
            else
            {
                dealer = new Dealer();
            }
            return dealer;
        }

        public List<Dealer> GetDealers()
        {
            List<Dealer> dealers = new List<Dealer>();
            IEnumerable<Database.Dealer> entities = _DbContext.Dealers.ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Dealer dealer = new Dealer();
                    dealer = AutoMapperConfig.DealerMapper.Map<Dealer>(item);
                    dealers.Add(dealer);
                }
            }
            return dealers;
        }
           public IEnumerable<Customer> GetCustomer(string userId)
            {
                List<Database.Customer> list = _DbContext.Customers.Where(x => x.Dealer.UserId == userId).ToList();
                List<Customer> customers = new List<Customer>();
                /*var entities = _DbContext.Customers.Include("Dealer").ToList();*/
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        Customer customer = new Customer();
                        customer = AutoMapperConfig.CustomerMapper.Map<Customer>(item);
                        customers.Add(customer);
                    }
                }
                return customers;
            }
        }
    }

