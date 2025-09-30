using Avalonia;
using System;

namespace KomaruClicker;

class Program
{
    public static int clicks { get; private set; }

    public static void Click()
    {
        clicks++;
    }

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        clicks = GameData.Load();
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    }


    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
