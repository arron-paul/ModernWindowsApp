namespace ModernWindowsApp.ViewModels
{
    using CommunityToolkit.Mvvm.Input;
    using Serilog;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public RelayCommand ButtonClick { get; private set; }
        public MainWindowViewModel()
        {
            ButtonClick = new RelayCommand(OnButtonClick);
            Log.Information("MainWindowViewModel initiated");
        }

        private void OnButtonClick()
        {
            Log.Information("Button clicked");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
