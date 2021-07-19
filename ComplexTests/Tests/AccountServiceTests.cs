using ComplexTests.Entities;
using ComplexTests.Repositories;
using ComplexTests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var fakeRepository = new FakeAccountRepository(account);
            var sut = new AccountService(fakeRepository);

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
        }
    }
}