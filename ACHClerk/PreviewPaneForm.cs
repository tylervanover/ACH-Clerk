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
    public partial class PreviewPaneForm : Form
    {
        public PreviewPaneForm()
        {
            InitializeComponent();
        }

        private void PreviewPaneForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
