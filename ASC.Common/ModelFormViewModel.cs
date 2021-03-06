using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class ModelFormViewModel
    {
        public IEnumerable<Brand> brands { get; set; }

        public Model modelData { get; set; }

    }
}
