using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Entities
{
    class SelectedService
    {
        public int Id { get; set; }
        public int ServiceBookingId { get; set; }
        public int ServiceId { get; set; }
    }
}
