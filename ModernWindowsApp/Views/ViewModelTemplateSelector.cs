namespace ModernWindowsApp.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ModernWindowsApp.ViewModels;

public class ViewModelTemplateSelector : DataTemplateSelector
{
    public DataTemplate StartupPageTemplate { get; set; }
    public DataTemplate MainPageTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is StartupPageViewModel)
            return StartupPageTemplate;
        if (item is MainPageViewModel)
            return MainPageTemplate;

        return base.SelectTemplateCore(item, container);
    }
}
