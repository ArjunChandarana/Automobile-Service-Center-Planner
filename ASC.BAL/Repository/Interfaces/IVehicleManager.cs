using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IVehicleManager
    {
        IEnumerable<Vehicle> GetVehicles();
        IEnumerable<Vehicle> GetVehiclesOfUser(string userId);
        Vehicle GetVehicle(int id);
        string CreateVehicle(Vehicle vehicle);
        string EditVehicle(Vehicle vehicle);
        string DeleteVehicle(int id);
    }
}
