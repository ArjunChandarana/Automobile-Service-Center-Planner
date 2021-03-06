using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumberPlate { get; set; }
        public string ChassisNumber { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public Nullable<System.DateTime> LastServiceDate { get; set; }
        public string FuelType { get; set; }
        public int CustomerId { get; set; }
        public int ModelId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Model Model { get; set; }
    }
}
