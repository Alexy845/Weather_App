using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Weather_App;

public partial class App : Application
{
    public static AppSettings? Settings { get; private set; }
    public override void Initialize()
    {
        const string optionsFilePath = "options.json";
        Settings = AppSettings.Load(optionsFilePath);
        AvaloniaXamlLoader.Load(this);
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