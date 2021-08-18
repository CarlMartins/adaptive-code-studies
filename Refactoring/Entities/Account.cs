using Refactoring.Enums;
using Refactoring.Interfaces;

namespace Refactoring.Entities
{
  public class Account
  {
    public Account(IAccountFactory accountFactory)
    {
      _accountFactory = accountFactory;
    }
    public void CreateAccount(AccountType accountType)
    {
      NewAccount = _accountFactory.CreateAccount(accountType);
    }
    private readonly IAccountFactory _accountFactory;
    private AccountBase NewAccount;
  }
}