using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace mLAMB
{
    public partial class Processor
    {
        public partial class Command
        {
            public string getlastest_apple()
            {
                var html = "";
                var categoryUri = new Uri("https://platinmods.com/forums/mods-for-jailbroken-ios-devices.134/");
                WebLoader request = new WebLoader(categoryUri,WebLoader.WebLoaderSetting.Cookie);

                html = WebLoader.webpageresult;

                try
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    var doccache = doc.DocumentNode.SelectNodes("//div[@class=\"block-body\"]/div/div/div")[0];
                        doccache = doccache.SelectSingleNode("./div[2]/div/a[2]");
                    string cache = "https://platinmods.com" + doccache.Attributes["href"].Value;
                    shell("?clipboard.settext\n" + cache);
                    if (Properties.Settings.Default.setFireWeb) System.Diagnostics.Process.Start(cache);
                    if (ask("y/n", 100, true, "Do you want to use this link?\n" + "LINK: " + cache)) ; // "\nTITLE: " + doccache.SelectSingleNode(".//span[@class='label label--silver']").NextSibling.InnerText.Trim()))
                        return cache;
                    return "";
                }
                catch (Exception e)
                {
                    shell($"`+++++\nError Code: 'get newest'.PROCESSOR.class Command.in start.is getnewest! \n{e.Message}");
                    return "";
                }


            }
        }
    }
}
