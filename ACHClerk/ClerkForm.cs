﻿using System;
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
                _clerk.PreConfig = _configFileName;
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
            listSelectedList.Items.Clear();
            listPacketList.Items.AddRange(_clerk.NativeChangeForms.ToArray());
            listSelectedList.Items.AddRange(_clerk.SelectedEntries.ToArray());
        }

        /// <summary>
        /// Updates the text boxes so that I can track functionality.
        /// </summary>
        private void UpdateForm()
        {
            DisplayPacketInfo();
            clerkNativeFormsCount.Text = _clerk.NativeFormsCount.ToString();
            clerkDirectoryDisp.Text = _clerk.ParentDirectory;
            txtSelectedEntriesCount.Text = _clerk.SelectedCount.ToString();
            lblNativeCountDisp.Text = (_clerk.NativeFormsCount.ToString() + " forms found.");
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
        /// Testing Right-click preview pane window feature.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listPacketList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    int index = listPacketList.IndexFromPoint(e.X, e.Y);
                    PdfDocument pdf = _clerk.NativeChangeForms.Find(p => p.PacketID == index).NativeDoc;
                    PreviewPaneForm preview = new PreviewPaneForm(ref pdf);
                    preview.ShowDialog();
                }
            }
            catch (NullReferenceException nrf)
            {
                MessageBox.Show("Try clicking on a listed PDF!");
            }
        }

        /// <summary>
        /// TESTING EVENT FUNCTIONALITY.
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
        /// Adds a collection of selected packets to the final collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            var selectedIndices = listPacketList.SelectedIndices;
            PacketEntry toAdd;
            var native = _clerk.NativeChangeForms;

            foreach (int i in selectedIndices)
            {
                // Find the selected packet by index.
                toAdd = (native.Find(pe => pe.PacketID == i));

                // If the entry is already registerd in SelectedEntries, do not add it again.
                if (!_clerk.SelectedContains(ref toAdd))
                {
                    _clerk.AddPacketsToFinal(toAdd);
                }
            }

            // Update form information.
            UpdateForm();
        }
    }
}
