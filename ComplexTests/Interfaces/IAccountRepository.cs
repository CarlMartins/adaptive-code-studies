using ComplexTests.Entities;

namespace ComplexTests.Interfaces
{
    public interface IAccountRepository
    {
        Account GetByName(string accountName);
    }
}