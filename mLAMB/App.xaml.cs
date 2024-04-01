using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
namespace mLAMB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Initialization();
        }
        public void Initialization()
        {
            if (!System.IO.Directory.Exists("C:\\BloggerSupporter\\")) System.IO.Directory.CreateDirectory("C:\\BloggerSupporter\\");
            using (var x = new StreamWriter("C:\\BloggerSupporter\\" + "profile_mLAMB.bb"))
            {
                x.WriteLine("ver=v.0.1.200823.0");
                x.WriteLine("dir=" + System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}
