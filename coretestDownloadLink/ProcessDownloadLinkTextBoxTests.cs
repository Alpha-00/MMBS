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
    public class ProcessDownloadLinkTextBoxTests
    {
        [TestMethod()]
        public void ProcessDownloadLinkTextBoxTest()
        {
            
            Assert.Fail();
        }
        [DataTestMethod]
        //Terabox
        [DataRow("https://www.terabox.com/sharing/link?surl=_4Foql2y54TbtobSKOVDnA", "56.4MB", "JewelsAtlantis_Puzzlegame_v47_mod.apk")]
        public void testFullProcDownloadLink(string link, string expectSize, string expectName, int expectValid=1)
        {
            MMBS.OldProcessor.ProcessDownloadLinkTextBox proc = new OldProcessor.ProcessDownloadLinkTextBox(link);
            Assert.AreEqual(expectValid, proc.valid);
            Assert.AreEqual(expectName, proc.fname,"Wrong file Name");
            Assert.AreEqual(expectSize, proc.fsize, "Wrong file Size");
        }
    }
}