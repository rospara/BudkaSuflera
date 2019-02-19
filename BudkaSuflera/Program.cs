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

        public static string CheckSongContent(string song, string chrisWords)
        {
            string[] songList = song.Split(' ');
            string[] chrisVersion = chrisWords.Split(' ');

            if (songList.Length == chrisVersion.Length)
            {
                return "0" + Environment.NewLine;
            }

            List<string> misssedWords = new List<string>(50000);
            int indexOfChrisArray = 0;

            for (int i = 0, end = songList.Length; i < end; ++i)
            {
                string word = songList[i];

                string first = chrisVersion.Length > indexOfChrisArray ? chrisVersion[indexOfChrisArray] : null;

                if (first == word)
                {
                    ++indexOfChrisArray;
                }
                else
                {
                    misssedWords.Add(word);
                }

                if (chrisVersion.Length <= indexOfChrisArray)
                {
                    for (int j = i + 1, inend = songList.Length; j < inend; ++j)
                    {
                        misssedWords.Add(songList[j]);
                    }
                    break;
                }
            }

            misssedWords.Sort(StringComparer.InvariantCultureIgnoreCase);

            return misssedWords.Count + Environment.NewLine + string.Join(Environment.NewLine, misssedWords);
        }
    }
}
