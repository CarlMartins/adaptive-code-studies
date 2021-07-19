namespace ComplexTests.Interfaces
{
    public interface IAccountService
    {
        void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount);
    }
}