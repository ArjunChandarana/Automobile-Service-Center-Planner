using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class ServiceBookingModel
    {
        public ServiceBooking ServiceBooking { get; set; }

        public int[] servicesIds { get; set; }
    }
}
