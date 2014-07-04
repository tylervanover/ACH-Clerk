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
        private readonly char[] alphabet = {  'a', 'b', 'c', 'd', 'e', 
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
            RootNode = new PFTNode(PFTNode.RootChar, false);
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
            // Get the index of the child we'll need to modify, based on the first character of the word. 
            // Because the children represent all the letters of the English alphabet, there should be 26 children.
            // We'll only want to work on the node with the equivalent index, i.e. 'a'-child == index 0,
            // 'b'-child == index 1, and so on.
            int cIndex = lookup[word[0]];

            // Check if that particular child already exists or not.
            if (RootNode.Children[cIndex] == null)
            {
                RootNode.Children[cIndex] = new PFTNode(word[0], false);
            }

            // Check that there is more to the word than just 1 character.
            if (word.Length > 1)
            {
                // Then begin the recursive insertion by stripping off the first letter of the word,
                // and letting the algorithm take care of the rest.
                RootNode.Children[cIndex] = rInsert(RootNode.Children[cIndex], word.Substring(1));
            }

            return RootNode != null;
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
            // Get the index of the child to populate the first character of
            // this word to.
            int cIndex = lookup[word[0]];

            // If that particular child is null,
            if (root.Children[cIndex] == null)
            {
                // Create a node for it with the first character of this word.
                root.Children[cIndex] = (word.Length > 1) ? new PFTNode(word[0], false) : new PFTNode(word[0], true);
            }

            if (word.Length > 1)
                root.Children[cIndex] = rInsert(root.Children[cIndex], word.Substring(1));

            return root;
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
