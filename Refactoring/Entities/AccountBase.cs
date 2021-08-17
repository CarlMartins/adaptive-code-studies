using System;
using Refactoring.Enums;

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

    public static AccountBase CreateAccount(AccountType type)
    {
      AccountBase account = null;
      switch (type)
      {
        case AccountType.Silver:
          account = new SilverAccount();
          break;
        case AccountType.Gold:
          account = new GoldAccount();
          break;
        case AccountType.Platinum:
          account = new SilverAccount();
          break;
      }
      return account;
    }

    

    public abstract int CalculateRewardPoints(decimal amount);
  }
}