using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Weather_App;

public class App : Application
{
    public static AppSettings? Settings { get; private set; }

    public override void Initialize()
    {
        const string optionsFilePath = "options.json";
        Settings = AppSettings.Load(optionsFilePath);
        
        base.Initialize();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}