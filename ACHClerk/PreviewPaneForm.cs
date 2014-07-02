using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PdfSharp.Pdf;
using PdfSharp.Drawing.Pdf;
using MigraDoc.Rendering;

namespace ACHClerk
{
    public partial class PreviewPaneForm : Form
    {
        /// <summary>
        /// The PdfDocument to display on this form.
        /// </summary>
        private PdfDocument _pdf;

        /// <summary>
        /// Public, default constructor.
        /// </summary>
        public PreviewPaneForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Non-default public constructor. Accepts a PdfDocument, which will then be
        /// used to render a preview of the doc for the user.
        /// </summary>
        /// <param name="doc"></param>
        public PreviewPaneForm(ref PdfDocument doc)
            : this()
        {
            this._pdf = doc;
        }

        /// <summary>
        /// On any mouse button, close this form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewPaneForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// On form load, display the name of the PDF doc. This is to make sure that
        /// the list box was indexed properly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewPaneForm_Load(object sender, EventArgs e)
        {
            this.Text = this._pdf.Info.Title;
        }
    }
}
