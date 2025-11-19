namespace ServiceDeskHelper.Web.Models;

using ServiceDeskHelper.Core.Models;

public class UsersListViewModel
{
    public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();
    public IEnumerable<string> Departments { get; set; } = Enumerable.Empty<string>();
    public string? SelectedDepartment { get; set; }
    public string? SearchQuery { get; set; }
}
