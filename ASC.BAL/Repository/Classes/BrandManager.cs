using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.BAL.Repository.Classes
{
    public class BrandManager : IBrandManager
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public string CreateBrand(Brand brand)
        {
            return _brandRepository.CreateBrand(brand);
        }

        public string DeleteBrand(int id)
        {
            return _brandRepository.DeleteBrand(id);
        }

        public string EditBrand(Brand brand)
        {
            return _brandRepository.EditBrand(brand);
        }

        public Brand GetBrand(int id)
        {
            return _brandRepository.GetBrand(id);
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brandRepository.GetBrands();
        }
    }
}
