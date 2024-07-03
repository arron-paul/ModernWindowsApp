namespace ModernWindowsApp.ViewModels;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class RootPageViewModel : INotifyPropertyChanged
{
    public IEnumerable<ViewModelBase> ViewModels { get; set; }

    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    public RootPageViewModel(
        StartupPageViewModel startupPageViewModel,
        MainPageViewModel mainPageViewModel)
    {
        ViewModels = new List<ViewModelBase>()
        {
            startupPageViewModel, mainPageViewModel,
        };

        CurrentViewModel = ViewModels.First();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

}
