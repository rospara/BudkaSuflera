using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void TestSong2()
        {
            string song = bezSatysfakcjiSong;
            List<string> songList = song.Split(new string[] { Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            WordTree wtree = new WordTree();

            for (int i = 0; i < songList.Count; ++i)
            {
                wtree.AddWord(songList[i]);
            }

            string[] result = wtree.PrintWords().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            songList.Sort();
            Assert.IsTrue(songList.Count == result.Length);
            for (int i = 0, j = 0; i < songList.Count && j < result.Length; ++i, ++j)
            {
                Assert.AreEqual(songList[i], result[j]);
            }
        }

        [TestMethod]
        public void TestSong3()
        {
            string song = "CHCE BYC A BAJKA BAJKA";
            List<string> songList = song.Split(new string[] { Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            WordTree wtree = new WordTree();

            for (int i = 0; i < songList.Count; ++i)
            {
                wtree.AddWord(songList[i]);
            }

            string[] result = wtree.PrintWords().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            songList.Sort();
            Assert.IsTrue(songList.Count == result.Length);
            for (int i = 0, j = 0; i < songList.Count && j < result.Length; ++i, ++j)
            {
                Assert.AreEqual(songList[i], result[j]);
            }
        }

        #region song for test 2
        private readonly string bezSatysfakcjiSong = @"LEDWIE TYLKO ODROSLEM OD ZIEMI
TROCHE WYZEJ NIZ METR
JUZ MYSLALEM ZE WSZYSTKO SIE SPELNI
ZE ZOSTANE KIM CHCE
CHCIALEM BYC WIELKA GWIAZDA ROCKA
SLAWNA JAK ROLLING STONES
WIDZIEC LUDZI TYSIACE WOKOL
ZASLUCHANYCH W MOJ GLOS
PRZEZ ZYCIE PRZEJSC WYLACZNIE NA SCENIE
PRZYZNACIE ZE NIEWIELKIE MARZENIE
DO ROBOTY NAWET SIE ZABRALEM
I PO LATACH DWOCH
PRAWIE DOBRZE ROZROZNIALEM
CO TO MOLL A CO DUR
I MOCNO W TO WIERZYLEM
ZE MOZNA WSZYSTKO MIEC
BY ZYCIE BAJKA BYLO
WYSTARCZY TYLKO CHCIEC
JAKOS ZARAZ POTEM PO MATURZE
OJCIEC PRZEKONAL MNIE
ZE SIE DAJE NAWET ZYC I W BIURZE
BYLE NIEZLY BYL SZEF
I TYLKO RAZ NA MIESIAC PO PIERWSZYM
ZNOW CZUJE ZE NO SATISFACTION
LEDWIE TYLKO ODROSLEM OD ZIEMI
TROCHE WYZEJ NIZ METR
JUZ MYSLALEM ZE WSZYSTKO SIE SPELNI
ZE ZOSTANE KIM CHCE
I MOCNO W TO WIERZYLEM
ZE MOZNA WSZYSTKO MIEC
BY ZYCIE BAJKA BYLO
WYSTARCZY TYLKO CHCIEC";
        #endregion
     
    }
}
