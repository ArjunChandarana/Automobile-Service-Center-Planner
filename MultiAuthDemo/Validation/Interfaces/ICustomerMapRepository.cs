using MultiAuthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiAuthDemo.Validation.Interfaces
{
    public interface ICustomerMapRepository
    {
        Boolean MapCustomer(RegisterViewModel model, string Id);
    }
}
