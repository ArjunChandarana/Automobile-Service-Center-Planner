using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class VehicleFormModel
    {
        public IEnumerable<Customer> customers { get; set; }
        public IEnumerable<Model> models { get; set; }
        public Vehicle vehicle { get; set; }
    }
}
