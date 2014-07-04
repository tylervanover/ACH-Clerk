using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTrie.cs
{
    public class PrefixTrie
    {
        public PrefixTrieNode RootNode { get; private set; }

        /// <summary>
        /// Public, non-default constructor.
        /// </summary>
        public PrefixTrie()
        {
            // Create a new root node. Use the constant within PrefixTrieNode to
            // set the root node's Letter. 
            RootNode = new PrefixTrieNode { Letter = PrefixTrieNode.Root };
        }

        public void Add(string word)
        {
            word = word.ToLowerInvariant() + PrefixTrieNode.EndOfWord;
            PrefixTrieNode currentNode = RootNode;
            foreach (char c in word)
            {
                currentNode = currentNode.AddChild(c);
            }
        }
    }
}
