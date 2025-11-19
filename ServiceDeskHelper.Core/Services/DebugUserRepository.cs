using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Services;

public class DebugUserRepository : IUserRepository
{
    private readonly string _filePath;
    private readonly List<User> _users = new();

    public DebugUserRepository(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
            throw new FileNotFoundException($"CSV file not found at {_filePath}");

        _users = LoadFromCsv(_filePath);
    }

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public void Add(User user)
    {
        _users.Add(user);
        SaveToCsv(); // optional if you want write-back persistence
    }

    public bool Delete(int id)
    {
        var removed = _users.RemoveAll(u => u.Id == id) > 0;
        if (removed) SaveToCsv();
        return removed;
    }

    private List<User> LoadFromCsv(string path)
    {
        var lines = File.ReadAllLines(path).Skip(1); // skip header
        var users = new List<User>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length < 5) continue;

            try
            {
                users.Add(new User(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4]
                ));
            }
            catch
            {
                // skip malformed line
            }
        }
        return users;
    }

    private void SaveToCsv()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Id,FirstName,LastName,Department,Email");
        foreach (var u in _users)
        {
            sb.AppendLine($"{u.Id},{u.FirstName},{u.LastName},{u.Department},{u.Email}");
        }
        File.WriteAllText(_filePath, sb.ToString());
    }
}
