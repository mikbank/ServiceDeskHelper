using Microsoft.AspNetCore.Mvc;
using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Factories;
using ServiceDeskHelper.Core.Services;
using ServiceDeskHelper.Web.Models;

public class UsersController : Controller
{
    private readonly IUserRepository _repo;

    public UsersController(IUserRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index(string? searchQuery, string? department)
    {
        var allUsers = _repo.GetAll();

        // 🔹 Create the ViewModel
        var viewmodel = new UsersListViewModel
        {
            SearchQuery = searchQuery, 
            SelectedDepartment = department,
            Departments = allUsers //here distinct departments are found via LINQ method syntax
                .Select(u => u.Department)
                .Distinct()
                .OrderBy(d => d)
                .ToList()
        };

        //  Search functionality
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            var strategy = UserSearchFactory.Create("all"); //searches all fields
            var processor = new UserSearchProcessor(strategy);
            allUsers = processor.Search(allUsers, searchQuery); 
        }

        // if department filter is set, apply it
        if (!string.IsNullOrWhiteSpace(department))
        {
            allUsers = allUsers
                .Where(u => u.Department == department);
        }

        // Sorts by last name, then first name
        viewmodel.Users =
            from u in allUsers
            orderby u.LastName, u.FirstName
            select u;

        return View(viewmodel);
    }
}
