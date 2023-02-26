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
using System.Windows.Media.Animation;
using System.Diagnostics;
namespace LAMB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Lib.Effect.Transition.Swaper anim1;//between panelS1 & panelS2
        Lib.Effect.Transition.Morph anim2;//between form
        /// <summary>
        /// Lock Form Style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Initialized(object sender, EventArgs e)
        {
            /*panelS2.Margin = panelS1.Margin;
            panelS2.Opacity = 0;
            panelS2.Visibility = Visibility.Collapsed;*/
            anim1 = new Lib.Effect.Transition.Swaper(this,panelS1, panelS2, Lib.Effect.Transition.Swaper.EffectCode.Fade1, 200);
            anim1.Arrange();
        }

        private void labelTitle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Anim(200);
            void Anim(int time)
            {
                if (panelS2.Opacity == 0)
                { labelTitle.HorizontalContentAlignment = HorizontalAlignment.Right; labelTitle.Content = "ChangeLogs"; labelTitle.FontSize = 20; }
                else
                { labelTitle.HorizontalContentAlignment = HorizontalAlignment.Left; labelTitle.Content = "LAMB"; labelTitle.FontSize = 48; };
                DoubleAnimation labelTitle_anim = new DoubleAnimation(anim1.code == 0 ? 0 : 73, panelS2.Opacity == 0 ? 73 : 0, new Duration(TimeSpan.FromMilliseconds(time * 2)));
                Storyboard.SetTargetName(labelTitle_anim, "animTitle");
                Storyboard.SetTargetProperty(labelTitle_anim, new PropertyPath("X"));
                anim1.storyboard.Children.Add(labelTitle_anim);
                anim1.Start();
            }
        }

        private void butAutoForm_Click(object sender, RoutedEventArgs e)
        {
            Forms.formAutoLeacher form = new Forms.formAutoLeacher();
            //anim2 = new Class.Effect.Transition.Morph(this, form, Class.Effect.Transition.Morph.EffectCode.Morph1, 500);
            //anim2.Start();
            
            this.Hide();
            form.ShowDialog();
        }
    }
}
