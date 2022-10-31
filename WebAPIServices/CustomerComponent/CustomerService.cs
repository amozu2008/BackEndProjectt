using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServices.CustomerComponent
{
    public class CustomerService : CustomerRepository
    {
        public CustomerService(IMapper mapper) : base(mapper)
        {
        }
    }
}
