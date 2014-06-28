using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;

namespace ACHClerk
{
    class PacketEntry
    {
        private PdfDocument _nativeDoc;
        private String _company;
        private List<String> _services;
        private String _toString;
        private bool _isTable;

        private StringBuilder strbldr;

        public PacketEntry(PdfDocument native, String company, List<String> services, bool isTable) 
        {
            _nativeDoc = native;
            _company = company;
            _services = new List<string>();
            _services.AddRange(services);
            _isTable = isTable;

            strbldr = new StringBuilder();
            strbldr.Append(_nativeDoc.Info.Title);
            strbldr.Append(_company);

            _toString = strbldr.ToString();
        }

        public override string ToString()
        {
            return _toString;
        }

        public String Title
        {
            get
            {
                return _nativeDoc.Info.Title;
            }
        }

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

        public String[] Services
        {
            get
            {
                return _services.ToArray(); ;
            }
        }

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
