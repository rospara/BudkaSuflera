using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudkaSufleraTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string song = "JOLKA JOLKA PAMIETASZ LATO ZE SNU";
            string crisWords = "JOLKA ZE SNU";

            string output = checkSongContent(song, crisWords);

            string [] allLines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert(int.Parse(allLines[0]), 1);
            foreach (var line in )
            {

            }
        }
    }
}
