using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IServiceBookingRepository
    {
        string AddBooking(ServiceBooking serviceBooking, int[] servicesIds);
    }
}
