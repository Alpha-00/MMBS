using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
namespace mLAMB
{
    public class Core
    {
        public class Constanter
        {
            public enum returncode
            {
                valid = 0,
                invalid = 255,
                skipcode = 256,
                unsupport = 400,
                neterror = 401,
                myfault = 42694269,
                exitcode = 1000000000
            }
            //Control Process Level
            public enum setConProcLevel
            {
                nocontrol = 0,
                fullcontrol = 100
            }
        }
        public class Data
        {
            public string ver = "mLAMB.200822";
            
            public Dictionary<string,string> temp = new Dictionary<string, string>();
           
            public Data()
            {

            }
            public int SendToMMBS()
            {
                API.InteractDebugger debug = new API.InteractDebugger("0");
                debug.AppendRegist("mLAMB", "sendtommbsprocesslog");
                debug.Logs("*Start Debug");
                debug.Logs("generate message");
                JObject cache = new JObject();
                JToken xxxx = ver;
                var ax =xxxx.Type;
                cache.Add("vercode", ver);
                JToken cache2 = JObject.FromObject(temp);
                cache.Add("dat",cache2);
                string message = cache.ToString(Formatting.None);
                debug.Logs($"\tmessage={message}");
                Process firstProc = new Process();
                debug.Logs("start call process");
                try
                {
                    string trymmbsdir = "";
                    if (System.IO.File.Exists("C:\\BloggerSupporter\\profile_MMBS.bb"))
                    trymmbsdir = System.IO.File.ReadAllText("C:\\BloggerSupporter\\profile_MMBS.bb");
                    trymmbsdir = trymmbsdir.Split('\n').First((x) => x.StartsWith("dir=")).Split('=')[1].Trim();
                    debug.Logs($"\tdir={trymmbsdir}");
                    firstProc.StartInfo.FileName = !string.IsNullOrWhiteSpace(trymmbsdir)?trymmbsdir + "\\mmbs.exe" : "D:\\Unpublished Project\\Unpublished Project\\Ya4r.net\\Minimize MyBloggerSupporter\\MMBS\\bin\\Debug\\MMBS.exe";
                    debug.Logs($"\tloc={firstProc.StartInfo.FileName}");
                    firstProc.EnableRaisingEvents = true;
                    firstProc.StartInfo.Arguments = $"mLAMB:\"{message.Replace("\"","mlambslash...")}\"";
                    debug.Logs($"\tconvertmess={firstProc.StartInfo.Arguments}");
                    
                    firstProc.Start();
                    debug.Logs("\t\t--STARTED");
                    firstProc.WaitForExit();
                    debug.Logs("\t\t--EXIT");
                }
                catch (Exception ex)
                {
                    debug.Logs($"\t\tERROR:{ex.Message}");
                    Console.WriteLine("An error occurred!!!: " + ex.Message);
                    return 255;
                }

                debug.Save();
                return 0;
            }
        }

        public class mLAMBEventArg
        {
            public class integerArg : EventArgs
            {
                public int x = 0;
            }
        }
    }
}
