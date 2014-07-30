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
    public partial class InformationPane : Form
    {
        public String Customer { get; set; }

        public InformationPane()
        {
            InitializeComponent();
        }

        private String ParseName()
        {
            return this.txtCustomerName.Text; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Customer = ParseName();
        }
    }
}
