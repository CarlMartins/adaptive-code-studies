using System;
using Refactoring.Enums;
using Refactoring.Interfaces;

namespace Refactoring.Entities
{
  public abstract class AccountBase
  {
    public decimal Balance { get; set; }
    public int RewardPoints { get; set; }

    public void AddTransaction(decimal amount)
    {
      RewardPoints += CalculateRewardPoints(amount);
      Balance += amount;
    }

    public abstract int CalculateRewardPoints(decimal amount);
  }
}