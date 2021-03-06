using ASC.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL
{
    public class AutoMapperConfig
    {
        public static Mapper DbCustomerToCustomerMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Customer, Customer>();
        }));

        public static Mapper DbBrandToBrandMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Brand, Brand>();
        }));

        public static Mapper BrandToDbBrandMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Brand, Database.Brand>();
        }));

        public static Mapper ModelMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Model, Database.Model>();
            cfg.CreateMap<Brand, Database.Brand>();
            cfg.CreateMap<Database.Model, Model>();
            cfg.CreateMap<Database.Brand, Brand>();
        }));

        public static Mapper ServiceMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Service, Database.Service>();
            cfg.CreateMap<Database.Service, Service>();
        }));

        public static Mapper CustomerMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Customer, Database.Customer>();
            cfg.CreateMap<Dealer, Database.Dealer>();
            cfg.CreateMap<Database.Customer, Customer>();
            cfg.CreateMap<Database.Dealer, Dealer>();
        }));

        public static Mapper DealerMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Dealer, Database.Dealer>();
            cfg.CreateMap<Database.Dealer, Dealer>();
        }));

        public static Mapper VehicleMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Vehicle, Database.Vehicle>();
            cfg.CreateMap<Database.Vehicle, Vehicle>();

            cfg.CreateMap<Customer, Database.Customer>();
            cfg.CreateMap<Database.Customer, Customer>();

            cfg.CreateMap<Model, Database.Model>();
            cfg.CreateMap<Database.Model, Model>();

            cfg.CreateMap<Dealer, Database.Dealer>();
            cfg.CreateMap<Database.Dealer, Dealer>();

            cfg.CreateMap<Brand, Database.Brand>();
            cfg.CreateMap<Database.Brand, Brand>();
        }));
    }
}