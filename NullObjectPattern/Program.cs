using System;
using AdaptiveCode.Interfaces;
using AdaptiveCode.Repositories;

namespace NullObjectPattern
{
    class Program
    {
        private static IUserRepository _userRepository = new UserRepository();
        static void Main(string[] args)
        {
            IUser user = _userRepository.GetById(Guid.NewGuid());
            user.IncrementSessionTicket();
        }
    }
}