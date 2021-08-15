namespace Refactoring.Interfaces
{
  public interface IAccount
  {
    void AddTransaction(decimal amount);
    int CalculateRewardPoints(decimal amount);
  }
}