using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

public sealed partial class inputFullPage : Page
{
    public inputFullViewModel ViewModel
    {
        get;
    }

    public inputFullPage()
    {
        ViewModel = App.GetService<inputFullViewModel>();
        InitializeComponent();
    }
}
