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
using System.Drawing;
using System.Windows.Interop;
using Newtonsoft.Json.Linq;

namespace mLAMB.Resources.Dialogs
{
    /// <summary>
    /// Interaction logic for userpassWindow.xaml
    /// </summary>
    public partial class userpassWindow : Window
    {
        private string Account_directory = "C:\\BloggerSupporter\\";
        private string Account_filename = "";
        public static string RetrieveResult = "";
        private bool remember = true;
        public userpassWindow()
        {
            InitializeComponent();
        }
        public userpassWindow(string name,string submitfile)
        {
            InitializeComponent();
            this.Title = name;
            Account_filename = submitfile;
            
        }
        public static Bitmap drawstring(int width, int height, string text)
        {
            Bitmap result = new Bitmap(width, height);
            Graphics cache = Graphics.FromImage(result);
            RectangleF rectF = new RectangleF(0, 0, width, height);
            cache.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            cache.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            cache.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            cache.Clear(System.Drawing.Color.FromArgb(255, 255, 255, 255));
            cache.DrawString(text, new Font("Segoe UI", 8), System.Drawing.Brushes.Black, rectF);
            cache.Flush();
            return result;
        }
        private BitmapSource Bitmap2BitmapImage(Bitmap bmp)
        {
            
            var cache = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
   bmp.GetHbitmap(),
   IntPtr.Zero,
   System.Windows.Int32Rect.Empty,
   BitmapSizeOptions.FromWidthAndHeight(bmp.Width, bmp.Height));
            return cache;
        }
        Dictionary<string, Bitmap> Bitmapcache = new Dictionary<string, Bitmap>() 
        {
            {"Username", drawstring(263,23,"Username") },
            {"Password", drawstring(263,23,"Password") }
        };
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(boxUsername.Text))
            {
                var cache = new ImageBrush();
                cache.ImageSource = Bitmap2BitmapImage(Bitmapcache["Username"]);
                cache.AlignmentX = AlignmentX.Left;
                cache.AlignmentY = AlignmentY.Center;
                cache.Stretch = Stretch.None;
                boxUsername.Background = cache;
            }
            else
            {
                boxUsername.Background = null;
            }
        }

        private void boxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(boxUsername.Text))
            {
                var cache = new ImageBrush();
                cache.ImageSource = Bitmap2BitmapImage(Bitmapcache["Password"]);
                cache.AlignmentX = AlignmentX.Left;
                cache.AlignmentY = AlignmentY.Center;
                cache.Stretch = Stretch.None;
                boxPassword.Background = cache;
            }
            else
            {
                boxPassword.Background = null;
            }
        }

        private void boxUsername_Loaded(object sender, RoutedEventArgs e)
        {
            var cache = new ImageBrush();
            cache.ImageSource = Bitmap2BitmapImage(Bitmapcache["Username"]);
            cache.AlignmentX = AlignmentX.Left;
            cache.AlignmentY = AlignmentY.Center;
            cache.Stretch = Stretch.None;
            boxUsername.Background = cache;
        }

        private void boxPassword_Loaded(object sender, RoutedEventArgs e)
        {
            var cache = new ImageBrush();
            cache.ImageSource = Bitmap2BitmapImage(Bitmapcache["Password"]);
            cache.AlignmentX = AlignmentX.Left;
            cache.AlignmentY = AlignmentY.Center;
            cache.Stretch = Stretch.None;
            boxPassword.Background = cache;
        }

        private void butRemember_Checked(object sender, RoutedEventArgs e)
        {
            
            remember = butRemember.IsChecked??true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JObject cache = new JObject();
            cache.Add("username", boxUsername.Text);
            cache.Add("password", boxPassword.Text);
            RetrieveResult = cache.ToString(Newtonsoft.Json.Formatting.None);
            DialogResult = remember;
            if (remember)
            {
                if (null!=Account_filename)
                System.IO.File.WriteAllText(Account_directory+Account_filename,cache.ToString());
            }
        }
    }
}
