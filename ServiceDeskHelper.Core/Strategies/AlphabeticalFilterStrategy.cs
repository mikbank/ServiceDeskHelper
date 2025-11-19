using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Strategies;

public class AlphabeticalFilterStrategy : IUserFilterStrategy
{
    private readonly char _start;
    private readonly char _end;

    public AlphabeticalFilterStrategy(char start, char end)
    {
        _start = start;
        _end = end;
    }

    public IEnumerable<User> Filter(IEnumerable<User> users)
    {
        return users.Where(u =>
        {
            var firstLetter = char.ToUpper(u.FirstName.FirstOrDefault());
            return firstLetter >= char.ToUpper(_start) && firstLetter <= char.ToUpper(_end);
        });
    }
}