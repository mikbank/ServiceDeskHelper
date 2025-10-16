using ServiceDeskHelper.Models;

namespace ServiceDeskHelper.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
    void Add(User user);
    bool Delete(int id);
}