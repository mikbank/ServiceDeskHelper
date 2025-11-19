using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class SearchByFullNameStrategy : IUserSearchStrategy
{
    public IEnumerable<User> Search(IEnumerable<User> users, string query)
    {
        return users.Where(u =>
            u.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase)
            || u.LastName.Contains(query, StringComparison.OrdinalIgnoreCase)
        );
    }
}