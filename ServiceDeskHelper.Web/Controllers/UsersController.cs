using Microsoft.AspNetCore.Mvc;
using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Strategies;
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
        var vm = new UsersListViewModel
        {
            SearchQuery = searchQuery,
            SelectedDepartment = department,
            Departments = allUsers
                .Select(u => u.Department)
                .Distinct()
                .OrderBy(d => d)
                .ToList()
        };

        // 🔹 Apply search
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            var strategy = new SearchByFullNameStrategy();
            var processor = new UserSearchProcessor(strategy);
            allUsers = processor.Search(allUsers, searchQuery);
        }

        // 🔹 Apply department filter
        if (!string.IsNullOrWhiteSpace(department))
        {
            allUsers = allUsers
                .Where(u => u.Department == department);
        }

        // 🔹 Sort alphabetically by last name
        vm.Users = allUsers
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName);

        return View(vm);
    }
}
