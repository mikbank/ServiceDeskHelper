using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Models;

namespace ServiceDeskHelper.Core.Services;
using System.Text.RegularExpressions;

public class CSVUserRepository : IUserRepository 
//Repository of users loaded from a csv file to simulate data ingestion 
//The list of records of users can be modified, but the list itself cannot be replaced, 
//if we ran on a SQL DB a select would replace loading, but we would have to consider transactionality
{
    private readonly string _filePath; 
    private readonly List<User> _users;
    private static readonly string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; //defining basic regex pattern to validate emails like test@test.com
    private static readonly Regex EmailRegex = new Regex(Pattern); //note: not very efficient


    public CSVUserRepository(string filePath) //constructor with basic file validation and also readonly functionality, thus securing the list of users. 
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
        SaveToCsv(); // saves users
    }

    public bool Delete(int id)
    {
        var removed = _users.RemoveAll(u => u.Id == id) > 0;
        if (removed) SaveToCsv();
        return removed;
    }

    private List<User> LoadFromCsv(string path)
    {
        var lines = File.ReadAllLines(path).Skip(1); // skip header for reading csv old fashioned but works
        var users = new List<User>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length < 6) continue;

            
            var email = parts[4];
            // Check that email is in correct format from data source, this could be problematic, but showcases basic regex
            if (!EmailRegex.IsMatch(email))
             {
                // Skip invalid email rows (could be defensive programming)
                continue;
            }

            try
            {
                users.Add(new User(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    isActive: bool.Parse(parts[5])
                ));
            }
            catch
            {
                // skip malformed line
            }
        }
        return users;
    }

    private void SaveToCsv() //for future use if we want to implement saving to datasource
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Id,FirstName,LastName,Department,Email,IsActive");
        foreach (var u in _users)
        {
            sb.AppendLine($"{u.Id},{u.FirstName},{u.LastName},{u.Department},{u.Email},{u.IsActive}");
        }
        File.WriteAllText(_filePath, sb.ToString());
    }
}
