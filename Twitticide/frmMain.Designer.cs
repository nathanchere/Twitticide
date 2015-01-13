namespace Twitticide
{
    partial class frmMain
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
            this.accountTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnManageAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.setDataDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountTabs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountTabs
            // 
            this.accountTabs.Controls.Add(this.tabPage1);
            this.accountTabs.Controls.Add(this.tabPage2);
            this.accountTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountTabs.Location = new System.Drawing.Point(0, 24);
            this.accountTabs.Name = "accountTabs";
            this.accountTabs.SelectedIndex = 0;
            this.accountTabs.Size = new System.Drawing.Size(1055, 587);
            this.accountTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1047, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1047, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManageAccounts,
            this.setDataDirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnManageAccounts
            // 
            this.btnManageAccounts.Name = "btnManageAccounts";
            this.btnManageAccounts.Size = new System.Drawing.Size(115, 20);
            this.btnManageAccounts.Text = "Manage Accounts";
            this.btnManageAccounts.Click += new System.EventHandler(this.btnManageAccounts_Click);
            // 
            // setDataDirToolStripMenuItem
            // 
            this.setDataDirToolStripMenuItem.Name = "setDataDirToolStripMenuItem";
            this.setDataDirToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.setDataDirToolStripMenuItem.Text = "Set data dir";
            this.setDataDirToolStripMenuItem.Click += new System.EventHandler(this.setDataDirToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 611);
            this.Controls.Add(this.accountTabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Twitticide - (c)2015 Nathan Chere";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.accountTabs.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion       

        private System.Windows.Forms.TabControl accountTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnManageAccounts;
        private System.Windows.Forms.ToolStripMenuItem setDataDirToolStripMenuItem;
    }
}

