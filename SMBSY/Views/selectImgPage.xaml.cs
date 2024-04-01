using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

public sealed partial class selectImgPage : Page
{
    public selectImgViewModel ViewModel
    {
        get;
    }

    public selectImgPage()
    {
        ViewModel = App.GetService<selectImgViewModel>();
        InitializeComponent();
    }
}
