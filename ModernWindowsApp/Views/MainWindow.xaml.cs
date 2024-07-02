// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ModernWindowsApp
{
    using Microsoft.UI.Xaml;
    using ModernWindowsApp.ViewModels;

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowViewModel { get; }

        public MainWindow()
        {
            this.InitializeComponent();
        }
    }
}
