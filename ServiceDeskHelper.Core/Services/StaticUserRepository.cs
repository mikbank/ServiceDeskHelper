using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Services;

public class StaticUserRepository : IUserRepository //THis repo is meant to showcase switching between data sources in appsettings
{
    private readonly List<User> _users = new();

    public StaticUserRepository()
    {
        // statically create users
        _users.AddRange(new[]
        {
            new User(1, "Test",     "Testesen",  "IT",      "asdf35hg@eksamen.com",  true),
            new User(2, "Test2",       "Testor",   "Finance", "hss335hg@eksamen.com",     false),
            new User(3, "Kristoffer",   "Konradsen", "HR",      "mssf7s@eksamen.com", false)
        });
    }

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) =>
        _users.FirstOrDefault(u => u.Id == id);

    public void Add(User user)
    {
        if (_users.Any(u => u.Id == user.Id))
            throw new InvalidOperationException($"User with Id {user.Id} already exists.");

        _users.Add(user);
    }

    public bool Delete(int id) =>
        _users.RemoveAll(u => u.Id == id) > 0;
}