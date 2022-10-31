using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServices.Dto;

namespace WebAPIServices.CustomerComponent
{
    public interface ICustomerRepository
    {
        CustomerDto FindCustomerById(int id);
        IEnumerable<CustomerDto> GetAllCustomer();
        CustomerDto AddCustomer(CustomerDto customerDto);
    }
}
