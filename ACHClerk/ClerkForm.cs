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
    public partial class ClerkForm : Form
    {   
        private Clerk _clerk;
        private String _configFileName = "CLERK.CFG";

        public ClerkForm()
        {
            InitializeComponent();
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
                    _clerk.LoadNativeChangeForms(_clerk.ParentDirectory, false);
                }
            }
            else
            {
                _clerk = new Clerk(parent);
            }
            UpdateForm();
        }

        /// <summary>
        /// Will load the clerk's native PDF forms and display them (as string) to the
        /// list box.
        /// </summary>
        private void DisplayPacketInfo()
        {
            // Wipe clean, the slate of items. 
            listPacketList.Items.Clear();
            listPacketList.Items.AddRange(_clerk.NativeChangeForms);
        }

        /// <summary>
        /// Updates the text boxes so that I can track functionality.
        /// </summary>
        private void UpdateForm()
        {
            DisplayPacketInfo();
            clerkNativeFormsCount.Text = _clerk.NativeFormsCount.ToString();
            clerkDirectoryDisp.Text = _clerk.ParentDirectory;
        }

        /// <summary>
        /// Sets the clerk's load directory to the default. 
        /// </summary>
        private void DefaultLoadDirectory()
        {
            try
            {
                _clerk.LoadNativeChangeForms(_clerk.ParentDirectory, false);
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
                UpdateForm();
            }
        }

        /// <summary>
        /// Set the clerk's load directory to the user specified location.
        /// </summary>
        private void ChangeLoadDirectory()
        {
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                String path = dlgFolderBrowser.SelectedPath;
                dlgSaveFolderDiag saveFolderDiag = new dlgSaveFolderDiag(ref _clerk, path);
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
            }
            UpdateForm();
        }

        /// <summary>
        /// TESTING FUNCTIONALITY OF FILE SYSTEM MANAGEMENT.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestLoad_Click(object sender, EventArgs e)
        {
            DefaultLoadDirectory();
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
        /// TESTING EVENT FUNCTIONALITY.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listPacketList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                PreviewPaneForm preview = new PreviewPaneForm();
                preview.Location = e.Location;
                preview.ShowDialog();
            }
        }

        /// <summary>
        /// TESTING EVENT FUNCTIONALITY.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listPacketList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
