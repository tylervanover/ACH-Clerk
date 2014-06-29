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
        private BinaryFormatter _binFormatter;

        public ClerkForm()
        {
            InitializeComponent();
            _binFormatter = new BinaryFormatter();
            CheckPreconfig();
        }

        /// <summary>
        /// Serialization needs to be replaced in Clerk.cs. Take as much logic out of the FORMS
        /// as possible.
        /// </summary>
        private void CheckPreconfig()
        {
            List<String> files = Directory.GetFiles(Application.ExecutablePath + "\\..", "*.ach").ToList<String>();
            if ( files.Count > 0 )
            {
                FileStream f = new FileStream((files.ToArray())[0], FileMode.OpenOrCreate, FileAccess.Read);
                _clerk = (Clerk)_binFormatter.Deserialize(f);
                f.Close();
            }
            else
            {
                String parent = Path.GetFullPath(Application.ExecutablePath + "\\..");
                _clerk = new Clerk(parent);
            }
        }

        /// <summary>
        /// TESTING FUNCTIONALITY OF FILE SYSTEM MANAGEMENT.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestLoad_Click(object sender, EventArgs e)
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
                try
                {
                    _clerk.LoadNativeChangeForms(dlgFolderBrowser.SelectedPath, true);
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
        }

        /// <summary>
        /// TESTING FUNCTIONALITY. Making sure that the user can specify
        /// to remember their choices and SAVE the PDF entries (native change forms) for
        /// next time use. The serialization needs to be moved within Clerk.cs, as the forms should
        /// contain as little logic as possible. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestPreConfig_Click(object sender, EventArgs e)
        {
            // IF OPTION IS CHOSEN TO SAVE
            FileStream f = new FileStream("clerk.ach", FileMode.Create, FileAccess.Write);
            _binFormatter.Serialize(f, _clerk);
            f.Close();
        }
    }
}
