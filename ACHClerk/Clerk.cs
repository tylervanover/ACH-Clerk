using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PdfSharp.Pdf;

namespace ACHClerk
{
    /// <summary>
    /// Public class Clerk.cs.
    /// Part of the ACHClerk namespace, which represents a program capbable delivering
    /// an easy way for employees of the bank to provide ACH transition packets to customers.
    /// 
    /// The Clerk represents the main brain of the ACH packet operation. It is what handles all document
    /// manipulation, conversion, presentation, etc.
    /// 
    /// It is realized, as of v1.0, by ClerkForm.cs. 
    /// 
    /// Author: Tyler Vanover.
    /// Created: 2014-06-26.
    /// Version: 1.0.
    /// </summary>
    public class Clerk
    {
        /// <summary>
        /// Documents to be printed as the final ACH packet. PacketEntry
        /// is a custom class, representing the PdfDocument, and various tags.
        /// The tag implementation (such as "gas" or "Manhattan") is
        /// still under construction.
        /// </summary>
        private List<PacketEntry> _selectedEntries;

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
        /// Allows a user to specify a non default path. This means that, upon being unserialized
        /// by the system, the previous path will remain (as the constructor will not have to be reused).
        /// Also, when the form starts for the first-time, the user will be asked if they would like to
        /// use the default directory of the executable as their load path.
        /// </summary>
        private bool _nonDefaultLoadPath;

        /// <summary>
        /// Default, public constructor. Sets the parent directory, and allocates memory
        /// for the class' collections. 
        /// </summary>
        public Clerk(String loadPath)
        {
            if (NonDefaultLoadPath)
                ParentDirectory = loadPath;
            else
                ParentDirectory = System.Reflection.Assembly.GetEntryAssembly().Location;
 
            _selectedEntries = new List<PacketEntry>();
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
            _selectedEntries.Add(toAdd);
        }

        /// <summary>
        /// Removes a PacketEntry from the final ACH document collection. This is in place
        /// should the user request to not print this document (maybe an erroneous selection?).
        /// </summary>
        /// <param name="toRemove">The packet entry which will be removed.</param>
        /// <returns>True if the collection no longer contains the toRemove entry.</returns>
        private bool RemovePacketEntry(int removePacketID)
        {
            PacketEntry p = _selectedEntries.Find(pe => pe.);
        }


        //====================================//
        //              PROPERTIES            //
        //====================================//
        /// <summary>
        /// Assign or return the parent directory, which houses the native change forms. 
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

        /// <summary>
        /// Returns the selected ach packet entires as an array. This will make it
        /// easier to iterate through and compile the final document. 
        /// </summary>
        public PacketEntry[] SelectedEntries
        {
            get
            {
                return _selectedEntries.ToArray();
            }
        }

        /// <summary>
        /// Returns the native change forms as an array. In case you need to iterate the
        /// raw PDF documents.
        /// </summary>
        public PacketEntry[] NativeChangeForms
        {
            get
            {
                return _nativeChangeForms.ToArray();
            }
        }
    }
}
