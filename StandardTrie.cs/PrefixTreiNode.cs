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
    /// A node of a prefix tree. The prefix tree will allow the user
    /// to build a structure of characters such that they can perform traversals
    /// of complete words, and of prefixes to words.
    /// 
    /// Most of this class was implemented at NullWorlds Blog, under an MIT License.
    /// 
    /// The MIT License is found here:
    /// 
    /*  The MIT License (MIT)
        Copyright (c) 2013
 
        Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
        to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
        and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
        The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
        THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
        FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
        WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    */
    /// </summary>
    public class PrefixTrieNode
    {
        /// <summary>
        /// Character representing the end of a valid word.
        /// </summary>
        public const char EndOfWord = '$';

        /// <summary>
        /// Character representing the root node.
        /// </summary>
        public const char Root = ' ';

        /// <summary>
        /// The letter of this node (the data).
        /// </summary>
        public char Letter { get; set; }

        /// <summary>
        /// A collection of children links. It will be optimized as a ListDictionary for
        /// entries under 10 items, and then switch optimization automatically to a Hashtable.
        /// </summary>
        public HybridDictionary Children { get; private set; }
        
        /// <summary>
        /// Public default constructor.
        /// </summary>
        public PrefixTrieNode() { }

        /// <summary>
        /// Public non-default constructor.
        /// </summary>
        /// <param name="letter"></param>
        public PrefixTrieNode(char letter)
        {
            this.Letter = letter;
        }

        /// <summary>
        /// Allows array access to the children.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PrefixTrieNode this[char index]
        {
            get { return (PrefixTrieNode)Children[index]; }
        }

        /// <summary>
        /// Returns a interface collection of keys for the children.
        /// Used to make the keys iterable/enumerable so a foreach can be
        /// utilized.
        /// </summary>
        public ICollection Keys
        {
            get { return Children.Keys; }
        }

        /// <summary>
        /// Check if the children contains a key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(char key)
        {
            return Children.Contains(key);
        }

        /// <summary>
        /// Adds a child. 
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public PrefixTrieNode AddChild(char letter)
        {
            // If there is no space allocated for children, generate it.
            if (Children == null)
                Children = new HybridDictionary();

            // If the children contain the letter as a key.
            if (!Children.Contains(letter))
            {
                // If the letter is EndOfWord, set node to null.
                // If the letter is not EndOfWord, create a new PrefixTrieNode
                // Then add node to the children, and return node.
                var node = (letter != EndOfWord) ? new PrefixTrieNode(letter) : null;
                Children.Add(letter, node);
                return node;
            }

            // The children must contain the letter as key, so return the node associated.
            return (PrefixTrieNode)Children[letter];
        }

        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}
