using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class CustomerVehicles
    {
        public Customer Customer { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
