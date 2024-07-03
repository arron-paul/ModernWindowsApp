namespace ModernWindowsApp.ViewModels;

using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

public class MainPageViewModel : ViewModelBase
{
    public IRelayCommand TestButtonTwoCommand { get; set; }

    public MainPageViewModel()
    {
        TestButtonTwoCommand = new RelayCommand(OnTestButtonOneClick, () => true);
    }

    private void OnTestButtonOneClick()
    {
        Debug.WriteLine("Button on the Main Page was pressed");
    }
}
