// Execute Module
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft;
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
using System.Web;
using System.Net;

using HtmlAgilityPack;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Net.Http;
using OpenQA.Selenium.Interactions;

using OpenQA.Selenium.Edge;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;

namespace MMBS
{
    class MMBStool
    {
        class codeSupporter
        {
            public static bool ContainsAll(string str, params string[] cha)
            {
                bool res = true;
                foreach (string cache in cha)
                {
                    res = res && str.Contains(cache);
                }
                return res;
            }
            public static bool ContainsOne(string str, params string[] cha)
            {
                bool res = false;
                foreach (string cache in cha)
                {
                    if (str.Contains(cache)) { return true; }
                }
                return res;
            }
        }
        public class SearchKeywordGenerator
        {
            static string Main(string modtype, string name) => Module.SearchKeywordModule.GetResStr(modtype, AnameAnalyse(name));
            public static string[] AnameAnalyse(string name)
            {
                List<string> cache = new List<string>();
                Console.WriteLine("MMBStool. SKG. AnA. create list");
                name = name.Trim();

                Console.WriteLine("MMBStool. SKG. AnA. trim string, result:" + name);
                cache.Add(name);
                if (codeSupporter.ContainsOne(name, ":", "-") || name.ToCharArray().Any(char.IsDigit))
                {
                    if (codeSupporter.ContainsOne(name, ":", "-"))
                    {
                        string[] minicache = name.Split(':', '-');
                        foreach (string _minicache in minicache)
                        {
                            if (!String.IsNullOrWhiteSpace(_minicache))
                            {
                                cache.Add(_minicache.Trim());
                            }
                        }
                    }
                    //TODO: Analyst App Series. Ex: Dragon Quest 2...
                }
                return cache.ToArray();
            }
        }
    }
    public class LinkerDataModule
    {
        public class Sample_DataResource
        {
            public string type;//play, apkpure
            public string link;
            public string linkmask;
            public string shortenlink;
            public string webpage;
            public bool valid;
            public string[] Identity;//Ma nhan dien link
            public int maxstep;
            public int step;
            public string processname;
            public Sample_DataResource(string link)
            {
                try
                {
                    valid = false;
                    System.Net.WebClient cache = new System.Net.WebClient();
                    webpage = cache.DownloadString(link);
                    valid = true;

                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("MEcode - 1: Data Retrieve Error" + e.Source + "\n" + e.Message);
                }
            }
            public Sample_DataResource()
            {

            }
            public bool Isthis(string link)
            {
                bool cache = false;
                foreach (string i in Identity)
                {
                    if (link.Contains(i)) return true;
                }
                return cache;
            }
            async public void SyncProc(string link, bool fullproc)
            {
                /*
                 * DeSripTion
                 * 1/GetLink
                 */

                System.Net.WebClient cache = new System.Net.WebClient();
                webpage = await cache.DownloadStringTaskAsync(link);
            }
        }
        public static class DataResourceInstance
        {


        }
    }
    public class OldProcessor
    {
        public static class ProcSupporter
        {
            public static string StrToHex(string st)
            {
                byte[] cache = Encoding.Default.GetBytes(st);
                string recheckcache = "%" + BitConverter.ToString(cache).Replace("-", "%");
                return (recheckcache == "%" ? "" : recheckcache);
            }
            public static string HtmlSpecialProcess(string st)
            {
                return System.Web.HttpUtility.HtmlDecode(st);
            }
            public static string BoldSpecialProcess(string st)
            {
                string cache = st;
                cache = re(new string[] { "features", "how to play", "what's new", "important", "rules", "note" });
                return cache;
                string re(string[] st2)
                {
                    string reres = "";
                    if (!String.IsNullOrWhiteSpace(cache))
                    {
                        string[] reCache = cache.Split('\n');
                        foreach (string reCache2 in reCache)
                        {
                            bool check = false;
                            foreach (string indentity in st2)
                                if (reCache2.ToLower().Contains(indentity) && (!reCache2.ToLower().Contains("<b>")) && reCache2.Length < indentity.Length + 6)
                                {
                                    reres += "<b>" + reCache2 + "</b>\n"; check = true; break;
                                }
                            if (!check) reres += reCache2 + "\n";
                        }
                    }
                    return reres;
                }
                //What is respeacial?
            }
            /* public static int imageDuplicateAIdistance(string dir1, string dir2, bool isURL)
             {
                 DeepAI_API api = new DeepAI_API(Class1.GetToken("Dai"));
                 if (isURL)
                 {

                     StandardApiResponse resp = api.callStandardApi("image-similarity", new
                     {
                         image1 = dir1,
                         image2 = dir2,
                     });
                     var check = api.objectAsJsonString(resp);

                     return GetRes(check);

                 }
                 else
                 {
                     StandardApiResponse resp = api.callStandardApi("image-similarity", new
                     {

                         image1 = System.IO.File.OpenRead(dir1),
                         image2 = System.IO.File.OpenRead(dir2),
                     });
                     var check = api.objectAsJsonString(resp);

                     return GetRes(check);
                 }
                 return 4269;
                 int GetRes(string check)
                 {
                     try
                     {
                         var cache = JObject.Parse(check)["distance"];
                         if (String.IsNullOrEmpty(cache.ToString()))
                         {
                             cache = JObject.Parse(check)["output"]["distance"];
                         }

                         if (String.IsNullOrEmpty(cache.ToString()))
                         {
                             cache = check.Substring(check.IndexOf("\"distance\":") + "\"distance\":".Length);
                             cache = cache.ToString().Remove(cache.ToString().IndexOf("\n"));

                         }
                         return Convert.ToInt32(cache.ToString());
                     }
                     catch (Exception e)
                     {
                         return 4269;
                     }

                 }
             }*/
            public static bool ValidLinker(string link)
            {
                try
                {
                    string cache = link.Replace(" ", "");

                    if (!String.IsNullOrWhiteSpace(link))
                    {
                        if (link.Contains("http") && link.Contains("/") && link.Contains("."))
                        {
                            Uri uri = new Uri(link);
                            if (uri.IsWellFormedOriginalString())
                            {
                                if (!String.IsNullOrWhiteSpace(uri.PathAndQuery)) return true;
                            }
                        }
                    }
                }
                catch (Exception e) { return false; }

                return false;
            }
            public class HtmlScriptCard
            {
                public int start;
                public int stop;
                public string script;
                public bool avalable;
                public bool trueform;

