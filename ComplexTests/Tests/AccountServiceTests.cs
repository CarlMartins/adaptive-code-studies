using ComplexTests.Entities;
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
    }
}