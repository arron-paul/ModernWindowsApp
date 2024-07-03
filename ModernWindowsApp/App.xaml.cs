namespace ModernWindowsApp;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using ModernWindowsApp.ViewModels;
using ModernWindowsApp.Views;
using Serilog;
using System;

public partial class App : Application
{
    public static IHost Host { get; private set; }

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
            // Initialise the Host
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .UseSerilog()
                .ConfigureServices((context, services) =>
                {
                    // Register Services
                    // ...

                    // Register ViewModels
                    services.AddSingleton<RootPageViewModel>(provider => new(
                        startupPageViewModel: provider.GetRequiredService<StartupPageViewModel>(),
                        mainPageViewModel: provider.GetRequiredService<MainPageViewModel>()
                    ));
                    services.AddSingleton<StartupPageViewModel>();
                    services.AddSingleton<MainPageViewModel>();

                    // Register Views
                    services.AddSingleton<RootPage>();
                    services.AddSingleton<StartupPage>();
                    services.AddSingleton<MainPage>();

                    // Register Shell
                    services.AddSingleton<Shell>();
                }
            ).Build();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "The application terminated unexpectedly");
            Log.CloseAndFlush();
            throw;
        }
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        try
        {
            Host.Start();
            Log.Information("Started Host");

            var window = Host.Services.GetRequiredService<Shell>();
            window.ExtendsContentIntoTitleBar = true;
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
