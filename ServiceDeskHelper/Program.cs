using ServiceDeskHelper.Interfaces;
using ServiceDeskHelper.Models;
using ServiceDeskHelper.Services;

IUserRepository repo = new InMemoryUserRepository();
repo.Add(new User(1, "jane.doe", "IT", "Admin"));
Console.WriteLine($"Users count: {repo.GetAll().Count()}");