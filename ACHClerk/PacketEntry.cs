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
        private String _service;
        private String _toString;
        private bool _isTable;

        private StringBuilder strbldr;

        public PacketEntry(PdfDocument native, String company, String service, bool isTable) 
        {
            _nativeDoc = native;
            _company = company;
            _service = service;
            _isTable = isTable;

            strbldr = new StringBuilder();
            strbldr.Append(_nativeDoc.Info.Title);
            strbldr.Append(_company);
            strbldr.Append(_service);

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

        public String Service
        {
            get
            {
                return _service;
            }
            private set
            {
                _service = value;
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
