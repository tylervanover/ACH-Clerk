using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ACHClerk
{
    public partial class AboutPane : Form
    {
        private StringBuilder _strBuilder;

        public AboutPane()
        {
            InitializeComponent();
            _strBuilder = new StringBuilder();
        }

        /// <summary>
        /// On form load, display the licensing information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutPane_Load(object sender, EventArgs e)
        {
            LicenseLabel.Text = ReadLicense();
        }

        /// <summary>
        /// Read in the license, and then send it to string to be displayed.
        /// </summary>
        /// <returns></returns>
        private string ReadLicense()
        {
            using (TextReader tr = new StreamReader("LICENSE.MD"))
            {
                string line;
                while ((line = tr.ReadLine()) != null)
                    _strBuilder.AppendLine(line);
            }

            return _strBuilder.ToString();
        }
    }
}
