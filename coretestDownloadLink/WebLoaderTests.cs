using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBS.Tests
{
    [TestClass()]
    public class WebLoaderTests
    {
        [TestMethod()]
        public void WebLoaderTest()
        {

        }

        [DataTestMethod()]
        [DataRow(MMBS.OldProcessor.ProcSupporter.WebLoader.WebLoaderSetting.Simple)]
        [DataRow(MMBS.OldProcessor.ProcSupporter.WebLoader.WebLoaderSetting.Cookie)]
        [DataRow(MMBS.OldProcessor.ProcSupporter.WebLoader.WebLoaderSetting.Headless)]
        public void webloadHeadlessTest(OldProcessor.ProcSupporter.WebLoader.WebLoaderSetting setting)
        {
            MMBS.OldProcessor.ProcSupporter.WebLoader x;
            Uri uri;
           
            Console.WriteLine("---Webload test 1---");
            uri = new Uri("https://www.terabox.com/sharing/link?surl=_4Foql2y54TbtobSKOVDnA");
             x = new MMBS.OldProcessor.ProcSupporter.WebLoader(uri, setting);
            Assert.AreNotEqual(true, string.IsNullOrEmpty(MMBS.OldProcessor.ProcSupporter.WebLoader.webpageresult), $"{setting.ToString()} error");
            //Console.WriteLine(MMBS.OldProcessor.ProcSupporter.WebLoader.webpageresult ?? "");

            //Console.WriteLine(MMBS.OldProcessor.ProcSupporter.WebLoader.webpageresult.Contains("The file is not found because of link error. Please open the correct shared link.").ToString() ?? "");
            Console.WriteLine(MMBS.OldProcessor.ProcSupporter.WebLoader.webpageresult.Contains("56.4MB").ToString() ?? "");
        }
        [DataTestMethod()]
        
        public void webloadSeleniumTest()
        {

        }
    }
    
}