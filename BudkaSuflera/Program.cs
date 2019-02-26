using System;
using System.Linq;

namespace BudkaSuflera
{
    public class WordTree
    {
        TreeNode[] arrayOfTreeNodes = Enumerable.Repeat(new TreeNode(), 10000).ToArray();

        private class TreeNode
        {
            public string Word { get; set; }
            public int Count { get; set; }
            public TreeNode LeftNode { get; set; }
            public TreeNode RightNode { get; set; }
        }

        private TreeNode root = null;
        public int Count { get; set; }
        private string result;

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
            if (root == null)
            {
                return string.Empty;
            }

            if (Count == 1)
            {
                return root.Word + Environment.NewLine;
            }

            result = String.Empty;
            PrintRecursivly(root);
            return result;

        }

        private void PrintRecursivly(TreeNode node)
        {
            if (node.LeftNode != null)
            {
                PrintRecursivly(node.LeftNode);
            }

            result += String.Concat(Enumerable.Repeat(node.Word + Environment.NewLine, node.Count));

            if (node.RightNode != null)
            {
                PrintRecursivly(node.RightNode);
            }
        }

        private void AddNodeRecursivly(TreeNode node, string word)
        {
            int compareValue = StringComparer.InvariantCulture.Compare(word, node.Word);

            switch (compareValue)
            {
                case 0:
                    {
                        ++node.Count;
                    }
                    break;


                case -1:
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
                    break;

                case 1:
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
                    break;
            }
        }
    }

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
}
