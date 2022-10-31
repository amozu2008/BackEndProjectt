using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServices.DomainModel;
using WebAPIServices.Dto;

namespace WebAPIServices.AccountComponent
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly IMapper _mapper;

        public static List<Account> AccountDB = new List<Account>
        {
        };
        

        public AccountRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AccountDto CreateAccount(AccountDto accountDto)
        {
            var account = _mapper.Map<AccountDto, Account>(accountDto);
          
            AccountDB.Add(account);
            return _mapper.Map<Account, AccountDto>(account);
        }

        public AccountDto FindAccountById(int id)
        {
            var foundAccount = AccountDB.Find(a => a.Customer.CustomerId == id);
            return _mapper.Map<AccountDto>(foundAccount);
        }

        public IEnumerable<AccountDto> GetAllAccount()
        {
            var listOfAccount = AccountDB.ToList();
            return _mapper.Map<List<AccountDto>>(listOfAccount);
        }
    }
}
