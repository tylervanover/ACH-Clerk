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
    /// </summary>
    public class PrefixTrieNode
    {
        public const char RootChar = ' ';
        public const char EOW = '$';

        public char Letter { get; set; }
        public bool IsEnd { get; set; }

        public PrefixTrieNode[] Children;

        public PrefixTrieNode()
        {

        }

        public PrefixTrieNode(char c, bool end)
        {
            Letter = c;
            IsEnd = end;
            Children = new PrefixTrieNode[26];
        }

        public PrefixTrieNode this[int index]
        {
            get
            {
                return Children[index];
            }
        }
    }
}
