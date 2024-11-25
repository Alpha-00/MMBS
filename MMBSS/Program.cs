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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
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
            if (System.Net.ServicePointManager.DefaultConnectionLimit < 8) System.Net.ServicePointManager.DefaultConnectionLimit = 8;
            using (var x = new StreamWriter(Class1.GetToken("mmbsprojectFolder") + "profile_MMBS.bb"))
            {
                x.WriteLine("ver=0.22.200822");
                x.WriteLine("dir=" + Class1.GetToken("curdir"));
            }
            // Generate default page sciban
            var pagePath = Class1.GetToken("mmbsprojectFolder") + "template\\page.scriban-html";
            var titlePath = Class1.GetToken("mmbsprojectFolder") + "template\\title.scriban-html";

            Model.PostForm.PostFormGeneralCustom.installDefaultTemplate(new Model.PostForm.PostFormGeneralCustom.defaultTemplate[]
            {
                Model.PostForm.PostFormGeneralCustom.defaultTemplate.page,
                Model.PostForm.PostFormGeneralCustom.defaultTemplate.title
            },
            (File.Exists(pagePath)&& File.Exists(titlePath))?
            new DateTime[]
            {
                File.GetLastWriteTime(pagePath),
                File.GetLastWriteTime(titlePath)
            }:null
            );
        }
    }
    
}
