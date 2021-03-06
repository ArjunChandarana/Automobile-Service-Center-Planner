using ASC.BAL.Helper;
using ASC.BAL.Repository.Classes;
using ASC.BAL.Repository.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ASC.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IBrandManager, BrandManager>();
            container.RegisterType<IModelManager, ModelManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IDealerManager, DealerManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}