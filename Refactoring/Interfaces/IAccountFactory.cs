using Refactoring.Entities;
using Refactoring.Enums;

namespace Refactoring.Interfaces
{
  public interface IAccountFactory
  {
    AccountBase CreateAccount(AccountType accountType);
  }
}