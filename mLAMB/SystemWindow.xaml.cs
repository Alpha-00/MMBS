using Newtonsoft.Json.Linq;
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

namespace mLAMB
{
    //Todo: Add Setting Menu; Add MMBS ping; Add more information; Restyle preset
    /// <summary>
    /// Interaction logic for SystemWindow.xaml
    /// </summary>
    public partial class SystemWindow : Window
    {
        public SystemWindow()
        {
            InitializeComponent();
            Reformatchangelogs();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitSettingItem();
        }
        public void Reformatchangelogs()
        {
            FlowDocument cache = new FlowDocument();
            //Insert tab per line
            int lasttab = 0;
            Color default_color = Color.FromArgb(255,255,255,255);
            Color offlinemods_maincolor = Color.FromRgb(255, 180, 22);
            //use to check the last block
            string versionname = this.textVersion.Content.ToString().Remove(this.textVersion.Content.ToString().IndexOf(" "));

            Dictionary<string, Func<Paragraph>> preset = new Dictionary<string, Func<Paragraph>>()
            /*{
                {"normal",(()=>new Paragraph())},
                {"title",set(18.00, offlinemods_maincolor, default_color, 0); },
                {"head1",set(18.00,Color.FromRgb(0,0,0),default_color,20) },
                {"head2",set(17.00,Color.FromRgb(10,10,10),default_color,40) }
            };*/
            {   {"normal",new Func<Paragraph>(()=>new Paragraph())},
                {"title",new Func<Paragraph>(()=>set(18.00, offlinemods_maincolor, default_color, 0))},
                {"head1",new Func<Paragraph>(()=>set(18.00,Color.FromRgb(0,0,0),default_color,20))},
                {"head2",new Func<Paragraph>(()=>set(17.00,Color.FromRgb(10,10,10),default_color,40))},
                {"head2-des",new Func<Paragraph>(()=>set(14.00,Color.FromRgb(40,40,40),default_color,65))}
            };
            foreach (var x in boxChangeLogs.Document.Blocks)
            {
                var y = new TextRange(x.ContentStart, x.ContentEnd);
                Paragraph z = new Paragraph();
                z.LineHeight = 4.0;
                if (string.IsNullOrEmpty(y.Text)) return; 
                switch (y.Text[0])
                {
                    case 'v':
                        {
                            z = preset["title"]();
                            lasttab = 0;
                            z.Inlines.Add(new Bold(new Run(y.Text)));
                            cache.Blocks.Add(z);
                            
                        }
                        break;
                    case '+':
                        {
                            z = preset["head1"]();
                            lasttab = 1;
                            z.Inlines.Add(new Italic(new Run(y.Text)));
                            cache.Blocks.Add(z);
                        }break;
                    case '-':
                        {
                            
                            lasttab = 2;
                            if (y.Text.Contains("{") && y.Text.Contains("}"))
                            {
                                JObject json = JObject.Parse(y.Text.Substring(y.Text.IndexOf("{")));
                                //Name
                                z = preset["head2"]();
                                z.Inlines.Add(new Run(y.Text.Remove(y.Text.IndexOf("{")) + json["name"]));
                                cache.Blocks.Add(z);
                                //Description
                                z = preset["head2-des"]();
                                z.Inlines.Add(new Run(json["description"].ToString()));
                                cache.Blocks.Add(z);
                            }
                            else
                            {
                                z = preset["head2"]();
                                z.Inlines.Add(new Run(y.Text));
                                cache.Blocks.Add(z);
                            }
                        }
                        break;
                    default: {
                            z.Inlines.Add(new Run(y.Text));
                            cache.Blocks.Add(z); } break;
                }
            }
            boxChangeLogs.Document = cache;
            Paragraph set(double fontsize,Color color,Color background, double indent)
            {
                var temp = new Paragraph();
                temp.FontSize = fontsize;
                temp.Foreground = new System.Windows.Media.SolidColorBrush(color);
                temp.Background = background == Color.FromArgb(255,255,255,255)?null:new System.Windows.Media.SolidColorBrush(background);
                temp.TextIndent = indent;
                temp.LineHeight = 4.0;
                return temp;
            }
        }
        public static Dictionary<Core.Constanter.setConProcLevel, string> conprocLabel = new Dictionary<Core.Constanter.setConProcLevel, string>()
        {
            {Core.Constanter.setConProcLevel.nocontrol, "Nothing" },
            {Core.Constanter.setConProcLevel.fullcontrol, "Full" }
        };
        //This will be the cache for the switch back to enum
        public Dictionary<string, string> boxconprocDisplayText = new Dictionary<string, string>(); 
        public void InitSettingItem()
        {
            //!Control Process Level
            {
                //Get item from enum
                string[] cache = Enum.GetNames(typeof(Core.Constanter.setConProcLevel));
                foreach (var x in cache)
                {
                    boxconprocDisplayText.Add(conprocLabel[(Core.Constanter.setConProcLevel)Enum.Parse(typeof(Core.Constanter.setConProcLevel), x)], x);
                    var xx = new ComboBoxItem();
                    xx.Content = boxconprocDisplayText.Last().Key;
                    setitemChooseConProc_select.Items.Add(xx);
                }
                //Setback value
                setitemChooseConProc_select.SelectedIndex = Array.IndexOf(cache,((Core.Constanter.setConProcLevel)Properties.Settings.Default.setConProc).ToString());
                
            }

            //!Open Webpage in Browser
            {
                setitemSwitchFireWeb_switch.IsChecked = Properties.Settings.Default.setFireWeb;
            }
            
            
        }
        private void boxChangeLogs_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void boxChangeLogs_Initialized(object sender, EventArgs e)
        {
            
        }

        private void boxChangeLogs_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void setitemChooseConProc_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(setitemChooseConProc_select.Text))
            {
                
                string cache = boxconprocDisplayText[((ComboBoxItem)e.AddedItems[0]).Content.ToString()];
                Core.Constanter.setConProcLevel cache2 = (Core.Constanter.setConProcLevel)Enum.Parse(typeof(Core.Constanter.setConProcLevel), cache);
                int cache3 = (int)cache2;
                Properties.Settings.Default.setConProc = cache3;
                Properties.Settings.Default.Save();
            }
        }

        private void setitemSwitchFireWeb_switch_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.setFireWeb = setitemSwitchFireWeb_switch.IsChecked?? Properties.Settings.Default.setFireWeb;
            Properties.Settings.Default.Save();
        }
    }
}
