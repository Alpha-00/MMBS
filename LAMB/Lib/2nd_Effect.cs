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
namespace LAMB.Lib
{
    public class ForTesting
    {

    }
    public class Effect
    {
        public class Transition
        {
            public class Swaper//Two Panel
            {
                DependencyObject panel1;
                DependencyObject panel2;
                public enum EffectCode {Fade1=0}
                public EffectCode effect = 0;
                public int duration;
                public int code = 0;//To check what is showed
                DoubleAnimation[] animator;
                public Storyboard storyboard;
                Window window;
                /// <summary>
                /// 
                /// </summary>
                /// <param name="panel1"></param>
                /// <param name="panel2"></param>
                /// <param name="effect"></param>
                /// <param name="time">In milisecond</param>
                public Swaper(Window window, DependencyObject panel1, DependencyObject panel2, EffectCode effect, int duration)
                {
                    this.panel1 = panel1;
                    this.panel2 = panel2;
                    this.effect = effect;
                    this.duration = duration;
                    this.window = window;
                    Fade1_PrepairStoryboard();
                }
                public void Arrange()
                {
                    ((StackPanel)panel2).Margin = ((StackPanel)panel1).Margin;
                    ((StackPanel)panel2).Opacity = 0;
                    ((StackPanel)panel2).Visibility = Visibility.Collapsed;
                }
                public void Fade1_PrepairStoryboard()
                {
                    storyboard = new Storyboard();
                    animator = new DoubleAnimation[2] {new DoubleAnimation(),new DoubleAnimation()};
                    //Animation For panel1
                    animator[0] = new DoubleAnimation(code==0?1:0, code==0?0:1, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[0], panel1);
                    Storyboard.SetTargetProperty(animator[0], new PropertyPath("Opacity"));
                    storyboard.Children.Add(animator[0]);
                    
                    //Animation For panel2
                    animator[1] = new DoubleAnimation(code == 0 ? 0 : 1, code == 0 ? 1 : 0, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[1], panel2);
                    Storyboard.SetTargetProperty(animator[1], new PropertyPath("Opacity"));
                    storyboard.Children.Add(animator[1]);

                    //Delayer
                    if (code == 0)
                        animator[1].BeginTime = TimeSpan.FromMilliseconds(duration * 1.1);
                    else animator[0].BeginTime = TimeSpan.FromMilliseconds(duration * 1.1);
                }
                public void Start()
                {
                    storyboard.Begin(window);
                    if (code == 0)
                    { ((StackPanel)panel2).Visibility = Visibility.Visible; }
                    else //animator[1].Completed += (s, ea) => 
                    { ((StackPanel)panel2).Visibility = Visibility.Collapsed; };
                    code = (code + 1) % 2;
                    Fade1_PrepairStoryboard();
                }

            }
            /// <summary>
            /// For two windows
            /// </summary>
            public class Morph
            {
                DependencyObject window1;
                DependencyObject window2;
                public enum EffectCode { Morph1 = 0 }
                public EffectCode effect = 0;
                public int duration;
                //public int code = 0;//To check what is showed
                DoubleAnimation[] animator;
                public Storyboard storyboard;
                /// <summary>
                /// [0]: Width <br/>
                /// [1]: Height <br/>
                /// [2]: Opacity <br/>
                /// </summary>
                public int[] win1 = new int[3] { 0,0,0 };
                //Window window;
                /// <summary>
                /// 
                /// </summary>
                /// <param name="window1"></param>
                /// <param name="window2"></param>
                /// <param name="effect"></param>
                /// <param name="time">In milisecond</param>
                public Morph(DependencyObject window1, DependencyObject window2, EffectCode effect, int duration)
                {
                    this.window1 = window1;
                    this.window2 = window2;
                    this.effect = effect;
                    this.duration = duration;
                    Morph1_RepairStoryboard();
                }
                public void Arrange()
                {
                    
                }
                public void Morph1_RepairStoryboard()
                {
                    storyboard = new Storyboard();
                    
                    animator = new DoubleAnimation[5] { new DoubleAnimation(), new DoubleAnimation(), new DoubleAnimation(), new DoubleAnimation(), new DoubleAnimation() };
                    //Animation For Width
                    animator[0] = new DoubleAnimation(((Window)window1).Width, ((Window)window2).Width, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[0], window1);
                    Storyboard.SetTargetProperty(animator[0], new PropertyPath("Width"));
                    storyboard.Children.Add(animator[0]);
                    
                    //Animation For Height
                    animator[1] = new DoubleAnimation(((Window)window1).Height, ((Window)window2).Height, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[1], window2);
                    Storyboard.SetTargetProperty(animator[1], new PropertyPath("Height"));
                    storyboard.Children.Add(animator[1]);

                    //Animation For Opacity Grid
                    animator[2] = new DoubleAnimation(1,0, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[2], ((MainWindow)window1).gridMain);
                    Storyboard.SetTargetProperty(animator[2], new PropertyPath("Opacity"));
                    storyboard.Children.Add(animator[2]);

                    //Animation For Width
                    animator[3] = new DoubleAnimation(((Window)window1).Left, (System.Windows.SystemParameters.PrimaryScreenWidth-((Window)window2).Width)/2, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[3], window1);
                    Storyboard.SetTargetProperty(animator[3], new PropertyPath("Left"));
                    storyboard.Children.Add(animator[3]);

                    //Animation For Height
                    animator[4] = new DoubleAnimation(((Window)window1).Top, (System.Windows.SystemParameters.PrimaryScreenHeight - ((Window)window2).Height) / 2, new Duration(TimeSpan.FromMilliseconds(duration)));
                    Storyboard.SetTarget(animator[4], window1);
                    Storyboard.SetTargetProperty(animator[4], new PropertyPath("Top"));
                    storyboard.Children.Add(animator[4]);

                }
                public void Start()
                {
                    storyboard.Begin();
                    /*if (code == 0)
                    { ((StackPanel)panel2).Visibility = Visibility.Visible; }
                    else //animator[1].Completed += (s, ea) => 
                    { ((StackPanel)panel2).Visibility = Visibility.Collapsed; };
                    code = (code + 1) % 2;*/
                    Morph1_RepairStoryboard();
                }
            }
        }
    }
}
