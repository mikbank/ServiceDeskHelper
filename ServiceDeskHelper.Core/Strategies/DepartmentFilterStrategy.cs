using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class DepartmentFilterStrategy : IUserFilterStrategy
{
    private readonly string _department;

    public DepartmentFilterStrategy(string department)
    {
        _department = department;
    }

    public IEnumerable<User> Filter(IEnumerable<User> users)
    {
        return users.Where(u => u.Department.Equals(_department, StringComparison.OrdinalIgnoreCase)); //FIX PLS
    }
}