using System;
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
        private Mock<Account> _mockAccount;
        private Mock<IAccountRepository> _mockRepository;
        private AccountService _sut;
        
        [TestInitialize]
        public void Setup()
        {
            _mockAccount = new Mock<Account>();
            _mockRepository = new Mock<IAccountRepository>();
            _sut = new AccountService(_mockRepository.Object);
        }
        
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Account();
            _mockRepository.Setup(repo => repo.GetByName("Trading Account"))
                .Returns(account);

            // Act
            _sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
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