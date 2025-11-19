using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Services;
using ServiceDeskHelper.Core.Factories;


namespace ServiceDeskHelper.ConsoleUI.UI;

public class ConsoleUI
{
    private readonly IUserRepository _repo;

    public ConsoleUI(IUserRepository repo)
    {
        _repo = repo;
    }

    public void Run()
    {
        while (true)
        {
            PrintMainMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllUsers();
                    break;

                case "2":
                    FilterUsersMenu();
                    break;

                case "3":
                    SearchUserMenu();
                    break;

                case "q":
                case "Q":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    private void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== ServiceDesk Helper ===");
        Console.WriteLine("[1] Show all users");
        Console.WriteLine("[2] Filter users");
        Console.WriteLine("[3] Search user");
        Console.WriteLine("[Q] Quit");
        Console.Write("Choose: ");
    }

    private void ShowAllUsers()
    {
        var users = _repo.GetAll();
        PrintUserList(users);
    }

    private void FilterUsersMenu()
    {
        Console.Write("Enter department (e.g. IT, HR, Sales): ");
        var dept = Console.ReadLine();

        var strategy = UserFilterFactory.Create("department", dept!);
        var processor = new UserFilterProcessor(strategy);

        var filtered = processor.Apply(_repo.GetAll());
        PrintUserList(filtered);
    }

    private void SearchUserMenu()
    {
    Console.WriteLine("=== Search Users ===");
    Console.WriteLine("[1] Search by Email");
    Console.WriteLine("[2] Search by First + Last Name");
    Console.WriteLine("[3] Search All Fields");
    Console.Write("Choose: ");
    var typeChoice = Console.ReadLine();

    string searchType = typeChoice switch
    {
        "1" => "email",
        "2" => "names",
        "3" => "all",
        _ => "all"  // fallback to safe universal search
    };

    Console.Write("Enter search query: ");
    var query = Console.ReadLine()!;

    var strategy = UserSearchFactory.Create(searchType);
    var processor = new UserSearchProcessor(strategy);

    var results = processor.Search(_repo.GetAll(), query);
    PrintUserList(results);
    }

    private void PrintUserList(IEnumerable<User> users)
    {
        Console.WriteLine("\n=== User List ===");
        foreach (var u in users.Take(20))
        {
            Console.WriteLine($"{u.Id,-4}: {u.FirstName} {u.LastName} - {u.Department,-12} {u.Email}");
        }
        Console.WriteLine("(showing max 20)");
    }
}
