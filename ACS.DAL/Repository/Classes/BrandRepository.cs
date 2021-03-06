using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Classes
{
    public class BrandRepository : IBrandRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public BrandRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        
        public IEnumerable<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();
            IEnumerable<Database.Brand> entities = _DbContext.Brands.ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Brand brand = new Brand();
                    brand = AutoMapperConfig.DbBrandToBrandMapper.Map<Brand>(item);
                    brands.Add(brand);
                }
            }
            return brands;
        }

        public string CreateBrand(Brand brand)
        {
            try
            {
                if (brand != null)
                {
                    var res = _DbContext.Brands.Where(x => x.Name == brand.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Brand entity = new Database.Brand();
                    entity = AutoMapperConfig.BrandToDbBrandMapper.Map<Database.Brand>(brand);

                    _DbContext.Brands.Add(entity);
                    _DbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Brand GetBrand(int id)
        {
            Brand brand;
            Database.Brand entity = _DbContext.Brands.Find(id);
            
            if (entity != null)
            {
                brand = AutoMapperConfig.DbBrandToBrandMapper.Map<Brand>(entity);
            }
            else
            {
                brand = new Brand();
            }
            return brand;
        }

        public string EditBrand(Brand brand)
        {
            try
            {
                var entity = _DbContext.Brands.Where(x => x.Id == brand.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = brand.Name;
                    entity.IsActive = brand.IsActive;

                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBrand(int id)
        {
            var entity = _DbContext.Brands.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                if (entity.IsActive == true)
                {
                    entity.IsActive = false;
                }
                else
                {
                    entity.IsActive = true;
                }
                _DbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }
    }
}
