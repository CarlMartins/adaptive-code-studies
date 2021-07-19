using System;
using ComplexTests.Entities;

namespace ComplexTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            Console.WriteLine(account.Balance);
        }
    }
}