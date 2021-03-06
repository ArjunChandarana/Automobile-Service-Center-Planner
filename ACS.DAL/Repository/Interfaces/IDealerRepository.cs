using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IDealerRepository
    {
        List<Dealer> GetDealers();
        Dealer GetDealer(int id);
        string CreateDealer(Dealer dealer);
        string EditDealer(Dealer dealer);
        string DeleteDealer(int id);

        IEnumerable<Customer> GetCustomer(string userId);
    }
}
