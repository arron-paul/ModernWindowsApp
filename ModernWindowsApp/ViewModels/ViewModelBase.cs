namespace ModernWindowsApp.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;

public abstract class ViewModelBase : ObservableValidator, IViewModelBase
{
    public virtual void Dispose() { }
}