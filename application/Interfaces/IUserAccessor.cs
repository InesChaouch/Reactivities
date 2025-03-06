using System;
using Domain;

namespace application.Interfaces;

public interface IUserAccessor
{
    string GetUserId();
    Task<User> GetUserAsync();
}
