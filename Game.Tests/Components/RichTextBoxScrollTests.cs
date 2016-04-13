using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Tests
{
    [TestClass]
    public class RichTextBoxScrollTests
    {
        //Verify that the RichTextBoxScroll properly appends
        //text to the box.
        [TestMethod]
        public void RichTextBoxScrollTest()
        {
            RichTextBoxScroll rtbs = new RichTextBoxScroll();

            string expected = "This text has been added to the log.";

            rtbs.AppendText(expected);

            string actual = rtbs.Lines[rtbs.Lines.Length - 1];

            Assert.AreEqual<string>(expected, actual);
        }
    }
}