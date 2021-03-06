using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public System.TimeSpan Duration { get; set; }
        public double Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
