namespace ModernWindowsApp.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ModernWindowsApp.ViewModels;

public sealed partial class StartupPage : Page
{
    public StartupPage()
    {
        InitializeComponent();
        DataContext = App.Host.Services.GetRequiredService<StartupPageViewModel>();
    }

    private void OnNavigateButtonClick(object sender, RoutedEventArgs e)
    {
        var shell = App.Host.Services.GetRequiredService<Shell>();
        shell.NavigateToAnotherPage();
    }
}
