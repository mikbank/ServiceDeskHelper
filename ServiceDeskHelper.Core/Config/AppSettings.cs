namespace ServiceDeskHelper.Core.Config;
//Application config loaded once during startup - Singleton pattern to demonstrate initializaion and locking
// only one Appsettings instance can exist, and it is initialized in app startup 
public sealed class AppSettings
{
    private static AppSettings? _instance;
    private static readonly object _lock = new();

    public string RepositoryMode { get; }
    public string CsvPath { get; }

    private AppSettings(string repoMode, string csvPath)
    {
        RepositoryMode = repoMode;
        CsvPath = csvPath;
    }

    public static void Initialize(string repoMode, string csvPath)
    {
        lock (_lock)
        {
            if (_instance == null)
                _instance = new AppSettings(repoMode, csvPath);
        }
    }

    public static AppSettings Instance =>
        _instance ?? throw new InvalidOperationException("AppSettings not initialized.");
}
