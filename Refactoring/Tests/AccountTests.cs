using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Entities;
using Refactoring.Enums;

namespace Refactoring.Tests
{
    [TestClass]
    public class AccountTests
    {
        private Account _sut;
        private AccountType _type; 
        
        [TestMethod]
        public void CalculateRewardPoints_WithGoldSilverAccount_ShouldWork()
        {
            // Arrange
            _type = AccountType.Silver;
            _sut = new Account(_type);
            
            // Act
            var actual = _sut.CalculateRewardPoints(100);

            // Assert
            Assert.AreEqual(10, actual);
            Assert.IsNotNull(actual);
        }
        
        [TestMethod]
        public void CalculateRewardPoints_WithGoldTierAccount_ShouldWork()
        {
            // Arrange
            _type = AccountType.Gold;
            _sut = new Account(_type);
            
            // Act
            var actual = _sut.CalculateRewardPoints(100);

            // Assert
            Assert.AreEqual(20, actual);
            Assert.IsNotNull(actual);
        }
        
        [TestMethod]
        public void CalculateRewardPoints_WithPlatinumTierAccount_ShouldWork()
        {
            // Arrange
            _type = AccountType.Platinum;
            _sut = new Account(_type);
            _sut.AddTransaction(100);
            
            // Act
            var actual = _sut.CalculateRewardPoints(100);

            // Assert
            Assert.AreEqual(51, actual);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void CalculateRewardPoint_WithValidValues_ShouldWork()
        {
            // Arrange
            _type = AccountType.Gold;
            _sut = new Account(_type);
            
            // Act
            _sut.AddTransaction(100);

            // Assert
            Assert.AreEqual(100, _sut.Balance);
        }
    }
}