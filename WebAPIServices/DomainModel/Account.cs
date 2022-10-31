using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServices.DomainModel
{
    public class Account
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public string Transactions { get; set; }

    }
}
