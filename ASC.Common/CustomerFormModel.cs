using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class CustomerFormModel
    {
        public IEnumerable<Dealer> dealers { get; set; }

        public Customer customer { get; set; }
    }
}
