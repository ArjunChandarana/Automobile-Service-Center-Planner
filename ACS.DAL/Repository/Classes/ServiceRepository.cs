using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Classes
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public ServiceRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        public string CreateService(Service service)
        {
            try
            {
                if (service != null)
                {
                    var res = _DbContext.Services.Where(x => x.Name == service.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Service entity = new Database.Service();
                    entity = AutoMapperConfig.ServiceMapper.Map<Database.Service>(service);

                    _DbContext.Services.Add(entity);
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

        public string DeleteService(int id)
        {
            var entity = _DbContext.Services.Where(x => x.Id == id).FirstOrDefault();
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

        public string EditService(Service service)
        {
            try
            {
                var entity = _DbContext.Services.Where(x => x.Id == service.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = service.Name;
                    entity.Type = service.Type;
                    entity.Duration = service.Duration;
                    entity.Amount = service.Amount;
                    entity.IsActive = service.IsActive;

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

        public Service GetService(int id)
        {
            Service service;
            Database.Service entity = _DbContext.Services.Find(id);

            if (entity != null)
            {
                service = AutoMapperConfig.ServiceMapper.Map<Service>(entity);
            }
            else
            {
                service = new Service();
            }
            return service;
        }

        public IEnumerable<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            IEnumerable<Database.Service> entities = _DbContext.Services.ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Service service = new Service();
                    service = AutoMapperConfig.ServiceMapper.Map<Service>(item);
                    services.Add(service);
                }
            }
            return services;
        }
    }
}
