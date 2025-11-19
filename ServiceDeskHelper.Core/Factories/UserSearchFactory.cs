using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Strategies;

namespace ServiceDeskHelper.Core.Factories;

public static class UserSearchFactory
{
    public static IUserSearchStrategy Create(string searchType)
    {
        return searchType.ToLower() switch
        {
            "names" => new SearchByFullNameStrategy(),
            "all"   => new SearchAllFieldsStrategy(),
            "email" => new SearchByEmailStrategy(),
            _ => throw new NotSupportedException($"Unknown search type: {searchType}")
        };
    }
}