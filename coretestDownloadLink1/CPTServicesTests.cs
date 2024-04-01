using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMBS;
using MMBS.Model.PostForm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MMBSTests
{
    [TestClass()]
    public class CPTServicesTests
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
        public void ToRtfStringTest()
        {
            string content = File.ReadAllText(@"C:\BloggerSupporter\template\page.scriban-html");
            var message = new PostFormGeneralCustom.ScribanLogMessage()
            {
                message = "test",
                span = PostFormGeneralCustom.ScribanException.quickSpan(389,418,content: content)
            };
            string output = CPTServices.ToRtfString(message,16,content: content);
            TestContext.WriteLine(output);

        }
        [TestMethod()]
        public void quickSpanTest()
        {
            string content = File.ReadAllText(@"C:\BloggerSupporter\template\page.scriban-html");
            int start = 389;
            int startLine = 18;
            int startCol = 25;
            int end = 418;
            int endLine = 18;
            int endCol = 54;
            string highlight = content.Substring(start, end-start+1);
            var x = PostFormGeneralCustom.ScribanException.quickSpan(start,end, content: content);
            
            Assert.AreEqual(highlight, "https://imgur.com/u59ftm6t.jpg");
            Assert.AreEqual(highlight.Length, x.Length);
            Assert.AreEqual(startLine, x.Start.Line);
            Assert.AreEqual(startCol, x.Start.Column);
            Assert.AreEqual(endLine, x.End.Line);
            Assert.AreEqual(endCol, x.End.Column);
        }

    }
}