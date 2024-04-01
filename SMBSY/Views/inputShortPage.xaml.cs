using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

public sealed partial class inputShortPage : Page
{
    public inputShortViewModel ViewModel
    {
        get;
    }

    public inputShortPage()
    {
        ViewModel = App.GetService<inputShortViewModel>();
        InitializeComponent();
    }
}
