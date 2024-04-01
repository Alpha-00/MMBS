using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OutputColorizer;
using PuppeteerSharp;
using FlareSolverrSharp;
namespace MMBS_Sandbox
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Setup
            //Uri uri = new Uri("https://www.terabox.com/sharing/link?surl=_4Foql2y54TbtobSKOVDnAx");
            //Action
            AccesibleTest(new Uri("https://apkadmin.com/wav49kf5ep9f/JokerArt_1.98.2.apk.html"));
        }
        static async void AccesibleTest(Uri uri)
        {/*
            foreach (var x in Enum.GetValues(typeof(WebLoader.WebLoaderSetting)).Cast<WebLoader.WebLoaderSetting>().ToList<WebLoader.WebLoaderSetting>())
            {
                try
                {
                    WebLoader client = new WebLoader(setting: x, uri: uri);
                    string webpage = await client.Execute();
                    if (webpage != null)
                    {
                        Console.WriteLine($"SUCCESSED {x}\n{webpage.Substring(100)}\n");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED {x}");
                }
            }*/
            var handler = new ClearanceHandler("http://localhost:8191/")
            {
                MaxTimeout = 60000,
                ProxyUrl = "http://127.0.0.1:8888"
            };

            var client = new HttpClient(handler);
            
            var content = await client.GetStringAsync(uri);
            Console.WriteLine(content);
            Console.ReadLine();
            
            
        }
        static async void ResultTest(Uri uri)
        {
            WebLoader client = new WebLoader(setting: WebLoader.WebLoaderSetting.AngleSharp, uri: uri);
            string webpage = await client.Execute();
            Colorizer.WriteLine("---[Red!TESTING START]---");
            Colorizer.WriteLine($"Uri: [Blue!{uri.OriginalString}]");
            Colorizer.WriteLine($"Preview:");
            Console.WriteLine(webpage);
            Colorizer.WriteLine($"Result: {!String.IsNullOrEmpty(webpage)}");
            Console.Read();
        }
        static async void SpeedTest(Uri uri)
        {
            string webpage1="";
            string webpage2="";
            WebLoader client;
            Stopwatch time;
            Colorizer.WriteLine("---[Red!TESTING START]---");
            Colorizer.WriteLine($"Uri: [Blue!{uri.OriginalString}]");

            /*
            Colorizer.Write($"- Engine: [Blue!Chrome Selenium] :");
            time = System.Diagnostics.Stopwatch.StartNew();
            client = new WebLoader(uri, WebLoader.WebLoaderSetting.SeleniumChrome);
            webpage1 = await client.Execute();
            time.Stop();
            Colorizer.WriteLine($"[Blue!{time.Elapsed}ms]");
            */


            /*Colorizer.Write($"- Engine: [Blue!Chrome Selenium 2] :");
            time = System.Diagnostics.Stopwatch.StartNew();
            client = new WebLoader(uri, WebLoader.WebLoaderSetting.SeleniumChrome);
            webpage1 = await client.Execute();
            time.Stop();
            Colorizer.WriteLine($"[Blue!{time.Elapsed}ms]");*/
            
            //Console.SetOut(System.IO.TextWriter.Null);
            Colorizer.Write($"- Engine: [Blue!Edge Selenium] :");
            time = System.Diagnostics.Stopwatch.StartNew();
            client = new WebLoader(uri, WebLoader.WebLoaderSetting.SeleniumEdge);
            webpage2 = await client.Execute();
            time.Stop();
            Colorizer.WriteLine($"[Blue!{time.Elapsed}ms]");

            //Console.SetIn(System.IO.TextReader.Null);

            /*Colorizer.Write($"- Engine: [Blue!Edge Selenium 2] :");
            time = System.Diagnostics.Stopwatch.StartNew();
            client = new WebLoader(uri, WebLoader.WebLoaderSetting.SeleniumEdge);
            webpage2 = await client.Execute();
            time.Stop();
            Colorizer.WriteLine($"[Blue!{time.Elapsed}ms]");*/
            /*string cache;
            
            using (var browserFetcher = new BrowserFetcher())
            {
                //Console.WriteLine(await browserFetcher.CanDownloadAsync(BrowserFetcher.DefaultChromiumRevision));
                await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
                var page = await browser.NewPageAsync();
                await page.GoToAsync(uri.OriginalString);
                cache = await page.GetContentAsync();
            }*/
            /*Colorizer.Write($"- Engine: [Blue!PuppeteerSharp] :");
            time = System.Diagnostics.Stopwatch.StartNew();
            client = new WebLoader(uri, WebLoader.WebLoaderSetting.Puppeteer);
            webpage1 = await client.Execute();
            
            time.Stop();
            Colorizer.WriteLine($"[Blue!{time.Elapsed}ms]");*/
            /*Colorizer.Write($"- Engine: [Blue!Lambda Selenium] :");
            time = System.Diagnostics.Stopwatch.StartNew();
            client = new WebLoader(uri, WebLoader.WebLoaderSetting.SeleniumLambda);
            webpage1 = await client.Execute();
            time.Stop();
            Colorizer.WriteLine($"[Blue!{time.Elapsed}ms]");*/

            Colorizer.WriteLine($"Valid: [Blue!{webpage1 == webpage2}]: [Green!{webpage1.Contains("56.4MB")} : {webpage2.Contains("56.4MB")}]");
            Console.Read();
        }
    }
}
