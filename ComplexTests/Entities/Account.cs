namespace ComplexTests.Entities
{
    public class Account
    {
        public string AccountName { get; set; }
        public decimal Balance { get; private set; }
        

        public virtual void AddTransaction(decimal amount)
        {
            Balance += amount;
        }
    }
}