                public string GetData(string keyword)
                {
                    string cache = script;
                    if (script.Contains(keyword))
                    {
                        int i = script.IndexOf(keyword + "=\"");
                        i += keyword.Length;
                        //System.Windows.Forms.MessageBox.Show(cache.Substring(i).Substring(cache.IndexOf('"')));
                        cache = cache.Substring(i);
                        cache = cache.Substring(cache.IndexOf('"') + 1);
                        cache = cache.Remove(cache.IndexOf('"'));

                        return cache;
                    }
                    return "";
                }
                public string GetData(string keyword, string ending)
                {
                    string cache = script;
                    if (script.Contains(keyword))
                    {
                        int i = script.IndexOf(keyword + "=\"");
                        i += keyword.Length;
                        //System.Windows.Forms.MessageBox.Show(cache.Substring(i).Substring(cache.IndexOf('"')));
                        cache = cache.Substring(i);
                        cache = cache.Substring(cache.IndexOf('"') + 1);
                        cache = cache.Remove(cache.IndexOf(ending));

                        return cache;
                    }
                    return "";
                }
            }
            public static HtmlScriptCard FindCardinScript(string script, string keyword)
            {
                return FindCardinScript(script, script.IndexOf(keyword));
            }
            public static HtmlScriptCard FindCardinScript(string script, int pos)
            {
                HtmlScriptCard cache = new HtmlScriptCard();
                cache.trueform = true;
                cache.avalable = false;
                try
                {
                    if (string.IsNullOrWhiteSpace(script))
                    {
                        throw new Exception("HTML Parser: Empty script!");
                    }
                    if (pos < 0)
                    {
                        throw new Exception("HTML Parser: Pos Index can't be negative");
                    }

                    int cache2 = pos;
                    int stack = 0;

                    for (int i = cache2; (i <= script.Length-1); i++)
                    {
                        if (script[i] == '>')
                        {
                            if (stack == 0)
                            {
                                cache.stop = i;
                                break;
                            }
                            // If stack > 0
                            stack--;
                        }
                        if (script[i] == '<')
                        {
                            stack++;
                        }
                        if (i == script.Length-1)
                        {
                            cache.stop = i;
                            cache.trueform = false;
                        }
                    }
                    stack = 0;
                    for (int i = cache2; (i >= 1); i--)
                    {
                        if (script[i] == '<')
                        {
                            if (stack == 0)
                            {
                                cache.start = i;
                                break;
                            }
                            // If stack > 0
                            stack--;
                        }
                        if (script[i] == '>')
                        {
                            stack++;
                        }
                        if (i == 1)
                        {
                            cache.start = i;
                            cache.trueform = false;
                        }
                    }

                    cache.script = script.Substring(cache.start, cache.stop - cache.start + 1);
                    cache.avalable = true;
                    return cache;

                }
                catch (Exception e)
                {
                    throw e;
                }
                return cache;
            }
            //Todo: I wanna have a Html webpage library
            public class ImageDownloader
            {
                public byte[] ImageinByte;
                public System.Drawing.Image image;
                public string name;
                public string ImageDir;
                public string Link;
                public string ImageType;
                public int height;
                public int width;
                public enum ImageFormat
                {
                    bmp,
                    jpeg,
                    gif,
                    tiff,
                    png,
                    webp,
                    unknown
                }
                public static ImageFormat GetImageFormat(byte[] bytes)
                {
                    // see http://www.mikekunz.com/image_file_header.html  
                    var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
                    var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
                    var png = new byte[] { 137, 80, 78, 71 };    // PNG
                    var tiff = new byte[] { 73, 73, 42 };         // TIFF
                    var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
                    var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
                    var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon
                    var webp = Encoding.ASCII.GetBytes("RIFF");

                    if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                        return ImageFormat.bmp;

                    if (gif.SequenceEqual(bytes.Take(gif.Length)))
                        return ImageFormat.gif;

                    if (png.SequenceEqual(bytes.Take(png.Length)))
                        return ImageFormat.png;

                    if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                        return ImageFormat.tiff;

                    if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                        return ImageFormat.tiff;

                    if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                        return ImageFormat.jpeg;

                    if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                        return ImageFormat.jpeg;

                    if (webp.SequenceEqual(bytes.Take(webp.Length)))
                        return ImageFormat.webp;

                    return ImageFormat.unknown;
                }
                public ImageDownloader(string link, string name_without_extension, string folder)
                {
                    try
                    {
                        Link = link;
                        System.Net.WebClient cache_net = new System.Net.WebClient();
                        ImageinByte = cache_net.DownloadData(link);
                        ImageType = GetImageFormat(ImageinByte).ToString();
                        MemoryStream ImageStream = new MemoryStream(ImageinByte);
                        image = System.Drawing.Image.FromStream(ImageStream);
                        width = image.Width;
                        height = image.Height;
                        this.name = name_without_extension;
                        ImageDir = folder + "\\" + name_without_extension + "." + ImageType;
                        System.IO.File.WriteAllBytes(ImageDir, ImageinByte);
                        return;
                    }
                    catch (Exception e)
                    {
                        if (ImageType == "webp") { }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Download ERROR\n"+link+"\n" + e.Message);
                        }
                    }
                    if (ImageType == "webp")
                        try
                        {
                            Link = link;
                            System.Net.WebClient cache_net = new System.Net.WebClient();
                            ImageinByte = cache_net.DownloadData(link);
                            ISupportedImageFormat format = new ImageProcessor.Plugins.WebP.Imaging.Formats.WebPFormat();
                            Size size = new Size(192, 0);
                            using (MemoryStream inStream = new MemoryStream(ImageinByte))
                            {
                                using (MemoryStream outStream = new MemoryStream())
                                {
                                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                                    {
                                        // Load, resize, set the format and quality and save an image.
                                        image = (Image)imageFactory.Load(inStream).Image.Clone();
                                        width = image.Width;
                                        height = image.Height;

                                        this.name = name_without_extension;
                                        ImageDir = folder + "\\" + name_without_extension + "." + ImageType;
                                        System.IO.File.WriteAllBytes(ImageDir, ImageinByte);
                                    }
                                    // Do something with the stream.
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show("Download ERROR 2\n" + e.Message);
                        }
                }


            }
            public static string ShortenLink(string link)
            {
                switch (Properties.Settings.Default.shortenlinkServer)
                {
                    case ("megaurl.in"): return server_megaurl(); break;
                }
                return link;
                string server_123link(params string[] dat)
                {
                    string cache;
                    if (System.IO.File.Exists("C:\\BloggerSupporter\\123linkToken.txt"))
                    {
                        cache = System.IO.File.ReadAllText("C:\\BloggerSupporter\\123linkToken.txt");

                    }
                    else
                    {
                        cache = Microsoft.VisualBasic.Interaction.InputBox("Nhập API token 123link của bạn", "API token");
                    }
                    if (cache != "")
                    {
                        try
                        {
                            cache = cache.Trim();
                            if (!ValidLinker(link)) return "";
                            var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://123link.co/api?api=" + cache + "&url=" + link + "&format=text");
                            var response = (System.Net.HttpWebResponse)request.GetResponse();
                            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            if (responseString != "")
                            {
                                return responseString;
                            }
                            else
                            {
                                // { "status":"error","message":"Invalid URL","shortenedUrl":""}
                                return "";
                            };
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                        }
                    }
                    return "";
                }
                string server_megaurl(params string[] dat)
                {
                    string cache;
                    if (System.IO.File.Exists("C:\\BloggerSupporter\\megaurlToken.txt"))
                    {
                        cache = System.IO.File.ReadAllText("C:\\BloggerSupporter\\megaurlToken.txt");

                    }
                    else
                    {
                        cache = Microsoft.VisualBasic.Interaction.InputBox("Nhập API token Megaurl của bạn", "API token");
                        if (cache == "")
                        { cache = Class1.GetToken("Murl"); }
                        else
                            System.IO.File.WriteAllText("C:\\BloggerSupporter\\megaurlToken.txt", cache);
                    }

                    try
                    {
                        cache = cache.Trim();
                        if (!ValidLinker(link)) return "";
                        var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://megaurl.in/api?api=" + cache + "&url=" + link + "&format=text");
                        var response = (System.Net.HttpWebResponse)request.GetResponse();

                        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        if (responseString.Contains("<html"))
                        {
                            throw new Exception("Can't bypass Firewall Of Magaurl API");
                        }
                        if (responseString != "")
                        {
                            return responseString;
                        }
                        else
                        {
                            // { "status":"error","message":"Invalid URL","shortenedUrl":""}
                            throw new Exception("Fail to shorten link in Megaurl.in");
                            return "";
                        };
                    }

                    catch (Exception e)
                    {
                        if (e.Message == "Can't bypass Firewall Of Magaurl API") return "SYSCall:MegaurlExc:" + "https://megaurl.in/api?api=" + cache + "&url=" + link + "&format=text";
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        return "";
                    }


                    return "";
                }
            }

 
            public static string httpreqDownloadString(Uri uri)
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
                        client.Encoding = Encoding.UTF8;
                        try
                        {
                            return client.DownloadString(uri);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Webload Error {uri}\n{e.Message}");
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
                        
                        using (var driver = new EdgeDriver(serviceSet,options))
                        {
                            driver.Navigate().GoToUrl(uri.OriginalString);
                            cache = driver.PageSource;
                        };
                        return cache;
                    }
                    catch(Exception e)
                    {
                        throw new Exception("Webloader Selenium Error\n" + e.Message);
                    }
                }

            }
            
        }
        public class ProcessDataResourceTextBox
        {

