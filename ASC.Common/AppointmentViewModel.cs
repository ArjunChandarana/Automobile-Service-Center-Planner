using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class AppointmentViewModel
    {
        public ServiceBooking ServiceBooking { get; set; }
        public CustomerVehicles CustomerVehicles { get; set; }
        public IEnumerable<Dealer> Dealers { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
