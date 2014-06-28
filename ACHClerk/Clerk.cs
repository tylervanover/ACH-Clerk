using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

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
    [Serializable]
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
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private void LoadNativeChangeForms(String path)
        {
            // Check that the parent directory exists.
            if (Directory.Exists(path))
            {
                // Get all 2nd tier directories. If no tables are present, then there should only be 1, called "Forms".
                String[] directories = Directory.GetDirectories(path);

                // Iterate each 2nd tier, and check that it is a valid entry for the 2nd tier. 
                foreach (String s in directories)
                {
                    if ( s == "Forms" )
                    {
                        ProcessFormDirectory(s);
                    }
                    else if (s == "Tables")
                    {
                        //ProcessTableDirectory();
                    }
                }
            }
            else
            {
                throw new DirectoryNotFoundException("This directory is not found.");
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
        private void RemovePacketEntry(int removePacketID)
        {
            // Use lambda to find the packet by ID.
            PacketEntry p = _selectedEntries.Find(pe => (pe.PacketID == removePacketID));

            if (p != null)
            {
                _selectedEntries.RemoveAll(pe => pe.PacketID == removePacketID);
            }
            else
            {
                throw new ArgumentException("Entry not found. Are you sure this PDF exists?");
            }
        }

        /// <summary>
        /// Process the directory which contains the PDF directories.
        /// </summary>
        /// <param name="formsPath"></param>
        private void ProcessFormDirectory(String formsPath)
        {
            int packetID = PacketID;
            String[] directories = Directory.GetDirectories(formsPath);
            List<String> tags = new List<String>();

            foreach (String s in directories)
            {
                String[] pdfs = Directory.GetFiles(s, "*.pdf");
                String[] txts = Directory.GetFiles(s, "*.txt");

                // Import the native pdf document into our environment. Only take the first file (there should only be one!).
                PdfDocument pdf = PdfReader.Open( pdfs[0], PdfDocumentOpenMode.Import );

                // Read the text file and process it for tags.
                tags = ProcessTags(txts[0]);
            }
        }

        /// <summary>
        /// Read in the tags text file and process each tag.
        /// </summary>
        /// <param name="textFilePath"></param>
        private List<String> ProcessTags(String textFilePath)
        {
            using( StreamReader txtfile = new StreamReader(textFilePath) )
            {
                String line;
                String[] pieces;
                List<String> tags = new List<String>();

                // Grab the file line by line.
                while( (line = txtfile.ReadLine()) != null )
                {
                    // Split each tag from the others.
                    pieces = line.Split(',');

                    // Add the new tags to the tag list.
                    tags.AddRange(pieces.ToList<String>());
                }

                return tags;
            }
        }

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

        public int PacketID
        {
            get
            {
                return _nativeChangeForms.Count;
            }
        }
    }
}
