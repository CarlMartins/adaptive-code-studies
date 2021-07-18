namespace UnitTests1
{
    public class Account
    {
        public void AddTransaction(decimal amount)
        {
            Balance += amount;
        }

        public decimal Balance { get; private set; }
    }
}