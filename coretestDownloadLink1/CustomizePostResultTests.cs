using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBSTests
{
    [TestClass()]
    public class CustomizePostResultTests
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
        public void SimpleProcessTest()
        {
            CustomizePostResult processor = new CustomizePostResult();
            PostDataBundle data = new PostDataBundle();
            data.appInfo.name = "Creative now or not is the Lie from the church !?!";
            data.modInfo.moddata = "Hello from newyork.\n-It's my life\nnotlike that isn't it.";
            TestContext.WriteLine(data.appInfo.name);
            processor.SimpleProcess(data);
            TestContext.WriteLine(processor.titleprocRes);
        }
    }
}