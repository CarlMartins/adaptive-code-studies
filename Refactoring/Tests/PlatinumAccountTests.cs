using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Entities;
using Refactoring.Enums;

namespace Refactoring.Tests
{
  [TestClass]
  public class PlatinumAccountTests
  {
    private PlatinumAccount _sut;

    public PlatinumAccountTests()
    {
      _sut = new PlatinumAccount();
    }

    [TestMethod]
    public void CalculateRewardPoints_ShouldWork()
    {
      // Arrange
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

      // Act
      _sut.AddTransaction(100);

      // Assert
      Assert.AreEqual(100, _sut.Balance);
    }
  }
}