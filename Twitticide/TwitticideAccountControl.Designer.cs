namespace Twitticide
{
    partial class TwitticideAccountControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFollowingCount = new System.Windows.Forms.Label();
            this.lblFollowersCount = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShowYouNewlyFollowing = new System.Windows.Forms.Button();
            this.btnShowNewFollowers = new System.Windows.Forms.Button();
            this.btnShowYouUnfollowed = new System.Windows.Forms.Button();
            this.btnShowUnfollowedBy = new System.Windows.Forms.Button();
            this.btnShowNotFollowing = new System.Windows.Forms.Button();
            this.btnShowNotFollowedBy = new System.Windows.Forms.Button();
            this.btnShowWhoYouFollow = new System.Windows.Forms.Button();
            this.btnShowFollowers = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateContactProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyGetMissingProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetNewEventCutoff = new System.Windows.Forms.ToolStripMenuItem();
            this.profileListbox = new Twitticide.TwitterProfileListbox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblLastUpdated);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblFollowingCount);
            this.panel1.Controls.Add(this.lblFollowersCount);
            this.panel1.Controls.Add(this.picAvatar);
            this.panel1.Controls.Add(this.lblDisplayName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 98);
            this.panel1.TabIndex = 0;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Location = new System.Drawing.Point(239, 78);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(72, 13);
            this.lblLastUpdated.TabIndex = 8;
            this.lblLastUpdated.Text = "{lastUpdated}";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Following";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Followers";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFollowingCount
            // 
            this.lblFollowingCount.BackColor = System.Drawing.Color.Lavender;
            this.lblFollowingCount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFollowingCount.Location = new System.Drawing.Point(370, 25);
            this.lblFollowingCount.Name = "lblFollowingCount";
            this.lblFollowingCount.Size = new System.Drawing.Size(126, 45);
            this.lblFollowingCount.TabIndex = 4;
            this.lblFollowingCount.Text = "{displayName}";
            this.lblFollowingCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFollowersCount
            // 
            this.lblFollowersCount.BackColor = System.Drawing.Color.Lavender;
            this.lblFollowersCount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFollowersCount.Location = new System.Drawing.Point(238, 25);
            this.lblFollowersCount.Name = "lblFollowersCount";
            this.lblFollowersCount.Size = new System.Drawing.Size(126, 45);
            this.lblFollowersCount.TabIndex = 3;
            this.lblFollowersCount.Text = "{displayName}";
            this.lblFollowersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAvatar.BackColor = System.Drawing.Color.Yellow;
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picAvatar.Location = new System.Drawing.Point(777, 7);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(64, 64);
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(37, 41);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(160, 29);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "{displayName}";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(3, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(214, 41);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "{UserName}";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnShowYouNewlyFollowing);
            this.panel2.Controls.Add(this.btnShowNewFollowers);
            this.panel2.Controls.Add(this.btnShowYouUnfollowed);
            this.panel2.Controls.Add(this.btnShowUnfollowedBy);
            this.panel2.Controls.Add(this.btnShowNotFollowing);
            this.panel2.Controls.Add(this.btnShowNotFollowedBy);
            this.panel2.Controls.Add(this.btnShowWhoYouFollow);
            this.panel2.Controls.Add(this.btnShowFollowers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 338);
            this.panel2.TabIndex = 1;
            // 
            // btnShowYouNewlyFollowing
            // 
            this.btnShowYouNewlyFollowing.Location = new System.Drawing.Point(6, 328);
            this.btnShowYouNewlyFollowing.Name = "btnShowYouNewlyFollowing";
            this.btnShowYouNewlyFollowing.Size = new System.Drawing.Size(158, 40);
            this.btnShowYouNewlyFollowing.TabIndex = 7;
            this.btnShowYouNewlyFollowing.Text = "You Newly Followed";
            this.btnShowYouNewlyFollowing.UseVisualStyleBackColor = true;
            this.btnShowYouNewlyFollowing.Click += new System.EventHandler(this.btnShowYouNewlyFollowing_Click);
            // 
            // btnShowNewFollowers
            // 
            this.btnShowNewFollowers.Location = new System.Drawing.Point(6, 282);
            this.btnShowNewFollowers.Name = "btnShowNewFollowers";
            this.btnShowNewFollowers.Size = new System.Drawing.Size(158, 40);
            this.btnShowNewFollowers.TabIndex = 6;
            this.btnShowNewFollowers.Text = "Your New Followers";
            this.btnShowNewFollowers.UseVisualStyleBackColor = true;
            this.btnShowNewFollowers.Click += new System.EventHandler(this.btnShowNewFollowers_Click);
            // 
            // btnShowYouUnfollowed
            // 
            this.btnShowYouUnfollowed.Location = new System.Drawing.Point(6, 236);
            this.btnShowYouUnfollowed.Name = "btnShowYouUnfollowed";
            this.btnShowYouUnfollowed.Size = new System.Drawing.Size(158, 40);
            this.btnShowYouUnfollowed.TabIndex = 5;
            this.btnShowYouUnfollowed.Text = "Who You Unfollowed";
            this.btnShowYouUnfollowed.UseVisualStyleBackColor = true;
            this.btnShowYouUnfollowed.Click += new System.EventHandler(this.btnShowYouUnfollowed_Click);
            // 
            // btnShowUnfollowedBy
            // 
            this.btnShowUnfollowedBy.Location = new System.Drawing.Point(6, 190);
            this.btnShowUnfollowedBy.Name = "btnShowUnfollowedBy";
            this.btnShowUnfollowedBy.Size = new System.Drawing.Size(158, 40);
            this.btnShowUnfollowedBy.TabIndex = 4;
            this.btnShowUnfollowedBy.Text = "Who Unfollowed You";
            this.btnShowUnfollowedBy.UseVisualStyleBackColor = true;
            this.btnShowUnfollowedBy.Click += new System.EventHandler(this.btnShowUnfollowedBy_Click);
            // 
            // btnShowNotFollowing
            // 
            this.btnShowNotFollowing.Location = new System.Drawing.Point(6, 144);
            this.btnShowNotFollowing.Name = "btnShowNotFollowing";
            this.btnShowNotFollowing.Size = new System.Drawing.Size(158, 40);
            this.btnShowNotFollowing.TabIndex = 3;
            this.btnShowNotFollowing.Text = "Who Follows You (but you are not following)";
            this.btnShowNotFollowing.UseVisualStyleBackColor = true;
            this.btnShowNotFollowing.Click += new System.EventHandler(this.btnShowNotFollowing_Click);
            // 
            // btnShowNotFollowedBy
            // 
            this.btnShowNotFollowedBy.Location = new System.Drawing.Point(6, 98);
            this.btnShowNotFollowedBy.Name = "btnShowNotFollowedBy";
            this.btnShowNotFollowedBy.Size = new System.Drawing.Size(158, 40);
            this.btnShowNotFollowedBy.TabIndex = 2;
            this.btnShowNotFollowedBy.Text = "Who You Follow (but aren\'t followed by)";
            this.btnShowNotFollowedBy.UseVisualStyleBackColor = true;
            this.btnShowNotFollowedBy.Click += new System.EventHandler(this.btnShowNotFollowedBy_Click);
            // 
            // btnShowWhoYouFollow
            // 
            this.btnShowWhoYouFollow.Location = new System.Drawing.Point(6, 52);
            this.btnShowWhoYouFollow.Name = "btnShowWhoYouFollow";
            this.btnShowWhoYouFollow.Size = new System.Drawing.Size(158, 40);
            this.btnShowWhoYouFollow.TabIndex = 1;
            this.btnShowWhoYouFollow.Text = "Who You Follow";
            this.btnShowWhoYouFollow.UseVisualStyleBackColor = true;
            this.btnShowWhoYouFollow.Click += new System.EventHandler(this.btnShowWhoYouFollow_Click);
            // 
            // btnShowFollowers
            // 
            this.btnShowFollowers.Location = new System.Drawing.Point(6, 6);
            this.btnShowFollowers.Name = "btnShowFollowers";
            this.btnShowFollowers.Size = new System.Drawing.Size(158, 40);
            this.btnShowFollowers.TabIndex = 0;
            this.btnShowFollowers.Text = "Followers";
            this.btnShowFollowers.UseVisualStyleBackColor = true;
            this.btnShowFollowers.Click += new System.EventHandler(this.btnShowFollowers_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.updateContactProfilesToolStripMenuItem,
            this.btnResetNewEventCutoff});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // updateContactProfilesToolStripMenuItem
            // 
            this.updateContactProfilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.onlyGetMissingProfilesToolStripMenuItem});
            this.updateContactProfilesToolStripMenuItem.Name = "updateContactProfilesToolStripMenuItem";
            this.updateContactProfilesToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.updateContactProfilesToolStripMenuItem.Text = "Update contact profiles";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // onlyGetMissingProfilesToolStripMenuItem
            // 
            this.onlyGetMissingProfilesToolStripMenuItem.Name = "onlyGetMissingProfilesToolStripMenuItem";
            this.onlyGetMissingProfilesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.onlyGetMissingProfilesToolStripMenuItem.Text = "Only get missing profiles";
            this.onlyGetMissingProfilesToolStripMenuItem.Click += new System.EventHandler(this.onlyGetMissingProfilesToolStripMenuItem_Click);
            // 
            // btnResetNewEventCutoff
            // 
            this.btnResetNewEventCutoff.Name = "btnResetNewEventCutoff";
            this.btnResetNewEventCutoff.Size = new System.Drawing.Size(130, 20);
            this.btnResetNewEventCutoff.Text = "Reset new event cutoff";
            this.btnResetNewEventCutoff.Click += new System.EventHandler(this.btnResetTimeCutoff_Click);
            // 
            // profileListbox
            // 
            this.profileListbox.DisplayMode = Twitticide.TwitterProfileListbox.DisplayModes.Minimal;
            this.profileListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileListbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.profileListbox.FormattingEnabled = true;
            this.profileListbox.ItemHeight = 24;
            this.profileListbox.Location = new System.Drawing.Point(167, 122);
            this.profileListbox.Name = "profileListbox";
            this.profileListbox.Size = new System.Drawing.Size(683, 222);
            this.profileListbox.TabIndex = 4;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLog.Location = new System.Drawing.Point(167, 344);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(683, 116);
            this.txtLog.TabIndex = 5;
            // 
            // TwitticideAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.profileListbox);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "TwitticideAccountControl";
            this.Size = new System.Drawing.Size(850, 460);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFollowingCount;
        private System.Windows.Forms.Label lblFollowersCount;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowYouUnfollowed;
        private System.Windows.Forms.Button btnShowUnfollowedBy;
        private System.Windows.Forms.Button btnShowNotFollowing;
        private System.Windows.Forms.Button btnShowNotFollowedBy;
        private System.Windows.Forms.Button btnShowWhoYouFollow;
        private System.Windows.Forms.Button btnShowFollowers;
        private System.Windows.Forms.Button btnShowYouNewlyFollowing;
        private System.Windows.Forms.Button btnShowNewFollowers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateContactProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyGetMissingProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnResetNewEventCutoff;
        private TwitterProfileListbox profileListbox;
        private System.Windows.Forms.TextBox txtLog;
    }
}
