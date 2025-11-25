using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class SearchByAllFields : IUserSearchStrategy

{
    public IEnumerable<User> Search(IEnumerable<User> users, string query)
    {
        var q = query.ToLower();

        // LINQ Query Syntax for searching in all fields
        var results =
            from u in users
            where u.FirstName.ToLower().Contains(q)
               || u.LastName.ToLower().Contains(q)
               || u.Department.ToLower().Contains(q)
               || u.Email.ToLower().Contains(q)
            select u;

        return results;
    }
}