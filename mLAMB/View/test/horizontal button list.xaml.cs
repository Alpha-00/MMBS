using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mLAMB.View.test
{
    /// <summary>
    /// Interaction logic for horizontal_button_list.xaml
    /// </summary>
    public partial class horizontal_button_list : UserControl
    {
        public horizontal_button_list()
        {
            InitializeComponent();
        }
        public void onButQuickclick(object sender, RoutedEventArgs e)
        {
            
            //buttonExe.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}
