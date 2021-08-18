using Refactoring.Enums;
using Refactoring.Interfaces;

namespace Refactoring.Entities
{
  public class ConcreteAccountFactory : IAccountFactory
  {
    public AccountBase CreateAccount(AccountType type)
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
  }
}