namespace ModernWindowsApp.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using ModernWindowsApp.ViewModels;

public sealed partial class StartupPage : Page
{
    public StartupPage()
    {
        InitializeComponent();
        DataContext = App.Host.Services.GetRequiredService<StartupPageViewModel>();
    }
}
