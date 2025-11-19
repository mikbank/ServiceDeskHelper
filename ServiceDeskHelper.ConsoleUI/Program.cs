
using ServiceDeskHelper.Core.Interfaces;
using ServiceDeskHelper.Core.Services;
using ServiceDeskHelper.ConsoleUI.UI;

var csvPath = @"C:\FULL\PATH\TO\users.csv";

// Create your repository from Core
IUserRepository repo = new DebugUserRepository(csvPath);

// Create your console UI (in this project)
var ui = new ConsoleUI(repo);

// Run it
ui.Run();