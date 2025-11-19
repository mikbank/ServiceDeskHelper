using System.Text;

int userCount = 100; // 👈 change this to however many users you want

var generator = new CsvUserGenerator();
var csv = generator.GenerateCsv(userCount);

// Write file
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.csv");
File.WriteAllText(filePath, csv, Encoding.UTF8);

Console.WriteLine($"✅ Generated {userCount} users and saved to: {filePath}");