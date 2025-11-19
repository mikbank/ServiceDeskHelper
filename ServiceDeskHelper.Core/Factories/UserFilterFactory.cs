using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Strategies;

namespace ServiceDeskHelper.Core.Factories;

public static class UserFilterFactory
{
    public static IUserFilterStrategy Create(string filterType, string? argument = null)
    {
        switch (filterType.ToLower())
        {
            case "department":
                if (argument is null)
                    throw new ArgumentException("Department filter requires an argument.");
                return new DepartmentFilterStrategy(argument);

            case "alphabetical":
                return new AlphabeticalFilterStrategy('A', 'M');

            case "all":
                return new AllUsersFilterStrategy();

            default:
                throw new NotSupportedException($"Unknown filter type: {filterType}");
        }
    }
}