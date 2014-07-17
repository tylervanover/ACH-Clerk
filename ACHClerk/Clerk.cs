using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

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
                int loaded = ProcessFormDirectory(path);
                if (loaded == 0)
                {
                    throw new ArgumentException("There were no forms found. Please select a new directory.");
                }
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
        /// Dispose of all the selected change forms.
        /// </summary>
        public void DisposeAllSelectedForms()
        {
            _selectedEntries.RemoveRange(0, SelectedCount);
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
        private int ProcessFormDirectory(String formsPath)
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
                        NativePDF = PdfReader.Open(pdfs[0], PdfDocumentOpenMode.Import);
                    }
                    catch (PdfReaderException) { }

                    NativePDF.Info.Title = company;

                    if (txts != null)
                    {
                        // Read the text file and process it for tags.
                        tags = ProcessTags(txts[0]);

                        AddNativeEntry(new PacketEntry(packetID++, NativePDF, company, pdfs[0], ref tags, false));
                    }
                    else
                        throw new IOException("The text file containing tags was not valid. Does it exist?");
                }
                else
                    throw new IOException("The PDF for this company was not found. Does it exist?");
            }

            return NativeFormsCount;
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
        internal void AddPacketToFinal(int addPacketID)
        {
            PacketEntry p = _nativeChangeForms.Find(pe => pe.PacketID == addPacketID);

            if (p != null)
            {
                _selectedEntries.Add(p);
            }
        }

        /// <summary>
        /// Removes a PacketEntry from the final ACH document collection. This is in place
        /// should the user request to not print this document (maybe an erroneous selection?).
        /// </summary>
        /// <param name="toRemove">The packet entry which will be removed.</param>
        internal void RemovePacketFromFinal(int removePacketID)
        {
            // Use lambda to find the packet by ID.
            PacketEntry p = _selectedEntries.Find(pe => (pe.PacketID == removePacketID));

            if (p != null)
            {
                _selectedEntries.Remove(p);
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
        /// <param name="addPacketID"></param>
        /// <returns></returns>
        internal bool SelectedContains(int addPacketID)
        {
            return (SelectedEntries.Find(pe => (pe.PacketID == addPacketID)) != null);
        }

        /// <summary>
        /// Builds the final ACH document and prompts the user to save or print.
        /// </summary>
        /// <returns></returns>
        internal PdfDocument CompileFinalDocument()
        {
            // Allocate space for the final packet, and generate the front page. 
            PdfDocument finalPacket = new PdfDocument();
            CreateFrontPage(ref finalPacket);

            // Prepare information for the table of contents.
            int[] indices = new int[SelectedCount];
            string[] headings = new string[SelectedCount];
            
            // Keep track of headings and pages; used to add indices of new documents.
            // Welcome page, followed by table of contents. Use page three as starter.
            int j = 0, k = finalPacket.PageCount+2;

            // Get the headings and page number information from the table of contents.
            foreach (PacketEntry p in SelectedEntries)
            {
                indices[j] = k;
                headings[j++] = p.NativeDoc.Info.Title;
                k += p.NativeDoc.PageCount; // Advance the page counter by the number of pages in this doc.
            }

            // Create the TOC.
            CreateTableOfContents(ref finalPacket, indices, headings);

            k = finalPacket.PageCount + 1;
            // For ever page in every packet, add that page to the final document.
            foreach (PacketEntry p in SelectedEntries)
            {
                PdfDocument doc = p.NativeDoc;
                int pages = doc.PageCount;

                PdfPage page;
                for (int i = 0; i < pages; ++i )
                {
                    page = finalPacket.AddPage(doc.Pages[i]);
                    DrawPageNumber(page, k++);
                }
            }

            return finalPacket;
        }

        /// <summary>
        /// Creates the front page of the PDF document. 
        /// </summary>
        /// <returns>A reference to the final ACH packet.</returns>
        private void CreateFrontPage(ref PdfDocument doc)
        {
            // Add a new page. 
            PdfPage page = doc.AddPage();

            // Set up the graphics object. 
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 16, XFontStyle.Bold);
            gfx.MUH = PdfFontEncoding.Unicode;
            gfx.MFEH = PdfFontEmbedding.Default;

            // Front page title.
            gfx.DrawString("Welcome, New Member!", font, XBrushes.Black, 
                new XRect(100, 100, page.Width - 200, 300), XStringFormats.Center);
            
            // Section Doc, need MigraDoc for rendering.
            MigraDoc.DocumentObjectModel.Document secDoc = new Document();
            Section sec = secDoc.AddSection();
            Paragraph para = sec.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Justify;
            para.Format.Font.Name = "Verdana";
            para.Format.Font.Size = 12;
            para.Format.Font.Color = Colors.DarkSlateGray;

            // Welcome text.
            para.AddText(
                " Hello, and thank you for choosing Sunflower Bank to meet your financial needs! We've " +
                "created a packet of forms specifically for you! We hope this will aid your transition from " +
                "your previous bank to us.\n\n" + 
                "All of those automatic payments you have tied to your previous " +
                "account number will slowly have to be switched to your new one. This packet will give you " +
                "the forms necessary to switch those payments, for each of your registered services.");
            para.Format.Borders.Distance = "5pt";

            // Create a renderer, and prepare the document.
            MigraDoc.Rendering.DocumentRenderer docRenderer = new MigraDoc.Rendering.DocumentRenderer(secDoc);
            docRenderer.PrepareDocument();

            // Render the paragraph.
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(5), XUnit.FromCentimeter(10), "12cm", para);
        }

        /// <summary>
        /// Create a table of contents within the final ACH packet. 
        /// </summary>
        /// <param name="doc">A reference to the final ACH packet.</param>
        private void CreateTableOfContents(ref PdfDocument doc, int[] indices, string[] headings)
        {
            // Add a new page.
            PdfPage page = doc.AddPage();

            // Set up the graphics object. 
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);
            gfx.MUH = PdfFontEncoding.Unicode;
            gfx.MFEH = PdfFontEmbedding.Default;

            // Draw the title of the page.
            gfx.DrawString("Table Of Contents", font, XBrushes.Blue,
                new XRect(100, 100, page.Width - 200, 200), XStringFormats.TopLeft);

            // Get a MigraDoc, and set up the properties of a new section.
            MigraDoc.DocumentObjectModel.Document secDoc = new MigraDoc.DocumentObjectModel.Document();
            Section sec = secDoc.AddSection();

            // Create the actual table.
            Table table = sec.AddTable();
            table.Style = "Table";
            
            // Define the columns.
            Column column = table.AddColumn("2in");
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn("3in");
            column.Format.Alignment = ParagraphAlignment.Right;

            int k = 0;
            foreach (int dex in indices)
            {
                // Add a new row to the table. Adjust its style.
                Row row = table.AddRow();
                row.Borders.Right.Width = row.Borders.Left.Width = 0.00;
                row.Borders.Style = BorderStyle.DashLargeGap;

                // Add the name of the current indexed document, and the
                // page it begins on.
                row.Cells[0].AddParagraph(headings[k++]);
                row.Cells[1].AddParagraph(dex.ToString());
            }

            table.Rows[0].Borders.Top.Clear();

            // Create a renderer, prepare the doc.
            MigraDoc.Rendering.DocumentRenderer docRenderer = new MigraDoc.Rendering.DocumentRenderer(secDoc);
            docRenderer.PrepareDocument();

            // Render the section.
            docRenderer.RenderObject(gfx, XUnit.FromInch(1.5), XUnit.FromInch(2.0), "12cm", table);
        }

        /// <summary>
        /// A separate function to draw the page number on each PDF page.
        /// This functionality is modular, in case the format of the page number is
        /// scheduled to change.
        /// </summary>
        /// <param name="page">The page to render XGraphics on.</param>
        /// <param name="i">The page number.</param>
        private void DrawPageNumber(PdfPage page, int i)
        {
            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            format.LineAlignment = XLineAlignment.Far;
            XGraphics gfx;
            XRect box;

            gfx = XGraphics.FromPdfPage(page);
            box = page.MediaBox.ToXRect();
            box.Inflate(0, -10);
            gfx.DrawString(String.Format("ACH Transition Packet, Page {0}", i), font,
                XBrushes.DarkRed, box, format);

        }

        /// <summary>
        /// Returns the selected ach packet entires as list. This will make it
        /// easier to iterate through and compile the final document. 
        /// </summary>
        public List<PacketEntry> SelectedEntries
        {
            get
            {
                return _selectedEntries;
            }
        }

        /// <summary>
        /// Returns the native change forms as an array. In case you need to iterate the
        /// raw PDF documents.
        /// </summary>
        public List<PacketEntry> NativeChangeForms
        {
            get
            {
                return _nativeChangeForms;
            }
            internal set
            {
                _nativeChangeForms = value;
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
