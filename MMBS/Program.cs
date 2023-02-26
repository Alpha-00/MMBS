using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace MMBS
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Initialization();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            Application.Run(new MainMenu());
            else API.Proc(args);
            UsersClass currentuser = new UsersClass();
        }
        /// <summary>
        /// Get Data from outside
        /// </summary>
        /// <returns></returns>
        public static string GetRefference(string Password, string cmd)
        {
            switch (cmd)
            {
                case "-p": return Environment.CurrentDirectory; break;
            }
            return "";
        }
        /// <summary>
        /// Mark Init Data for the first start 
        /// Included Slashscreen
        /// </summary>
        public static void Initialization()
        {
            using (var x = new StreamWriter(Class1.GetToken("mmbsprojectFolder") + "profile_MMBS.bb"))
            {
                x.WriteLine("ver=0.22.200822");
                x.WriteLine("dir=" + Class1.GetToken("curdir"));
            }
        }
    }
    
}
