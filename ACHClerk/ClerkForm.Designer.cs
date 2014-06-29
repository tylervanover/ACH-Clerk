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
            this.btnTestPreConfig = new System.Windows.Forms.Button();
            this.listPacketList = new System.Windows.Forms.ListBox();
            this.btnTestPacketDisplay = new System.Windows.Forms.Button();
            this.clerkNativeFormsCount = new System.Windows.Forms.TextBox();
            this.clerkDirectoryDisp = new System.Windows.Forms.TextBox();
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
            // btnTestPreConfig
            // 
            this.btnTestPreConfig.Location = new System.Drawing.Point(12, 70);
            this.btnTestPreConfig.Name = "btnTestPreConfig";
            this.btnTestPreConfig.Size = new System.Drawing.Size(184, 23);
            this.btnTestPreConfig.TabIndex = 2;
            this.btnTestPreConfig.Text = "Test PreConfig Mechanic";
            this.btnTestPreConfig.UseVisualStyleBackColor = true;
            this.btnTestPreConfig.Click += new System.EventHandler(this.btnTestPreConfig_Click);
            // 
            // listPacketList
            // 
            this.listPacketList.FormattingEnabled = true;
            this.listPacketList.Location = new System.Drawing.Point(12, 251);
            this.listPacketList.Name = "listPacketList";
            this.listPacketList.Size = new System.Drawing.Size(471, 95);
            this.listPacketList.TabIndex = 3;
            // 
            // btnTestPacketDisplay
            // 
            this.btnTestPacketDisplay.Location = new System.Drawing.Point(12, 99);
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
            this.clerkNativeFormsCount.Size = new System.Drawing.Size(100, 20);
            this.clerkNativeFormsCount.TabIndex = 5;
            // 
            // clerkDirectoryDisp
            // 
            this.clerkDirectoryDisp.Location = new System.Drawing.Point(211, 43);
            this.clerkDirectoryDisp.Name = "clerkDirectoryDisp";
            this.clerkDirectoryDisp.Size = new System.Drawing.Size(272, 20);
            this.clerkDirectoryDisp.TabIndex = 6;
            // 
            // ClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 358);
            this.Controls.Add(this.clerkDirectoryDisp);
            this.Controls.Add(this.clerkNativeFormsCount);
            this.Controls.Add(this.btnTestPacketDisplay);
            this.Controls.Add(this.listPacketList);
            this.Controls.Add(this.btnTestPreConfig);
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
        private System.Windows.Forms.Button btnTestPreConfig;
        private System.Windows.Forms.ListBox listPacketList;
        private System.Windows.Forms.Button btnTestPacketDisplay;
        private System.Windows.Forms.TextBox clerkNativeFormsCount;
        private System.Windows.Forms.TextBox clerkDirectoryDisp;
    }
}

