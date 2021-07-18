using System;
using System.Collections.Generic;
using System.Linq;
using AdaptiveCode.Entities;
using AdaptiveCode.Interfaces;

namespace AdaptiveCode.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ICollection<User> _users;
        public UserRepository()
        {
            _users = new List<User>
            {
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid())
            };
        }
        public IUser GetById(Guid userId)
        {
            IUser userFound = _users.SingleOrDefault(user => user.UserId == userId);
            if (userFound == null)
            {
                userFound = new NullUser();
            }

            return userFound;
        }
    }
}