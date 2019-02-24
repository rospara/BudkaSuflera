using System;
using System.Linq;

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

            WordTree tree = new WordTree();
            int indexOfChrisArray = 0;

            for (int i = 0, end = songList.Length; i < end; ++i)
            {
                string word = songList[i];

                string first = chrisVersion.Length > indexOfChrisArray ? chrisVersion[indexOfChrisArray] : null;

                if (first.First() == word.First() && first.Length == word.Length && first == word)
                {
                    ++indexOfChrisArray;
                }
                else
                {
                    tree.AddWord(word);
                }

                if (chrisVersion.Length <= indexOfChrisArray)
                {
                    for (int j = i + 1, inend = songList.Length; j < inend; ++j)
                    {
                        tree.AddWord(songList[j]);
                    }
                    break;
                }
            }

            return tree.Count.ToString() + Environment.NewLine + tree.PrintWords();
        }
    }

    class WordTree
    {
        private class TreeNode
        {
            public string Word { get; set; }
            public uint Count { get; set; }
            public TreeNode LeftNode { get; set; }
            public TreeNode RightNode { get; set; }
        }

        private TreeNode root = null;
        public uint Count { get; set; }
        public string Result { get; set; }

        public void AddWord(string word)
        {
            ++Count;

            if (root == null)
            {
                root = new TreeNode() { Word = word, Count = 1, LeftNode = null, RightNode = null };
            }
            else
            {
                AddNodeRecursivly(root, word);
            }

        }

        public string PrintWords()
        {
            if (Count == 1)
            {
                return root.Word + Environment.NewLine;
            }
            else
            {
                Result = String.Empty;
                PrintRecursivly(root);
                return Result;
            }
        }

        private void PrintRecursivly(TreeNode node)
        {
            if (node.LeftNode != null)
            {
                PrintRecursivly(node.LeftNode);
            }

            Result += String.Concat(Enumerable.Repeat(node.Word + Environment.NewLine, (int)node.Count));

            if (node.RightNode != null)
            {
                PrintRecursivly(node.RightNode);
            }
        }

        private void AddNodeRecursivly(TreeNode node, string word)
        {
            if (word.First() < node.Word.First() && StringComparer.InvariantCulture.Compare(word, node.Word) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new TreeNode() { Word = word, Count = 1, LeftNode = null, RightNode = null };
                }
                else
                {
                    AddNodeRecursivly(node.LeftNode, word);
                }
            }
            else if (word.First() > node.Word.First() && StringComparer.InvariantCulture.Compare(word, node.Word) > 0)
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new TreeNode() { Word = word, Count = 1, LeftNode = null, RightNode = null };
                }
                else
                {
                    AddNodeRecursivly(node.RightNode, word);
                }
            }
            else
            {
                ++node.Count;
            }
        }
    }
}
