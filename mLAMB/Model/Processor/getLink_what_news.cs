using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace mLAMB
{
    public partial class Processor
    {
        public partial class Command
        {

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
                    if (code.Length > 0)
                        do
                        {

                            var cache2 = doccache.SelectSingleNode(".//div[@class='structItem-title']");
                            cache2 = cache2.SelectSingleNode(".//span");
                            //"PMT FREE MOD"
                            if (code[0] == cache2.InnerText)
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
        }
    }
}
