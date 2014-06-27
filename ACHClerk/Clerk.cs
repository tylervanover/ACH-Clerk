using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PdfSharp.Pdf;

namespace ACHClerk
{
    public class Clerk
    {
        /// <summary>
        /// Documents to be printed as the final ACH packet. PacketEntry
        /// is a custom class, which will be generated soon.
        /// </summary>
        private List<PacketEntry> _packetDocuments;

        /// <summary>
        /// Using PDFSharp library to manage PDF manipulation.
        /// </summary>
        private List<PdfDocument> _nativeChangeForms;

        private String _loadPath;

        /// <summary>
        /// Default, public constructor. More to come.
        /// </summary>
        public Clerk(String Path)
        {
            LoadPath = Path;
            _packetDocuments = new List<PacketEntry>();
            _nativeChangeForms = new List<PdfDocument>();
        }

        private bool LoadNativeChangeForms(String path)
        {
            if (Directory.Exists(path))
            {
                String[] files = Directory.GetFiles(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        public String LoadPath
        {
            get
            {
                return _loadPath;
            }
            set
            {
               _loadPath = value;
            }
        }
    }
}
