using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHClerk
{
    public class Clerk
    {
        /// <summary>
        /// Documents to be printed as the final ACH packet. PacketEntry
        /// is a custom class, which will be generated soon.
        /// </summary>
        private List<PacketEntry> PacketDocuments;

        /// <summary>
        /// Using PDFSharp library to manage PDF manipulation.
        /// </summary>
        private List<PdfDocument> NativeChangeForms;

        /// <summary>
        /// Default, public constructor. More to come.
        /// </summary>
        public Clerk()
        {
            throw new NotImplementedException();
        }
    }
}
