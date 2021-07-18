using System;
using AdaptiveCode.Interfaces;

namespace AdaptiveCode.Entities
{
    public class User : IUser
    {
        public Guid UserId { get; set; }
        public User(Guid userId)
        {
            UserId = userId;
        }
        public void IncrementSessionTicket()
        {
            // Code
        }
    }
}