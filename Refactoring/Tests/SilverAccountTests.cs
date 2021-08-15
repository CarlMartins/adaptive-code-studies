using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Entities;
using Refactoring.Enums;

namespace Refactoring.Tests
{
  [TestClass]
  public class SilverAccountTests
  {
    private SilverAccount _sut;

    [TestMethod]
    public void CalculateRewardPoints_ShouldWork()
    {
      // Arrange
      _sut = new SilverAccount();

      // Act
      var actual = _sut.CalculateRewardPoints(100);

      // Assert
      Assert.AreEqual(10, actual);
      Assert.IsNotNull(actual);
    }
  }
}