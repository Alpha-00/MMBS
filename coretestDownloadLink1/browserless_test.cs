using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace coretestDownloadLink1
{
    [TestClass]
    public class BrowserlessTests
    {
        private TestContext _testContext;
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return _testContext;
            }
            set
            {
                _testContext = value;
            }
        }
        [TestMethod]
        public void modsfireTests()
        {
            var browserless = new MMBS.Service.Browserless();
            //browserless.init();
            var task = browserless.fetch("https://modsfire.com/oCa4r9g72J3M864");
            task.Wait();
            var result = task.Result;
            Assert.IsNotNull(result);
            TestContext.WriteLine(result);
        }
        [TestMethod]
        public void cloudflareTests()
        {
            var browserless = new MMBS.Service.Browserless();
            //browserless.init();
            var task = browserless.fetchWithCloudflareBypass("https://apkpure.com/vn/plants-vs-zombies/com.ea.game.pvzfree_row");
            task.Wait();
            var result = task.Result;
            Assert.IsNotNull(result);
            TestContext.WriteLine(result);
        }
    }
}
