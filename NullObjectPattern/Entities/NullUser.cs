using System;
using AdaptiveCode.Interfaces;

namespace AdaptiveCode.Entities
{
    public class NullUser : IUser
    {
        public void IncrementSessionTicket()
        {
            // Do nothing
        }
    }
}