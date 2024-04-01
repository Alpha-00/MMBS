using Microsoft.UI.Xaml.Controls;

using SMBSY.ViewModels;

namespace SMBSY.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class previewPage : Page
{
    public previewViewModel ViewModel
    {
        get;
    }

    public previewPage()
    {
        ViewModel = App.GetService<previewViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
