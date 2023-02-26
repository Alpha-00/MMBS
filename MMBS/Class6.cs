using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace MMBS
{
    /// <summary>
    /// API Process Class
    /// </summary>
    public static class Class6
    {
       
    }
    public class API
    {
        //Enumerable

        //
        private static PostDataBundle thenow = new PostDataBundle();
        public API.InteractDebugger debug = new InteractDebugger("1");
        public static void Proc(string[] args)
        {
            
            API x = new API();
            //!x.tmpReceiver(args.ToString());
            var cache = "mLAMB:{mlambslash...vercodemlambslash...:mlambslash...mLAMB.200822mlambslash...,mlambslash...datmlambslash...:{mlambslash...playlinkmlambslash...:mlambslash...https://play.google.com/store/apps/details?id=com.shoot.hotheadgame.antimlambslash...,mlambslash...leechlabelmlambslash...:mlambslash...PMT FREE MODmlambslash...,mlambslash...creditmlambslash...:mlambslash...LEIIKUNmlambslash...,mlambslash...versionmlambslash...:mlambslash...v1.0.11.11mlambslash...,mlambslash...obbmlambslash...:mlambslash...falsemlambslash...,mlambslash...rootmlambslash...:mlambslash...falsemlambslash...,mlambslash...modmlambslash...:mlambslash...All Gun Unlocked.\\nLots of Gold.\\nLots of Ammo.mlambslash...}}";
            if (0!=args.Length)
            x.ProcessInput(args[0]);
            else
            x.ProcessInput(cache);
            System.Environment.Exit(222);
        }
        public void ProcessInput(string cmd)
        {
            debug.AppendRegist("MMBS", "API Proc ProcessInput");
            debug.Logs("*Start Debug");
            debug.Logs($"cmd:{cmd}");
            //System.Windows.Forms.MessageBox.Show(cmd,"MMBS prompt");
            SystemAlt.Windows_Forms_Clipboard_SetText(cmd);
            switch (cmd.Remove(cmd.IndexOf(":")))
            {

                case "mLAMB":
                    {
                        try
                        {
                            debug.Logs("start process mLAMB");
                            cmd = cmd.Substring(cmd.IndexOf(":") + 1);
                            //Reserve " symbol
                            cmd = cmd.Replace("mlambslash...", "\"");
                            debug.Logs($"\tproc:{cmd}");
                            Dictionary<string, string> cache = new Dictionary<string, string>();
                            JObject parser = new JObject();
                            parser = JObject.Parse(cmd);
                            debug.Logs($"\tparsed:{parser.ToString(Formatting.None)}");
                            cache = parser["dat"].ToObject<Dictionary<string, string>>();
                            if (cache.ContainsKey("playlink"))
                            thenow.appinfo.datasource = cache["playlink"];
                            if (cache.ContainsKey("version"))
                                thenow.appinfo.version = cache["version"];
                            if (cache.ContainsKey("obb"))
                                thenow.appinfo.obbReq = Convert.ToBoolean(cache["obb"]);
                            if (cache.ContainsKey("root"))
                                thenow.appinfo.rootReq = Convert.ToBoolean(cache["root"]);
                            if (cache.ContainsKey("mod"))
                                thenow.modinfo.moddata = cache["mod"];
                            if (cache.ContainsKey("credit"))
                            {
                                //PostDataBundle.creditpack.CreditsList.New(cache["credit"] ,"Platinmods");
                                PostDataBundle.creditpack.CreditsList.New(cache["credit"], "");
                                thenow.credit.Search_and_Set( cache["credit"]);
                            }
                            debug.Logs($"\trunform");
                            Application.Run(new AFForm("process", thenow));
                            debug.Logs($"\tformexit");
                        }
                        catch(Exception e)
                        {
                            debug.Logs($"\t\tERROR:{e.StackTrace}xxx{e.Message}");
                        }
                    }
                    break;
            }
            debug.Save();
        }
        /// <summary>
        /// &decode from message
        /// Temporary communicate message "[App name]::::[MMBS cmd]::::[other information]\n[DATA]
        /// </summary>

        public void tmpReceiver(string message)
        {
            string cache = message.Remove(message.IndexOf("\n"));
            string[] setting = cache.Split("::::");
            switch (setting[0])
            {
                case "LAMB":
                    if (setting.Length < 2) return;
                    if (setting[1] == "AFFcmd")
                    {
                        PostDataBundle importdata = new PostDataBundle();
                        AFForm form = new AFForm();
                        if (setting.Length < 3) return;
                        if (setting[2] == "FreeData")
                        {
                            bool done = false;
                            cache = message.Substring(message.IndexOf("\n") + 1);
                            //Parse content
                            do
                            {
                                if (cache.Length < 4) break;
                                if (cache.StartsWith("$"))
                                {
                                    int i = 0;
                                    i = Convert.ToInt32(cache.Remove(cache.IndexOf("]")).Substring(2));
                                    cache = cache.Substring(cache.IndexOf("]") + 1);
                                    string key = cache.Remove(i);
                                    cache = cache.Substring(i);
                                    i = Convert.ToInt32(cache.Remove(cache.IndexOf("]")).Substring(2));
                                    cache = cache.Substring(cache.IndexOf("]") + 1);
                                    string data = cache.Remove(i);
                                    cache = cache.Substring(i);
                                    switch (key)
                                    {
                                        case "playID": importdata.appinfo.datasource = data; break;
                                        case "ver": importdata.appinfo.version = data; break;
                                        case "obb": importdata.appinfo.obbReq = data == "TRUE"; break;
                                        case "root": importdata.appinfo.rootReq = data == "TRUE"; break;

                                        default: break;
                                    }
                                }
                                else break;
                            }
                            while (!done);
                        }
                    }

                    break;
                default: break;
            }

        }

        /// <summary>
        /// Is a couple with mLAMB API Interact Debugger
        /// </summary>
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
               // JToken cache = JObject.FromObject(obj);
                dat.Add(DateTime.Now.ToString("Log at {H:mm:ss fffffff}") + (tmp++), (string)obj);
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
                System.IO.File.WriteAllText($"C:\\BloggerSupporter\\ILogs{code}.txt", dat.ToString());
            }
        }
        /// <summary>
        /// Alternative Implementation for System API
        /// </summary>
        
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
                System.Windows.Forms.Clipboard.SetData(DataFormats.UnicodeText, dat);
                res = true;
                return res;
            }
            catch(Exception e)
            {
                ERROR += $"{winner} : {e.Message}\n";
            }
            //Method 2: SetDataObject
            try
            {
                winner++;
                System.Windows.Forms.Clipboard.SetDataObject(data: dat,copy: true, retryTimes: 3, retryDelay: 200);
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
                    System.Windows.Forms.Clipboard.SetText(dat);
                    res = true;
                    //return res;
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
}
