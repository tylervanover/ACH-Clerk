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
            this.btnTestLoad = new System.Windows.Forms.Button();
            this.btnTestChangeLoad = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // dlgPrintDiag
            // 
            this.dlgPrintDiag.UseEXDialog = true;
            // 
            // dlgOpenFileDiag
            // 
            this.dlgOpenFileDiag.FileName = "some folder";
            // 
            // btnTestLoad
            // 
            this.btnTestLoad.Location = new System.Drawing.Point(12, 12);
            this.btnTestLoad.Name = "btnTestLoad";
            this.btnTestLoad.Size = new System.Drawing.Size(184, 23);
            this.btnTestLoad.TabIndex = 0;
            this.btnTestLoad.Text = "Test Basic Load";
            this.btnTestLoad.UseVisualStyleBackColor = true;
            this.btnTestLoad.Click += new System.EventHandler(this.btnTestLoad_Click);
            // 
            // btnTestChangeLoad
            // 
            this.btnTestChangeLoad.Location = new System.Drawing.Point(12, 41);
            this.btnTestChangeLoad.Name = "btnTestChangeLoad";
            this.btnTestChangeLoad.Size = new System.Drawing.Size(184, 23);
            this.btnTestChangeLoad.TabIndex = 1;
            this.btnTestChangeLoad.Text = "Test Change Directory Load";
            this.btnTestChangeLoad.UseVisualStyleBackColor = true;
            this.btnTestChangeLoad.Click += new System.EventHandler(this.btnTestChangeLoad_Click);
            // 
            // ClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 358);
            this.Controls.Add(this.btnTestChangeLoad);
            this.Controls.Add(this.btnTestLoad);
            this.Name = "ClerkForm";
            this.Text = "ACH Clerk";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog dlgPrintDiag;
        private System.Windows.Forms.OpenFileDialog dlgOpenFileDiag;
        private System.Windows.Forms.Button btnTestLoad;
        private System.Windows.Forms.Button btnTestChangeLoad;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
    }
}

