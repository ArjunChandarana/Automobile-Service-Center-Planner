using ACS.DAL.Repository.Classes;
using ACS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;

namespace ASC.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IBrandRepository, BrandRepository>();
            Container.RegisterType<IModelRepository, ModelRepository>();
            Container.RegisterType<IServiceRepository, ServiceRepository>();
            Container.RegisterType<IDealerRepository, DealerRepository>();
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
        }
    }
}
