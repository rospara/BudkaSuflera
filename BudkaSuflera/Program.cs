using System;
using System.Collections.Generic;
using System.Text;

namespace BudkaSuflera
{
    public class Program
    {
        static void Main()
        {
            string song = Console.ReadLine();
            string crisWords = Console.ReadLine();

            Console.Write(CheckSongContent(song, crisWords));
        }

        public static string CheckSongContent(string song, string crisWords)
        {
            List<string> songList = new List<string>(song.Split(' '));
            songList.Sort();
            List<string> crisVersion = new List<string>(crisWords.Split(' '));
            crisVersion.Sort();        
            StringBuilder resultString = new StringBuilder();
            resultString.Append("{0}" + Environment.NewLine);

            int wordsCount = 0;

            for (int i = 0; i < songList.Count; ++i)
            {
                string word = songList[i];

                int found = crisVersion.BinarySearch(word);

                if (found >= 0)
                {
                    crisVersion.RemoveAt(found);
                }
                else
                {
                    resultString.Append(word + Environment.NewLine);
                    ++wordsCount;
                }

                if (crisVersion.Count == 0)
                {
                    for (int j = i + 1; j < songList.Count; ++j)
                    {
                        resultString.Append(songList[j] + Environment.NewLine);
                        ++wordsCount;
                    }
                    break;
                }
            }

            return string.Format(resultString.ToString(), wordsCount);
        }
    }
}
