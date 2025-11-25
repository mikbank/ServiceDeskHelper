using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class SearchByEmail : IUserSearchStrategy
{
    public IEnumerable<User> Search(IEnumerable<User> users, string query)
    {
        var q = query.ToLower();

        // LINQ Query Syntax Demonstration (email-only search)
        var results =
            from u in users
            where u.Email.ToLower().Contains(q)
            select u;

        return results;
    }
}