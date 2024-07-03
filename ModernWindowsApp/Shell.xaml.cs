namespace ModernWindowsApp;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using ModernWindowsApp.Views;

public sealed partial class Shell : Window
{
    public Shell()
    {
        this.InitializeComponent();
        NavigateToHomePage();
    }

    private void NavigateToHomePage()
    {
        var homePage = App.Host.Services.GetRequiredService<StartupPage>();
        MainFrame.Navigate(homePage.GetType());
    }

    public void NavigateToAnotherPage()
    {
        var anotherPage = App.Host.Services.GetRequiredService<MainPage>();
        MainFrame.Navigate(anotherPage.GetType());
    }
}
