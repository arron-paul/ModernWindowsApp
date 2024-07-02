// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ModernWindowsApp
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.UI.Xaml;
    using ModernWindowsApp.ViewModels;
    using Serilog;
    using System;

    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            this.InitializeComponent();

            // Catch exceptions that propagate upwards
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                Log.Fatal(eventArgs.ExceptionObject as Exception, "An unhandled exception occurred.");
                Log.CloseAndFlush();
            };

            // Configure Serilog
            Log.Logger = new LoggerConfiguration().WriteTo.File(
                path: "log.txt",
                outputTemplate: "{Timestamp} [{Level:u3}] {Message:lj} {Exception}{NewLine}",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose,
                levelSwitch: new Serilog.Core.LoggingLevelSwitch(Serilog.Events.LogEventLevel.Verbose),
                rollingInterval: RollingInterval.Infinite
            ).CreateLogger();

            try
            {
                // Initialise the host
                host = CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application terminated unexpectedly");
                Log.CloseAndFlush();
                throw;
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureServices((context, services) =>
            {
                // Register services
                services.AddSingleton<MainWindowViewModel>();
            });


        private Window window;

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            try
            {
                host.Start();
                Log.Information("Started host");

                window = new MainWindow();
                window.ExtendsContentIntoTitleBar = true;

                // todo: figure out how to set window height in WinUI 3
                // Use 'this' rather than 'window' as variable if this is about the current window.
                IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 480, Height = 800 });

                window.Activate();
                Log.Information("Activated main window");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application terminated unexpectedly");
                Log.CloseAndFlush();
                throw;
            }

        }
    }
}
