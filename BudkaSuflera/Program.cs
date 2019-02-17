using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudkaSuflera
{
    public class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
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
