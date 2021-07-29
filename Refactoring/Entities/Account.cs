using System;
using Refactoring.Enums;

namespace Refactoring.Entities
{
    public class Account
    {
        private readonly AccountType _type;

        private const int SilverTransactionCostPerPoint = 10;
        private const int GoldTransactionCostPerPoint = 5; 
        private const int PlatinumTransactionCostPerPoint = 2;

        private const int GoldBalanceCostPerPoint = 2000;
        private const int PlatinumBalanceCostPerPoint = 1000;
        
        public Account(AccountType type)
        {
            _type = type;
        }
        
        public decimal Balance { get; private set; }
        public int RewardPoints { get; private set; }
        
        public void AddTransaction(decimal amount)
        {
            RewardPoints += CalculateRewardPoints(amount);
            Balance += amount;
        }
        
        public int CalculateRewardPoints(decimal amount)
        {
            int points;
            switch(_type)
            {
                case AccountType.Silver:
                    points = (int)decimal.Floor(amount / SilverTransactionCostPerPoint);
                    break;
                case AccountType.Gold:
                    points = (int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + (amount / GoldTransactionCostPerPoint));
                    break;
                case AccountType.Platinum:
                    points = (int)decimal.Ceiling((Balance / PlatinumBalanceCostPerPoint) + (amount / PlatinumTransactionCostPerPoint));
                    break;
                default:
                    points = 0;
                    break;
            }
            return Math.Max(points, 0);
        }
    }
}