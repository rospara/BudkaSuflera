using System;
using BudkaSuflera;
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

            string output = Program.CheckSongContent(song, crisWords);

            string [] outputLines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.IsTrue(int.Parse(outputLines[0]) == 3);
            var expectedResult = new string [] { "JOLKA", "LATO", "PAMIETASZ"};
            Assert.IsTrue(outputLines.Length - 1 == expectedResult.Length);
            for (int i = 1, j=0; i < outputLines.Length && j < expectedResult.Length; ++i,++j)
            {
                Assert.AreEqual(outputLines[i], expectedResult[j]);
            }
        }
    }
}
