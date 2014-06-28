using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;

namespace ACHClerk
{
    class PacketEntry
    {
        private int _packetID;
        private PdfDocument _nativeDoc;
        private String _company;
        private List<String> _services;
        private String _toString;
        private bool _isTable;

        private StringBuilder strbldr;

        public PacketEntry(int packetID, PdfDocument native, String company, List<String> services, bool isTable) 
        {
            PacketID = packetID;
            NativeDoc = native;
            Company = company;
            _services = new List<string>();
            _services.AddRange(services);
            _isTable = isTable;

            strbldr = new StringBuilder();
        }

        /// <summary>
        /// Overrides the ToString function, returning the PacketEntry as a string.
        /// This is very rough, as of now, and will require refinement as the project progresses.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_toString.Equals(null))
            {
                strbldr.Append(PacketID);
                strbldr.Append(" | ");
                strbldr.Append(Company);
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
        public String[] Services
        {
            get
            {
                return _services.ToArray(); ;
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
