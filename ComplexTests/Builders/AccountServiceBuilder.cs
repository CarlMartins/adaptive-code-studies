using System;
using ComplexTests.Entities;
using ComplexTests.Interfaces;
using ComplexTests.Services;
using Moq;

namespace ComplexTests.Builders
{
    public class AccountServiceBuilder
    {
        private readonly AccountService _accountService;
        private readonly Mock<IAccountRepository> _mockAccountRepo;

        public Mock<Account> MockAccount { get; private set; }

        public AccountServiceBuilder()
        {
            _mockAccountRepo = new Mock<IAccountRepository>();
            _accountService = new AccountService(_mockAccountRepo.Object);
        }

        public AccountServiceBuilder WithAccountCalled(string accountName)
        {
            MockAccount = new Mock<Account>();
            _mockAccountRepo.Setup(repo => repo.GetByName(accountName))
                .Returns(MockAccount.Object);

            return this;
        }

        public AccountServiceBuilder AddTransactionOfValue(decimal transactionValue)
        {
            MockAccount.Setup(account => account.AddTransaction(transactionValue)).Verifiable();
            return this;
        }

        public AccountService Build()
        {
            return _accountService;
        }
    }
}