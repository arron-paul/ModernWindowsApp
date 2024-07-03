namespace ModernWindowsApp.ViewModels;

using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

public class StartupPageViewModel : ViewModelBase
{
    public IRelayCommand TestButtonOneCommand { get; set; }

    public StartupPageViewModel()
    {
        TestButtonOneCommand = new RelayCommand(OnTestButtonOneClick, () => true);
    }

    private void OnTestButtonOneClick()
    {
        Debug.WriteLine("Button on the Startup Page was pressed");
    }
}