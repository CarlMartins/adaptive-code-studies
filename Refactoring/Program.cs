using System;
using Refactoring.Entities;
using Refactoring.Interfaces;

namespace Refactoring
{
  class Program
  {
    static void Main(string[] args)
    {
      IAccountFactory accountFactory = new ConcreteAccountFactory();
      Account newAccount = new Account(accountFactory);

      newAccount.CreateAccount(Enums.AccountType.Platinum);
    }
  }
}