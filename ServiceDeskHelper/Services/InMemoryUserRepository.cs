using ServiceDeskHelper.Interfaces;
using ServiceDeskHelper.Models;

namespace ServiceDeskHelper.Services;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public void Add(User user)
    {
        if (_users.Any(u => u.Id == user.Id))
            throw new InvalidOperationException($"User with Id {user.Id} already exists.");
        _users.Add(user);
    }

    public bool Delete(int id) => _users.RemoveAll(u => u.Id == id) > 0;
}
