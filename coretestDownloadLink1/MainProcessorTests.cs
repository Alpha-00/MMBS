using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MMBS.OldProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBS.OldProcessorTests
{
    [TestClass()]
    public class MainProcessorTests
    {
        [TestMethod()]
        public void MainProcessorTest()
        {

		}
        [TestMethod()]
        public void ApkPureTest()
        {
            const string url = "https://apkpure.com/vn/genshin-impact/com.miHoYo.GenshinImpact";
            var processor = new ProcessDataResourceTextBox(url);
            // First stage
            {
                Assert.IsTrue(processor.valid==1, "Invalid link");
                Console.WriteLine($"Host Recognize: {processor.host}");
                Console.WriteLine($"Cover Image Link: {processor.coverImage.Link}");
                Console.WriteLine($"Valid Code: {processor.valid}");
                Console.WriteLine($"Package: {processor.packagename}");
                Assert.IsFalse(String.IsNullOrEmpty(processor.webpage), "Invalid content");
            }
            // Second stage
            {
                var mainProc = new MainProcessor(processor.webpage,processor.host,processor.cacheDir);
                Assert.IsFalse(String.IsNullOrEmpty(mainProc.title), "Invalid link");
            }

        }
    }
}