using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBS.OldProcessorTest
{
    [TestClass()]
    public class ProcSupporterTests

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
        [TestMethod()]
        public void ShortenLinkTest()
        {
            const string url = "https://modsfire.com/Tsu4809E280Yfzq";
            var result = MMBS.OldProcessor.ProcSupporter.ShortenLink(url);
            Assert.IsNotNull(result);
            TestContext.WriteLine(result);
        }
    }
}