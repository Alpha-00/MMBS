using AngleSharp;
using AngleSharp.Css;
using AngleSharp.Dom;
using AngleSharp.Io;
using AngleSharp.Js;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Jint;
using OpenQA.Selenium.Interactions;
using PuppeteerSharp;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace MMBS_Sandbox
{

    internal class WebLoader
    {
        
        public enum WebLoaderSetting { Simple, Cookie, AngleSharp, SeleniumChrome, SeleniumEdge, SeleniumLambda, Puppeteer }
        public string webpageresult;
        public WebLoaderSetting setting;
        public Uri uri;
        
        public WebLoader(Uri uri, WebLoaderSetting setting = WebLoaderSetting.Simple)
        {
            this.uri = uri;
            this.setting = setting;
        }
        public async Task<string> Execute()
        {
            switch (setting)
            {
                case WebLoaderSetting.Simple: return webloadSimple();
                    break;
                case WebLoaderSetting.Cookie: return webloadCookie();
                    break;
                case WebLoaderSetting.AngleSharp: return await webloadAngleSharp();
                    break;
                case WebLoaderSetting.SeleniumChrome: return await webloadSeleniumChrome();
                    break;
                case WebLoaderSetting.SeleniumEdge: return await webloadSeleniumEdge();
                    break;
                case WebLoaderSetting.Puppeteer: return await webloadPuppeteer();
                    break;
                case WebLoaderSetting.SeleniumLambda: return await webloadSeleniumLambda();
                    break;
            }
            return "";
        }
        public string webloadSimple()
        {
            WebClient client = new WebClient();
            try
            {
                return client.DownloadString(uri);
            }
            catch (Exception e)
            {
                throw new Exception($"Webload Error {uri}");
            }
        }
        public string webloadCookie()
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
        public async Task<string> webloadAngleSharp()
        {
            return "";
            try
            {
                var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies().WithJs().WithEventLoop().WithCss();
                var context = BrowsingContext.New(config);

                var document = await context.OpenAsync(AngleSharp.Dom.Url.Create(uri.OriginalString)).WaitUntilAvailable();
                await document.WaitForReadyAsync();
                if (document == null) throw new Exception("Document creating failed");
                if (document.ReadyState != DocumentReadyState.Complete) return "";
                string cache = document.ToHtml();
                document.Dispose();
                return cache;
            }
            catch (Exception e)
            {
                
            }
            return "";
        }
        public async Task<string> webloadSeleniumChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("incognito");
            options.AddArgument("disable-extensions");
            options.AddArguments("no-sandbox");
            options.AddArgument("enable-automation");
            options.AddArgument("test-type=browser");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing", "enabled");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddArgument("force-headless-for-tests");
            options.AddArgument("window-position=-32000,-32000");
            options.AddArgument("window-size=50,50");
            string cache = "";
            using (var driver = new ChromeDriver())
            {
                driver.Manage().Window.Position = new System.Drawing.Point(-32000, -32000);
                driver.Manage().Window.Size = new System.Drawing.Size(0, 0);
                driver.Navigate().GoToUrl(uri.OriginalString);
                cache = driver.PageSource;
            };
            return cache;
        }
        public async Task<string> webloadSeleniumEdge()
        {
            var options = new EdgeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.AddArgument("headless");
            //options.AddArgument("disable-popup-blocking");
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
            options.AddArgument("disable-in-process-stack-traces");
            options.AddArgument("disable-logging");
            options.AddArgument("disable-dev-shm-usage");
            //options.AddArgument("--disable-extensions");
            //options.AddArgument("--safebrowsing-disable-download-protection");
            //options.AddArguments("no-sandbox");
            //options.AddArgument("enable-automation");
            //options.AddUserProfilePreference("safebrowsing", "enabled");
            //options.AddUserProfilePreference("permissions.default.image", "disabled");
            string cache = "";
            using (var driver = new EdgeDriver(options))
            {
                driver.Navigate().GoToUrl(uri.OriginalString);
                cache = driver.PageSource;
            };
            return cache;
        }
        public async Task<string> webloadSeleniumLambda()
        {
            EdgeOptions capabilities = new EdgeOptions();

            capabilities.BrowserVersion = "107.0";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", "lebibibioihandsomeboy.ghost");
            ltOptions.Add("accessKey", "37SUxGioYmbLROX9W3TmjVPgyR1W6hvEDSyewMwjBgRkcbgnYU");
            ltOptions.Add("platformName", "Windows 10");
            ltOptions.Add("project", "Untitled");
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-c#");
            capabilities.AddAdditionalOption("LT:Options", ltOptions);
            string cache = "";
            using (var driver = new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), capabilities))
            {
                driver.Navigate().GoToUrl(uri.OriginalString);
                cache = driver.PageSource;
                driver.Quit();
            };
            return cache;
        }
        /// <summary>
        /// Failed
        /// </summary>
        /// <returns></returns>
        public async Task<string> webloadPuppeteer()
        {
            string cache;
            using (var browserFetcher = new BrowserFetcher()) 
            { 
                await browserFetcher.DownloadAsync();
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
                var page = await browser.NewPageAsync();
                await page.GoToAsync(uri.OriginalString);
                cache = await page.GetContentAsync();
            }
            
            return cache;
        }
    }
    //Try to create an abstract class
    public abstract class engineWebLoad
    {
        Uri uri;
        engineWebLoad(Uri uri)
        {
            this.uri = uri;
        }
        public abstract string Execute();

    }
}
