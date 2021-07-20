using System;
using ComplexTests.Entities;
using ComplexTests.Interfaces;
using ComplexTests.Repositories;
using ComplexTests.Services;

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