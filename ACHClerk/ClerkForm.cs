using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Charting;
using PdfSharp.Forms;

namespace ACHClerk
{
    /// <summary>
    /// Author: Tyler Vanover
    /// Created: 2014-07-04
    /// Version: 1.0
    /// 
    /// Part of StandardTrie.cs namespace. 
    /// 
    /// Represents the actual user interface.
    ///</summary>
    public partial class ClerkForm : Form
    {   
        /// <summary>
        /// A reference to the clerk managing a user's session.
        /// </summary>
        private Clerk _clerk;

        /// <summary>
        /// The configuration filename; this is where preconfig settings will
        /// looked for.
        /// </summary>
        private String _configFileName = "CLERK.CFG";

        /// <summary>
        /// The list of displayable packet entries. If there is a search performed, you must limit
        /// the displayable to the search criteria.
        /// </summary>
        private List<PacketEntry> _displayable;

        public ClerkForm()
        {
            InitializeComponent();
            _displayable = new List<PacketEntry>();
            CheckPreconfig();
        }

        /// <summary>
        /// Take as much logic out of the FORMS
        /// as possible.
        /// </summary>
        private void CheckPreconfig()
        {
            // PdfDocument is unserializable. Instead, check for a file in the parent directory called
            // CLERK.CFG. This will have a new parent directory from the previous session.
            String parent = Path.GetFullPath(Application.ExecutablePath + "\\..");
            List<String> files = Directory.GetFiles(parent, _configFileName).ToList<String>();

            // If a preconfig file exists, then
            if (files.Count > 0)
            {
                using (TextReader tr = new StreamReader((files.ToArray())[0]))
                {
                    // Use a text reader to open, parse the contents, and apply them to the clerk.
                    String path = tr.ReadLine();
                    _clerk = new Clerk(path);
                    _clerk.PreConfig = _configFileName;

                    // Go ahead and preload the forms for the user. If they wish to specify another
                    // folder at start time. They can, and can ask to "Save this location for future
                    // loads."
                    try
                    {
                        _clerk.LoadNativeChangeForms(_clerk.ParentDirectory, false);
                    }
                    catch (ArgumentException arge)
                    {
                        MessageBox.Show(arge.Message, "Select New Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChangeLoadDirectory();
                    }
                    finally
                    {
                        _displayable = _clerk.NativeChangeForms;
                        UpdateForm();
                    }
                }
            }
            else
            {
                _clerk = new Clerk(parent);
                _clerk.PreConfig = _configFileName;
                try
                {
                    _clerk.LoadNativeChangeForms(_clerk.ParentDirectory, false);
                }
                catch (ArgumentException arge)
                {
                    MessageBox.Show(arge.Message, "Select New Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeLoadDirectory();
                }
                finally
                {
                    _displayable = _clerk.NativeChangeForms;
                    UpdateForm();
                }
            }
        }

        /// <summary>
        /// Will load the clerk's native PDF forms and display them (as string) to the
        /// list box.
        /// </summary>
        private void DisplayPacketInfo()
        {
            // Wipe clean, the slate of items. 
            listPacketList.Items.Clear();
            listFinalList.Items.Clear();
            listPacketList.Items.AddRange(_displayable.ToArray());
            listFinalList.Items.AddRange(_clerk.SelectedEntries.ToArray());
        }

        /// <summary>
        /// Updates the text boxes so that I can track functionality.
        /// </summary>
        private void UpdateForm()
        {
            DisplayPacketInfo();
            clerkNativeFormsCount.Text = _displayable.Count.ToString();
            clerkDirectoryDisp.Text = _clerk.ParentDirectory;
            txtSelectedEntriesCount.Text = _clerk.SelectedCount.ToString();
            lblNativeCountDisp.Text = (_displayable.Count.ToString() + " forms found.");
        }

        /// <summary>
        /// Set the clerk's load directory to the user specified location.
        /// </summary>
        private void ChangeLoadDirectory()
        {
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                String path = dlgFolderBrowser.SelectedPath;
                SaveFolderDiag saveFolderDiag = new SaveFolderDiag(ref _clerk, path);
                saveFolderDiag.ShowDialog();

                try
                {
                    _clerk.LoadNativeChangeForms(path, true);
                }
                catch (DirectoryNotFoundException dnf)
                {
                    MessageBox.Show(dnf.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    _displayable = _clerk.NativeChangeForms;
                    UpdateForm();
                }
            }
        }

        /// <summary>
        /// Creates a final packet, and then allows the user to preview it.
        /// </summary>
        private void PreviewFinalPacket()
        {
            PdfDocument doc = _clerk.CompileFinalDocument();
            doc.Save("temp.pdf");
            List<string> finalTag = new List<string>();
            finalTag.Add("final");

            PacketEntry packet = new PacketEntry(_clerk.NativeFormsCount + 1, doc, "FINAL", "temp.pdf", ref finalTag, false);
            PreviewPaneForm preview = new PreviewPaneForm(ref packet, this.Height, new System.Drawing.Point(this.Left + this.Width, this.Top));
            preview.ShowDialog();
        }

        /// <summary>
        /// Add items selected in the listPacketList box to the listSelectedList box.
        /// </summary>
        private void AddSelectedToListBox()
        {
            var selectedIndices = listPacketList.SelectedIndices;
            int toAdd;
            var native = _displayable;

            foreach (int i in selectedIndices)
            {
                // Find the selected packet by index.
                toAdd = (native.Find(pe => pe.PacketID == i)).PacketID;

                // If the entry is already registerd in SelectedEntries, do not add it again.
                if (!_clerk.SelectedContains(toAdd))
                {
                    _clerk.AddPacketToFinal(toAdd);
                }
            }

            // Update form information.
            UpdateForm();  
        }

        /// <summary>
        /// Removes items selected in the listSelectedList box from itself.
        /// Useful for if the user changes their mind.
        /// </summary>
        private void RemoveSelectedItems()
        {
            var selected_items = listFinalList.SelectedItems;
            int toRemove;
            var final = _clerk.SelectedEntries;

            foreach (PacketEntry p in selected_items)
            {
                // Bit of a hack, but this will work for now.
                toRemove = (final.Find(pe => pe.PacketID == p.PacketID)).PacketID;

                // Remove the entry.
                try
                {
                    _clerk.RemovePacketFromFinal(toRemove);
                }
                catch(ArgumentException arge)
                {
                    MessageBox.Show("Something went wrong! We couldn't find that file to remove. Has the folder been moved or changed? Please check, and then try again.",
                        "Whoops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            UpdateForm();
        }

        /// <summary>
        /// Remove everything from the listFinalList pane.
        /// </summary>
        private void RemoveAllFinalItems()
        {
            _clerk.DisposeAllSelectedForms();
            UpdateForm();
        }

        /// <summary>
        /// Performs a search for the packet entries containing the search term.
        /// </summary>
        /// <param name="p"></param>
        private void PerformSearch(string word)
        {
            // Trim off any non-alphabetic characters. 
            var arr = word.ToCharArray();
            arr = Array.FindAll<char>(arr, (ce => (char.IsLetter(ce))));
            word = new string(arr);
            
            // Check that the entered search phrase is not an empty string.
            if(word.Length > 0)
            {
                txtSearchBar.Text = word;
                _displayable = _clerk.NativeChangeForms.FindAll(pe => pe.ContainsSearchTerm(word));
            }
            // If it is, just load the native change forms.
            else
            {
                _displayable = _clerk.NativeChangeForms;
            }
            UpdateForm();
        }

        /// <summary>
        /// TESTING FUNCTIONALITY OF FILE SYSTEM MANAGEMENT.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestChangeLoad_Click(object sender, EventArgs e)
        {
            ChangeLoadDirectory();
        }

        /// <summary>
        /// TESTING FUNCTIONALITY.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestPacketDisplay_Click(object sender, EventArgs e)
        {
            DisplayPacketInfo();
        }

        /// <summary>
        /// Testing Right-click preview pane window feature.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listPacketList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // On a right click
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    // Get the index from the location of the mouse pointer
                    int index = listPacketList.IndexFromPoint(e.X, e.Y);

                    // Retrieve the associated pdf.
                    PacketEntry doc = _clerk.NativeChangeForms.Find(p => p.PacketID == index);

                    // Send it to the preview pane, and show the dialog.
                    // Align the preview form based on the right hand panel of the parent container.
                    PreviewPaneForm preview = new PreviewPaneForm(ref doc, this.Height, new System.Drawing.Point(this.Left + this.Width, this.Top));
                    preview.Show();
                }
            }
            catch (NullReferenceException nrf)
            {
                MessageBox.Show("Try clicking on a listed PDF!");
            }
        }

        /// <summary>
        /// Allows for the user to select a specific section of the listPacketList box,
        /// and then will raise an even to repaint the selected items' bounds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listPacketList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Invalidate the form's rendered display, causing the
            // listPacketList_DrawItem event to be raised.
            listPacketList.Invalidate();
        }

        /// <summary>
        /// Highlights the selected item(s) in listPacketList.
        /// Upon a form object invalidation (i.e., an item being selected), this
        /// event will be called, passed a DrawItemEventArgs, and then
        /// the state of the draw item e will have it's background updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listPacketList_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Get the index of the calling item.
            int index = e.Index;
            Graphics g = e.Graphics;

            // Get the indices of the selected items.
            var selected = listPacketList.SelectedIndices;
            foreach (int i in selected)
            {
                // For the item that matches the index.
                if (i == index)
                {
                    // Draw a new background on the calling item, and fill it with a color.
                    e.DrawBackground();
                    g.FillRectangle(new SolidBrush(Color.AliceBlue), e.Bounds);
                }
            }
        }

