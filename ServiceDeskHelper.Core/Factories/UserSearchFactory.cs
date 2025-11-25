using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Strategies;

namespace ServiceDeskHelper.Core.Factories;

public static class UserSearchFactory 
//factory pattern to facilitate search strategies - Utilized by UsersController, originally built for terminal app but was replaced with MVC structure
 
{
    public static IUserSearchStrategy Create(string searchType)
    {
        return searchType.ToLower() switch
        {
            "names" => new SearchByFullName(),
            "all"   => new SearchByAllFields(),
            "email" => new SearchByEmail(),
            _ => throw new NotSupportedException($"Unknown search type: {searchType}")
        };
    }
}