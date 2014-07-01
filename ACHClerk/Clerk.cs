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
        /// The parent directory of the project.
        /// </summary>
        private string _parentDirectory;

        /// <summary>
        /// Clerk's preconfig file name.
        /// </summary>
        private String _preConfigName;

        /// <summary>
        /// Default, public constructor. Sets the parent directory, and allocates memory
        /// for the class' collections. 
        /// </summary>
        public Clerk(String loadPath)
        {
            ParentDirectory = loadPath;
            _selectedEntries = new List<PacketEntry>();
            _nativeChangeForms = new List<PacketEntry>();
        }

        /// <summary>
        /// Loads the native Change forms. They are all PDF documents that contain
        /// information on switching ACH transfers between financial institutions.
        /// </summary>
        /// <param name="path">Path to load the native forms from.</param>
        /// <param name="SetNewParentDirectory">Set "True" to overwrite the current ParentDirectory.</param>
        /// <returns>Void.</returns>
        public void LoadNativeChangeForms(String path, Boolean SetNewParentDirectory)
        {
            // Check that the parent directory exists.
            if (Directory.Exists(path))
            {
                // Dispose of the current selection of change forms.
                DisposeNativeChangeForms();

                // Overwrite the parent directory for future uses on this session.
                if (SetNewParentDirectory)
                {
                    ParentDirectory = path;
                }

                // Process forms. This will be done in a separate method to hide the functionality.
                ProcessFormDirectory(path);
            }
            else
            {
                throw new DirectoryNotFoundException("You did not select a directory. Please select a directory.");
            }
        }

        /// <summary>
        /// Dispose of all the native change forms.
        /// </summary>
        internal void DisposeNativeChangeForms()
        {
            _nativeChangeForms.RemoveRange(0, NativeFormsCount);
        }

        /// <summary>
        /// Saves the preconfig information.
        /// </summary>
        internal void SavePreconfig()
        {
            using (TextWriter tw = new StreamWriter(PreConfig))
            {
                tw.Write(ParentDirectory);
            }
        }

        /// <summary>
        /// Gets the name of the folder at the end of the path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private String FolderName(String path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }

        /// <summary>
        /// Process the directory which contains the PDF directories.
        /// </summary>
        /// <param name="formsPath"></param>
        private void ProcessFormDirectory(String formsPath)
        {
            // Query the file system and get all of the directories from this forms path.
            String[] directories = Directory.GetDirectories(formsPath);
            List<String> tags = new List<String>();
            
            // Set a placeholder for the company name, so space does not have to be
            // reallocated on each pass.
            String company;
            int packetID = 0;

            foreach (String s in directories)
            {
                String[] pdfs = Directory.GetFiles(s, "*.pdf");     // Query all files ending in .pdf
                String[] txts = Directory.GetFiles(s, "*.txt");     // Query all files ending in .pdf

                if (pdfs != null)
                {
                    // Set the company name.
                    company = FolderName(s);

                    // Import the native pdf document into our environment. Only take the first file (there should only be one!).
                    PdfDocument NativePDF = new PdfDocument();
                    try
                    {
                        PdfReader.Open(pdfs[0], PdfDocumentOpenMode.Import);
                    }
                    catch (PdfReaderException) { }

                    NativePDF.Info.Title = company;

                    if (txts != null)
                    {
                        // Read the text file and process it for tags.
                        tags = ProcessTags(txts[0]);

                        AddNativeEntry(new PacketEntry(++packetID, NativePDF, company, ref tags, false));
                    }
                    else
                        throw new IOException("The text file containing tags was not valid. Does it exist?");
                }
                else
                    throw new IOException("The PDF for this company was not found. Does it exist?");
            }
        }

        /// <summary>
        /// Read in the tags text file and process each tag.
        /// </summary>
        /// <param name="textFilePath"></param>
        private List<String> ProcessTags(String textFilePath)
        {
            using (StreamReader txtfile = new StreamReader(textFilePath))
            {
                String line;
                String[] pieces;
                List<String> tags = new List<String>();

                // Grab the file line by line.
                while ((line = txtfile.ReadLine()) != null)
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
        /// Adds a native PDF entry to the native change forms.
        /// </summary>
        /// <param name="toAdd"></param>
        private void AddNativeEntry(PacketEntry toAdd)
        {
            _nativeChangeForms.Add(toAdd);
        }

        /// <summary>
        /// Adds a PacketEntry to the final ACH document collection.
        /// </summary>
        /// <param name="toAdd">A packet entry, of a PDF and some other ID information.</param>
        public void AddPacketsToFinal(PacketEntry toAdd)
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
        /// Checks if the selected packets already contain an item still marked as selected.
        /// This will prevent from multiple copies of the same item.
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <returns></returns>
        internal bool SelectedContains(ref PacketEntry itemToAdd)
        {
            return SelectedEntries.ToList<PacketEntry>().Contains(itemToAdd);
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

        /// <summary>
        /// Number of elements in the native change forms collection.
        /// </summary>
        public int NativeFormsCount
        {
            get
            {
                return _nativeChangeForms.Count;
            }
        }

        /// <summary>
        /// Number of elements in the selected change forms collection.
        /// </summary>
        public int SelectedCount
        {
            get
            {
                return _selectedEntries.Count;
            }
        }

        /// <summary>
        /// Get or set the parent directory of the clerk file system.
        /// </summary>
        public String ParentDirectory
        {
            get
            {
                return _parentDirectory;
            }
            internal set
            {
                _parentDirectory = value;
            }
        }
        
        /// <summary>
        /// Gets the preconfig name.
        /// </summary>
        public String PreConfig
        {
            get
            {
                return _preConfigName;
            }
            internal set
            {
                _preConfigName = value;
            }
        }
    }
}
