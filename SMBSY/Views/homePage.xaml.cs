using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

public sealed partial class homePage : Page
{
    public homeViewModel ViewModel
    {
        get;
    }

    public homePage()
    {
        ViewModel = App.GetService<homeViewModel>();
        InitializeComponent();
    }
}
