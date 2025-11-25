using System.Text;

public class CsvUserGenerator 
//csv generator to make a list of random users, used if csv is not available for, just run dotnet run --project .\ServiceDeskHelper.Sandbox\servicedeskhelper.sandbox.csproj
//Uses a list for firstnames, lastnames and departments, to randomly generate users - this is pretty brute-force but works for this project.
{
    private readonly string[] firstNames =
    {
        "Emma", "Oliver", "Noah", "Ava", "William", "Sophia", "Lucas", "Isabella", "Liam", "Mia",
        "Elias", "Ella", "Freja", "Oscar", "Ida", "Alma", "Magnus", "Laura", "Emil", "Clara",
        "Karl", "Nora", "Mikkel", "Lærke", "Anton", "Sara", "Mathias", "Anna", "Victor", "Sofie"
    };

    private readonly string[] lastNames =
    {
        "Jensen", "Nielsen", "Hansen", "Pedersen", "Andersen", "Christensen", "Larsen", "Sørensen",
        "Rasmussen", "Jørgensen", "Petersen", "Madsen", "Kristensen", "Olsen", "Thomsen", "Christiansen",
        "Poulsen", "Johansen", "Knudsen", "Mortensen", "Møller", "Jakobsen", "Henriksen", "Iversen",
        "Simonsen", "Andreasen", "Jeppesen", "Clausen", "Lund", "Eriksen"
    };

    private readonly string[] departments =
    {
        "IT", "Support", "Finance", "HR", "Sales", "R&D", "Management"
    };

    private readonly Random random = new(); //instantiate random, for use in user generation

    public string GenerateCsv(int count)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id,FirstName,LastName,Department,Email");

        for (int i = 1; i <= count; i++)
        {
            var firstName = firstNames[random.Next(firstNames.Length)];
            var lastName = lastNames[random.Next(lastNames.Length)];
            var department = departments[random.Next(departments.Length)];
            var email = $"{Guid.NewGuid().ToString("N")[..5]}@eksamen.com"; 
            var isActive = true; //always set to true for ease of demonstration

            sb.AppendLine($"{i},{firstName},{lastName},{department},{email},{isActive}");
        }

        return sb.ToString();
    }
}
