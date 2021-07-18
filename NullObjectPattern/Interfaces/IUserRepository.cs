using System;

namespace AdaptiveCode.Interfaces
{
    public interface IUserRepository
    {
        IUser GetById(Guid userId);
    }
}