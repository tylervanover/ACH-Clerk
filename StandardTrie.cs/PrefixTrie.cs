using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTrie.cs
{
    // Shorten up the typing, just a tad.
    using PFTNode = StandardTrie.cs.PrefixTrieNode;

    /// <summary>
    /// The PrefixTrie structure. This class will handle the manipulation of
    /// nodes within the trie. It has a single root node, from which the
    /// rest of the insertion, contains, and removal methods can be initiated.
    /// </summary>
    public class PrefixTrie
    {
        /// <summary>
        /// The root node of the tree.
        /// </summary>
        public PFTNode RootNode { get; private set; }

        /// <summary>
        /// Alphabet used to index children from.
        /// </summary>
        private const char[] alphabet = {  'a', 'b', 'c', 'd', 'e', 
                                        'f', 'g', 'h', 'i', 'j', 
                                        'k', 'l', 'm', 'n', 'o',
                                        'p', 'q', 'r', 's', 't',
                                        'u', 'v', 'w', 'x', 'y',
                                        'z' };

        private Grid lookup;

        /// <summary>
        /// Public, non-default constructor.
        /// </summary>
        public PrefixTrie()
        {
            // Create a new root node. Use the constant within PrefixTrieNode to
            // set the root node's Letter. 
            RootNode = new PFTNode { Letter = PFTNode.RootChar, IsEnd = false };
            lookup = BuildLookup(alphabet);
        }

        /// <summary>
        /// The entry point insertion method. This will then call a private, recursive function
        /// to finish the insertion of the word. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Insert(string word)
        {
            int childIndex = lookup[word[0]];
            throw new NotImplementedException();
        }

        /// <summary>
        /// A recursive function to insert a word into the PrefixTrie. It must be called
        /// by the entry function, Insert. The function will continue to build the word
        /// path along the PrefixTrie, and then will return the primary node to the entry
        /// function. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        private PFTNode rInsert(PFTNode root, string word)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a looup for the alphabet.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private Grid BuildLookup(char[] values)
        {
            return new Grid(values);
        }
    }
}
