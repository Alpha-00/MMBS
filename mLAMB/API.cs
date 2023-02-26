using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
namespace mLAMB
{
    public class API
    {
        public class InteractDebugger
        {
            public JObject dat = new JObject();
            public int tmp = 0;
            //Code to define the name of log file
            public string code = "";
            public InteractDebugger(string code)
            {
                this.code = code;
                //if (System.IO.File.Exists($"C:\\BloggerSupporter\\ILogs{code}.txt"))
                //    dat = JObject.Parse(System.IO.File.ReadAllText($"C:\\BloggerSupporter\\ILogs{code}.txt").Trim());
            }
            public void Logs(object obj)
            {
               // JToken cache = typeof(obj)=="string"?(string)obj:JObject.FromObject(obj);
                dat.Add(DateTime.Now.ToString("Log at {H:mm:ss fffffff} x")+(tmp++),(string)obj);
                
            }
            public void AppendRegist(string name, string description)
            {
                
                dat.Add(name, description);
                try
                {
                    dat.Add("startAt", Environment.CurrentDirectory);
                }
                finally
                {

                }
            }
            public void Save()
            {
                this.Logs("----");
                System.IO.File.WriteAllText($"C:\\BloggerSupporter\\ILogs{code}.txt",dat.ToString());
            }
        }
    }
    public static class SystemAlt
    {
        public static bool Windows_Forms_Clipboard_SetText(string dat)
        {
            bool res = false;
            int winner = 0;
            string ERROR = "";
            //Method 1: SetData
            try
            {
                winner++;
                System.Windows.Clipboard.SetData(DataFormats.UnicodeText, dat);
                res = true;
                return res;
            }
            catch (Exception e)
            {
                ERROR += $"{winner} : {e.Message}\n";
            }
            //Method 2: SetDataObject
            try
            {
                winner++;
                System.Windows.Clipboard.SetDataObject(dat, true);
                res = true;
                return res;
            }
            catch (Exception e)
            {
                ERROR += $"{winner} : {e.Message}\n";
            }
            //Method 3: Normal SetText Couple Time with offset
            winner++;
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    System.Windows.Clipboard.SetText(dat);
                    res = true;
                    return res;
                }
                catch (Exception e)
                {
                    ERROR += $"{winner}.{i} : {e.Message}\n";
                }
                Task.Delay(500);
            }
            //Method 3: Find what suck the process
            try
            {
                var proc = ProcessHoldingClipboard();
                if (proc == null) return true;
                ERROR += "no winner : \n"
                    + $"process_name: {proc.ProcessName}\n"
                    + $"window_title: {proc.MainWindowTitle}\n";
            }
            catch (Exception)
            {

            }
            MessageBox.Show("Clipboard Error\n"+ERROR);
            return false;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        ///-----------------------------------------------------------------------------
        /// <summary>
        /// Gets the Process that's holding the clipboard
        /// </summary>
        /// <returns>A Process object holding the clipboard, or null</returns>
        ///-----------------------------------------------------------------------------
        public static Process ProcessHoldingClipboard()
        {
            Process theProc = null;

            IntPtr hwnd = GetOpenClipboardWindow();

            if (hwnd != IntPtr.Zero)
            {
                uint processId;
                uint threadId = GetWindowThreadProcessId(hwnd, out processId);

                Process[] procs = Process.GetProcesses();
                foreach (Process proc in procs)
                {
                    IntPtr handle = proc.MainWindowHandle;

                    if (handle == hwnd)
                    {
                        theProc = proc;
                    }
                    else if (processId == proc.Id)
                    {
                        theProc = proc;
                    }
                }
            }

            return theProc;
        }
    }
    public class WebLoader
    {
        public enum WebLoaderSetting { Simple, Cookie, Headless }
        public static string webpageresult;
        public WebLoader(Uri uri, WebLoaderSetting setting = WebLoaderSetting.Simple)
        {
            var proc = new Dictionary<WebLoaderSetting, Func<string>>();
            proc.Add(WebLoaderSetting.Simple, () => { return webloadSimple(); });
            proc.Add(WebLoaderSetting.Cookie, () => { return webloadCookie(); });
            //proc.Add(WebLoaderSetting.Headless, () => { return; });
            webpageresult = proc[setting]();

            string webloadSimple()
            {
                WebClient client = new WebClient();
                try
                {
                    client.DownloadString(uri);
                }
                catch (Exception e)
                {
                    throw new Exception($"Webload Error {uri}");
                }
                return "";
            }
            string webloadCookie()
            {
                //! The Code to solve 403 Forbiden problem
                //Source Code: https://stackoverflow.com/questions/16735042/the-remote-server-returned-an-error-403-forbidden
                //Navigate to front page to Set cookies
                // HttpRequest htmlReq = new HttpRequest("","","");

                // Dictionary<string,List<string>> OLinks = new Dictionary<string, List<string>>();

                // string Url = uri.AbsoluteUri;
                CookieContainer cookieJar = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.CookieContainer = cookieJar;

                request.Accept = @"text/html, application/xhtml+xml, */*";
                //request.Referer = @"https://www.apkadmin.com/";
                request.Headers.Add("Accept-Language", "en-GB");
                request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
                //request.Host = @"www.apkadmin.com";
                request.UseDefaultCredentials = true;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string webpage;
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    webpage = reader.ReadToEnd();
                }
                //End Source
                return webpage;

            }

        }

        public static async Task<string> webloadSeleniumEdge(Uri uri)
        {
            try
            {
                var options = new EdgeOptions();
                options.PageLoadStrategy = PageLoadStrategy.Normal;
                options.AddArgument("headless");
                options.AddArgument("disable-popup-blocking");
                options.AddArgument("incognito");
                options.AddArgument("disable-logging");
                options.AddArgument("disable-gpu");
                options.AddArgument("disable-crash-reporter");
                options.AddArgument("disable-extensions");
                options.AddArgument("disable-in-process-stack-traces");
                options.AddArgument("disable-logging");
                options.AddArgument("disable-dev-shm-usage");
                options.AddArgument("disable-crash-reporter");
                options.AddArgument("disable-extensions");
                //options.AddArgument("--disable-extensions");
                //options.AddArgument("--safebrowsing-disable-download-protection");
                options.AddArguments("no-sandbox");
                options.AddArgument("enable-automation");
                options.AddUserProfilePreference("safebrowsing", "enabled");
                options.AddUserProfilePreference("permissions.default.image", "disabled");
                string cache = "";
                var serviceSet = EdgeDriverService.CreateDefaultService();
                serviceSet.HideCommandPromptWindow = true;

                using (var driver = new EdgeDriver(serviceSet, options))
                {
                    driver.Navigate().GoToUrl(uri.OriginalString);
                    cache = driver.PageSource;
                };
                return cache;
            }
            catch (Exception e)
            {
                throw new Exception("Webloader Selenium Error\n" + e.Message);
            }
        }

    }
}
