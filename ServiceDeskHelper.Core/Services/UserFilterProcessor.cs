using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Services;

public class UserFilterProcessor
{
    private readonly IUserFilterStrategy _strategy;

    public UserFilterProcessor(IUserFilterStrategy strategy)
    {
        _strategy = strategy;
    }

    public IEnumerable<User> Apply(IEnumerable<User> users) => _strategy.Filter(users);
}
