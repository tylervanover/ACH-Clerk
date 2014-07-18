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
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.listPacketList = new System.Windows.Forms.ListBox();
            this.listFinalList = new System.Windows.Forms.ListBox();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.lblNativeCountDisp = new System.Windows.Forms.Label();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.dlgSaveFileDiag = new System.Windows.Forms.SaveFileDialog();
            this.lblNativeDirectory = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            // listPacketList
            // 
            this.listPacketList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPacketList.FormattingEnabled = true;
            this.listPacketList.HorizontalScrollbar = true;
            this.listPacketList.ItemHeight = 16;
            this.listPacketList.Location = new System.Drawing.Point(16, 236);
            this.listPacketList.Name = "listPacketList";
            this.listPacketList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPacketList.Size = new System.Drawing.Size(344, 212);
            this.listPacketList.TabIndex = 3;
            this.listPacketList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listPacketList_DrawItem);
            this.listPacketList.SelectedIndexChanged += new System.EventHandler(this.listPacketList_SelectedIndexChanged);
            this.listPacketList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listPacketList_MouseClick);
            // 
            // listFinalList
            // 
            this.listFinalList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFinalList.FormattingEnabled = true;
            this.listFinalList.HorizontalScrollbar = true;
            this.listFinalList.ItemHeight = 16;
            this.listFinalList.Location = new System.Drawing.Point(376, 236);
            this.listFinalList.Name = "listFinalList";
            this.listFinalList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listFinalList.Size = new System.Drawing.Size(344, 212);
            this.listFinalList.TabIndex = 9;
            this.listFinalList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listSelectedList_DrawItem);
            this.listFinalList.SelectedIndexChanged += new System.EventHandler(this.listSelectedList_SelectedIndexChanged);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Location = new System.Drawing.Point(373, 216);
            this.lblSelectedCount.MinimumSize = new System.Drawing.Size(15, 10);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(15, 13);
            this.lblSelectedCount.TabIndex = 12;
            // 
            // lblNativeCountDisp
            // 
            this.lblNativeCountDisp.AutoSize = true;
            this.lblNativeCountDisp.Location = new System.Drawing.Point(13, 216);
            this.lblNativeCountDisp.MinimumSize = new System.Drawing.Size(15, 10);
            this.lblNativeCountDisp.Name = "lblNativeCountDisp";
            this.lblNativeCountDisp.Size = new System.Drawing.Size(15, 13);
            this.lblNativeCountDisp.TabIndex = 13;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtSearchBar.Location = new System.Drawing.Point(376, 158);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(274, 20);
            this.txtSearchBar.TabIndex = 16;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // lblNativeDirectory
            // 
            this.lblNativeDirectory.AutoSize = true;
            this.lblNativeDirectory.Location = new System.Drawing.Point(13, 161);
            this.lblNativeDirectory.MinimumSize = new System.Drawing.Size(15, 10);
            this.lblNativeDirectory.Name = "lblNativeDirectory";
            this.lblNativeDirectory.Size = new System.Drawing.Size(15, 13);
            this.lblNativeDirectory.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 478);
            this.Controls.Add(this.lblNativeDirectory);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.lblNativeCountDisp);
            this.Controls.Add(this.lblSelectedCount);
            this.Controls.Add(this.listFinalList);
            this.Controls.Add(this.listPacketList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClerkForm";
            this.Text = "ACH Clerk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog dlgPrintDiag;
        private System.Windows.Forms.OpenFileDialog dlgOpenFileDiag;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.ListBox listPacketList;
        private System.Windows.Forms.ListBox listFinalList;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label lblNativeCountDisp;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.SaveFileDialog dlgSaveFileDiag;
        private System.Windows.Forms.Label lblNativeDirectory;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

