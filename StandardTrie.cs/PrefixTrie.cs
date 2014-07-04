using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTrie.cs
{
    /// <summary>
    /// The parent class for a Prefix Trie structure. Contained within the StandardTrie namespace.
    /// 
    /// This variation of a Trie will allow the user to search each node using prefixes to strings.
    /// It will help with an auto-complete function, such that only portions of a string can be searched.
    /// </summary>
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
