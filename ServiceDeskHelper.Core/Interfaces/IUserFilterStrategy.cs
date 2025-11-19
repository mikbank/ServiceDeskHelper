using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Interfaces;

public interface IUserFilterStrategy
{
    IEnumerable<User> Filter(IEnumerable<User> users);
}