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

using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Charting;
using PdfSharp.Forms;

namespace ACHClerk
{
    public partial class ClerkForm : Form
    {   
        private Clerk _clerk;

        public ClerkForm()
        {
            String parent = Path.GetFullPath(Application.ExecutablePath + "\\..");

            InitializeComponent();
            _clerk = new Clerk(parent);
        }

        /// <summary>
        /// TESTING FUNCTIONALITY OF FILE SYSTEM MANAGEMENT.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestLoad_Click(object sender, EventArgs e)
        {
            _clerk.LoadNativeChangeForms(_clerk.ParentDirectory, false);
        }

        /// <summary>
        /// TESTING FUNCTIONALITY OF FILE SYSTEM MANAGEMENT.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestChangeLoad_Click(object sender, EventArgs e)
        {
            if( dlgFolderBrowser.ShowDialog() == DialogResult.OK )
            {
                _clerk.LoadNativeChangeForms(dlgFolderBrowser.SelectedPath, true);
            }
        }
    }
}
