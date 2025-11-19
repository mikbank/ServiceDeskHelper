using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Services;

public class UserSearchProcessor
{
    private readonly IUserSearchStrategy _strategy;

    public UserSearchProcessor(IUserSearchStrategy strategy)
    {
        _strategy = strategy;
    }

    public IEnumerable<User> Search(IEnumerable<User> users, string query)
        => _strategy.Search(users, query);
}
