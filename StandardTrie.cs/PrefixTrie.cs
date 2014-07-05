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
    /// Author: Tyler Vanover
    /// Created: 2014-07-04
    /// Version: 1.0
    /// 
    /// Part of StandardTrie.cs namespace. 
    /// 
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

        /// <summary>
        /// A custom lookup table of characters in the alphabet, and their indexes.
        /// </summary>
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
            // Uncapitalize the entire phrase. This saves space and brainwork, as you don't have to manage
            // both capital and lower case letters.
            word = word.ToLower();

            // Trim any whitespace. You do not have any children to represent gaps in words, so just juxtapose
            // pairs of words into a single one. The same methodology applies.
            word = word.Trim();

            // Get the index of the child we'll need to modify, based on the first character of the word. 
            // Because the children represent all the letters of the English alphabet, there should be 26 children.
            // We'll only want to work on the node with the equivalent index, i.e. 'a'-child == index 0,
            // 'b'-child == index 1, and so on.
            int cIndex = lookup[word[0]];

            // Check if that particular child already exists or not.
            if (RootNode.Children[cIndex] == null)
            {
                // If not, create a new node in its place.
                RootNode.Children[cIndex] = new PFTNode(word[0], false);
            }

            // Check that there is more to the word than just 1 character.
            if (word.Length > 1)
            {
                // Then begin the recursive insertion by stripping off the first letter of the word,
                // and letting the algorithm take care of the rest. Return the indexed child created
                // (and its subsequent nodes) into the indexed child of the root.
                RootNode.Children[cIndex] = rInsert(RootNode.Children[cIndex], word.Substring(1));
            }

            // If the node was not null, then return true to the calling function. Used for validation of insert.
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

            // If there is more to the word than the first character, recursively insert the rest.
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
