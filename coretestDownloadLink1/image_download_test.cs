using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace coretestDownloadLink1
{
    [TestClass]
    public class ImageDownloadTests
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
        public void apkpureTest()
        {
            var request = @"https://image.winudf.com/v2/image1/Y29tLmVhLmdhbWUucHZ6ZnJlZV9yb3dfaWNvbl8xNjY1NDEyNjgwXzA4Nw/icon.webp?fakeurl=1&type=.webp";
            var result = new MMBS.OldProcessor.ProcSupporter.ImageDownloader(request, "test", "C:\\Users\\E5-576G\\Desktop\\com.ea.game.pvzfree_row");
            TestContext.WriteLine(result.name);
        }
    }
}
