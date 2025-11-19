using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Interfaces;

public interface IUserSearchStrategy
{
    IEnumerable<User> Search(IEnumerable<User> users, string query);
}