using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACHClerk
{
    public partial class dlgSaveFolderDiag : Form
    {
        /// <summary>
        /// Holds the status of the checkbox button.
        /// </summary>
        private bool _isChecked;

        /// <summary>
        /// A reference to the clerk, to send back information.
        /// </summary>
        private Clerk _clerk;

        /// <summary>
        /// Path to overwrite preconfig.
        /// </summary>
        private String _path;

        /// <summary>
        /// Public, default constructor.
        /// </summary>
        public dlgSaveFolderDiag()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Public, non-default constructor. Allows for the clerk to receive
        /// information back from the dialog. 
        /// </summary>
        /// <param name="clerk"></param>
        public dlgSaveFolderDiag(ref Clerk clerk, String path)
            : this()
        {
            _clerk = clerk;
            _path = path;
        }

        /// <summary>
        /// Gets or privately sets the status of the checkbox button.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            private set
            {
                _isChecked = value;
            }
        }

        /// <summary>
        /// Handles the event that user checks/unchecks the box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkbxSaveChoice_CheckedChanged(object sender, EventArgs e)
        {
            // Updates the status of the checkbox. 
            IsChecked = chkbxSaveChoice.Checked;
        }

        /// <summary>
        /// Closes the dialog and sends the user's choice back to the ClerkForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsChecked)
            {
                // Save the preconfig information.
                _clerk.ParentDirectory = _path;
                _clerk.SavePreconfig();
            }
            this.Close();
        }

        /// <summary>
        /// Closes the dialog without sending the user's choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
