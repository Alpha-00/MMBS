using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using mLAMB.Resources.Dialogs;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Web;
using System.Windows;

namespace mLAMB
{
    public partial class Processor
    {
        public partial class Command
        {
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
                client.Encoding = Encoding.UTF8;
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
                    var cache = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'p-title')]/h1");
                    //cache = cache.SelectSingleNode(".//span");
                    var str = cache.ChildNodes.ToArray().Where<HtmlNode>((x) => x.Name == "#text").Select<HtmlNode, string>((x) => x.InnerText);
                    shell("@leechlabel," + String.Join("", str));
                    dat.temp.Add("leechlabel", String.Join("", str));
                    /*if (cache.InnerText!= "PMT FREE MOD")
                    {
                        if (!ask("y/n", -1, false, "WARNING: This post is not completely supported yet. Do you want to continue?"))
                        {
                            goto processSendtoMMBS;
                        }
                        
                    }
                    else*/
                    {
                        //Get Credit
                        cache = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'p-description')]");
                        cache = cache.SelectSingleNode(".//a[contains(@class,\"username\")]");
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
                                        break;
                                    if (xx.InnerHtml == "Stay away from harmful malicious mods that fill your device with UNWANTED ADS! I always provide quality service with no such malicious tricks to earn money. We want you happy, that's our goal. You can be sure to download quality on platinmods.com.")
                                        break;
                                    if (xx.InnerText.StartsWith("<br>\n*Video Preview*"))
                                        break;

                                    if (xx.InnerText.StartsWith("You need to enable"))
                                    {
                                        if (xx.NextSibling.InnerText.Contains("Overlay Permission and Storage Permission")) dat.temp.Add("extperm", "true");
                                        break;
                                    }
                                    if (xx.InnerText.StartsWith("___"))
                                        break;
                                    if (xx.InnerText.StartsWith("***"))
                                        break;
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
                //devtext = doc_cache.InnerHtml;
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
                Dictionary<string, int> links = new Dictionary<string, int>();

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
                            links.Add(xxx.Attributes["href"].Value, b1);
                            shell($"`{++l}.{links.Last().Key}");
                        }
                        b1++;

                    }
                    proclink =
                    !links.Keys.Any((linkx) => { return linkx.Contains("drive.google.com"); }) ? false : ask("y/n", 100, true, "Do you want the program process all those link?");
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
                        switch ((new Uri(xx)).Host)
                        {
                            case "drive.google.com":
                                {
                                    proc_Downlink = string.IsNullOrEmpty(proc_Downlink) ? xx : proc_Downlink;
                                }
                                break;
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

        }
    }
}
