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
    public class VehicleManager : IVehicleManager
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public string CreateVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.CreateVehicle(vehicle);
        }

        public string DeleteVehicle(int id)
        {
            return _vehicleRepository.DeleteVehicle(id);
        }

        public string EditVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.EditVehicle(vehicle);
        }

        public Vehicle GetVehicle(int id)
        {
            return _vehicleRepository.GetVehicle(id);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetVehicles();
        }

        public IEnumerable<Vehicle> GetVehiclesOfUser(string userId)
        {
            return _vehicleRepository.GetVehiclesOfUser(userId);
        }
    }
}
