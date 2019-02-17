using System;
using System.Collections.Generic;
using System.Text;

namespace BudkaSuflera
{
    public class Program
    {
        static void Main(string[] args)
        {
            string song = Console.ReadLine();
            string crisWords = Console.ReadLine();

            Console.Write(CheckSongContent(song, crisWords));
        }

        public static string CheckSongContent(string song, string crisWords)
        {
            List<string> songList = new List<string>(song.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            List<string> crisVersion = new List<string>(crisWords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            List<string> resultList = new List<string>();

            foreach (var word in songList)
            {
                if (crisVersion.Contains(word))
                {
                    crisVersion.Remove(word);
                }
                else
                {
                    resultList.Add(word);
                }
            }

            resultList.Sort();

            StringBuilder resultString = new StringBuilder();
            resultString.Append(resultList.Count + Environment.NewLine);
            resultString.Append(string.Join(Environment.NewLine, resultList));
            return resultString.ToString();
        }
    }
}