        /// <summary>
        /// Allows for the user to select a specific section of the selectedPackets box,
        /// and then will raise an even to repaint the selected item's bounds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listSelectedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Invalidate the form's rendered display,
            // causing the listPacketList_DrawItem event to be raised.
            listFinalList.Invalidate();
        }

        /// <summary>
        /// Highlights the selected item(s), and paints in it's bounds. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listSelectedList_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Get the index of the calling item.
            int index = e.Index;
            Graphics g = e.Graphics;

            // Get the indices of the selected items.
            var selected = listFinalList.SelectedIndices;
            foreach (int i in selected)
            {
                // For the item that matches the index.
                if (i == index)
                {
                    // Draw a new background on the calling item, and fill it with a color.
                    e.DrawBackground();
                    g.FillRectangle(new SolidBrush(Color.MistyRose), e.Bounds);
                }
            }
        }

        /// <summary>
        /// TESTS THE FUNCTIONALITY OF AddSelectedToListBox().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            AddSelectedToListBox();
        }

        private void btnTestRmvSelected_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems();
        }

        private void btnTestRmvAllFinal_Click(object sender, EventArgs e)
        {
            RemoveAllFinalItems();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            PerformSearch(txtSearchBar.Text);
        }

        private void btnBuildFinal_Click(object sender, EventArgs e)
        {
            PreviewFinalPacket();
        }
    }
}
