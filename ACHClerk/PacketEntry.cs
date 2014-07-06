using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;

using StandardTrie.cs;

namespace ACHClerk
{
    using PFT = PrefixTrie;

    /// <summary>
    /// Public class PacketEntry.cs.
    /// Part of the ACHClerk namespace, which represents a program capbable delivering
    /// an easy way for employees of the bank to provide ACH transition packets to customers.
    ///
    /// A PacketEntry is simply a collection of features regarding a single PDF document. 
    /// Each PacketEntry has a unique ID, a company name, and a list of tags -- the list of
    /// tags will the user to type in a string in the search bar and have a number of documents
    /// show as a result.
    /// 
    /// Author: Tyler Vanover.
    /// Created: 2014-06-26.
    /// Version: 1.0.
    /// </summary>
    public class PacketEntry
    {
        private int _packetID;
        private PdfDocument _nativeDoc;
        private String _company;
        private List<String> _tags;
        private String _toString;
        private bool _isTable;
        private PFT _tagTree;

        private StringBuilder strbldr;

        /// <summary>
        /// Public, non-default constructor. 
        /// </summary>
        /// <param name="packetID">A packet ID, to track the packet without sending all objects.</param>
        /// <param name="native">The pdf this packet entry will represent.</param>
        /// <param name="company">The company name associated with this packet entry.</param>
        /// <param name="tags">A list of tags.</param>
        /// <param name="isTable">Whether this packet is a table entry or not.</param>
        public PacketEntry(int packetID, PdfDocument native, String company, ref List<String> tags, bool isTable)
        {
            PacketID = packetID;
            NativeDoc = native;
            NativeDoc.Info.Title = company;
            Company = company;
            Tags = tags;
            TagTree = BuildTagTree();
            IsTable = isTable;
            _toString = "";

            strbldr = new StringBuilder();
        }

        /// <summary>
        /// The packet will invoke its PrefixTrie's "Contains"
        /// entry method for a given search term.
        /// </summary>
        /// <param name="word">The string to search for.</param>
        /// <returns>True if the PrefixTrie contains the term as a valid word. False otherwise.</returns>
        public bool ContainsSearchTerm(string word)
        {
            return TagTree.Contains(word);
        }

        /// <summary>
        /// Overrides the ToString function, returning the PacketEntry as a string.
        /// Build the string once, and store it. Never rebuild the string, as the tags won't change.
        /// </summary>
        /// <returns>A string representing a packet entry.</returns>
        public override String ToString()
        {
            if (_toString == "")
            {
                strbldr.Append(Company);
                strbldr.Append(" |  tagged as: ");
                for (int i = 0; i < TagsCount - 1; ++i)
                {
                    strbldr.Append(Tags[i]);
                    strbldr.Append(", ");
                }
                strbldr.Append(Tags[TagsCount - 1]);
                strbldr.Append(".");
                _toString = strbldr.ToString();
            }
            return _toString;
        }

        /// <summary>
        /// Builds a PrefixTrie out of the list of tags read in intially.
        /// The tree will be built such that the search term "banking" will
        /// insert "b", "ba", "ban", etc. This will perform like an autocomplete.
        /// </summary>
        /// <returns>Privately returns a PrefixTrie of tags.</returns>
        private PFT BuildTagTree()
        {
            PFT trie = new PFT();
            foreach (String s in Tags)
            {
                int sLength = s.Length;
                for (int i = 0; i < sLength; ++i)
                {
                    trie.Insert(s.Substring(0, i+1));
                }
            }
            return trie;
        }

        /// <summary>
        /// Assigns or returns the native PdfDocument attached to this packet entry.
        /// Will allow for rendering of individual packet entries as applied to a list box/combo box
        /// on a viewing pane.
        /// </summary>
        public PdfDocument NativeDoc
        {
            get
            {
                return _nativeDoc;
            }
            private set
            {
                _nativeDoc = value;
            }
        }

        /// <summary>
        /// Assigns or returns the packet entry's ID number.
        /// </summary>
        public int PacketID
        {
            get
            {
                return _packetID;
            }
            private set
            {
                _packetID = value;
            }
        }

        /// <summary>
        /// Assigns or returns the packet entry's company.
        /// </summary>
        public String Company
        {
            get
            {
                return _company;
            }
            private set
            {
                _company = value;
            }
        }

        /// <summary>
        /// Returns an array of the various service tags applied to this packet entry.
        /// Will be used for a tree-based search.
        /// </summary>
        public List<String> Tags
        {
            get
            {
                return _tags;
            }
            private set
            {
                _tags = value;
            }
        }

        /// <summary>
        /// Returns the number of tags associated with each PDF packet.
        /// </summary>
        public int TagsCount
        {
            get
            {
                return _tags.Count;
            }
        }

        /// <summary>
        /// Sets the tag prefix trie.
        /// </summary>
        internal PFT TagTree
        {
            get
            {
                return _tagTree;
            }
            private set
            {
                _tagTree = value;
            }
        }

        /// <summary>
        /// Determines if the packet entry is a table. Will allow for easier manipulation later on
        /// when compiling tables.
        /// </summary>
        public bool IsTable
        {
            get
            {
                return _isTable;
            }
            private set
            {
                _isTable = value;
            }
        }
    }
}
