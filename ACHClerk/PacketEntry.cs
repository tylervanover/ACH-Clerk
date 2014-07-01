using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;

namespace ACHClerk
{
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

        private StringBuilder strbldr;

        public PacketEntry(int packetID, PdfDocument native, String company, ref List<String> tags, bool isTable)
        {
            PacketID = packetID;
            NativeDoc = native;
            Company = company;
            Tags = tags;
            IsTable = isTable;
            _toString = "";

            strbldr = new StringBuilder();
        }

        /// <summary>
        /// Overrides the ToString function, returning the PacketEntry as a string.
        /// This is very rough, as of now, and will require refinement as the project progresses.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            if (_toString == "")
            {
                strbldr.Append(PacketID);
                strbldr.Append("  | ");
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
