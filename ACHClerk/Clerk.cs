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
        /// is a custom class, representing the PdfDocument, and various tags.
        /// The tag implementation (such as "service: gas" or "company: WestStar") is
        /// still under construction.
        /// </summary>
        private List<PacketEntry> _packetDocuments;

        /// <summary>
        /// A complete collection of the native change form PDFs. From this selection, the final _packetDocuments
        /// will be compiled, and then printed.
        /// </summary>
        private List<PacketEntry> _nativeChangeForms;

        /// <summary>
        /// The path representing the parent directory of the collection of native change forms.
        /// The parent directory will then contain numerous subdirectories, which will be walked
        /// recursively to load the actual PDF, and to read the various tags associated to each.
        /// </summary>
        private String _parentDirectory;

        /// <summary>
        /// Default, public constructor. Sets the parent directory, and allocates memory
        /// for the class' collections. 
        /// </summary>
        public Clerk(String loadPath)
        {
            ParentDirectory = loadPath;
            _packetDocuments = new List<PacketEntry>();
            _nativeChangeForms = new List<PacketEntry>();
        }

        /// <summary>
        /// Loads the native Change forms. They are all PDF documents that contain
        /// information on switching ACH transfers between financial institutions.
        /// The method is going to first check the load path, which is an initial directory.
        /// Next, it will recursively walk through each subdirectory, each one representing a separate 
        /// company's ACH form, and then a quick text file that contains the tags for "service", "company".
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool LoadNativeChangeForms(String path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Member access modifier. 
        /// </summary>
        public String ParentDirectory
        {
            get
            {
                return _parentDirectory;
            }
            set
            {
                _parentDirectory = value;
            }
        }
    }
}
