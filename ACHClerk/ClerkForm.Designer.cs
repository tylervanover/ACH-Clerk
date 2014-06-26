namespace ACHClerk
{
    partial class ClerkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlgPrintDiag = new System.Windows.Forms.PrintDialog();
            this.dlgOpenFileDiag = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // dlgPrintDiag
            // 
            this.dlgPrintDiag.UseEXDialog = true;
            // 
            // dlgOpenFileDiag
            // 
            this.dlgOpenFileDiag.FileName = "openFileDialog1";
            // 
            // ClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ClerkForm";
            this.Text = "ACH Clerk";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog dlgPrintDiag;
        private System.Windows.Forms.OpenFileDialog dlgOpenFileDiag;
    }
}

