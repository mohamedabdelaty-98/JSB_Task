using AutoMapper;
using BussinessLayer.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, DTOProduct>();
            CreateMap<DTOProduct, Product>();

            CreateMap<Order, DTOOrder>();
            CreateMap<DTOOrder, Order>();
        }
    }
}
