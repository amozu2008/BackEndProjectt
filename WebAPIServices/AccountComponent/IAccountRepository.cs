using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServices.Dto;

namespace WebAPIServices.AccountComponent
{
    public interface IAccountRepository
    {
        AccountDto FindAccountById(int id);
        IEnumerable<AccountDto> GetAllAccount();
        AccountDto CreateAccount(AccountDto accountDto);
    }
}
