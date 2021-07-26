using System;
using ComplexTests.Builders;
using ComplexTests.Entities;
using ComplexTests.Exceptions;
using ComplexTests.Interfaces;
using ComplexTests.Repositories;
using ComplexTests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ComplexTests.Tests
{
    [TestClass]
    public class AccountServiceTests
    {
        private AccountServiceBuilder _accountServiceBuilder;

        private Mock<Account> _mockAccount;
        private Mock<IAccountRepository> _mockRepository;
        private AccountService _sut;
        
        [TestInitialize]
        public void Setup()
        {
            _mockAccount = new Mock<Account>();
            _mockRepository = new Mock<IAccountRepository>();
            _sut = new AccountService(_mockRepository.Object);

            _accountServiceBuilder = new AccountServiceBuilder();
        }
        
        // WITH BUILDER
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var sut = _accountServiceBuilder
                .WithAccountCalled("Trading Account")
                .AddTransactionOfValue(200m)
                .Build();

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            _accountServiceBuilder.MockAccount.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateAccountServiceWithNullAccountRepository()
        {
            // Arrage
            
            // Act
            new AccountService(null);

            // Assert
        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // Arrange

            // Act
            _sut.AddTransactionToAccount("Trading Account", 100m);

            // Assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            _mockAccount.Setup(a => a.AddTransaction(100m))
                .Throws<DomainException>();
            _mockRepository.Setup(r => r.GetByName("Trading Account"))
                .Returns(_mockAccount.Object);

            // Act
            try
            {
                _sut.AddTransactionToAccount("Trading Account", 100m);
            }
            catch (ServiceException serviceException)
            {
                // Assert
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
            }
        }
    }
}