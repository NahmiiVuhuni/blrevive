using Avalonia;
using Avalonia.Logging.Serilog;

// Avalonia configuration, don't remove; also used by visual designer.
static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<Launcher.UI.App>()
        .UsePlatformDetect()
        .LogToDebug();

// if cli arguments provided, run app in cli mode
if(args.Length > 0)
{
    Launcher.CLI.App.Run(args);
}
// else start UI
else
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
}