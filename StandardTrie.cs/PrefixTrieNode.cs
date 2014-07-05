using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTrie.cs
{
    /// <summary>
    /// Author: Tyler Vanover
    /// Created: 2014-07-04
    /// Version: 1.0
    /// 
    /// Part of StandardTrie.cs namespace.
    /// 
    /// A node of a prefix tree. The prefix tree will allow the user
    /// to build a structure of characters such that they can perform traversals
    /// of complete words, and of prefixes to words during a search.
    /// </summary>
    public class PrefixTrieNode
    {
        /// <summary>
        /// A character denoting the node is the root of the entire tree.
        /// It will be written in this class so that automatic object initializers may
        /// be used in future releases, e.g., new PrefixTrieNode { Letter = PrefixTrieNode.RootChar; }
        /// </summary>
        public const char RootChar = ' ';

        /// <summary>
        /// The letter that this node represents. Similar to the "Data" node of a
        /// binary search tree.
        /// </summary>
        public char Letter { get; set; }

        /// <summary>
        /// True/False value indicating if this node is the end of a valid word in
        /// the inserted set. May not reflect the end of a search path, however, as an example of
        /// inserting "flower" and then "flowers" would mean that both this 'r'-child and this 'r'-child's 's'-child
        /// would be marked IsEnd, as they are valid words. Only if all children are null is this the true end of a
        /// search path.
        /// </summary>
        public bool IsEnd { get; set; }

        /// <summary>
        /// A collection of children nodes.
        /// </summary>
        public PrefixTrieNode[] Children;

        /// <summary>
        /// Public, default constructor. Currently unimplemented.
        /// </summary>
        public PrefixTrieNode()
        {

        }

        /// <summary>
        /// Public, non-default constructor. 
        /// </summary>
        /// <param name="c">The character to serve as this node's Letter.</param>
        /// <param name="end">True if this node is the end of a valid word, false otherwise.</param>
        public PrefixTrieNode(char c, bool end)
        {
            Letter = c;
            IsEnd = end;
            Children = new PrefixTrieNode[26];
        }

        /// <summary>
        /// Overloading [] so that children can be accessed like an array.
        /// </summary>
        /// <param name="index">The index of the child to return.</param>
        /// <returns>The indexed child node.</returns>
        public PrefixTrieNode this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

        /// <summary>
        /// Determines if this node is the end of a complete path. What this means
        /// is that even though a valid word may end at this node, there could be subsequent
        /// nodes representing additional words. "flower" and "flowers" is a prime example.
        /// </summary>
        /// <returns>If all the children are null, this node is the end of a complete path.</returns>
        public bool EndOfPath()
        {
            bool allNull = true;
            foreach (PrefixTrieNode p in this.Children)
            {
                if (p != null)
                {
                    allNull = false;
                    break;
                }
            }

            return allNull;
        }

        /// <summary>
        /// Display the Letter of this node. That's the most critical portion of data.
        /// </summary>
        /// <returns>A string version of the node's Letter.</returns>
        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}
