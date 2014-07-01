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
            this.listPacketList = new System.Windows.Forms.ListBox();
            this.btnTestPacketDisplay = new System.Windows.Forms.Button();
            this.clerkNativeFormsCount = new System.Windows.Forms.TextBox();
            this.clerkDirectoryDisp = new System.Windows.Forms.TextBox();
            this.dispSplit = new System.Windows.Forms.Splitter();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.listSelectedList = new System.Windows.Forms.ListBox();
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
            // listPacketList
            // 
            this.listPacketList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listPacketList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPacketList.FormattingEnabled = true;
            this.listPacketList.ItemHeight = 20;
            this.listPacketList.Location = new System.Drawing.Point(0, 194);
            this.listPacketList.Name = "listPacketList";
            this.listPacketList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPacketList.Size = new System.Drawing.Size(550, 164);
            this.listPacketList.TabIndex = 3;
            this.listPacketList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listPacketList_DrawItem);
            this.listPacketList.SelectedIndexChanged += new System.EventHandler(this.listPacketList_SelectedIndexChanged);
            this.listPacketList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listPacketList_MouseClick);
            // 
            // btnTestPacketDisplay
            // 
            this.btnTestPacketDisplay.Location = new System.Drawing.Point(12, 70);
            this.btnTestPacketDisplay.Name = "btnTestPacketDisplay";
            this.btnTestPacketDisplay.Size = new System.Drawing.Size(184, 23);
            this.btnTestPacketDisplay.TabIndex = 4;
            this.btnTestPacketDisplay.Text = "TestDisplayPacketInfo";
            this.btnTestPacketDisplay.UseVisualStyleBackColor = true;
            this.btnTestPacketDisplay.Click += new System.EventHandler(this.btnTestPacketDisplay_Click);
            // 
            // clerkNativeFormsCount
            // 
            this.clerkNativeFormsCount.Location = new System.Drawing.Point(383, 15);
            this.clerkNativeFormsCount.Name = "clerkNativeFormsCount";
            this.clerkNativeFormsCount.Size = new System.Drawing.Size(155, 20);
            this.clerkNativeFormsCount.TabIndex = 5;
            // 
            // clerkDirectoryDisp
            // 
            this.clerkDirectoryDisp.Location = new System.Drawing.Point(211, 43);
            this.clerkDirectoryDisp.Name = "clerkDirectoryDisp";
            this.clerkDirectoryDisp.Size = new System.Drawing.Size(327, 20);
            this.clerkDirectoryDisp.TabIndex = 6;
            // 
            // dispSplit
            // 
            this.dispSplit.BackColor = System.Drawing.SystemColors.Control;
            this.dispSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dispSplit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.dispSplit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dispSplit.Location = new System.Drawing.Point(0, 189);
            this.dispSplit.Name = "dispSplit";
            this.dispSplit.Size = new System.Drawing.Size(550, 5);
            this.dispSplit.TabIndex = 7;
            this.dispSplit.TabStop = false;
            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Location = new System.Drawing.Point(12, 99);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(184, 23);
            this.btnAddSelected.TabIndex = 8;
            this.btnAddSelected.Text = "Test Add Selected";
            this.btnAddSelected.UseVisualStyleBackColor = true;
            this.btnAddSelected.Click += new System.EventHandler(this.btnAddSelected_Click);
            // 
            // listSelectedList
            // 
            this.listSelectedList.FormattingEnabled = true;
            this.listSelectedList.Location = new System.Drawing.Point(211, 73);
            this.listSelectedList.Name = "listSelectedList";
            this.listSelectedList.Size = new System.Drawing.Size(326, 108);
            this.listSelectedList.TabIndex = 9;
            // 
            // ClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 358);
            this.Controls.Add(this.listSelectedList);
            this.Controls.Add(this.btnAddSelected);
            this.Controls.Add(this.dispSplit);
            this.Controls.Add(this.clerkDirectoryDisp);
            this.Controls.Add(this.clerkNativeFormsCount);
            this.Controls.Add(this.btnTestPacketDisplay);
            this.Controls.Add(this.listPacketList);
            this.Controls.Add(this.btnTestChangeLoad);
            this.Controls.Add(this.btnTestLoad);
            this.Name = "ClerkForm";
            this.Text = "ACH Clerk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog dlgPrintDiag;
        private System.Windows.Forms.OpenFileDialog dlgOpenFileDiag;
        private System.Windows.Forms.Button btnTestLoad;
        private System.Windows.Forms.Button btnTestChangeLoad;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.ListBox listPacketList;
        private System.Windows.Forms.Button btnTestPacketDisplay;
        private System.Windows.Forms.TextBox clerkNativeFormsCount;
        private System.Windows.Forms.TextBox clerkDirectoryDisp;
        private System.Windows.Forms.Splitter dispSplit;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.ListBox listSelectedList;
    }
}

