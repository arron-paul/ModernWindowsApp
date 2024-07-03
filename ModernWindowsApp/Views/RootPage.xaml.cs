// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ModernWindowsApp.Views;
using Microsoft.UI.Xaml.Controls;
using ModernWindowsApp.ViewModels;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class RootPage : Page
{
    public RootPage()
    {
        this.InitializeComponent();
        this.DataContext = new RootPageViewModel(
            new StartupPageViewModel(),
            new MainPageViewModel()
        );
    }
}