            public string step;
            public string cacheDir;
            System.Net.WebClient cache_net;
            //Data Here
            public string coverImagelink;
            public string coverImageDir;
            public ProcSupporter.ImageDownloader coverImage;
            public string packagename;
            public string webpage;
            public string link;
            public string host;
            public string customdata;
            public Newtonsoft.Json.Linq.JObject jsondata;
            public int valid;
            //
            public ProcessDataResourceTextBox(string content)
            {
                string cache = content.Replace(" ", "");
                if (OldProcessor.ProcSupporter.ValidLinker(content))
                {
                    Uri uri = new Uri(cache);
                    host = uri.Host;
                    link = uri.ToString();
                    cache_net = new System.Net.WebClient();
                    cache_net.Proxy = null;
                    cache_net.Encoding = Encoding.UTF8;
                    valid = 0;
                    switch (uri.Host.ToLower())
                    {
                        case "play.google.com": PLAYproc(Play_Getpackedname(uri)); break;
                        case "apps.apple.com": APPLEproc(uri);break;
                        case "apkpure.com": APKPUREproc(APKpure_Getpackedname(uri)); break;
                        case "apkcombo.com": APKCOMBOproc(APKcombo_Getpackedname(uri)); break;
                        case "apps.qoo-app.com": QOOAPPproc(uri);break;
                        default: valid = 0; break;
                    }

                }
                else valid = 2;
                void PLAYproc(string packagename)
                {
                    this.packagename = packagename;
                    link = ("https://play.google.com/store/apps/details?id=" + packagename + "&hl=en");
                    try
                    {

                        webpage = cache_net.DownloadString(link);
                        //System.Windows.Forms.Clipboard.SetText(webpage);
                        cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + packagename;
                        if (!System.IO.Directory.Exists(cacheDir)) System.IO.Directory.CreateDirectory(cacheDir);
                        ProcSupporter.HtmlScriptCard scriptCache;
                        scriptCache = ProcSupporter.FindCardinScript(webpage, "alt=\"Icon image\"");
                        coverImagelink = scriptCache.GetData("src");

                        if (string.IsNullOrEmpty(coverImagelink)) throw new Exception("Can't find cover image");
                        if (coverImagelink.Contains("-rw")) coverImagelink = coverImagelink.Remove(coverImagelink.Length - 2);
                        if (!coverImagelink.Contains("http")) coverImagelink = "https://" + coverImagelink;
                        //https://play-lh.googleusercontent.com/IeGa7ALAZCgO5TNWfEbxtJdtmM6QKZjbPax4uHHgFhMJfpWdupkmjY5WvUfq99ThZPc=s180
                        string temp_coverthumbnailLink = coverImagelink.Remove(coverImagelink.IndexOf("=") + 1) + "s140";
                        coverImage = new ProcSupporter.ImageDownloader(temp_coverthumbnailLink, "cover", cacheDir);
                        coverImageDir = coverImage.ImageDir;
                        coverImage.ImageinByte = null;
                        link = ("https://play.google.com/store/apps/details?id=" + packagename);
                        valid = 1;

                        // System.Windows.Forms.MessageBox.Show(coverImagelink);

                    }

                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Loi gi roi\nPlay Processor\n" + e.Message);
                        valid = 2;

                    }

                }
                void APPLEproc_dedicated (string packagename)
                {
                    this.packagename = packagename;
                    link = ($"https://apps.apple.com/us/app/{packagename}");
                    try
                    {
                        webpage = cache_net.DownloadString(link);
                        //System.Windows.Forms.Clipboard.SetText(webpage);
                        cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + packagename;
                        if (!System.IO.Directory.Exists(cacheDir)) System.IO.Directory.CreateDirectory(cacheDir);
                        HtmlDocument htmlDocument = new HtmlDocument();
                        htmlDocument.LoadHtml(webpage);
                        coverImagelink = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[@class=\"ember-view\"]/main//section[1]/div/div[1]/picture/source[2]").Attributes["srcset"].Value;
                        coverImagelink = coverImagelink.Remove(coverImagelink.IndexOf(" ")).Trim();

                        coverImage = new ProcSupporter.ImageDownloader(coverImagelink, "cover", cacheDir);
                        coverImageDir = coverImage.ImageDir;
                        coverImage.ImageinByte = null;
                        valid = 1;

                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Loi gi roi\n" + e.Message);
                        valid = 2;
                    }
                }
                void APPLEproc(Uri url)
                {
                    string identity_head = "/id";
                    if (!url.AbsolutePath.Contains(identity_head)) 
                        {
                            packagename = APPLE_Getpackedname(url);
                            APPLEproc_dedicated(packagename);
                            return; 
                        };
                    string temp = url.AbsolutePath.Substring(url.AbsolutePath.IndexOf(identity_head)+3);
                    if (temp.Contains("?")) temp = temp.Remove(temp.IndexOf("?"));
                    link = url.OriginalString;
                    Uri lookupURL = new Uri($"https://itunes.apple.com/lookup?id={temp}");
                    try
                    {
                        //webpage = cache_net.DownloadString(lookupURL);
                        webpage = ProcSupporter.httpreqDownloadString(lookupURL);
                        //System.Windows.Forms.Clipboard.SetText(webpage);
                        JObject dat = JObject.Parse(webpage) ;
                        if (dat.SelectToken("$.resultCount").Value<int>()>0)
                        {
                            valid = 2;
                        }
                        packagename = dat.SelectToken("$.results[0].bundleId").Value<string>();
                        cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + packagename;
                        if (!System.IO.Directory.Exists(cacheDir)) System.IO.Directory.CreateDirectory(cacheDir);
                        //webpage = cache_net.DownloadString(url);
                        coverImagelink = dat.SelectToken("$.results[0].artworkUrl512").Value<string>();
                        coverImage = new ProcSupporter.ImageDownloader(coverImagelink, "cover", cacheDir);
                        coverImageDir = coverImage.ImageDir;
                        coverImage.ImageinByte = null;
                        valid = 1;

                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Loi gi roi\n" + e.Message);
                        valid = 2;
                    }
                }
                void APKPUREproc(string packagename)
                {
                    this.packagename = packagename;
                    try
                    {
                        if (link.Contains("/vn/")) link = link.Replace("/vn/", "/");
                        //! The Code to solve 403 Forbiden problem
                        //Source Code: https://stackoverflow.com/questions/16735042/the-remote-server-returned-an-error-403-forbidden
                        //Navigate to front page to Set cookies
                        // HttpRequest htmlReq = new HttpRequest("","","");

                        // Dictionary<string,List<string>> OLinks = new Dictionary<string, List<string>>();

                        // string Url = uri.AbsoluteUri;
                        CookieContainer cookieJar = new CookieContainer();
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                        request.CookieContainer = cookieJar;

                        request.Accept = @"text/html, application/xhtml+xml, */*";
                        //request.Referer = @"https://www.apkadmin.com/";
                        request.Headers.Add("Accept-Language", "en-GB");
                        request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
                        //request.Host = @"www.apkadmin.com";
                        request.UseDefaultCredentials = true;

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            webpage = reader.ReadToEnd();
                        }
                        //End Source
                        cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + packagename;
                        if (!System.IO.Directory.Exists(cacheDir)) cache = System.IO.Directory.CreateDirectory(cacheDir).FullName;
                        ProcSupporter.HtmlScriptCard scriptCache;
                        scriptCache = ProcSupporter.FindCardinScript(webpage, "class=\"apk_info\"");
                        // 3 next index include a stop, a next begin and a line break /n
                        scriptCache = ProcSupporter.FindCardinScript(webpage, scriptCache.stop + 3);

                        coverImagelink = scriptCache.GetData("src");
                        //System.Windows.Forms.MessageBox.Show(scriptCache.script);
                        if (!coverImagelink.Contains("http")) coverImagelink = "https://" + coverImagelink;
                        coverImagelink = Regex.Replace(coverImagelink, "(?<url>[^?]+\\?)(?<prefix>.+)?(?<remove>w=\\d+(&amp;|&))(?<suffix>.+)?", "${url}${prefix}${suffix}");
                        coverImagelink = Regex.Replace(coverImagelink, "(?<url>[^?]+\\?)(?<prefix>.+)?(?<remove>h=\\d+(&amp;|&))(?<suffix>.+)?", "${url}${prefix}${suffix}");
                        coverImage = new ProcSupporter.ImageDownloader(coverImagelink, "cover", cacheDir);
                        coverImageDir = coverImage.ImageDir;
                        coverImage.ImageinByte = null;

                        valid = 1;
                    }
                    catch (System.Net.WebException e)
                    {
                        valid = 2;

                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        valid = 2;
                    }
                }
                void APKCOMBOproc(string packagename)
                {
                    this.packagename = packagename;
                    try
                    {
                        cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + packagename;
                        if (!System.IO.Directory.Exists(cacheDir)) System.IO.Directory.CreateDirectory(cacheDir);

                        if (link.Contains("/vn/")) link = link.Replace("/vn/", "/");
                        CookieContainer cookieJar = new CookieContainer();
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                        request.CookieContainer = cookieJar;
                        request.Accept = @"text/html, application/xhtml+xml, */*";
                        request.Headers.Add("Accept-Language", "en-GB");
                        request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
                        request.UseDefaultCredentials = true;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            webpage = reader.ReadToEnd();
                        }

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(webpage);
                        //HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//body/section[@id=\"main\"]/div[1]//div[@class=\"info\"]/div[@class=\"app_name\"]");
                        coverImagelink = doc.DocumentNode.SelectSingleNode("//body/section[@id=\"main\"]//div[@class=\"avatar\"]/img").Attributes["data-src"].Value;
                        coverImagelink = "https:"+coverImagelink.Substring(coverImagelink.IndexOf("f=auto/") + "f=auto/".Length);
                        if (string.IsNullOrEmpty(coverImagelink)) throw new Exception("Can't find cover image");
                        if (coverImagelink.Contains("-rw")) coverImagelink = coverImagelink.Remove(coverImagelink.Length - 2);
                        if (!coverImagelink.Contains("http")) coverImagelink = "https://" + coverImagelink;
                        coverImagelink = coverImagelink.Remove(coverImagelink.IndexOf("="))+ "=w240-h480";
                        string temp_coverthumbnailLink = coverImagelink.Remove(coverImagelink.IndexOf("=") + 1) + "s140";
                        coverImage = new ProcSupporter.ImageDownloader(temp_coverthumbnailLink, "cover", cacheDir);
                        coverImageDir = coverImage.ImageDir;
                        coverImage.ImageinByte = null;
                        valid = 1;
                        

                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        valid = 2;
                    }
                }
                async void QOOAPPproc(Uri uri)
                {
                    try
                    {
                        
                        webpage = await ProcSupporter.WebLoader.webloadSeleniumEdge(uri);
                        
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(webpage);
                        this.packagename = doc.DocumentNode.SelectSingleNode("//span[cite[.=\"Package ID:\"]]/var").InnerText;

                        cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + packagename;
                        if (!System.IO.Directory.Exists(cacheDir)) System.IO.Directory.CreateDirectory(cacheDir);


                        coverImagelink = doc.DocumentNode.SelectSingleNode("/html/body//section[1]//figure/picture/source").Attributes["srcset"].Value;
                        coverImagelink = "https:" + coverImagelink.Remove(coverImagelink.IndexOf(" ")).Trim();

                        if (string.IsNullOrEmpty(coverImagelink)) throw new Exception("Can't find cover image");
                        coverImagelink = coverImagelink.Remove(coverImagelink.IndexOf("?"));
                        string temp_coverthumbnailLink = coverImagelink + "?w=192";
                        coverImage = new ProcSupporter.ImageDownloader(temp_coverthumbnailLink, "cover", cacheDir);
                        coverImageDir = coverImage.ImageDir;
                        coverImage.ImageinByte = null;
                        valid = 1;


                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        valid = 2;
                    }
                }
            }
            static string Play_Getpackedname(Uri uri)
            {
                string identity_id = "id=";
                string cache_fake1 = uri.PathAndQuery;
                cache_fake1 = cache_fake1.Substring(cache_fake1.IndexOf(identity_id) + identity_id.Length);//DeleteHeader
                if (cache_fake1.Contains('&')) cache_fake1 = cache_fake1.Remove(cache_fake1.IndexOf('&'));

                return cache_fake1;
            }
            static string APPLE_Getpackedname(Uri uri)
            {
                string cache = uri.OriginalString;
                cache = cache.Substring(cache.LastIndexOf("id"));
                return cache;
            }
            static string APKpure_Getpackedname(Uri uri)
            {
                //string structure = "host/country/app_name/apppacked";
                if (uri.ToString().Contains("vn/")) return uri.Segments[3];
                //string structure = "host/app_name/apppacked";
                //if (uri.Segments.Length > 2) return uri.Segments[2].Substring(2); //Deprecated
                if (uri.Segments.Length > 2) return uri.Segments[2];


                return "";
            }
            static string APKcombo_Getpackedname(Uri uri)
            {
                //string structure = "host/lang/app_name/apppacked";
                if (uri.Segments.Length > 3) return uri.Segments[3].Substring(2);
                if (uri.Segments.Length > 2) return uri.Segments[2].Substring(2);
                return "";
            }
        }
        public class MirrorLink
        {
            public int valid;//0: Nothing; 1: Valid; 2: Invalid
            public string link;
            public string name;
            public string host;
            public MirrorLink(string linkname, string oldlink)
            {
                LinkValidator form = new LinkValidator("Mirror Link", linkname, oldlink);
                form.ShowDialog();
                DefineInfoPack.Linker info = form.GetData();
                valid = (string.IsNullOrWhiteSpace(info.link) ? 0 : (info.check ? 1 : 2));
                link = info.link;
                name = info.linkalias;
                host = info.host;
            }
        }
       
        public class ProcessDownloadLinkTextBox
        {
            public enum request_code 
            { 
                ///<summary>Valid Check only</summary>
                SimpleInfo, 
                FullInfo 
            };
            public string step;
            System.Net.WebClient cache_net;
            //Data here
            public string host;
            public string link;
            public int valid;//0:noncheck;1:true;2:false;
            public string webpage;
            public string fname;
            public string fsize;
            public request_code REQUEST;
            //
            public ProcessDownloadLinkTextBox(string content, request_code Request = request_code.FullInfo)
            {
                REQUEST = Request;
                string cache = content.Replace(" ", "");
                //Special Pre Process for www.4file.net
                if (content.Contains("www.4file.net") && !(content.Contains("http://")||content.Contains("https://"))) cache = "http://"+content.Replace(" ", "");
                if (REQUEST == request_code.SimpleInfo)
                {
                    // User_DebugSystem.Command("call\nB?t d?u ki?m duy?t link");
                    
                    if (OldProcessor.ProcSupporter.ValidLinker(content))
                    {
                        Uri uri = new Uri(cache);
                        host = uri.Host;
                        link = cache;
                        cache_net = new System.Net.WebClient();
                        
                        valid = 0;
                        try
                        {
                            switch (uri.Host.ToLower())
                            {
                                case "userscloud.com": webpage = cache_net.DownloadString(uri); if (!string.IsNullOrEmpty(webpage)) valid = 1; break;
                                case "drive.google.com": googledriveProc(uri); break;
                                case "www.4file.net": webpage = cache_net.DownloadString(uri); if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("<b>File Not Found</b>")) valid = 1; break;
                                case "sharemods.com": webpage = cache_net.DownloadString(uri); if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("<b>File Not Found</b>")) valid = 1; break;
                                case "apkadmin.com": webpage = ProcSupporter.httpreqDownloadString(uri); if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("<h2>File Not Found</h2>")) valid = 1; break;
                                case "www.file-upload.com": webpage = ProcSupporter.httpreqDownloadString(uri); if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("<h2>File Not Found</h2>")) valid = 1; break;
                                case "www.terabox.com": webpage = ProcSupporter.httpreqDownloadString(uri); if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("share-error-msg")) valid = 1; break;
                                case "modsfire.com": webpage = ProcSupporter.httpreqDownloadString(uri); if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("Page Not Found")) valid = 1; break;
                                default: webpage = cache_net.DownloadString(uri); if (!string.IsNullOrEmpty(webpage)) valid = 1; break;
                            }
                            if (valid == 0) valid = 2;
                        }
                        catch (Exception e)
                        {
                            valid = 2;
                        }
                    }
                }
                else
                if (REQUEST == request_code.FullInfo)//!Main Processor
                {
          
                    // User_DebugSystem.Command("call\nB?t d?u ki?m duy?t link");
                    if (OldProcessor.ProcSupporter.ValidLinker(content))
                    {
                        Uri uri = new Uri(cache);
                        host = uri.Host;
                        link = cache;
                        cache_net = new System.Net.WebClient();
                        valid = 0;
                        //User_DebugSystem.Command("call\nHoàn t?t ki?m duy?t và Chu?n b? x? lý");
                        switch (uri.Host.ToLower())
                        {
                            case "userscloud.com": userscloudProc(uri); break;
                            case "drive.google.com": googledriveProc(uri); break;
                            case "www.4file.net": www4fileProc(uri); break;
                            case "sharemods.com": sharemodsProc(uri); break;
                            case "apkadmin.com": apkadminProc(uri); break;
                            case "www.file-upload.com": fileuploadProc(uri);  break;
                            case "www.terabox.com": teraboxProc(uri);  break;
                            case "modsfire.com":modsfireProc(uri); break;
                            default: valid = 0; break;
                        }

                    }
                    else valid = 2;
                }
                void userscloudProc(Uri uri)
                {
                    webpage = cache_net.DownloadString(uri);
                    ProcSupporter.HtmlScriptCard scriptCache;
                    scriptCache = ProcSupporter.FindCardinScript(webpage, "name=\"fname\"");
                    fname = scriptCache.GetData("value");
                    GetSize();
                    valid = 1;
                    void GetSize()
                    {
                        int cache1 = webpage.IndexOf("File size:");
                        if (cache1 > 0)
                        {
                            cache1 += ("File size:").Length;
                            string proccache = webpage.Substring(cache1, 50);
                            proccache = proccache.Substring(proccache.IndexOf("<b>") + "<b>".Length);
                            proccache = proccache.Remove(proccache.IndexOf("</b>"));
                            proccache = proccache.Trim(' ');
                            fsize = proccache;
                            //System.Windows.Forms.MessageBox.Show(proccache.ToCharArray()[0].ToString());
                        }
                    }
                }
                void googledriveProc(Uri uri)
                {
                    //User_DebugSystem.Command("call\nNhánh x? lý link: Host = 'drive.google.com'");
                    //Init service
                    //User_DebugSystem.Command("call\nKh?i t?o liên k?t v?i API");
                    //var service = new DriveService();
                    //try

                    string[] Scopes = { DriveService.Scope.DriveReadonly };
                    string ApplicationName = "MMBS";
                    UserCredential credential;
                    //User_DebugSystem.Command("call\nHoàn t?t kh?i t?o c?p phép");
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
                    //User_DebugSystem.Command("call\nHoàn t?t c?p phép");
                    var service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
                    //User_DebugSystem.Command("call\nHoàn t?t liên k?t v?i API");

                    //catch (Exception e)
                    {
                        //User_DebugSystem.Command("call\nÐã x?y ra l?i\n"+e.Message);
                    }
                    //Init done;
                    //User_DebugSystem.Command("call\nKh?i t?o ti?n trình thu nh?n tin");
                    try
                    {

                        string ID = GetID();
                        if (!string.IsNullOrWhiteSpace(ID) || ID.Length < 5)
                        {
                            var pretest = service.Files.Get(ID);
                            //System.Windows.Forms.MessageBox.Show(GetID());
                            pretest.Fields = "name,size";
                            //.Command("call\nTi?n hành thu nh?n tin");
                            Google.Apis.Drive.v3.Data.File metaget = pretest.Execute();
                            //.Command("call\nNh?n tin thành công và ti?n hành x? lý");
                            fname = metaget.Name;
                            fsize = ByteToSize(metaget.Size);
                            //System.Windows.Forms.MessageBox.Show(fsize);
                            valid = 1;
                        }
                        else valid = 2;
                    }
                    catch (Google.GoogleApiException e)
                    {
                        valid = 2;
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        Console.WriteLine(e.Message);
                        if (!string.IsNullOrWhiteSpace(e.HelpLink))
                            SystemAlt.Windows_Forms_Clipboard_SetText(e.HelpLink);
                    }
                    catch (Exception e)
                    {
                        valid = 2;
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                    
                    string GetID()
                    {

                        //User_DebugSystem.Command("call\nB?t d?u x? lý link d? l?y ID");

                        if (link.StartsWith("https://drive.google.com/open?id=")) { if (uri.Segments.Length > 1) { return System.Web.HttpUtility.ParseQueryString(uri.Query).Get("id"); }/*uri.Segments[1].Substring(uri.Segments[1].IndexOf("id=") + 3);*/ }
                        else if (link.StartsWith("https://drive.google.com/file/d/")) if (uri.Segments.Length > 3) return uri.Segments[3].Replace("/", "");
                        //System.Windows.Forms.MessageBox.Show(link.StartsWith("https://drive.google.com/file/d/").ToString()+"\n"+ (uri.Segments.Length > 3).ToString());
                        //AnotherStyle of GetID
                        /*string idcache = link;
                        if (idcache.Contains("https://drive.google.com/open?id=")) { idcache = idcache.Remove(link.IndexOf("https://drive.google.com/open?id="), "https://drive.google.com/open?id=".Length);return idcache.Contains("/") ? idcache.Remove(idcache.IndexOf("/")) : idcache; }
                        else if (link.Contains("https://drive.google.com/file/d/")) { idcache = idcache.Remove(link.IndexOf("https://drive.google.com/file/d/"), "https://drive.google.com/file/d/".Length); return idcache.Contains("/") ? idcache.Remove(idcache.IndexOf("/")) : idcache; }
                        */
                        return "";

                    }
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
                void www4fileProc(Uri uri)
                {
                    //webpage = cache_net.DownloadString(uri);
                    ProcSupporter.HtmlScriptCard scriptCache;
                    try
                    {
                        System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", AppDomain.CurrentDomain.BaseDirectory+"\\Driver\\chromedriver.exe");
                        ChromeOptions options = new ChromeOptions();
                        //options.BinaryLocation = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+ "\\CocCoc\\Browser\\Application\\browser.exe";
                        options.AddArgument("--headless");
                        //options.AddArguments("user-data-dir=C:/Users/user_name/AppData/Local/Google/Chrome/User Data");
                        OpenQA.Selenium.Chrome.ChromeDriver driver = new ChromeDriver(options);
                        driver.Navigate().GoToUrl(uri);
                        driver.FindElement(By.Id("method_free")).Click();
                        webpage = driver.PageSource;
                        driver.Quit();
                    }
                    catch(Exception e)
                    {
                        try
                        {
                            OpenQA.Selenium.Edge.EdgeDriver driver = new OpenQA.Selenium.Edge.EdgeDriver();
                            driver.Navigate().GoToUrl(uri);
                            driver.FindElement(By.Id("method_free")).Click();
                            webpage = driver.PageSource;
                            driver.Quit();
                        }
                        catch (Exception e1)
                        {
                            try
                            {
                                OpenQA.Selenium.Firefox.FirefoxDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                                driver.Navigate().GoToUrl(uri);
                                driver.FindElement(By.Id("method_free")).Click();
                                webpage = driver.PageSource;
                                driver.Quit();
                            }
                            catch(Exception e2)
                            {
                                try
                                {
                                    OpenQA.Selenium.IE.InternetExplorerDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver();
                                    driver.Navigate().GoToUrl(uri);
                                    driver.FindElement(By.Id("method_free")).Click();
                                    webpage = driver.PageSource;
                                    driver.Quit();
                                }
                                catch(Exception e3)
                                {
                                    System.Windows.Forms.MessageBox.Show("Vui lòng cài Chrome để xử lý link này");
                                }
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(webpage)) valid = 2;
                    else
                    {
                        try
                        {
                            const string fname_header = "<span class=\"dfilename\">";
                            const string fname_tail = "</span>";
                            string smallcache = webpage.Substring(webpage.IndexOf(fname_header), 3000);
                            fname = smallcache.Substring(smallcache.IndexOf(fname_header) + fname_header.Length, smallcache.Substring(smallcache.IndexOf(fname_header)).IndexOf(fname_tail) - fname_header.Length);
                            const string fsize_header = "<span class=\"statd\">size</span>\r\n\t\t\t\t\t<span>";
                            const string fsize_tail = "</span>";
                            fsize = smallcache.Substring(smallcache.IndexOf(fsize_header) + fsize_header.Length);
                            //  fsize =   smallcache.Substring(smallcache.IndexOf(fsize_header)).IndexOf(fsize_tail) - fsize_header.Length);
                            fsize = fsize.Remove(fsize.IndexOf(fsize_tail));
                            valid = 1;
                        }
                        catch (Exception e)
                        {
                            valid = 2;
                        }
                    }
                    
                    
                }
                void sharemodsProc(Uri uri)
                {
                    try
                    {
                        webpage = cache_net.DownloadString(uri);
                        ProcSupporter.HtmlScriptCard scriptCache;
                        if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("<b>File Not Found</b>"))
                        {
                            scriptCache = ProcSupporter.FindCardinScript(webpage, "f-info");
                            string cache1 = webpage.Substring(scriptCache.stop + 1);
                            cache1 = cache1.Remove(cache1.IndexOf('<'));
                            //Download: frosty_heavy_winter_7_3.scs [79.4 MB]
                            fsize = cache1.Substring(cache1.LastIndexOf('[')).Trim('[', ']');
                            fname = cache1.Substring("Download: ".Length);
                            fname = fname.Remove(fname.Length - fsize.Length - 3);
                            valid = 1;
                        }
                        else valid = 2;
                    }
                    catch (Exception e)
                    {
                        valid = 0;
                        System.Windows.Forms.MessageBox.Show("Sharemods link Process Error\n"+e.Message);
                    }
                }
          
                void apkadminProc(Uri uri)
                {
                    try
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
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            webpage = reader.ReadToEnd();
                        }
                        //End Source
                        //Old Script
                        //cache_net.UseDefaultCredentials = true;
                        //cache_net.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                        //webpage = cache_net.DownloadString(uri);
                        ProcSupporter.HtmlScriptCard scriptCache;
                        if (!string.IsNullOrEmpty(webpage) && !webpage.Contains("<h2>File Not Found</h2>"))
                        {
                            string cache1 = webpage.Substring(webpage.IndexOf("file-name text-center"));
                            //cache1 = cache1.Substring(cache1.IndexOf("File: <strong> ") + "File: <strong> ".Length);
                            cache1 = cache1.Substring(cache1.IndexOf(">")+1);
                            fname = cache1.Remove(cache1.IndexOf("<"));
                            //Warn: name code &#x27;
                            // Temp Function for debug                            
                            {
                                if (fname.Contains("&#"))
                                {
                                    if (fname.Contains("&#x27;"))
                                    {
                                        fname = fname.Replace("&#x27;", "'");
                                    }
                                    if (fname.Contains("&#133"))
                                    {
                                        fname = fname.Replace("&#133", "");
                                    }
                                }
                            }
                            //Download: frosty_heavy_winter_7_3.scs [79.4 MB]
                            //cache1 = cache1.Substring(cache1.IndexOf("Size: <strong> ") + "Size: <strong> ".Length);
                            cache1 = cache1.Substring(cache1.IndexOf("has-size-icon") + 1);
                            cache1 = cache1.Substring(cache1.IndexOf("has-size-icon") + "has-size-icon\">Size: ".Length);
                            fsize = cache1.Remove(cache1.IndexOf("<"));
                            //! Temporarily Fix for fname
                            if (uri.Segments.Length > 2) fname = uri.Segments[2].Remove(uri.Segments[2].Length - 5);
                            valid = 1;
                        }
                        else valid = 2;
                    }
                    catch (Exception e)
                    {
                        valid = 0;
                        System.Windows.Forms.MessageBox.Show("APKADMIN link Process Error\n" + e.Message);
                    }
                }

                void fileuploadProc(Uri uri)
                {
                    try
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
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            webpage = reader.ReadToEnd();
                        }
                        //End Source

                        HtmlDocument tmpDoc = new HtmlDocument();
                        tmpDoc.LoadHtml(webpage);
                        HtmlNode cacheNode = tmpDoc.DocumentNode.SelectSingleNode("/html/body/section[@class=\"page-content\"]//div[@class=\"dareaname\"]");
                        fname = cacheNode.SelectSingleNode(".//h1").InnerText.Substring(14).Trim()??"";
                        Console.WriteLine(cacheNode.InnerHtml);
                        fsize = cacheNode.SelectSingleNode(".//p").InnerText;

                        RegexOptions options = RegexOptions.Multiline;
                        fsize = Regex.Matches(fsize, @"\((.*)\)", options)[0].Groups[1].Value.Trim() ?? "";
                        valid = 1;
                    }
                    catch (Exception e)
                    {
                        valid = 0;
                        System.Windows.Forms.MessageBox.Show("File-Upload link Process Error\n" + e.Message);
                    }
                    

                }
                async void teraboxProc(Uri uri)
                {
                    //API Crawl
                    try
                    {
                        var surl = uri.QueryKey("surl");
                        webpage = OldProcessor.ProcSupporter.httpreqDownloadString(new Uri($"https://www.terabox.com/share/list?app_id=250528&web=1&channel=dubox&clienttype=0&page=1&num=20&order=time&desc=1&shorturl={surl}&root=1"));
                        JObject json = JObject.Parse(webpage);
                        if (json.SelectToken("$.errno").Value<int>() > 0) throw new Exception("Not found file in this URL");
                        var x = json.SelectToken("$.list[0].server_filename");
                        if (x == null) valid = 2;
                        else fname =  x.Value<string>();
                        x = json.SelectToken("$.list[0].size"); 
                        if (x == null) valid = 2;
                        else fsize = MyFunction.SizeSuffix(x.Value<int>());
                        valid = 1;
                    }
                    catch (Exception e)
                    {
                        valid = 0;
                        System.Windows.Forms.MessageBox.Show("Terabox link Process Error\n" + e.Message);
                    }
                    //Full WebLoad Crawl
                    /*
                    try
                    {
                        webpage = await ProcSupporter.WebLoader.webloadSeleniumEdge(uri);

                        HtmlDocument tmpDoc = new HtmlDocument();
                        tmpDoc.LoadHtml(webpage);
                        HtmlNode cacheNode = tmpDoc.DocumentNode.SelectSingleNode("/html/body//div[@class=\"common-file-list\"]/div[@class=\"common-file-list-box\"]/div[1]/div[@class=\"file-item-name\"]");
                        fname = cacheNode.InnerText;
                        fsize = cacheNode.NextSibling.InnerText;
                        valid = 1;
                    }
                    catch (Exception e)
                    {
                        valid = 0;
                        System.Windows.Forms.MessageBox.Show("Terabox link process Error\n" + e.Message);
                    }
                    */
                }
                async void modsfireProc(Uri uri)
                {
                    try
                    {
                        webpage = OldProcessor.ProcSupporter.httpreqDownloadString(uri);
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(webpage);
                        var x = doc.DocumentNode.SelectSingleNode("/html/body//div[@class=\"name-file\"]").InnerText;
                        fname = x.Split(" - ")[0];
                        fsize = x.Split(" - ")[1];
                        valid = 1;
                    }
                    catch (Exception e)
                    {
                        valid = 0;
                        System.Windows.Forms.MessageBox.Show("modsfire link Process Error\n" + e.Message);
                    }
                    
                }
            }

        }
        public class MainProcessor
        {
            public string webpage;
            public string dir;
            public string title;
            public string videolink;
            public string req;
            public string version;
            public string desc;
            public string Desc_Bold;
            public string[] imagelink;
            
            public Dictionary<string, string> miscellaneous;
            public ProcSupporter.ImageDownloader[] image;
            public MainProcessor(string webpage, string webhost, string dir)
            {
                if (webhost == "play") webhost = "play.google.com";

                this.dir = dir;
                if (string.IsNullOrWhiteSpace(webhost)) { }
                else
                {
                    switch (webhost.ToLower())
                    {
                        case "play.google.com": PlayModule cache = new PlayModule(webpage, dir); 
                            { this.title = cache.title; this.videolink = cache.videolink; this.req = cache.req; this.version = cache.version; this.desc = cache.desc; this.Desc_Bold = cache.Desc_Bold; this.imagelink = cache.imagelink; this.image = cache.image; this.miscellaneous = cache.miscellaneous; } break;
                        case "apps.apple.com": APPLEModule cache4 = new APPLEModule(webpage, dir);
                            { this.title = cache4.title; this.videolink = cache4.videolink; this.req = cache4.req; this.version = cache4.version; this.desc = cache4.desc; this.Desc_Bold = cache4.Desc_Bold; this.imagelink = cache4.imagelink; this.image = cache4.image; this.miscellaneous = cache4.miscellaneous;
                            } break;
                        case "apkpure.com": APKpureModule cache2 = new APKpureModule(webpage, dir); 
                            { this.title = cache2.title; this.videolink = cache2.videolink; this.req = cache2.req; this.version = cache2.version; this.desc = cache2.desc; this.Desc_Bold = cache2.Desc_Bold; this.imagelink = cache2.imagelink; this.image = cache2.image; } break;
                        case "apkcombo.com": APKcomboModule cache3 = new APKcomboModule(webpage, dir); 
                            { this.title = cache3.title; this.videolink = cache3.videolink; this.req = cache3.req; this.version = cache3.version; this.desc = cache3.desc; this.Desc_Bold = cache3.Desc_Bold; this.imagelink = cache3.imagelink; this.image = cache3.image; } break;
                        case "apps.qoo-app.com":
                            QooappModule cache5 = new QooappModule(webpage, dir);
                            { this.title = cache5.title; this.videolink = cache5.videolink; this.req = cache5.req; this.version = cache5.version; this.desc = cache5.desc; this.Desc_Bold = cache5.Desc_Bold; this.imagelink = cache5.imagelink; this.image = cache5.image; }
                            break;

                    }
                }

            }
            public class PlayModule
            {
                public string webpage;
                public string dir;
                public string title;
                public string videolink;
                public string req;
                public string version;
                public string desc;
                public string Desc_Bold;
                public string[] imagelink;
                public Dictionary<string, string> miscellaneous;
                public ProcSupporter.ImageDownloader[] image;
                public HtmlDocument HTMLdoc = new HtmlDocument();
                public HtmlNode tmpHTMLnode;
                // Json String
                protected string _customdata;
                protected JObject customdata;
                
                public PlayModule() 
                {
                    
                }
                
                public PlayModule(string webpage, string dir)
                {
                    /*try
                    {*/
                        this.dir = dir;
                        this.webpage = webpage;
                        HTMLdoc.LoadHtml(webpage);
                        Get_CustomData();
                        Get_Title();
                        Get_Video();
                        Get_Req();
                        Get_Version();
                        Get_Image();
                        Get_Desc();

                    /*}
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Process Error\n" + e.Message);
                    }*/
                }
                
                public void Get_CustomData()
                {
                    //Extract Json
                    if (webpage.Contains("AF_initDataCallback"))
                    {
                        string cache = HTMLdoc.DocumentNode.SelectSingleNode("//script[contains(.,\"key: 'ds:5'\")]").InnerText;
                        if (String.IsNullOrEmpty(cache)) {
                            System.Windows.Forms.MessageBox.Show("PlayProc: Get JSON data error");
                        }
                        _customdata = cache;
                        //_customdata = webpage.Length > 100000?webpage.Substring(webpage.IndexOf("AF_initDataCallback({key: 'ds:4'"),50000): webpage.Substring(webpage.IndexOf("AF_initDataCallback({key: 'ds:4'"));
                        _customdata = _customdata.Substring(_customdata.IndexOf("{"), _customdata.IndexOf("sideChannel: {}}") - _customdata.IndexOf("{") + "sideChannel: {}}".Length);
                        JsonLoadSettings settings = new JsonLoadSettings();
                        settings.DuplicatePropertyNameHandling = DuplicatePropertyNameHandling.Ignore;
                        customdata = Newtonsoft.Json.Linq.JObject.Parse(_customdata, settings);
                    }
                }
                
                public void Get_Title()
                {
                    tmpHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//h1");
                    if (tmpHTMLnode is null) return;
                    string cache = tmpHTMLnode.InnerText;
                    cache = cache.Trim();
                    title = OldProcessor.ProcSupporter.HtmlSpecialProcess(cache);
                }

                public void Get_Video()
                {
                    tmpHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/c-wiz[2]//c-wiz/div[@class=\"PyyLUd\"]/img");
                    if (tmpHTMLnode is null) return;
                    string cache = tmpHTMLnode.Attributes["src"].Value;
                    cache = cache.Trim();
                    this.videolink = cache is null ? "": $"https://youtu.be/{(new Uri(cache)).Segments[2]}";
                }
                public void Get_Req()
                {
                    var tmpJToken = customdata.SelectToken("$.data[1][2][140][1][1][0][0][1]");
                    if (tmpJToken is null) return;
                    string cache = tmpJToken.Value<string>();
                    this.req =  cache.Contains("Varies with device") ? cache : $"Android {cache}+";
                    if (String.IsNullOrEmpty(cache)) this.req = "N/A";
                }
                public void Get_Version()
                {
                    var tmpJToken = customdata.SelectToken("$.data[1][2][140][0][0][0]");
                    if (tmpJToken is null) return;
                    string cache = tmpJToken.Value<string>();
                    cache = cache.Trim();
                    version = cache;
                }
                public void Get_Image()
                {
                    var cacheHTMLColect = HTMLdoc.DocumentNode.SelectNodes("/html/body/c-wiz[2]//div[@class=\"wkMJlb YWi3ub\"]//div[@role=\"list\"]/div//img");
                    if (cacheHTMLColect is null) return;
                    string[] cache = cacheHTMLColect.AsParallel().Select((x) =>
                    {
                        string tmp = x.Attributes["src"].Value;
                        tmp = tmp.Remove(tmp.IndexOf("="));
                        return tmp;
                    }).ToArray<string>();

                    string[] cache_thumbLink = cache.Select((x) => x + "=h160").ToArray<string>();

                    if (cache != null)
                    {
                        if (!Properties.Settings.Default.NoDownImage)
                        {
                            this.image = new ProcSupporter.ImageDownloader[cache.Length];
                            Parallel.For(0, cache.Length, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(cache_thumbLink[i], "Screenshot " + i.ToString(), this.dir); });
                            //for (int i=0;i<= cache.Count-1; i++) image[i] = new ProcSupporter.ImageDownloader(cache[i], "Screenshot " + i.ToString(), this.dir);

                            this.imagelink = cache.ToArray();
                        }
                    }


                }
                public void Get_Desc()
                {
                    var tmpJToken = customdata.SelectToken("$.data[1][2][72][0][1]");
                    if (tmpJToken is null) return;
                    string cache = tmpJToken.Value<string>();
                    cache = cache.Replace("\n", "");
                    cache = cache.Replace("<br>", "\n");
                    cache = cache.Replace("<br/>", "\n");
                    //cache = cache.Substring(cache.IndexOf("<div class=\"content\">") + "<div class=\"content\">".Length);
                    cache = cache.Replace("<div>", "\n").Replace("</div>", "");
                    string subcache = "";
                    string cardtext = "";//Get card for other process
                    /* while (cache.Contains("<") || cache.Contains(">"))
                     {
                         subcache += cache.Remove(cache.IndexOf(">") + 1);
                         cache = cache.Substring(cache.IndexOf(">") + 1);
                         cardtext = subcache.Substring(subcache.IndexOf("<")>=0? subcache.IndexOf("<"):0);
                         subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                     }*/
                    while (cache.Contains("<") || cache.Contains(">"))
                    {
                        subcache = cache.IndexOf(">") != cache.Length - 1 ? cache.Remove(cache.IndexOf(">") + 1) : cache;

                        cardtext = subcache.Substring(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                        cache = cache.Substring(0, (cache.IndexOf(cardtext)) >= 0 ? (cache.IndexOf(cardtext)) : 0) + cache.Substring(cache.IndexOf(">") + 1);

                        //  subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                    }
                    // subcache += cache;
                    cache = ProcSupporter.HtmlSpecialProcess(cache);
                    desc = cache;
                    Desc_Bold = cache;

                }
                // Legacy Code for parsing Play html before 220528 
                /*
                public void Get_Misc()
                {
                    string cache = webpage;
                    try
                    {
                        miscellaneous = new Dictionary<string, string>();
                        if (!string.IsNullOrWhiteSpace(cache))
                        {
                            //Developer
                            string header;
                            string keyword = "class=\"hrTbp R8zArc\"";
                            string subcache = cache.Substring(cache.IndexOf(keyword),1000);
                            subcache = subcache.Substring(subcache.IndexOf(">")+1);
                            subcache = subcache.Remove(subcache.IndexOf("</a></span>"));
                            miscellaneous.Add("developer", subcache);
                            //Genre
                            keyword = "a itemprop=\"genre\" href=\"/store/apps/category/";
                            subcache = cache.Substring(cache.IndexOf(keyword), 1000);
                            subcache = subcache.Substring(subcache.IndexOf(">")+1);
                            subcache = subcache.Remove(subcache.IndexOf("</a></span>"));
                            miscellaneous.Add("genre", subcache);
                            //Editors' Choice
                            keyword = "<span class=\"dMMEE\">Editors&#39; Choice</span>";
                            if (cache.Contains(keyword))
                                miscellaneous.Add("editorsChoice", "Editors' Choice");

                        }
                    }
                    catch(Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Miscellaneous Finder Error");
                    }
                }
                public void Get_Title()
                {
                    string identity_head = "<h1 itemprop=\"name\" class=\"Fd93Bb F5UCq xwcR9d\"><span>";
                    string identity_tail = "</span>";
                    //System.Windows.Forms.Clipboard.SetText(webpage);
                    int subcache = this.webpage.IndexOf(identity_head) + identity_head.Length;
                    if (subcache >= identity_head.Length)
                    {
                        string cache = this.webpage.Substring(subcache, 255);
                        cache = cache.Remove(cache.IndexOf(identity_tail));
                        subcache += cache.Length + identity_tail.Length;
                        this.webpage = this.webpage.Remove(1, subcache);
                        this.title = oldProcessor.ProcSupporter.HtmlSpecialProcess(cache);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Old Processor: Title Process: Identity Object");
                    }
                }
                public void Get_Video()
                {
                    string identity_head = "data-trailer-url";
                    int subcache = this.webpage.IndexOf(identity_head);
                    if (subcache >= 0)
                    {
                        oldProcessor.ProcSupporter.HtmlScriptCard card = ProcSupporter.FindCardinScript(this.webpage, subcache);
                        subcache = card.stop;
                        //this.webpage = this.webpage.Remove(1, subcache);
                        this.videolink = card.GetData("data-trailer-url");
                    }
                    else this.videolink = "";
                }
                public void Get_Req()
                {
                    //TODO: Require Json Section
                   
                    string identity_head = "<div class=\"BgcNfc\">Requires Android</div><span class=\"htlgb\"><div class=\"IQ1z0d\"><span class=\"htlgb\">";
                    string identity_tail = "</span></div></span></div>";
                    int subcache = this.webpage.IndexOf(identity_head) + identity_head.Length;
                    string cache = this.webpage.Substring(subcache, 255);
                    cache = cache.Remove(cache.IndexOf(identity_tail));
                    subcache += cache.Length + identity_tail.Length;
                    //this.webpage = this.webpage.Remove(1, subcache);
                    this.req = ReqProc(cache);
                    string ReqProc(string st)
                    {
                        string minicache = st.Trim(' ');
                        if (minicache.Contains("and up"))
                        {
                            minicache = minicache.Substring(0, minicache.IndexOf(" and up")).Trim(' ');
                            return "Android " + minicache + "+";
                        }
                        else if (!minicache.Contains("Varies with device"))
                        {
                            //Something Wrong Here
                        }
                        return minicache;
                    }
                }
                public void Get_Version()
                {
                    string identity_head = "<div class=\"hAyfc\"><div class=\"BgcNfc\">Current Version</div><span class=\"htlgb\"><div class=\"IQ1z0d\"><span class=\"htlgb\">";
                    string identity_tail = "</span></div></span></div>";
                    int subcache = this.webpage.IndexOf(identity_head) + identity_head.Length;
                    string cache = this.webpage.Substring(subcache, 255);
                    cache = cache.Remove(cache.IndexOf(identity_tail));
                    subcache += cache.Length + identity_tail.Length;
                    //this.webpage = this.webpage.Remove(1, subcache);
                    this.version = VerProc(cache);
                    string VerProc(string st)
                    {
                        string minicache = st.Trim(' ');
                        if (minicache.Contains("Varies with device"))
                        {
                            return minicache;
                        }
                        return minicache;
                    }
                }
                public void Get_Image()
                {
                    string identity = "alt=\"Screenshot Image\"";
                    oldProcessor.ProcSupporter.HtmlScriptCard card;
                    List<string> cache = new List<string>();
                    List<string> cache_thumbLink = new List<string>();
                    string cache_string;
                    while (this.webpage.Contains(identity))
                    {
                        card = ProcSupporter.FindCardinScript(this.webpage, identity);
                        cache_string = card.GetData("srcset");
                        cache.Add(cache_string.Contains(" ") ? cache_string.Remove(cache_string.IndexOf(" ")) : cache_string);
                        cache_thumbLink.Add(cache.Last().Remove(cache.Last().IndexOf("=")) + "=h160");
                        this.webpage = this.webpage.Remove(1, card.stop);
                    }

                    if (cache != null)
                    {
                        if (!Properties.Settings.Default.NoDownImage)
                        {
                            this.image = new ProcSupporter.ImageDownloader[cache.Count];
                            Parallel.For(0, cache.Count, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(cache_thumbLink[i], "Screenshot " + i.ToString(), this.dir); });
                            //for (int i=0;i<= cache.Count-1; i++) image[i] = new ProcSupporter.ImageDownloader(cache[i], "Screenshot " + i.ToString(), this.dir);

                            this.imagelink = cache.ToArray();
                        }
                    }

                }
                public void Get_Desc()
                {
                    string identity_head = "meta itemprop=\"description\" content=\"";
                    int subcache = this.webpage.IndexOf(identity_head);
                    oldProcessor.ProcSupporter.HtmlScriptCard card = ProcSupporter.FindCardinScript(this.webpage, subcache);
                    subcache = card.stop;
                    this.webpage = this.webpage.Remove(1, subcache);
                    this.desc = ProcSupporter.HtmlSpecialProcess(card.GetData("content"));
                    //
                    identity_head = "<div jsname=\"bN97Pc\" class=\"DWPxHb\" itemprop=\"description\"><span jsslot><div jsname=\"sngebd\">";
                        //Update Content jsslot tag to span tag
                    string identity_tail = "</div></span>";

                    string cache = this.webpage.Substring(this.webpage.IndexOf(identity_head) + identity_head.Length);
                    cache = cache.Remove(cache.IndexOf(identity_tail));

                    //
                    cache = cache.Replace("<br>", "\n");
                    cache = cache.Replace("</font>", "");
                    cache = cache.Replace("<strong>", "<b>");
                    cache = cache.Replace("</strong>", "</b>");
                    //
                    cache = ProcSupporter.HtmlSpecialProcess(cache);
                    cache = ProcSupporter.BoldSpecialProcess(cache);
                    //
                    subcache = cache.IndexOf("<font");
                    while (subcache > 0)
                    {
                        cache = cache.Remove(subcache, cache.Substring(subcache).IndexOf(">")+1);
                        subcache = cache.IndexOf("<font");
                    }


                    this.Desc_Bold = cache;
                }
                */
            }
            public class APPLEModule
            {
                public string webpage;
                public string dir;
                public string title;
                public string videolink;
                public string req;
                public string version;
                public string desc;
                public string Desc_Bold;
                public string[] imagelink;
                public Dictionary<string, string> miscellaneous;
                public ProcSupporter.ImageDownloader[] image;
                public HtmlDocument HTMLdoc = new HtmlDocument();
                public HtmlNode tmpHTMLnode;
                // Json String
                protected string _customdata;
                protected JObject customdata;

                public APPLEModule(string webpage, string dir)
                {
                    /*try
                    {*/
                    this.dir = dir;
                    this.webpage = webpage;
                    if (webpage.StartsWith("<!DOCTYPE html>"))
                    {

                        HTMLdoc.LoadHtml(webpage);
                        
                        Get_Title();
                        Get_Video();
                        Get_Req();
                        Get_Version();
                        Get_Image();
                        Get_Desc();
                    }
                    Get_CustomData();
                    /*}
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Process Error\n" + e.Message);
                    }*/
                }

                public void Get_CustomData()
                {
                    customdata = JObject.Parse(webpage);
                    title = customdata.SelectToken("$.results[0].trackName").Value<string>();
                    desc = customdata.SelectToken("$.results[0].description").Value<string>();
                    Desc_Bold = desc;
                    string[] listcache = customdata.SelectToken("$.results[0].screenshotUrls").Values<string>().ToArray();
                    if (listcache != null)
                    {
                        if (!Properties.Settings.Default.NoDownImage)
                        {
                            this.image = new ProcSupporter.ImageDownloader[listcache.Length];
                            Parallel.For(0, listcache.Length, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(listcache[i], "Screenshot " + i.ToString(), this.dir); });
                            this.imagelink = listcache;
                        }
                    }

                }

                public void Get_Title()
                {
                    tmpHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//h1").FirstChild;
                    if (tmpHTMLnode is null) return;
                    string cache = tmpHTMLnode.InnerHtml;
                    cache = cache.Trim();
                    title = OldProcessor.ProcSupporter.HtmlSpecialProcess(cache);
                }

                public void Get_Video()
                {
                   /* tmpHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/c-wiz[2]//c-wiz/div[@class=\"PyyLUd\"]/img");
                    if (tmpHTMLnode is null) return;
                    string cache = tmpHTMLnode.Attributes["src"].Value;
                    cache = cache.Trim();
                    this.videolink = cache is null ? "" : $"https://youtu.be/{(new Uri(cache)).Segments[2]}";*/
                }
                public void Get_Req()
                {
                    
                }
                public void Get_Version()
                {
                    string cache = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//main//section[4]//p[1]").FirstChild.InnerHtml;
                    cache = cache.Substring(cache.IndexOf(" ") + 1);
                    cache = cache.Trim();
                    version = cache;
                }
                public void Get_Image()
                {
                    var cacheHTMLColect = HTMLdoc.DocumentNode.SelectNodes("/html/body//main//section[2]//div[contains(@class,\"we-screenshot-viewer\")]//ul/li/picture/source[2]");
                    if (cacheHTMLColect is null) return;
                    string[] cache = cacheHTMLColect.AsParallel().Select((x) =>
                    {
                        string tmp = x.Attributes["srcset"].Value;
                        tmp = tmp.Remove(tmp.IndexOf(" "));
                        return tmp;
                    }).ToArray<string>();

                    string[] cache_thumbLink = cache.Select((x) => x ).ToArray<string>();

                    if (cache != null)
                    {
                        if (!Properties.Settings.Default.NoDownImage)
                        {
                            this.image = new ProcSupporter.ImageDownloader[cache.Length];
                            Parallel.For(0, cache.Length, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(cache_thumbLink[i], "Screenshot " + i.ToString(), this.dir); });
                            //for (int i=0;i<= cache.Count-1; i++) image[i] = new ProcSupporter.ImageDownloader(cache[i], "Screenshot " + i.ToString(), this.dir);

                            this.imagelink = cache.ToArray();
                        }
                    }


                }
                public void Get_Desc()
                {
                    string cache = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//main//section[3]/div/div/div").InnerHtml;
                    ////////
                    cache = cache.Replace("\n", "");
                    cache = cache.Replace("<br>", "\n");
                    cache = cache.Replace("<br/>", "\n");
                    cache = cache.Replace("<div>", "\n").Replace("</div>", "");
                    string subcache = "";
                    string cardtext = "";
                    while (cache.Contains("<") || cache.Contains(">"))
                    {
                        subcache = cache.IndexOf(">") != cache.Length - 1 ? cache.Remove(cache.IndexOf(">") + 1) : cache;

                        cardtext = subcache.Substring(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                        cache = cache.Substring(0, (cache.IndexOf(cardtext)) >= 0 ? (cache.IndexOf(cardtext)) : 0) + cache.Substring(cache.IndexOf(">") + 1);
                    }
                    //////
                    cache = ProcSupporter.HtmlSpecialProcess(cache);
                    desc = cache;
                    Desc_Bold = cache;
                }
            }
            public class APKpureModule
            {
                public string webpage;
                public string dir;
                public string title;
                public string videolink;
                public string req;
                public string version;
                public string desc;
                public string Desc_Bold;
                public string[] imagelink;
                private HtmlDocument doc;
                public ProcSupporter.ImageDownloader[] image;
                
                public APKpureModule(string webpage, string dir)
                {
                    /*try
                    {*/
                    this.dir = dir;
                    this.webpage = webpage;
                    doc = new HtmlDocument();
                    doc.LoadHtml(webpage);
                    Get_Title();
                    //Get_Video();// Disable
                    Get_Req();
                    Get_Version();
                    Get_Image();
                    Get_Desc();
                    /*}
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Process Error\n"+e.Message);
                    }*/
                }
                public void Get_Title()
                {
                    webpage = webpage.Substring(webpage.IndexOf("<div class=\"title_link\">"));
                    string cache = webpage.Substring(webpage.IndexOf("<h1>") + "<h1>".Length, 255);
                    /*if (cache.Contains("<div class=\"clear\"></div>"))
                    {
                        cache = cache.Remove(cache.IndexOf("</h1>"));
                    }
                    else
                    {
                        cache = cache.Remove(cache.IndexOf("</h1>")) + ":" + cache.Substring(cache.IndexOf("</h1>") + "</h1>".Length, cache.IndexOf("</div>") - cache.IndexOf("</h1>") + "</h1>".Length);
                        cache = cache.Replace("\n", "");
                        cache = cache.Trim(' ');
                    }*/
                    if (cache.Contains("</h1>\r\n                    </div>"))
                    {
                        cache = cache.Remove(cache.IndexOf("</h1>"));
                    }
                    else
                    {
                        // Solve 2 part title
                        cache = cache.Remove(cache.IndexOf("</h1>")) + ":" + cache.Substring(cache.IndexOf("</h1>") + "</h1>".Length, cache.IndexOf("</div>") - cache.IndexOf("</h1>") - "</h1>".Length);
                        cache = cache.Replace("\n", "");
                        cache = cache.Replace("\r", "");
                        cache = cache.Trim(' ');
                        // Remove : if the name have only one part
                        if (cache.Last() == ':') cache = cache.Remove(cache.Length - 1);
                    }
                    title = cache;
                    if (title.Contains(" APK")) title = title.Remove(title.LastIndexOf(" APK"), " APK".Length);
                    title = OldProcessor.ProcSupporter.HtmlSpecialProcess(title);
                }
                public void Get_Video()
                {
                    if (webpage.Contains("https://www.youtube.com/embed/"))
                    {
                        string cache = webpage.Substring(webpage.IndexOf("https://www.youtube.com/embed/") + "https://www.youtube.com/embed/".Length, 255);
                        cache = cache.Remove(cache.IndexOf("?"));
                        videolink = "https://www.youtube.be/" + cache;
                    }
                }
                public void Get_Req()
                {
                    //string cache = webpage.Substring(webpage.IndexOf("<p><strong>Requirements:</strong></p>") + "<p><strong>Requirements:</strong></p>".Length, 512);
                    //cache = cache.Substring(cache.IndexOf(">") + 1);
                    //cache = cache.Remove(cache.IndexOf("<"));
                    //req = cache;
                }
                public void Get_Version()
                {
                    string cache = webpage.Substring(webpage.IndexOf("<p class=\"details_sdk\">") + "<p class=\"details_sdk\">".Length, 512);
                    cache = cache.Substring(cache.IndexOf(">") + 1);
                    cache = cache.Remove(cache.IndexOf("<"));
                    version = cache;
                }
                public void Get_Image()
                {
                    if (webpage.Contains("<div class=\"screen-wrap\">") == false)
                    {
#if DEBUG
                        throw new Exception("Parser Error: No Image Found");
#endif
                    }
                    // Hot fix for Html Agilty Pack is not support img tag
                    var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"screen\"]/div/a").Nodes().ToList();
                    var images = nodes.Where((node) => node.OuterHtml.StartsWith("<img"));
                    List<string> subcache = images.Select((node) => node.Attributes["src"].Value).ToList();
                    // Process and filter links
                    List<string> tempLinkList = new List<string>();
                    for (int i = 0; i < subcache.Count; i++)
                    {
                        var link = subcache[i];
                        // remove gifs data image (no link src)
                        if (!link.StartsWith("http")) continue;
                        link = Regex.Replace(link, "(?<url>[^?]+\\?)(?<prefix>.+)?(?<remove>w=\\d+(&amp;|&))(?<suffix>.+)?", "${url}${prefix}${suffix}");
                        link = Regex.Replace(link, "(?<url>[^?]+\\?)(?<prefix>.+)?(?<remove>h=\\d+(&amp;|&))(?<suffix>.+)?", "${url}${prefix}${suffix}");
                        tempLinkList.Add(link);

                    }
                    subcache = tempLinkList;
                    if (subcache.Count > 0)
                    {
                        this.image = new ProcSupporter.ImageDownloader[subcache.Count];
                        Parallel.For(0, subcache.Count, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(subcache[i], "Screenshot " + i.ToString(), this.dir); });

                        imagelink = subcache.ToArray();
                    }

                }
                public void Get_Desc()
                {
                    var results = doc.DocumentNode.SelectNodes("//div[@class=\"content\"]/div[1]/div/div");
                    if (results is null) throw new Exception("Parser Error: No description Found");
                    var nodes = results.Nodes().ToList();
                    if (nodes.Count <= 0) throw new Exception("Parser Error: No description Found");
                    string content = "";
                    for (int i = 0; i< nodes.Count; i++)
                    {
                        if (nodes[i].InnerHtml == "<br>") { content += "\n"; continue; }
                        content += nodes[i].InnerText + "\n";
                    }
                    content = content.Trim();
                     //string cache = webpage.Substring(webpage.IndexOf("<div class=\"description\">"), webpage.IndexOf("<div class=\"showmore_trigger\">") - webpage.IndexOf("<div class=\"description\">"));
                    
                    //cache = cache.Remove(cache.Length - 1 - 23, 24);
                    //cache = cache.Replace("\n", "");
                    //cache = cache.Replace("<br>", "\n");
                    //cache = cache.Replace("<br/>", "\n");
                    ////cache = cache.Substring(cache.IndexOf("<div class=\"content\">") + "<div class=\"content\">".Length);
                    //cache = cache.Substring(cache.IndexOf("<div class=\"content\" itemprop=\"description\">") + "<div class=\"content\" itemprop=\"description\">".Length);
                    //cache = cache.Remove(cache.LastIndexOf("</div>"));
                    //cache = cache.Remove(cache.LastIndexOf("</div>"));
                    //cache = cache.Replace("<div>", "\n").Replace("</div>", "");
                    //string subcache = "";
                    //string cardtext = "";//Get card for other process
                                         /* while (cache.Contains("<") || cache.Contains(">"))
                                          {
                                              subcache += cache.Remove(cache.IndexOf(">") + 1);
                                              cache = cache.Substring(cache.IndexOf(">") + 1);
                                              cardtext = subcache.Substring(subcache.IndexOf("<")>=0? subcache.IndexOf("<"):0);
                                              subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                                          }*/
                    //while (cache.Contains("<") || cache.Contains(">"))
                    //{
                    //    subcache = cache.Remove(cache.IndexOf(">") + 1);
                        
                    //    cardtext = subcache.Substring(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                    //    cache = cache.Substring(0,(cache.IndexOf(cardtext))>=0? (cache.IndexOf(cardtext)):0)+cache.Substring(cache.IndexOf(">") + 1);

                    //  //  subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                    //}
                   // subcache += cache;
                    string cache = ProcSupporter.HtmlSpecialProcess(content);
                    desc = cache;
                    Desc_Bold = cache;

                }
            }
            public class APKcomboModule
            {
                public string webpage;
                public string dir;
                public string title;
                public string videolink;
                public string req;
                public string version;
                public string desc;
                public string Desc_Bold;
                public string[] imagelink;
                public string playlink;
                public ProcSupporter.ImageDownloader[] image;
                public HtmlDocument HTMLdoc = new HtmlDocument();
                public HtmlNode cacheHTMLnode;

                public APKcomboModule(string webpage, string dir)
                {
                    try
                    {
                        this.dir = dir;
                        this.webpage = webpage;
                        HTMLdoc.LoadHtml(webpage);
                        Get_PlayLink();

                        Get_Title();
                        Get_Req();
                        Get_Version();
                        Get_Image();
                        Get_Desc();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Process Error\n" + e.Message);
                    }
                }
                public void Get_Title()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("//body/section[@id=\"main\"]//div[contains(@class,\"app_header\")]/div[@class=\"info\"]/div[@class=\"app_name\"]");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerText;
                    cache = cache.Trim();
                    title = OldProcessor.ProcSupporter.HtmlSpecialProcess(cache);
                }
                public void Get_PlayLink()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/section[@id=\"main\"]/div/div/div/section[@class=\"info widget\"]/div[@class=\"information-table\"]/div[div[@class=\"name\"and text()=\"Google Play ID\"]]/div[@class=\"value\"]/a");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.Attributes["href"].Value;
                    cache = cache.Remove(cache.IndexOf("&"));
                    if (String.IsNullOrEmpty(cache)) return;
                    playlink = cache;
                }    
                public void Get_Video()
                {

                }
                public void Get_Req()
                {
                    if (String.IsNullOrEmpty(playlink)) { req = "N/A"; return; }
                    this.req = retrievePlayReq();
                }
                public void Get_Version()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/section[@id=\"main\"]/div[1]/div[1]/div[1]/section/div[@class=\"information-table\"]/div[div[text()=\"Version\"]]/div[@class=\"value\"]");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerText;
                    cache = cache.Trim();
                    version = cache;
                }
                public void Get_Image()
                {
                    var cacheHTMLColection = HTMLdoc.DocumentNode.SelectNodes("/html/body/section/div/div/div/div[@id=\"gallery-screenshots\"]/a");
                    if (cacheHTMLColection is null) return;
                    string[] cache = cacheHTMLColection.AsParallel().Select((x) =>
                    {
                        string tmp = x.Attributes["href"].Value;
                        tmp = tmp.Remove(tmp.IndexOf("="));
                        return tmp;
                    }).ToArray<string>();
                    //=w360-h640
                    string[] cache_thumbLink = cache.Select((x) => x + "=h160").ToArray<string>();

                    if (cache != null)
                    {
                        if (!Properties.Settings.Default.NoDownImage)
                        {
                            this.image = new ProcSupporter.ImageDownloader[cache.Length];
                            Parallel.For(0, cache.Length, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(cache_thumbLink[i], "Screenshot " + i.ToString(), this.dir); });
                            //for (int i=0;i<= cache.Count-1; i++) image[i] = new ProcSupporter.ImageDownloader(cache[i], "Screenshot " + i.ToString(), this.dir);

                            this.imagelink = cache.ToArray();
                        }
                    }


                }
                public void Get_Desc()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/section[@id=\"main\"]//article/div/div/div");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerHtml;
                    cache = cache.Replace("\n", "");
                    cache = cache.Replace("<br>", "\n");
                    cache = cache.Replace("<br/>", "\n");
                    //cache = cache.Substring(cache.IndexOf("<div class=\"content\">") + "<div class=\"content\">".Length);
                    cache = cache.Replace("<div>", "\n").Replace("</div>", "");
                    string subcache = "";
                    string cardtext = "";//Get card for other process
                    /* while (cache.Contains("<") || cache.Contains(">"))
                     {
                         subcache += cache.Remove(cache.IndexOf(">") + 1);
                         cache = cache.Substring(cache.IndexOf(">") + 1);
                         cardtext = subcache.Substring(subcache.IndexOf("<")>=0? subcache.IndexOf("<"):0);
                         subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                     }*/
                    while (cache.Contains("<") || cache.Contains(">"))
                    {
                        subcache = cache.IndexOf(">") != cache.Length - 1 ? cache.Remove(cache.IndexOf(">") + 1) : cache;

                        cardtext = subcache.Substring(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                        cache = cache.Substring(0, (cache.IndexOf(cardtext)) >= 0 ? (cache.IndexOf(cardtext)) : 0) + cache.Substring(cache.IndexOf(">") + 1);

                        //  subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                    }
                    // subcache += cache;
                    cache = ProcSupporter.HtmlSpecialProcess(cache);
                    desc = cache;
                    Desc_Bold = cache;

                }

                private string retrievePlayReq()
                {
                    try
                    {
                        MainProcessor.PlayModule tmp = new PlayModule();
                        var cacheNet = new System.Net.WebClient();
                        tmp.webpage = cacheNet.DownloadString($"{playlink}&hl=en");
                        tmp.HTMLdoc = new HtmlAgilityPack.HtmlDocument();
                        tmp.HTMLdoc.LoadHtml(tmp.webpage);
                        tmp.Get_CustomData();
                        tmp.Get_Req();
                        return tmp.req;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    return "N/A";
                }
            }
            public class QooappModule
            {
                public string webpage;
                public string dir;
                public string title;
                public string videolink;
                public string req;
                public string version;
                public string desc;
                public string Desc_Bold;
                public string[] imagelink;
                public string playlink;
                public ProcSupporter.ImageDownloader[] image;
                public HtmlDocument HTMLdoc = new HtmlDocument();
                public HtmlNode cacheHTMLnode;

                public QooappModule(string webpage, string dir)
                {
                    try
                    {
                        this.dir = dir;
                        this.webpage = webpage;
                        HTMLdoc.LoadHtml(webpage);
                        Get_PlayLink();
                        if (!String.IsNullOrEmpty(playlink))
                        {
                            playlink += "&hl=en";
                            ProcSupporter.WebLoader client = new ProcSupporter.WebLoader(new Uri(playlink));
                            string play_webpage = ProcSupporter.WebLoader.webpageresult;
                            MainProcessor temp = new MainProcessor(play_webpage, "play.google.com", dir);
                            title = temp.title;
                            req = temp.req;
                            version = temp.version;
                            imagelink = temp.imagelink;
                            image = temp.image;
                            desc = temp.desc;
                            Desc_Bold = temp.Desc_Bold;
                            videolink = temp.videolink;
                            return;
                        }
                        Get_Title();
                        Get_Req();
                        Get_Version();
                        Get_Image();
                        Get_Desc();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Process Error\n" + e.Message);
                    }
                }
                public void Get_PlayLink()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//section[2]//nav//a[@class=\"download-on-google-play\"]");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.Attributes["href"].Value;
                    if (String.IsNullOrEmpty(cache)) return;
                    playlink = cache;
                }

                public void Get_Title()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//section//h2[@class=\"subtitle\"]");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerText;
                    cache = cache.Trim();
                    title = OldProcessor.ProcSupporter.HtmlSpecialProcess(cache);
                }
                
                public void Get_Video()
                {

                }
                public void Get_Req()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/section[2]//ul//span[cite[.=\"Requirements:\"]]/var");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerText;
                    cache = cache.Trim();
                    req = cache;
                }
                public void Get_Version()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/section[2]//ul//span[cite[.=\"Version:\"]]/var");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerText;
                    cache = cache.Trim();
                    version = cache;
                }
                public void Get_Image()
                {
                    var cacheHTMLColection = HTMLdoc.DocumentNode.SelectNodes("/html/body//section[1]//p/img");
                    if (cacheHTMLColection is null) return;
                    string[] cache = cacheHTMLColection.AsParallel().Select((x) =>
                    {
                        string tmp = "https:"+x.Attributes["data-large"].Value;
                        tmp = tmp.Remove(tmp.IndexOf("="));
                        return tmp;
                    }).ToArray<string>();
                    //=w360-h640
                    string[] cache_thumbLink = cache.Select((x) => x + "=h160").ToArray<string>();

                    if (cache != null)
                    {
                        if (!Properties.Settings.Default.NoDownImage)
                        {
                            this.image = new ProcSupporter.ImageDownloader[cache.Length];
                            Parallel.For(0, cache.Length, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i => { image[i] = new ProcSupporter.ImageDownloader(cache_thumbLink[i], "Screenshot " + i.ToString(), this.dir); });
                            //for (int i=0;i<= cache.Count-1; i++) image[i] = new ProcSupporter.ImageDownloader(cache[i], "Screenshot " + i.ToString(), this.dir);

                            this.imagelink = cache.ToArray();
                        }
                    }


                }
                public void Get_Desc()
                {
                    cacheHTMLnode = HTMLdoc.DocumentNode.SelectSingleNode("/html/body//section[1]/div[@id=\"intro\"]/div");
                    if (cacheHTMLnode is null) return;
                    string cache = cacheHTMLnode.InnerHtml;
                    cache = cache.Replace("\n", "");
                    cache = cache.Replace("<br>", "\n");
                    cache = cache.Replace("<br/>", "\n");
                    //cache = cache.Substring(cache.IndexOf("<div class=\"content\">") + "<div class=\"content\">".Length);
                    cache = cache.Replace("<div>", "\n").Replace("</div>", "");
                    string subcache = "";
                    string cardtext = "";//Get card for other process
                    /* while (cache.Contains("<") || cache.Contains(">"))
                     {
                         subcache += cache.Remove(cache.IndexOf(">") + 1);
                         cache = cache.Substring(cache.IndexOf(">") + 1);
                         cardtext = subcache.Substring(subcache.IndexOf("<")>=0? subcache.IndexOf("<"):0);
                         subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                     }*/
                    while (cache.Contains("<") || cache.Contains(">"))
                    {
                        subcache = cache.IndexOf(">") != cache.Length - 1 ? cache.Remove(cache.IndexOf(">") + 1) : cache;

                        cardtext = subcache.Substring(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                        cache = cache.Substring(0, (cache.IndexOf(cardtext)) >= 0 ? (cache.IndexOf(cardtext)) : 0) + cache.Substring(cache.IndexOf(">") + 1);

                        //  subcache = subcache.Remove(subcache.IndexOf("<") >= 0 ? subcache.IndexOf("<") : 0);
                    }
                    // subcache += cache;
                    cache = ProcSupporter.HtmlSpecialProcess(cache);
                    desc = cache;
                    Desc_Bold = cache;

                }

                
            }
        }
    }
}
