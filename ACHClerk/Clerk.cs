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
        /// The tag implementation (such as "gas" or "Manhattan") is
        /// still under construction.
        /// </summary>
        private List<PacketEntry> _finalACHPacket;

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

        private bool _nonDefaultLoadPath;

        /// <summary>
        /// Default, public constructor. Sets the parent directory, and allocates memory
        /// for the class' collections. 
        /// </summary>
        public Clerk(String loadPath)
        {
            if (_nonDefaultLoadPath)
                ParentDirectory = loadPath;
            else
                ParentDirectory = System.Reflection.Assembly.GetEntryAssembly().Location;
 
            _finalACHPacket = new List<PacketEntry>();
            _nativeChangeForms = new List<PacketEntry>();
        }

        /// <summary>
        /// Loads the native Change forms. They are all PDF documents that contain
        /// information on switching ACH transfers between financial institutions.
        /// The method is going to first check the load path, which is an initial directory.
        /// Next, it will recursively walk through each subdirectory, each one representing a separate 
        /// company's ACH form, and then a quick text file that contains the tags for what type of service it provides.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool LoadNativeChangeForms(String path)
        {
            if (Directory.Exists(path))
            {
                //Logic to recursively walk directories, stopping at each to sift out the
                //PDF of each company, as well as it's tags. Company name is stripped from sub-directory
                //folder name.
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a PacketEntry to the final ACH document collection.
        /// </summary>
        /// <param name="toAdd">A packet entry, of a PDF and some other ID information.</param>
        private void AddPacketEntry(PacketEntry toAdd)
        {
            _finalACHPacket.Add(toAdd);
        }

        /// <summary>
        /// Removes a PacketEntry from the final ACH document collection. This is in place
        /// should the user request to not print this document (maybe an erroneous selection?).
        /// </summary>
        /// <param name="toRemove">The packet entry which will be removed.</param>
        /// <returns>True if the collection no longer contains the toRemove entry.</returns>
        private bool RemovePacketEntry(int removePacketID)
        {
            PacketEntry p = _finalACHPacket.Find(pe => pe.);
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

        /// <summary>
        /// Member access modifier.
        /// </summary>
        public bool NonDefaultLoadPath
        {
            get
            {
                return _nonDefaultLoadPath;
            }
            set
            {
                _nonDefaultLoadPath = value;
            }
        }
    }
}
