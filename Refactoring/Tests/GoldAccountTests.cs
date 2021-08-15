using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Entities;
using Refactoring.Enums;

namespace Refactoring.Tests
{
  [TestClass]
  public class GoldAccountTests
  {
    private GoldAccount _sut;

    public GoldAccountTests()
    {
      _sut = new GoldAccount();
    }

    [TestMethod]
    public void CalculateRewardPoints_ShouldWork()
    {
      // Arrange

      // Act
      var actual = _sut.CalculateRewardPoints(100);

      // Assert
      Assert.AreEqual(20, actual);
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