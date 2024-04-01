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

                var html ="";
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
                    if (ask("y/n", 100, true, "Do you want to use this link?\n" + "LINK: " + cache + "\nTITLE: " + doccache.SelectSingleNode(".//span[@class='label label--silver']").NextSibling.InnerText.Trim()))
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
