// ServiceDeskHelper/Strategies/AllUsersFilterStrategy.cs
using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class AllUsersFilterStrategy : IUserFilterStrategy
{
    public IEnumerable<User> Filter(IEnumerable<User> users) => users;
}