using ComplexTests.Interfaces;

namespace ComplexTests.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        
        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = _repository.GetByName(uniqueAccountName);
            account.AddTransaction(transactionAmount);
        }
    }
}