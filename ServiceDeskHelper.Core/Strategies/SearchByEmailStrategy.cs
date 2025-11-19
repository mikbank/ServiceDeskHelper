using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class SearchByEmailStrategy : IUserSearchStrategy
{
    public IEnumerable<User> Search(IEnumerable<User> users, string query)
    {
        return users.Where(u =>
            u.Email.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}