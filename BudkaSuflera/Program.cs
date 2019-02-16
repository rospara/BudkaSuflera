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
            HashSet<string> songSet = new HashSet<string>(song.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            HashSet<string> crisSet = new HashSet<string>(crisWords.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            songSet.ExceptWith(crisSet);
            StringBuilder result = new StringBuilder();
            result.Append(songSet.Count);
            result.Append(Environment.NewLine);
            //songSet
            //result.

            return result.ToString();
        }
    }
}
