using ComplexTests.Entities;
using ComplexTests.Interfaces;

namespace ComplexTests.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        private readonly Account _account;
        public FakeAccountRepository(Account account)
        {
            _account = account;
        }
        public Account GetByName(string accountName)
        {
            return _account;
        }
    }
}