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
            this.btnTestChangeLoad = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.listPacketList = new System.Windows.Forms.ListBox();
            this.clerkNativeFormsCount = new System.Windows.Forms.TextBox();
            this.clerkDirectoryDisp = new System.Windows.Forms.TextBox();
            this.dispSplit = new System.Windows.Forms.Splitter();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.listFinalList = new System.Windows.Forms.ListBox();
            this.txtSelectedEntriesCount = new System.Windows.Forms.TextBox();
            this.lblNativeCount = new System.Windows.Forms.Label();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.lblNativeCountDisp = new System.Windows.Forms.Label();
            this.btnTestRmvSelected = new System.Windows.Forms.Button();
            this.btnTestRmvAllFinal = new System.Windows.Forms.Button();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
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
            // btnTestChangeLoad
            // 
            this.btnTestChangeLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestChangeLoad.Location = new System.Drawing.Point(12, 15);
            this.btnTestChangeLoad.Name = "btnTestChangeLoad";
            this.btnTestChangeLoad.Size = new System.Drawing.Size(184, 23);
            this.btnTestChangeLoad.TabIndex = 1;
            this.btnTestChangeLoad.Text = "Test Change Directory Load";
            this.btnTestChangeLoad.UseVisualStyleBackColor = true;
            this.btnTestChangeLoad.Click += new System.EventHandler(this.btnTestChangeLoad_Click);
            // 
            // listPacketList
            // 
            this.listPacketList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listPacketList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPacketList.FormattingEnabled = true;
            this.listPacketList.ItemHeight = 20;
            this.listPacketList.Location = new System.Drawing.Point(0, 236);
            this.listPacketList.Name = "listPacketList";
            this.listPacketList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPacketList.Size = new System.Drawing.Size(763, 224);
            this.listPacketList.TabIndex = 3;
            this.listPacketList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listPacketList_DrawItem);
            this.listPacketList.SelectedIndexChanged += new System.EventHandler(this.listPacketList_SelectedIndexChanged);
            this.listPacketList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listPacketList_MouseClick);
            // 
            // clerkNativeFormsCount
            // 
            this.clerkNativeFormsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clerkNativeFormsCount.Location = new System.Drawing.Point(497, 17);
            this.clerkNativeFormsCount.Name = "clerkNativeFormsCount";
            this.clerkNativeFormsCount.Size = new System.Drawing.Size(56, 20);
            this.clerkNativeFormsCount.TabIndex = 5;
            // 
            // clerkDirectoryDisp
            // 
            this.clerkDirectoryDisp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clerkDirectoryDisp.Location = new System.Drawing.Point(386, 46);
            this.clerkDirectoryDisp.Name = "clerkDirectoryDisp";
            this.clerkDirectoryDisp.Size = new System.Drawing.Size(365, 20);
            this.clerkDirectoryDisp.TabIndex = 6;
            // 
            // dispSplit
            // 
            this.dispSplit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.dispSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dispSplit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.dispSplit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dispSplit.Location = new System.Drawing.Point(0, 228);
            this.dispSplit.Name = "dispSplit";
            this.dispSplit.Size = new System.Drawing.Size(763, 8);
            this.dispSplit.TabIndex = 7;
            this.dispSplit.TabStop = false;
            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSelected.Location = new System.Drawing.Point(11, 44);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(184, 23);
            this.btnAddSelected.TabIndex = 8;
            this.btnAddSelected.Text = "Test Add Selected";
            this.btnAddSelected.UseVisualStyleBackColor = true;
            this.btnAddSelected.Click += new System.EventHandler(this.btnAddSelected_Click);
            // 
            // listFinalList
            // 
            this.listFinalList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listFinalList.FormattingEnabled = true;
            this.listFinalList.Location = new System.Drawing.Point(386, 76);
            this.listFinalList.Name = "listFinalList";
            this.listFinalList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listFinalList.Size = new System.Drawing.Size(365, 108);
            this.listFinalList.TabIndex = 9;
            this.listFinalList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listSelectedList_DrawItem);
            this.listFinalList.SelectedIndexChanged += new System.EventHandler(this.listSelectedList_SelectedIndexChanged);
            // 
            // txtSelectedEntriesCount
            // 
            this.txtSelectedEntriesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedEntriesCount.Location = new System.Drawing.Point(688, 17);
            this.txtSelectedEntriesCount.Name = "txtSelectedEntriesCount";
            this.txtSelectedEntriesCount.Size = new System.Drawing.Size(63, 20);
            this.txtSelectedEntriesCount.TabIndex = 10;
            // 
            // lblNativeCount
            // 
            this.lblNativeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNativeCount.AutoSize = true;
            this.lblNativeCount.Location = new System.Drawing.Point(383, 20);
            this.lblNativeCount.Name = "lblNativeCount";
            this.lblNativeCount.Size = new System.Drawing.Size(108, 13);
            this.lblNativeCount.TabIndex = 11;
            this.lblNativeCount.Tag = "";
            this.lblNativeCount.Text = "Native Forms count =";
            this.lblNativeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Location = new System.Drawing.Point(559, 20);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(123, 13);
            this.lblSelectedCount.TabIndex = 12;
            this.lblSelectedCount.Text = "Selected Entries count =";
            // 
            // lblNativeCountDisp
            // 
            this.lblNativeCountDisp.AutoSize = true;
            this.lblNativeCountDisp.Location = new System.Drawing.Point(4, 211);
            this.lblNativeCountDisp.MinimumSize = new System.Drawing.Size(15, 10);
            this.lblNativeCountDisp.Name = "lblNativeCountDisp";
            this.lblNativeCountDisp.Size = new System.Drawing.Size(15, 13);
            this.lblNativeCountDisp.TabIndex = 13;
            // 
            // btnTestRmvSelected
            // 
            this.btnTestRmvSelected.Location = new System.Drawing.Point(11, 76);
            this.btnTestRmvSelected.Name = "btnTestRmvSelected";
            this.btnTestRmvSelected.Size = new System.Drawing.Size(185, 23);
            this.btnTestRmvSelected.TabIndex = 14;
            this.btnTestRmvSelected.Text = "Test Remove Selected";
            this.btnTestRmvSelected.UseVisualStyleBackColor = true;
            this.btnTestRmvSelected.Click += new System.EventHandler(this.btnTestRmvSelected_Click);
            // 
            // btnTestRmvAllFinal
            // 
            this.btnTestRmvAllFinal.Location = new System.Drawing.Point(12, 106);
            this.btnTestRmvAllFinal.Name = "btnTestRmvAllFinal";
            this.btnTestRmvAllFinal.Size = new System.Drawing.Size(183, 23);
            this.btnTestRmvAllFinal.TabIndex = 15;
            this.btnTestRmvAllFinal.Text = "Test Remove All Final";
            this.btnTestRmvAllFinal.UseVisualStyleBackColor = true;
            this.btnTestRmvAllFinal.Click += new System.EventHandler(this.btnTestRmvAllFinal_Click);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtSearchBar.Location = new System.Drawing.Point(12, 163);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(274, 20);
            this.txtSearchBar.TabIndex = 16;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // ClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 460);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.btnTestRmvAllFinal);
            this.Controls.Add(this.btnTestRmvSelected);
            this.Controls.Add(this.lblNativeCountDisp);
            this.Controls.Add(this.lblSelectedCount);
            this.Controls.Add(this.lblNativeCount);
            this.Controls.Add(this.txtSelectedEntriesCount);
            this.Controls.Add(this.listFinalList);
            this.Controls.Add(this.btnAddSelected);
            this.Controls.Add(this.dispSplit);
            this.Controls.Add(this.clerkDirectoryDisp);
            this.Controls.Add(this.clerkNativeFormsCount);
            this.Controls.Add(this.listPacketList);
            this.Controls.Add(this.btnTestChangeLoad);
            this.Name = "ClerkForm";
            this.Text = "ACH Clerk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog dlgPrintDiag;
        private System.Windows.Forms.OpenFileDialog dlgOpenFileDiag;
        private System.Windows.Forms.Button btnTestChangeLoad;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.ListBox listPacketList;
        private System.Windows.Forms.TextBox clerkNativeFormsCount;
        private System.Windows.Forms.TextBox clerkDirectoryDisp;
        private System.Windows.Forms.Splitter dispSplit;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.ListBox listFinalList;
        private System.Windows.Forms.TextBox txtSelectedEntriesCount;
        private System.Windows.Forms.Label lblNativeCount;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label lblNativeCountDisp;
        private System.Windows.Forms.Button btnTestRmvSelected;
        private System.Windows.Forms.Button btnTestRmvAllFinal;
        private System.Windows.Forms.TextBox txtSearchBar;
    }
}

