using System.Text;

public class CsvUserGenerator
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

    private readonly Random random = new();

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

            sb.AppendLine($"{i},{firstName},{lastName},{department},{email}");
        }

        return sb.ToString();
    }
}
