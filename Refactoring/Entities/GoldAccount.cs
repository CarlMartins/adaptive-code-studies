using System;

namespace Refactoring.Entities
{
  public class GoldAccount : AccountBase
  {
    public override int CalculateRewardPoints(decimal amount)
    {
      return Math.Max((int)decimal.Floor(
        (Balance / GoldBalanceCostPerPoint) +
        (amount / GoldTransactionCostPerPoint)), 0);
    }

    private const int GoldTransactionCostPerPoint = 5;
    private const int GoldBalanceCostPerPoint = 2000;
  }
}