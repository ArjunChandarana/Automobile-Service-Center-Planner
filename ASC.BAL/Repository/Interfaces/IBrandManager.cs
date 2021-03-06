using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IBrandManager
    {
        IEnumerable<Brand> GetBrands();
        Brand GetBrand(int id);
        string CreateBrand(Brand brand);
        string EditBrand(Brand brand);
        string DeleteBrand(int id);
    }
}
