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
    public partial class ClerkForm : Form
    {
        private SearchForm fSearchDialog;
        private PdfViewer pdfEmbedPane;
        private Clerk _clerk;
        private TableCreatorForm fTableCreator;

        //Form also has an open file dialog, called dlgOpenFileDiag
        //Form also has a print dialog, called dlgPrintDiag

        public ClerkForm()
        {
            InitializeComponent();
        }

    }
}
