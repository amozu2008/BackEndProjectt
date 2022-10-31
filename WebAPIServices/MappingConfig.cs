using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServices.DomainModel;
using WebAPIServices.Dto;

namespace WebAPIServices
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(m =>
            {
                m.CreateMap<CustomerDto, Customer>().ReverseMap();
                m.CreateMap<AccountDto, Account>().ReverseMap();
                
            });

            return mappingConfig;
        }
    }
}
