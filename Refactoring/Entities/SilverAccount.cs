using System;

namespace Refactoring.Entities
{
  public class SilverAccount : AccountBase
  {
    public override int CalculateRewardPoints(decimal amount)
    {
      return Math.Max((int)decimal.Floor(amount / SilverTransactionCostPerPoint), 0);
    }

    private const int SilverTransactionCostPerPoint = 10;
  }
}