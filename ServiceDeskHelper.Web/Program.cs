using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Services;
using ServiceDeskHelper.Core.Config;

var builder = WebApplication.CreateBuilder(args);
// Register MVC controllers + views
builder.Services.AddControllersWithViews();

// Register Authorization (required if using UseAuthorization())
builder.Services.AddAuthorization();

// Add services to the container.
var repoMode = builder.Configuration["App:RepositoryMode"] ?? "Static";
var csvFileName  = builder.Configuration["App:CsvPath"] ?? "users.csv";
var solutionRoot = Directory.GetParent(builder.Environment.ContentRootPath)!.FullName; //fetches root adress of project, to find csv file, would never be done in a prod scenario
var csvFullPath = Path.Combine(solutionRoot, csvFileName);
AppSettings.Initialize(repoMode, csvFullPath);

// Register the Singleton for DI (optional but nice)
builder.Services.AddSingleton(AppSettings.Instance);

builder.Services.AddSingleton<IUserRepository>(provider => //Dep injection Singleton - to make sure that the repo is a single instance this way we have persisten data
{
    var settings = AppSettings.Instance; //fetches instance

    return settings.RepositoryMode switch
    {
        "Csv" => new CSVUserRepository(settings.CsvPath),
        "Static" => new StaticUserRepository(),
        _ => throw new Exception($"Unknown RepositoryMode: {settings.RepositoryMode}")
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts. CHECK THIS
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
