using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

public sealed partial class outputPage : Page
{
    public outputViewModel ViewModel
    {
        get;
    }

    public outputPage()
    {
        ViewModel = App.GetService<outputViewModel>();
        InitializeComponent();
    }
}
