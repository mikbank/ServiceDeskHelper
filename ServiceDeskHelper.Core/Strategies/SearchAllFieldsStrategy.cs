using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class SearchAllFieldsStrategy : IUserSearchStrategy
{
    public IEnumerable<User> Search(IEnumerable<User> users, string query)
    {
        return users.Where(u =>
            u.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) //FFIX PLS
            || u.LastName.Contains(query, StringComparison.OrdinalIgnoreCase)
            || u.Department.Contains(query, StringComparison.OrdinalIgnoreCase)
            || u.Email.Contains(query, StringComparison.OrdinalIgnoreCase)
        );
    }
}