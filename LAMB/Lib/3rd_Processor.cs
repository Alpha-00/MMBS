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

namespace LAMB.Lib
{
    public class Processor
    {
        public class AutoProcessor
        {
            public class processLink
            {
                // Variables
                public Type.Link link;
                public Type.sourceHTML source;
                //
                public processLink()
                {

                }
                public processLink(string cmd)
                {
                    // Normal Process with no cmd
                    if (!cmd.Contains("::::"))
                    {
                        
                        if (ProcSupport.checkValid.ValidLink(cmd))
                        {
                            link = new Type.Link(cmd);
                        }
                        return;
                    }
                }
                public processLink(string cmd, params string[] p)
                {

                }
                public void Start()
                {
                    ProcessLink();
                }
                public void ProcessLink()
                {
                    if (link.source == Enum.Source.platinmods) ProcessLink_Platinmods();
                }
                public void ProcessLink_Platinmods()
                {
                    
                    //Simple relative process
                    {
                        ProcSupport.Webdriver.platinmods platinmods = new ProcSupport.Webdriver.platinmods();
                        platinmods.Login();
                        platinmods.driver.Navigate().GoToUrl(link.link);
                        string postcode = platinmods.driver.PageSource.Substring(platinmods.driver.PageSource.IndexOf("post-") + "post-".Length);
                        string cache = platinmods.driver.PageSource;
                        postcode = postcode.Remove(postcode.IndexOf("\""));
                        platinmods.driver.Navigate().GoToUrl($"https://platinmods.com/posts/{postcode}/react?reaction_id=1");
                        if (!platinmods.driver.PageSource.Contains("Are you sure you want to remove your reaction?"))
                        { platinmods.driver.FindElement(OpenQA.Selenium.By.ClassName("button--icon--confirm")).Click();
                            cache = platinmods.driver.PageSource;
                        }
              
                        platinmods.driver.Dispose();
                        localAPI.File.txtTest(cache);
                        //Parser
                        //For PlayStore source only
                        if (cache.Substring(0, 2000).Contains("play.google.com"))
                        {
                            Lib.Type.outputMMBS outputer = new Type.outputMMBS();
                            string keyword = "play.google.com/store/apps/details?id=";
                            string res = cache.Substring(cache.IndexOf(keyword) + keyword.Length);
                            res = res.Remove(res.IndexOf("\n"));
                            res = res.Trim();
                            outputer.FreeData.Add("playID", res);
                            keyword = " Ver. ";
                            res = cache.Substring(cache.IndexOf(keyword) + keyword.Length);
                            res = res.Remove(res.IndexOf(" "));
                            res = res.Trim();
                            outputer.FreeData.Add("ver", res);
                            bool resVercompare = false;
                            {//Version compare
                                var cache_net = new System.Net.WebClient();
                                cache_net.Encoding = Encoding.UTF8;
                                string webpage = "";
                                try
                                {
                                    webpage = cache_net.DownloadString("https://play.google.com/store/apps/details?id=" + outputer.FreeData["playID"] + "&hl=en");
                                }
                                catch (Exception e)
                                {
                                    
                                }
                                string identity_head = "<div class=\"hAyfc\"><div class=\"BgcNfc\">Current Version</div><span class=\"htlgb\"><div class=\"IQ1z0d\"><span class=\"htlgb\">";
                                string identity_tail = "</span></div></span></div>";
                                int subcache = webpage.IndexOf(identity_head) + identity_head.Length;
                                string tmp = webpage.Substring(subcache, 255);
                                tmp = tmp.Remove(tmp.IndexOf(identity_tail));
                                res = tmp.Trim(' ');
                                if (!(res.Contains(" ") && outputer.FreeData["ver"].Contains(" ")))
                                {
                                    int i = 0;
                                    int counter1 = res.Split('.').Sum((x) => { return Convert.ToInt32(x) * (10 ^ i++); });
                                    i = 0;
                                    int counter2 = outputer.FreeData["ver"].Split('.').Sum((x) => { return Convert.ToInt32(x) * (10 ^ i++); });
                                    resVercompare = counter1 == counter2;
                                    if (!resVercompare)
                                    {
                                        switch ( MessageBox.Show("This is not lastest version", "WARNING", MessageBoxButton.OKCancel))
                                        {
                                            case MessageBoxResult.OK: break;
                                            case MessageBoxResult.Cancel: return; break;
                                        }
                                    }
                                }
                                else Console.WriteLine("LAMBWarning: Can't Compare Value");
                                
                            }//Endof Version compare
                            {//Check for duplicated

                            }
                            {//Get More Information
                                string cacheArticle = cache.Substring(cache.IndexOf("<article class=\"message-body js-selectToQuote\">") + "<article class=\"message-body js-selectToQuote\">".Length);
                                cacheArticle = cacheArticle.Remove(cacheArticle.IndexOf("</article>"));
                                //OBB
                                if (cacheArticle.ToLower().Contains(" obb"))
                                {
                                    res = cacheArticle.Substring(cacheArticle.ToLower().IndexOf(" obb"));
                                    res = res.Remove(res.IndexOf("<br>"));
                                    bool check = false;
                                    //Remove Html tag
                                    res = res.Select((s) => { if (!check) { check = s == '<'; if (!check) return s; } else { check = !(s == '>'); } return '\0';  }).ToString();
                                    res = (!res.ToLower().Contains("no")).ToString();
                                    outputer.FreeData.Add("obb", res);
                                }
                                //ROOT
                                if (cacheArticle.ToLower().Contains(" root"))
                                {
                                    res = cacheArticle.Substring(cacheArticle.ToLower().IndexOf(" root"));
                                    res = res.Remove(res.IndexOf("<br>"));
                                    bool check = false;
                                    //Remove Html tag
                                    res = res.Select((s) => { if (!check) { check = s == '<'; if (!check) return s; } else { check = !(s == '>'); } return '\0'; }).ToString();
                                    res = (!res.ToLower().Contains("no")).ToString();
                                    outputer.FreeData.Add("root", res);
                                }
                                //Mod information
                                res = cacheArticle.Substring("<div class=\"contentRow-main\">");
                                if (res.RemoveFrom("How To Install").ToLower().Contains("mod "))
                                {

                                }
                            }

                        }
                        else MessageBox.Show("Error: This post is not supported");
                    }
                    //
                }
            }
            
        }
    }
}
