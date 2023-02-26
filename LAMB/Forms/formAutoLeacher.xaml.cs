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
using System.Windows.Shapes;
using LAMB.Lib;

namespace LAMB.Forms
{
    /// <summary>
    /// Interaction logic for formAutoLeacher.xaml
    /// </summary>
    public partial class formAutoLeacher : Window
    {
        public formAutoLeacher()
        {
            InitializeComponent();
        }

        private void butPlatinmods_Click(object sender, RoutedEventArgs e)
        {

        }

        private void butAct_Click(object sender, RoutedEventArgs e)
        {
            progbarMarquee.Visibility = Visibility.Visible;
            Lib.Processor.AutoProcessor.processLink processor = new Lib.Processor.AutoProcessor.processLink(boxLink.Text);
            processor.Start();
        }
    }
}
