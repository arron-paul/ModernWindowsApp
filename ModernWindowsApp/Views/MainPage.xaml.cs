namespace ModernWindowsApp.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using ModernWindowsApp.ViewModels;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        DataContext = App.Host.Services.GetRequiredService<MainPageViewModel>();
    }
}
