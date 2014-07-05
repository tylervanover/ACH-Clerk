using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StandardTrie.cs;

namespace TestPrefixTrie
{
    class TestPrefixTrie
    {
        static void Main(string[] args)
        {
            PrefixTrie tree = new PrefixTrie();

            tree.Insert("flower");
            tree.Insert("fire");
            tree.Insert("goal");
            tree.Insert("seventeen");
            tree.Insert("flame");
            tree.Insert("flames");

            Console.WriteLine("Checking if tree contains 'flame'.");
            if (tree.Contains("flames"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
