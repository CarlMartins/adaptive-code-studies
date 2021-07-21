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
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Account();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(repo => repo.GetByName("Trading Account"))
                .Returns(account);
            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

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
            var mockRepository = new Mock<IAccountRepository>();
            var sut = new AccountService(mockRepository.Object);
            
            // Act
            sut.AddTransactionToAccount("Trading Account", 100m);

            // Assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(100m))
                .Throws<DomainException>();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account"))
                .Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            // Act
            try
            {
                sut.AddTransactionToAccount("Trading Account", 100m);
            }
            catch (ServiceException serviceException)
            {
                // Assert
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
            }
        }
    }
}