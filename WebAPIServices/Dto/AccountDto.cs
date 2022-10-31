using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServices.Dto
{
    public class AccountDto
    {
        public CustomerDto Customer { get; set; }
        public decimal Balance { get; set; }
        public string Transactions { get; set; }
    }
}
