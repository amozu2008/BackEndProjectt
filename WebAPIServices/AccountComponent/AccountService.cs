using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServices.CustomerComponent;
using WebAPIServices.DomainModel;
using WebAPIServices.Dto;
using WebAPIServices.TransactionComponent;

namespace WebAPIServices.AccountComponent
{
    public class AccountService : AccountRepository
    {
        private ResponseDto<object> _reponse;
        private CustomerService _customerService;
        private TransactionService _transactionService;
        public AccountService(IMapper mapper, CustomerService customerService, 
                                                TransactionService transactionService) : base(mapper)
        {
            _reponse = new ResponseDto<object>();
            _customerService = customerService;
            _transactionService = transactionService;
        }

        public ResponseDto<object> RegisterUser(int customerId, decimal initialCredit)
        {
            var foundCustomerDto = _customerService.FindCustomerById(customerId);

            if (foundCustomerDto != null && initialCredit == 0)
            {
                foundCustomerDto.InitialCredit = initialCredit;
               // var responseDto = CheckUser(customerId);
           
                    var accountDto = new AccountDto
                    {
                        Balance = 0,
                        Customer = foundCustomerDto,
                    };
                    var acDto = this.CreateAccount(accountDto);
                    _reponse.IsSuccess = true;
                    _reponse.DisplayMessages = "Customer Account created successfully";
                    _reponse.Result = acDto;
            }
            else if (foundCustomerDto != null && initialCredit != 0)
            {
                foundCustomerDto.InitialCredit = initialCredit;
                var accountDto = new AccountDto
                {
                    Customer = foundCustomerDto,
                };
                var transResponsedto = _transactionService.DoTransaction(accountDto);
                 var createdAccountDto = this.CreateAccount((AccountDto)transResponsedto.Result);
                
                    _reponse.IsSuccess = transResponsedto.IsSuccess;
                    _reponse.DisplayMessages = transResponsedto.DisplayMessages;
                    _reponse.Result = createdAccountDto;
         
            }         
            else
            {
                _reponse.IsSuccess = false;
                _reponse.DisplayMessages = "Invalid customer Id";

            }

            return _reponse;
        }


        public ResponseDto<object> FindByCustomerID(int id)
        {
            var foundCustomer = AccountDB.FindAll(ac => ac.Customer.CustomerId == id); //Where(ac => ac.Customer.CustomerId == id);
            if (foundCustomer.Count != 0)
            {
                var mappedAccountDto = _mapper.Map<List<AccountDto>>(foundCustomer);
                _reponse.IsSuccess = true;
                _reponse.DisplayMessages = "Found an account";
                _reponse.Result = mappedAccountDto;
            }
            else
            {
                _reponse.IsSuccess = false;
                _reponse.DisplayMessages = "No account Found";
            }

            return _reponse;   
        }
    }
}
