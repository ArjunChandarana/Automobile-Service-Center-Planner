using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.BAL.Repository.Classes
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public string CreateService(Service service)
        {
            return _serviceRepository.CreateService(service);
        }

        public string DeleteService(int id)
        {
            return _serviceRepository.DeleteService(id);
        }

        public string EditService(Service service)
        {
            return _serviceRepository.EditService(service);
        }

        public Service GetService(int id)
        {
            return _serviceRepository.GetService(id);
        }

        public IEnumerable<Service> GetServices()
        {
            return _serviceRepository.GetServices();
        }
    }
}
