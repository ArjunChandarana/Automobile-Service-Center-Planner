using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Classes
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public VehicleRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }
        public string CreateVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    var res = _DbContext.Vehicles.Where(x => x.NumberPlate == vehicle.NumberPlate).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Vehicle entity = new Database.Vehicle();
                    entity = AutoMapperConfig.VehicleMapper.Map<Database.Vehicle>(vehicle);

                    _DbContext.Vehicles.Add(entity);
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


        public string DeleteVehicle(int id)
        {
            var res = _DbContext.Vehicles.Find(id);
            if (res != null )
            {
                _DbContext.Vehicles.Remove(res);
                _DbContext.SaveChanges();
                return "deleted";
            }
            return "not";
        }

        public string EditVehicle(Vehicle vehicle)
        {
            try
            {
                var entity = _DbContext.Vehicles.Where(x => x.Id == vehicle.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = vehicle.Name;
                    entity.NumberPlate = vehicle.NumberPlate;
                    entity.ChassisNumber = vehicle.ChassisNumber;
                    entity.RegistrationDate = vehicle.RegistrationDate;
                    entity.LastServiceDate = vehicle.LastServiceDate;
                    entity.FuelType = vehicle.FuelType;
                    entity.CustomerId = vehicle.CustomerId;
                    entity.ModelId = vehicle.ModelId;

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

        public Vehicle GetVehicle(int id)
        {
            Vehicle vehicle;
            Database.Vehicle entity = _DbContext.Vehicles.Find(id);

            if (entity != null)
            {
                vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(entity);
            }
            else
            {
                vehicle = new Vehicle();
            }
            return vehicle;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _DbContext.Vehicles.Include("Customer").Include("Model").ToList();
                       
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehiclesOfUser(string userId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _DbContext.Vehicles.Include("Model").Where(x => x.Customer.UserId == userId).ToList();
            
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }
    }
}
