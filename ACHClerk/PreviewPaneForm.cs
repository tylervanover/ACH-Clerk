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
        private PacketEntry _entry;

        /// <summary>
        /// Public, default constructor.
        /// </summary>
        public PreviewPaneForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Non-default public constructor. Accepts a PdfDocument, which will then be
        /// used to render a preview of the doc for the user. Dock to the right side.
        /// </summary>
        /// <param name="doc"></param>
        public PreviewPaneForm(ref PacketEntry doc)
            : this()
        {
            this._entry = doc;
            DockToRightSide();
        }
        
        /// <summary>
        /// On form load, display the name of the PDF doc. This is to make sure that
        /// the list box was indexed properly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewPaneForm_Load(object sender, EventArgs e)
        {
            this.Text = this._entry.NativeDoc.Info.Title;
            RenderPDFandPanel();
        }

        /// <summary>
        /// Render the PDF to the preview pane, using the ActiveX COM control.
        /// Set the preview pane size to match the height of the parent pane,
        /// and then snap this panel to the right side of the parent pane (by default).
        /// </summary>
        private void RenderPDFandPanel()
        {
            axAdobePane.LoadFile(this._entry.FullPath);
        }

        private void DockToRightSide()
        {
            this.DesktopLocation = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
        }
    }
}
