namespace ServiceDeskHelper.Core.Models;

public record User //The main model for the user please note needs better annotation!
{
    public int Id { get; init; } //must be set at constructor, can't be changed
    public string FirstName { get; set;  } = "";
    public string LastName { get; set;  } = "";
    public string Department { get; set; } = "";
    public string Email { get; init; } = ""; //Same as ID, simulates UPN, so no takesie-backsies!
    public bool IsActive { get; set; } = true; // isactive to be used in the future for simple deactivation functionality

    public User() {} //empty constructor needed for MVC to be able to create uyser

    public User(int id, string firstName, string lastName, string department, string email, bool isActive = true)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Department = department;
        Email = email;
        IsActive = isActive;
    }
}