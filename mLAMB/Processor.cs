using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Web;
using System.Windows;
using System.Runtime.CompilerServices;

using HtmlAgilityPack;
using mLAMB.Resources.Dialogs;
using Google.Apis.Requests;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace mLAMB
{
    public class Processor
    {
        public class Support
        {
            public static class Check
            {
                public static bool isLink(string str)
                {
                    if (string.IsNullOrWhiteSpace(str)) return false;
                    Uri cache = null;
                    return Uri.TryCreate(str,UriKind.Absolute,out cache);
                }
            }
        }
        public class Command
        {
            public MainWindow windows;
            public MainWindow.shellcall shell = null;
            public MainWindow.shellcall listencall = null;
            public MainWindow.shellfeed shellfeed = null;
            public Core.Data dat = new Core.Data();
            public int exitcode = 0;
            public Command()
            {

            }
            public enum commander {
                mmbs = 0,
                lastest = 1,
                news = 2,
                exit = 1000000000
            };
            public int start(MainWindow.shellcall shell, MainWindow.shellcall listencall, MainWindow.shellfeed shellfeed, string cmd, params string[] code)
            {
                //cmd = "https://platinmods.com/threads/random-merge-defense-ver-1-1-0-mod-apk-free-upgrade.105766/";
                /*
                //!Sandbox
                string result = "";
                bool dialogResult = false;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    userpassWindow prompt = new userpassWindow("Platinmods Login", "platinmodsToken.txt");
                    JObject mainwinloc = JObject.Parse(shellfeed("?location"));
                    prompt.Top = mainwinloc["top"].ToObject<double>() + (mainwinloc["height"].ToObject<double>() - prompt.Height) / 2;
                    prompt.Left = mainwinloc["left"].ToObject<double>() + (mainwinloc["width"].ToObject<double>() - prompt.Width) / 2;
                    dialogResult = prompt.ShowDialog() ?? false;
                    result = userpassWindow.RetrieveResult;
                }
                ), System.Windows.Threading.DispatcherPriority.Normal);
                return 0;
                //!SandboxEnd*/
                this.shell = shell;
                this.shellfeed = shellfeed;
                this.listencall = listencall;
                if (string.IsNullOrWhiteSpace(cmd)) return 255;
                shell("prepare");
                shell("`INIT PROCESSOR");

                cmd = cmd.TrimStart();
                if (cmd.StartsWith("http")) { exitcode = proclink(cmd, code); goto doneprocess; }

                if (cmd.StartsWith("cmd:"))
                {
                    shell("`detected CMD");
                    cmd = cmd.Substring(4);
                    switch (cmd.Split(':')[0])
                    {
                        case nameof(commander.mmbs): {
                                shell("`Sending...");
                                dat.SendToMMBS();
                                shell("`\tSENT");
                                if (ask("y/n",100,true, "Do you want to exit mLAMB?")) 
                                {
                                    exitcode = 1000000000; goto doneprocess; 
                                }
                            } break;
                        case nameof(commander.exit): { exitcode = 1000000000; goto doneprocess; } break;
                        case nameof(commander.lastest): { proclink(getlastest(), ""); } break;
                        case nameof(commander.news): { proclink(getnewest(code), ""); } break;
                        default: { shell("`\twrong cmd"); exitcode = 255; } break;
                    }
                    return 0;
                }
            doneprocess:
                shell("`\nEXIT PROCESSOR");
                return exitcode;
            }

            public static MainWindow sshell;

            public static string[] SupportedHost = { "platinmods.com", };
            
            public int proclink(string cmd, params string[] code)
            {
                /// use for toggle beta mode
                const bool test1 = false;
                ///
                if (string.IsNullOrWhiteSpace(cmd)) return 256;//Check for getnewest
                shell("`detected LINK");
                if (dat.temp.Count > 0) dat = new Core.Data();
                //!Check link
                if (!Support.Check.isLink(cmd)) return 255;
                shell("`\t-LINK valid");
                Uri link = new Uri(cmd);
                shell("@\t-LINK.host," + link.Host);
                shell("`\t\t--" + (SupportedHost.Contains<string>(link.Host) ? "SUPPORTED" : "UNSUPPORT YET"));
                if (!SupportedHost.Contains<string>(link.Host)) return 400;

                System.Net.WebClient client = new System.Net.WebClient();
                string webpage = client.DownloadString(link);
                shell("`\t\t--" + (!string.IsNullOrEmpty(webpage) ? "CONNECTED" : "ERROR"));
                ///shell("`" + webpage);
                if (string.IsNullOrEmpty(webpage)) return 255;
                //shell("?clipboard.settext\n" + webpage);

                //!Parsing
                shell("`**START PARSING");
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(webpage);
                string devtext = "";
                var doc_cache = doc.DocumentNode.SelectNodes("//article")[0];
                doc_cache = doc_cache.SelectNodes(".//article")[0];
                //Get Play link
                {
                    var getcache = doc_cache.SelectSingleNode(".//div[@class='bbCodeBlock bbCodeBlock--unfurl    js-unfurl fauxBlockLink']");
                    if (getcache != null)
                    {
                        string strparse = getcache.Attributes["data-url"].Value;
                        strparse = HttpUtility.HtmlDecode(strparse);
                        dat.temp.Add("playlink", strparse);
                        shell("@playlink," + dat.temp.Last().Value);
                    }
                    else
                        //Try Again
                        try
                        {
                            var strparse = doc_cache.InnerHtml;
                            strparse = strparse.Substring(strparse.IndexOf("https://play.google.com"));
                            strparse = strparse.Remove(strparse.IndexOf("\""));
                            strparse = HttpUtility.HtmlDecode(strparse);
                            shell("@playlink," + strparse);
                            if (ask("y/n", 100, true, "This may not your play link\nDo you want to use this?"))
                                dat.temp.Add("playlink", strparse);
                        }
                        catch (Exception e)
                        {
                            shell($"`+++++\nError Code: 'get2 Playlink'.PROCESSOR.class Command.in start.is proclink! \n{e.Message}");
                        }
                }
                //!Title Silver Label Check and Credit
                try
                {
                    var cache = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'p-title')]");
                    cache = cache.SelectSingleNode(".//span");
                    shell("@leechlabel," + cache.InnerText);
                    dat.temp.Add("leechlabel", cache.InnerText);
                    if (cache.InnerText!= "PMT FREE MOD")
                    {
                        if (!ask("y/n", -1, false, "WARNING: This post is not completely supported yet. Do you want to continue?"))
                        {
                            goto processSendtoMMBS;
                        }
                        
                    }
                    else
                    {
                        //Get Credit
                        cache = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'p-description')]");
                        cache = cache.SelectSingleNode(".//span[@class='username--staff']");
                        shell("@credit," + cache.InnerText);
                        dat.temp.Add("credit", cache.InnerText);
                    }

                }
                catch (Exception e)
                {
                    shell($"`+++++\nError Code: 'nolabel TitleLabel'.PROCESSOR.class Command.in start.is proclink! \n{e.Message}");
                }
                //Get Requirement
                try
                {
                    var doc_cache2 = doc_cache.SelectNodes(".//span[@style='color: #ff0000']");
                    foreach (var x in doc_cache2)
                    {
                        if (x.InnerText.StartsWith("Game Name:"))
                        {
                            var xx = x;
                            while (xx.Name != "div")
                            {
                                xx = xx.NextSibling;
                                if (xx.Name == "#text")
                                {
                                    if (xx.InnerText.ToLower().Contains("version"))
                                    {
                                        dat.temp.Add("version", xx.InnerText.Split(':')[1].Trim());
                                        shell("@version," + dat.temp.Last().Value);
                                        continue;
                                    }
                                    if (xx.InnerText.ToLower().Contains("obb"))
                                    {
                                        dat.temp.Add("obb", (xx.NextSibling.InnerText.Trim().ToLower().Contains("no") ? "false" : "true"));
                                        shell("@obb," + dat.temp.Last().Value);
                                        continue;
                                    }
                                    if (xx.InnerText.ToLower().Contains("root"))
                                    {
                                        dat.temp.Add("root", (xx.NextSibling.InnerText.Trim().ToLower().Contains("no") ? "false" : "true"));
                                        shell("@root," + dat.temp.Last().Value);
                                        break;
                                    }
                                }
                            }
                        }
                        if (x.InnerText.ToLower().StartsWith("*mod features*"))
                        {
                            var xx = x.NextSibling;
                            var getcache = "";
                            while ((xx.Name != "span") || (xx.GetAttributeValue("style", "") != "color: #ff0000"))
                            {
                                xx = xx.NextSibling;
                                if ((xx.Name == "#text") || (xx.Name == "b") || (xx.Name == "span"))
                                {
                                    if (xx.InnerHtml == "\n") 
                                        continue;
                                    if (xx.InnerHtml == "Stay away from harmful malicious mods that fill your device with UNWANTED ADS! I always provide quality service with no such malicious tricks to earn money. We want you happy, that's our goal. You can be sure to download quality on platinmods.com.")
                                        break;
                                    if (xx.InnerHtml == "\nStay away from harmful malicious mods that fill your device with UNWANTED ADS! I always provide quality service with no such malicious tricks to earn money. We want you happy, that's our goal. You can be sure to download quality on platinmods.com.")
                                        break ;
                                    if (xx.InnerHtml == "Stay away from harmful malicious mods that fill your device with UNWANTED ADS! I always provide quality service with no such malicious tricks to earn money. We want you happy, that's our goal. You can be sure to download quality on platinmods.com.")
                                        break;
                                    if (xx.InnerText.StartsWith("<br>\n*Video Preview*"))
                                        break;

                                    if (xx.InnerText.StartsWith("You need to enable")) 
                                    {
                                        if (xx.NextSibling.InnerText.Contains("Overlay Permission and Storage Permission")) dat.temp.Add("extperm","true");
                                        break; 
                                    }
                                   
                                    if (!string.IsNullOrWhiteSpace(xx.InnerText))
                                        getcache += xx.InnerText.Trim() + "\n";
                                }
                                if (xx.Name == "ol")
                                {
                                    getcache += xx.InnerText.Trim();
                                }
                                if (xx.Name == "ul")
                                {
                                    getcache += xx.InnerText.Trim();
                                }
                                    
                                
                            }
                           
                            if (!string.IsNullOrWhiteSpace(getcache))
                            {
                                //Edit symbol text
                                getcache = getcache.Replace("&gt;", ">");
                                //Remove last \n
                                getcache = getcache.Remove(getcache.Length - 1);
                                dat.temp.Add("mod", getcache);
                                shell("@mod,\"" + dat.temp.Last().Value + "\"");
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    shell($"`+++++\nError Code: 'get Requirement'.PROCESSOR.class Command.in start.is proclink! \n{e.Message}");
                }
                //shell("?clipboard.settext\n" + doc_cache.InnerHtml);
                devtext = doc_cache.InnerHtml;
                //shell("@devtext," + devtext);
                shell("`**//PARSING COMPLETED");
                //todo: Fix login system
                goto processSendtoMMBS;
                //!Login
                shell("`**TRY GET LINK");
                bool trysuccess = true;
                shell(" Login: ");
                //Getting Account
                string platinmods_username = "";
                string platinmods_password = "";
                var Jcache = new JObject();
                //final result cache
                string resultcache = "";
                if (System.IO.File.Exists("C:\\BloggerSupporter\\" + "platinmodsToken.txt"))
                {
                    Jcache = JObject.Parse(System.IO.File.ReadAllText("C:\\BloggerSupporter\\" + "platinmodsToken.txt"));
                    shell(" -");
                }
                else
                {
                    string result = "";
                    bool dialogResult = false;
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        userpassWindow prompt = new userpassWindow("Platinmods Login", "platinmodsToken.txt");
                        JObject mainwinloc = JObject.Parse(shellfeed("?location"));
                        prompt.Top = mainwinloc["top"].ToObject<double>() + (mainwinloc["height"].ToObject<double>() - prompt.Height) / 2;
                        prompt.Left = mainwinloc["left"].ToObject<double>() + (mainwinloc["width"].ToObject<double>() - prompt.Width) / 2;
                        dialogResult = prompt.ShowDialog() ?? false;
                        result = userpassWindow.RetrieveResult;
                    }
                    ), System.Windows.Threading.DispatcherPriority.Normal);
                    Jcache = JObject.Parse(result);
                    shell(" " + (dialogResult ? "-" : "*"));
                    shell(" _");
                }
                //Start to Loggin

                ChromeOptions options = new ChromeOptions();
                if (!System.IO.Directory.Exists("C:\\BloggerSupporter\\seleniumcache")) System.IO.Directory.CreateDirectory("C:\\BloggerSupporter\\seleniumcache");
                options.AddArguments($"user-data-dir={"C:\\BloggerSupporter\\seleniumcache"}");
                options.AddArgument("--headless");
                options.AddArgument("--silent");
                // options.AddArgument("log-level=3");
                ChromeDriver driver = null;

                try
                {
                    driver = new ChromeDriver(options);
                }
                catch (Exception e)
                {
                    shell($"`+++++\nError Code: 'init driver'.PROCESSOR.class Command.in start.is process! \n{e.Message}");
                    shell("`Closing...");
                    MessageBox.Show("Please CLOSE the OPEN CHROME CONSOLE window and execute again");
                    trysuccess = false;
                    goto processSendtoMMBS;
                };
                shell(" -");
                driver.Navigate().GoToUrl("https://platinmods.com/login/login");
                shell(" :");
                if (driver.PageSource.Contains("already logged")) shell("`Done");
                else
                {
                    platinmods_username = Jcache["username"].ToString();
                    shell(" " + platinmods_username + ":");
                    platinmods_password = Jcache["password"].ToString();
                    driver.FindElement(By.Name("login")).SendKeys(platinmods_username);
                    driver.FindElement(By.Name("password")).SendKeys(platinmods_password);
                    driver.FindElement(By.ClassName("button--icon--login")).Click();
                    shell("`Done");
                }
                shell(" React: ");
                driver.Navigate().GoToUrl(link);
                shell(" -");
                try
                {
                    if (driver.PageSource.Contains("<a href=\"javascript:\" class=\"notice-dismiss js-enablePushDismiss\"></a>"))
                    {
                        driver.FindElement(By.XPath(".//a[@class='notice-dismiss js-enablePushDismiss']")).Click();
                        if (driver.PageSource.Contains("<a href=\"javascript:\" class=\"js-dismissPerm\">Never ask again</a>"))
                            driver.FindElement(By.XPath(".//a[@class='js-dismissPerm']")).Click();
                    }
                }
                catch (Exception e)
                {
                    //Notthing, it's just pop an popup
                }
                try
                {
                        doc = new HtmlDocument();
                        doc.LoadHtml(driver.PageSource);
                        
                        if (!doc.DocumentNode.SelectSingleNode("//article").SelectSingleNode(".//footer").SelectSingleNode(".//a").Attributes["class"].Value.Contains("has-reaction"))
                        {
                            driver.FindElement(By.XPath(".//div[@class='actionBar-set actionBar-set--external']")).Click();
                        }
                    resultcache = driver.PageSource;
                    shell(" -");
                }
                catch (Exception e)
                {
                    shell(" x");
                }
                finally
                {
                    driver.Quit();
                }
                shell("`Done");
                //shell("?clipboard.settext\n" + resultcache);
                if (string.IsNullOrEmpty(resultcache))
                {
                    shell("`ERROR: 'Get link fail'");
                    goto processSendtoMMBS;
                }
                doc = new HtmlDocument();
                doc.LoadHtml(resultcache);
                shell(" No. of Links: ");
                HtmlNodeCollection xlist = null;
                Dictionary<string,int> links = new Dictionary<string, int>();
                
                bool proclink = false;
                if (!resultcache.Contains("bbCodeBlock bbCodeBlock--hide bbCodeBlock--visible"))
                {
                    shell("`0");
                }
                else
                {
                    xlist = doc.DocumentNode.SelectNodes("//div[@class='bbCodeBlock bbCodeBlock--hide bbCodeBlock--visible']");
                    shell($"`{xlist.Count} blocks");
                    int l = 0;
                    foreach (var xx in xlist)
                    {
                        int b1 = 0;
                        foreach (var xxx in xx.SelectNodes(".//a"))
                        {
                            links.Add(xxx.Attributes["href"].Value,b1);
                            shell($"`{++l}.{links.Last().Key}");
                        }
                        b1++;

                    }
                    proclink =
                    !links.Keys.Any((linkx) => { return linkx.Contains("drive.google.com"); })?false:ask("y/n",100,true, "Do you want the program process all those link?");
                    if (!proclink)
                    {

                        //fire them all to the browser
                        if (ask("y/n", 100, false, "Do you want open all of them in your browser?"))
                        {
                            foreach (var xx in links)
                            {
                                System.Diagnostics.Process.Start(xx.Key);
                            }
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(link.AbsoluteUri);
                            goto processSendtoMMBS;
                        }

                    }
                }
                shell("`**//TRY GET LINK COMPLETED");
                //!Process Link
                if (!proclink) goto processSendtoMMBS;
                shell("`**HYPERLINK PROCESS");
                //blocks separate
                int b = 0;
                List<List<string>> a = new List<List<string>>();
                a.Add(new List<string>());
                foreach (var xx in links)
                {
                    if (b < xx.Value) b++;
                    a[xx.Value].Add(xx.Key);
                }
                foreach (var x in a)
                {
                    string proc_Downlink = "";
                    string proc_Mirrorlink = "";
                    //Define which to be use
                    foreach (var xx in x)
                    {
                        switch((new Uri(xx)).Host)
                        {
                            case "drive.google.com":
                                {
                                    proc_Downlink = string.IsNullOrEmpty(proc_Downlink) ? xx : proc_Downlink;
                                } break;
                            case "www.mirrored.to":
                                {
                                    proc_Mirrorlink = string.IsNullOrEmpty(proc_Mirrorlink) ? xx : proc_Mirrorlink;
                                }
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(proc_Downlink))
                    {

                        //todo: Start Process here
                        Application.Current.Dispatcher.Invoke(new Action(() => 
                        {
                            fileurlprocWindow window = new fileurlprocWindow(proc_Downlink, proc_Mirrorlink);
                            bool? isDone = window.ShowDialog();
                        }), System.Windows.Threading.DispatcherPriority.Normal);
                    }
                }
                shell("`**//HYPERLINK PROCESS");
            //!Send to MMBS
            processSendtoMMBS:
                DataFixer();
                if (ask("y/n", 100, true, "Do you want to send collected data to MMBS?"))
                {
                    shell("`Waiting for MMBS...");
                    if (dat.SendToMMBS() == 255) return 255;
                }
                return 0;
            }
            public int errorcode = 0;
            public void DataFixer()
            {
                bool isfix_mod = false;
                string cache_mod = "";
                foreach (var x in dat.temp)
                {
                    
                    switch (x.Key)
                    {
                        case "mod":
                            {
                               
                                
                                foreach (String xx in x.Value.Split('\n'))
                                {
                                    string xxx = xx;
                                    if (string.IsNullOrWhiteSpace(xxx)) continue;
                                    // Check numbered list
                                    Regex pattern = new Regex(@"^(\d+).\s+([^\r\n]+)(?:[\r\n]*)");

                                    if (pattern.IsMatch(xx))
                                    {
                                        xxx = xxx.Substring(xxx.IndexOf(" ") + 1);
                                        isfix_mod = true;
                                    }
                                    //Check dot at end
                                    
                                    if (!xxx.EndsWith(",")) xxx.Remove(xxx.Length - 1);
                                    if (!(xxx.EndsWith(".") || xxx.EndsWith("!") || xxx.EndsWith("?")||xxx.EndsWith("-")))
                                    {
                                        xxx += ".";
                                        isfix_mod = true;
                                    }
                                    // spcial character
                                    if (xxx.Contains("&quot;")) xxx.Replace("&quot;", " ");
                                    cache_mod += xxx+"\n";
                                }
                                if (isfix_mod) { 
                                    cache_mod = cache_mod.Trim();
                                    shell($"`fix mod:{cache_mod}");
                                };
                            }
                            break;
                    }
                }
                if (isfix_mod)
                {
                    dat.temp["mod"] = cache_mod;
                }
            }
            /// <summary>
            /// get lastest mod
            /// </summary>
            /// <returns></returns>
            public string getlastest()
            {
                //Update: 201209
                return getnewest("PMT FREE MOD");
                //[Old Code]
                //End date: 9/12/2020
                
                string html;
                try
                {
                    var myUri = new Uri("https://platinmods.com/latest-pmt-mods/");
                    // Create a 'HttpWebRequest' object for the specified url. 
                    var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                    // Set the user agent as if we were a web browser
                    myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

                    var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    var stream = myHttpWebResponse.GetResponseStream();
                    var reader = new StreamReader(stream);
                    html = reader.ReadToEnd();
                    // Release resources of response object.
                    myHttpWebResponse.Close();
                }
                catch (WebException ex)
                {
                    using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                        html = sr.ReadToEnd();
                }
                
                try
                {
                        System.Net.WebClient client = new System.Net.WebClient();

                        string webpage = client.DownloadString("https://platinmods.com/latest-pmt-mods/?__cf_chl_jschl_tk__=f2da5f5584e485322b19aba609f4c6a77bb8390e-1607517501-0-AaBfT_Zi1eX_XkRHk8-_Xn5oLYNPR8nosjm8M9YYOzBVGL8NUznqA2-I3Vks93wSs-8RbN5dFHA0IbX_cMkrMEWPMluv7PakV9cTu941m2XdH08MmrlfQHSdLt0tyCkSriK9jowGlh0xAdJPQH6m5HKLM0C4oi-BCDzBSLgWhzgveI3pR7IIej4O8Y9NXcZkctHzX41Kcd6cKFe3LXBKCUMc-zduGG75xGTJhIoRAk2UWtqLktCfdnKTu_upvNBcP6KebC61LGZ2QV2vKiuF5-6bJ4pu6ju_J1AH9fqTYu03abXeRys8GFySFFagnhvM1XD1pYf9UnMML-z3obz_7_I");
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(webpage);
                        var doccache = doc.DocumentNode.SelectNodes("//div[@class='porta-article-item']")[1];
                        string cache = "https://platinmods.com" + doccache.SelectSingleNode(".//a").Attributes["href"].Value;
                        shell("?clipboard.settext\n" + cache);
                        if (Properties.Settings.Default.setFireWeb) System.Diagnostics.Process.Start(cache);
                        if (ask("y/n",100,true,"Do you want to use this link?\n" + "LINK: " + cache + "\nTITLE: " + doccache.SelectSingleNode(".//span[@class='label label--silver']").NextSibling.InnerText.Trim()))
                            return cache;
                        return "";
                    }
                    catch (Exception e)
                    {
                        shell($"`+++++\nError Code: 'get newest'.PROCESSOR.class Command.in start.is getnewest! \n{e.Message}");
                        return "";
                    }
                    

                }

            /// <summary>
            /// Get normal view newest post
            /// </summary>
            /// <returns></returns>
            public string getnewest(params string[] code)
            {
                try
                {
                    
                    System.Net.WebClient client = new System.Net.WebClient();
                    string webpage = client.DownloadString("https://platinmods.com/whats-new/");
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(webpage);
                    var cache = "";
                    //Get block of data
                    var doccache = doc.DocumentNode.SelectSingleNode("//div[@class='block-body']");
                    //doccache = doccache.SelectSingleNode("//div[@class='structItemContainer']");
                    //Get first block
                    doccache = doccache.SelectSingleNode(".//div[contains(@class, 'structItem')]").FirstChild.NextSibling;
                    if (code.Length>0)
                    do
                    {

                        var cache2 = doccache.SelectSingleNode(".//div[@class='structItem-title']");
                        cache2 = cache2.SelectSingleNode(".//span");
                        //"PMT FREE MOD"
                        if (code[0]  == cache2.InnerText)
                        {
                             break;
                        }
                        do
                        {
                            doccache = doccache.NextSibling;
                        }
                        while ((doccache.Name == "#text") && (null != doccache.NextSibling));
                    }
                    while (null != doccache.NextSibling);
                    doccache = doccache.SelectSingleNode(".//div[@class='structItem-title']");
                    doccache = doccache.SelectSingleNode(".//a");

                    cache = "https://platinmods.com" + doccache.Attributes["href"].Value;
                    shell("?clipboard.settext\n" + cache);
                    if (Properties.Settings.Default.setFireWeb) System.Diagnostics.Process.Start(cache);
                    if (ask("y/n", 100, true, "Do you want to use this link?\n" + "LINK: " + cache + "\nTITLE: " + doccache.InnerText.Trim()))
                        return cache;
                    return "";
                }
                catch (Exception e)
                {
                    shell($"`+++++\nError Code: 'get newest'.PROCESSOR.class Command.in start.is getnewest! \n{e.Message}");
                    return "";
                }
                /*
                try
                {
                    System.Net.WebClient client = new System.Net.WebClient();
                    string webpage = client.DownloadString("https://platinmods.com/forums/exclusive-android-mods-by-pmt.30/");
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(webpage);
                    var doccache = doc.DocumentNode.SelectNodes("//h3[@class='block-minorHeader uix_threadListSeparator']")[1];
                    doccache = doccache.NextSibling.NextSibling.SelectSingleNode(".//div[@class='structItem-title']");
                    string cache = doccache.Attributes["uix-data-href"].Value;
                    cache = "https://platinmods.com/" + cache;
                    doc.LoadHtml(client.DownloadString(cache));
                    shell("?clipboard.settext\n" + cache);
                    if (Properties.Settings.Default.setFireWeb) System.Diagnostics.Process.Start(cache);
                    if (ask("y/n", 100, true, "Do you want to use this link?\n" + "LINK: " + cache ))
                        return cache;
                    return "";
                }
                catch(Exception e)
                {
                    shell($"`+++++\nError Code: 'get newest'.PROCESSOR.class Command.in start.is getnewest! \n{e.Message}");
                    return "";
                }
                */
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="cmd"></param>
            /// <param name="def">Default Value: Return def when cmd can't work\nIt's should be 100</param>
            /// <returns></returns>
            public bool ask(string cmd,int level, bool def, params string[] message)
            {
                // the less level the more its need to get feedback
                if (level<=Properties.Settings.Default.setConProc)
                switch (cmd)
                {
                    case "y/n": 
                        {
                            shell($" ?? {message[0]??"y/n"}\n(y/n)>>");
                            string cache = shellfeed("y/n");
                            if (string.IsNullOrWhiteSpace(cache)) return def;
                            else return cache == "y" ? true : cache == "n" ? false : def;
                        } break;
                }
                return def;
            }
        }
        public class WindowCommands
        {
            public class fileurlprocWindowCommand
            {
                public Uri downlink;
                public Uri mirrorlink;
                public fileurlprocWindow.shellfeed shell;
                public fileurlprocWindow.updateprog udown;
                public fileurlprocWindow.updateprog umirr;
                public fileurlprocWindow.updateprog ureup;
                public int returncode = 0;
                public DriveService driveService = null;
                public fileurlprocWindowCommand(Uri down, Uri mirror)
                {
                    downlink = down;
                    mirrorlink = mirror;
                }
                public int start(fileurlprocWindow.updateprog udown, fileurlprocWindow.updateprog umirr, fileurlprocWindow.updateprog ureup, fileurlprocWindow.shellfeed feed)
                {
                    this.shell = feed;
                    this.udown = udown;
                    this.umirr = umirr;
                    this.ureup = ureup;
                    shell("`INIT DOWNLOAD PROCESS");
                downloadprocess:
                    {
                        shell("`\tDownload: " + downlink.AbsoluteUri);
                        shell("`\t\thost: " + downlink.Host);
                        switch (downlink.Host)
                        {
                            //!Drive Link Process
                            case "drive.google.com":
                                {
                                    shell("`\t\t\t-supported");
                                    string[] Scopes = { DriveService.Scope.Drive };
                                    string ApplicationName = "mLAMB";
                                    UserCredential credential;
                                    
                                    using (var stream =
                                        new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                                    {
                                        // The file token.json stores the user's access and refresh tokens, and is created
                                        // automatically when the authorization flow completes for the first time.
                                        string credPath = "token4D.json";
                                        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                            GoogleClientSecrets.Load(stream).Secrets,
                                            Scopes,
                                            "user",
                                            CancellationToken.None,
                                            new FileDataStore(credPath, true)).Result;
                                        Console.WriteLine("Credential file saved to: " + credPath);
                                    }
                                    
                                    driveService = new DriveService(new BaseClientService.Initializer()
                                    {
                                        HttpClientInitializer = credential,
                                        ApplicationName = ApplicationName,
                                    });
                                    string fname = "";
                                    string fsize = "";
                                    int validID = 0;
                                    string fileID = "";
                                    
                                    if (downlink.AbsolutePath.StartsWith("https://drive.google.com/open?id=")) { if (downlink.Segments.Length > 1) { fileID = HttpUtility.ParseQueryString(downlink.Query).Get("id"); } }
                                    else if (downlink.AbsolutePath.StartsWith("https://drive.google.com/file/d/")) if (downlink.Segments.Length > 3) fileID = downlink.Segments[3].Replace("/", "");
                                    if (!string.IsNullOrWhiteSpace(fileID) || fileID.Length < 5)
                                    {
                                        try
                                        {
                                            string ID = fileID;
                                            var tryget = driveService.Files.Get(ID);
                                            tryget.Fields = "name,size";
                                            Google.Apis.Drive.v3.Data.File metaget = tryget.Execute();
                                            fname = metaget.Name;
                                            shell($"`Name: {fname}");
                                            shell($"?set label downname\n{fname}");
                                            fsize = ByteToSize(metaget.Size);
                                            shell($"`\nSize: {fsize}");
                                            shell($"?set label downsize\n{fsize}");

                                            shell($"?set down ready");
                                            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\mLAMP\\");
                                            StartDownload(tryget, metaget.Size, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\mLAMP\\"+fname);

                                        }
                                        catch (Google.GoogleApiException e)
                                        {
                                            shell($"`+++++\nError Code: 'Gdrive API error'.PROCESSOR.class fileurlprocWindowCommand.in start.is downloadprocess! \n{e.Message}\n{e.HelpLink}");
                                        }
                                        catch (Exception e)
                                        {
                                            shell($"`+++++\nError Code: 'Download error'.PROCESSOR.class fileurlprocWindowCommand.in start.is downloadprocess! \n{e.Message}");
                                        }
                                    }
                                }
                                break;
                            default: 
                                {
                                    shell("`\t\t\t-UNSUPPORTED");
                                    goto mirrorprocess;
                                } break;
                        }
                        //!Function for Gdrive proce
                        //https://stackoverflow.com/questions/57607729/cannot-update-progress-bar-when-download-in-google-drive-in-c-sharp
                        
                        string ByteToSize(long? bytenum)
                        {
                            if (bytenum != null)
                            {
                                if ((bytenum < 100) && (bytenum > 0))
                                {
                                    return bytenum.ToString() + (bytenum > 1 ? " Bytes" : "Byte");
                                }
                                else if (bytenum < 1024 * 1024)
                                {
                                    return (bytenum / 1024f).Value.ToString("0.00") + " KB";
                                }
                                else if (bytenum < 1024 * 1024 * 1024)
                                {
                                    return (bytenum / 1024f / 1024f).Value.ToString("0.00") + " MB";
                                }
                                else if (Convert.ToDouble(bytenum) < Math.Pow(1024, 4))
                                {
                                    return (bytenum / Math.Pow(1024, 4)).Value.ToString("0.00") + " GB";
                                }
                            }
                            return "";
                        }
                    }
                    mirrorprocess:
                 reuploadprocess:
                    {
                        //!For Gdrive upload only
                        /*var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                        {
                            Name = "fname",
                            MimeType = "application/vnd.google-apps.folder",
                            // MimeType = "application/vnd.google-apps.spreadsheet"
                        };
                        FilesResource.CreateMediaUpload request;
                        using (var stream = new System.IO.FileStream("files/report.csv",
                                                System.IO.FileMode.Open))
                        {
                            request = driveService.Files.Create(
                                fileMetadata, stream, "text/csv");
                            request.Fields = "id";
                            request.Upload();
                        }
                        var file = request.ResponseBody;
                        Console.WriteLine("File ID: " + file.Id);
                        */
                        System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\mLAMP\\");
                    }    
                    endprocess:
                    shell("`DOWNLOAD PROCESS DONE");
                    return returncode;
                }
                public async void StartDownload(FilesResource.GetRequest tryget,long? size, string filename)
                {
                    // Creating an instance of Progress<T> captures the current 
                    // SynchronizationContext (UI context) to prevent cross threading when updating the ProgressBar
                    IProgress<double> progressReporter =
                      new Progress<double>(value => udown(value));
                    await DownloadAsync(progressReporter, tryget, size,filename);
                }
                public async Task DownloadAsync(IProgress<double> progressReporter, FilesResource.GetRequest tryget,long? size, string filename)
                {
                    var streamDownload = new MemoryStream();
                    // Report progress to UI via the captured UI's SynchronizationContext using IProgress<T>
                    tryget.MediaDownloader.ProgressChanged +=
                      (progress) => ReportProgress(progress, progressReporter, streamDownload, size,filename);

                    // Execute download asynchronous
                    await Task.Run(() => tryget.Download(streamDownload));
                }
                private void ReportProgress(Google.Apis.Download.IDownloadProgress progress, IProgress<double> progressReporter, MemoryStream streamDownload, long? fileSize,string filename)
                {
                    switch (progress.Status)
                    {
                        case Google.Apis.Download.DownloadStatus.Downloading:
                            {
                                double progressValue = Convert.ToDouble(progress.BytesDownloaded * 100 / fileSize);

                                // Update the ProgressBar on the UI thread
                                progressReporter.Report(progressValue);
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Completed:
                            {
                                shell("`Completed");
                                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                                {
                                    streamDownload.WriteTo(fs);
                                    fs.Flush();
                                }
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Failed:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
