using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServices.AccountComponent;
using WebAPIServices.Dto;

namespace WebAPIServices.TransactionComponent
{
    public class TransactionService
    {
        private ResponseDto<object> _reponse;
        public TransactionService()
        {
            _reponse = new ResponseDto<object>();
        }

        public ResponseDto<object> DoTransaction(AccountDto accountDto)
        {
            //var foundAccountDto = _accountService.FindAccountById(id);
            if(accountDto != null && accountDto.Customer.InitialCredit > 0)
            {
                accountDto.Balance += accountDto.Customer.InitialCredit;
                accountDto.Transactions = "Credit";
                _reponse.IsSuccess = true;
                _reponse.DisplayMessages = "Account created and Transaction successful";
                _reponse.Result = accountDto;
            }
            else if(accountDto != null && accountDto.Customer.InitialCredit < 0)
            {
                accountDto.Balance -= -(accountDto.Customer.InitialCredit);
                accountDto.Transactions = "Debit";
                _reponse.IsSuccess = true;
                _reponse.DisplayMessages = "Account created and Transaction successful";
                _reponse.Result = accountDto;
            }


            return _reponse;
        }
    }
}
