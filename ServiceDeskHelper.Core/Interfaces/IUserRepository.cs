using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
    void Add(User user);
    bool Delete(int id);
}