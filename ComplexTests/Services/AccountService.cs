using System;
using ComplexTests.Exceptions;
using ComplexTests.Interfaces;

namespace ComplexTests.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentException("A valid account repository must be supplied", 
                    nameof(repository));
            }
            _repository = repository;
        }
        
        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = _repository.GetByName(uniqueAccountName);
            if (account != null)
            {
                try
                {
                    account.AddTransaction(transactionAmount);
                }
                catch (DomainException domainException)
                {
                    throw new ServiceException("Adding transaction to account failed", domainException);
                }
            }
        }
    }
}