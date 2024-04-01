using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

public sealed partial class miscPage : Page
{
    public miscViewModel ViewModel
    {
        get;
    }

    public miscPage()
    {
        ViewModel = App.GetService<miscViewModel>();
        InitializeComponent();
    }
}
