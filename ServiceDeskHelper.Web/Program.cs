using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IUserRepository>(provider =>
{
    // Choose a CSV path appropriate for your environment
    var path = @"C:\Users\mikh\OneDrive - NIRAS\Dokumenter\Akademi i IT\Avanceret Programmering\ServiceDesk Helper\users.csv";

    return new DebugUserRepository(path);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
