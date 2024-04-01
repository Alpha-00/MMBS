using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;

namespace mLAMB
{
    public partial class Processor
    {
        public partial class Command
        {
            public int proclink_apple(string cmd, params string[] code)
            {
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

                // START PARSING
                shell("`**START PARSING");

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(webpage);
                string devtext = "";
                var doc_cache = doc.DocumentNode.SelectNodes("//article")[0];
                //doc_cache = doc_cache.SelectNodes(".//article")[0];
                doc_cache = doc_cache.SelectSingleNode(".//div[@class='message-cell message-cell--main']//div[@class='message-content js-messageContent']/div/article/div");
                {
                    var getcache = doc_cache.SelectSingleNode("./a");
                    if (getcache != null)
                    {
                        string strparse = getcache.Attributes["href"].Value;
                        strparse = HttpUtility.HtmlDecode(strparse);
                        dat.temp.Add("playlink", strparse);
                        shell("@playlink," + dat.temp.Last().Value);
                    }
                    /*else
                        //Try Again
                        try
                        {
                            var strparse = doc_cache.InnerHtml;
                            strparse = strparse.Substring(strparse.IndexOf("https://apps.apple.com"));
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
                    */
                }
                try
                {
                    var x = doc_cache.SelectSingleNode(".//span[@style='color: #ff0000']");
                    while (!(x is null))
                    {
                        if (x.InnerText.StartsWith("Game Name:"))
                        {
                            while (x.Name != "div")
                            {
                                x = x.NextSibling;
                                if (x.Name == "#text")
                                {

                                    if (x.InnerText.ToLower().Contains("game version"))
                                    {
                                        dat.temp.Add("version", x.InnerText.Split(':')[1].Trim());
                                        shell("@version," + dat.temp.Last().Value);
                                        
                                    }

                                    if (x.InnerText.ToLower().Contains("bundle id"))
                                    {
                                        dat.temp.Add("package", x.InnerText.Split(':')[1].Trim());
                                        shell("@package," + dat.temp.Last().Value);
                                    }

                                    if (x.InnerText.ToLower().Contains("needs jailbreak"))
                                    {
                                        dat.temp.Add("root", (x.NextSibling.InnerText.Trim().ToLower().Contains("no") ? "false" : "true"));
                                        shell("@root," + dat.temp.Last().Value);

                                    }
                                    if (x.InnerText.ToLower().Contains("supported ios"))
                                    {
                                        dat.temp.Add("reqsys", x.InnerText.Split(':')[1].Trim());
                                        shell("@reqsys," + dat.temp.Last().Value);
                                        break;
                                    }
                                }
                            }
                        }
                        if (x.InnerText.ToLower().StartsWith("supported devices:"))
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
                                    if (xx.InnerText.Contains("free download:"))
                                        break;
                                    if (xx.InnerText.Contains("how to make"))
                                        break;
                                    if (xx.InnerText.Contains("How to make this cheat run for you"))
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
                                dat.temp.Add("device", getcache);
                                shell("@device,\"" + dat.temp.Last().Value + "\"");
                            }
                        }
                        if (x.InnerText.ToLower().StartsWith("*mod features*"))
                        {
                            var xx = x.NextSibling;
                            var getcache = "";
                            while ((xx.Name != "span") || (xx.GetAttributeValue("style", "") != "color: #ff0000"))
                            {
                                xx = xx.NextSibling;
                                if (xx is null) break;
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
                                    if (xx.InnerText.Contains("free download:"))
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
                        //Search for next node
                        x = x.NextSibling;
                    }
                }
                catch (Exception e)
                {
                    shell($"`+++++\nError Code: 'get Requirement'.PROCESSOR.class Command.in start.is proclink! \n{e.Message}");
                }
                //Sending Data
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
