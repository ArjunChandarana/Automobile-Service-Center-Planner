using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetServices();
        Service GetService(int id);
        string CreateService(Service service);
        string EditService(Service service);
        string DeleteService(int id);
    }
}
