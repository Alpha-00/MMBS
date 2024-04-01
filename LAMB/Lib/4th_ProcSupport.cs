using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium;
using Selenium.WebDriver;

using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace LAMB.Lib
{
    public class ProcSupport
    {
        public class checkValid
        {
            //function
            public static bool ValidLink(string link)
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
                catch (Exception e) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("False: 4th: ProcSupport.checkValid.ValidLink\n"+e.Message);
                    Console.ResetColor();
                    return false; 
                }
                return false;
            }
            public static bool ValidUri(Uri uri)
            {

                return false;
            }
            
        }
        public class Webdriver
        {
            //variable
            public static string dirChromecache = "C:\\BloggerSupporter\\seleniumcache\\profile";
            
            //
            public abstract class webdriver
            {
                public ChromeDriver driver;
                public enum optionable
                {
                    headless,
                    userdata
                }
                public bool Login()
                {
                    return false;
                }
                public bool Init(params optionable[] opt)
                {
                    ChromeOptions options = new ChromeOptions();
                    if (opt!=null)
                    foreach (optionable a in opt)
                    {
                        switch (a)
                        {
                            case optionable.headless: options.AddArgument("--headless"); break;
                            case optionable.userdata: options.AddArguments($"user-data-dir={dirChromecache}"); break;
                        }
                    }
                    driver = new ChromeDriver(options);
                    return false;
                }
            }
            public class platinmods:webdriver
            {
                
                public bool Login()
                {
                    Init(optionable.userdata);
                    
                    driver.Navigate().GoToUrl("https://platinmods.com/login/login");
                    /*int i = 0;
                    while ((driver.Url != "https://platinmods.com/") && (driver != null) && (!driver.PageSource.Contains("already logged")))
                    {
                        Selenium.WebDriver.WaitExtensions.WebDriverExtensions.Wait(driver, 3000).ForPage().UrlToMatch("https://platinmods.com/");
                        if (++i > 100) { Lib.localAPI.Overmind.Error("Error: 4th: Platinmods login"); break; }
                        Thread.Sleep(3000);
                    }
                    System.Windows.MessageBox.Show("Test");
                    */
                    if (!driver.PageSource.Contains("already logged"))
                    {
                        if (!System.IO.File.Exists(localAPI.SLink.dirCache + "accPLatinmods.mmbs"))
                        {
                            localAPI.Overmind.Dialog dialog = new localAPI.Overmind.Dialog(localAPI.Overmind.Dialog.define.ddLogin, "return\n*username\n*password");
                            string cache = dialog.Perform();
                            driver.FindElement(By.Name("login")).SendKeys(cache.Split('\n')[1]);
                            driver.FindElement(By.Name("password")).SendKeys(cache.Split('\n')[2]);
                            driver.FindElement(By.ClassName("button--icon--login")).Click();
                            if (!((driver.Url != "https://platinmods.com/") && (driver != null) && (!driver.PageSource.Contains("already logged"))))
                            using (var stream = System.IO.File.CreateText(localAPI.SLink.dirCache + "accPlatinmods.mmbs"))
                            {
                                stream.WriteLine(cache.Split('\n')[1]);
                                stream.WriteLine(cache.Split('\n')[2]);
                            }
                        }
                        else
                        {
                            using (var stream = System.IO.File.OpenText(localAPI.SLink.dirCache + "accPlatinmods.mmbs"))
                            {
                                string cache = "";

                                cache =stream.ReadLine();
                                driver.FindElement(By.Name("login")).SendKeys(cache);
                                stream.ReadLine();
                                driver.FindElement(By.Name("password")).SendKeys(cache);
                                driver.FindElement(By.ClassName("button--icon--login")).Click();
                                
                            }
                        }
                    }
                    else {
                        Console.WriteLine("Have Login");
                        return true;
                    };
                    return false;
                }

            }
        }
    }
}
