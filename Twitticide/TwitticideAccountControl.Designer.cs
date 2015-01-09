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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFollowingCount = new System.Windows.Forms.Label();
            this.lblFollowersCount = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShowFollowers = new System.Windows.Forms.Button();
            this.btnShowWhoYouFollow = new System.Windows.Forms.Button();
            this.btnShowNotFollowedBy = new System.Windows.Forms.Button();
            this.btnShowNotFollowing = new System.Windows.Forms.Button();
            this.btnShowUnfollowedBy = new System.Windows.Forms.Button();
            this.btnShowYouUnfollowed = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblLastUpdated);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblFollowingCount);
            this.panel1.Controls.Add(this.lblFollowersCount);
            this.panel1.Controls.Add(this.picAvatar);
            this.panel1.Controls.Add(this.lblDisplayName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 98);
            this.panel1.TabIndex = 0;
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
            this.picAvatar.Location = new System.Drawing.Point(622, 7);
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(538, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(53, 49);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnShowYouUnfollowed);
            this.panel2.Controls.Add(this.btnShowUnfollowedBy);
            this.panel2.Controls.Add(this.btnShowNotFollowing);
            this.panel2.Controls.Add(this.btnShowNotFollowedBy);
            this.panel2.Controls.Add(this.btnShowWhoYouFollow);
            this.panel2.Controls.Add(this.btnShowFollowers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 362);
            this.panel2.TabIndex = 1;
            // 
            // btnShowFollowers
            // 
            this.btnShowFollowers.Location = new System.Drawing.Point(6, 6);
            this.btnShowFollowers.Name = "btnShowFollowers";
            this.btnShowFollowers.Size = new System.Drawing.Size(158, 52);
            this.btnShowFollowers.TabIndex = 0;
            this.btnShowFollowers.Text = "Followers";
            this.btnShowFollowers.UseVisualStyleBackColor = true;
            // 
            // btnShowWhoYouFollow
            // 
            this.btnShowWhoYouFollow.Location = new System.Drawing.Point(9, 64);
            this.btnShowWhoYouFollow.Name = "btnShowWhoYouFollow";
            this.btnShowWhoYouFollow.Size = new System.Drawing.Size(158, 52);
            this.btnShowWhoYouFollow.TabIndex = 1;
            this.btnShowWhoYouFollow.Text = "Who You Follow";
            this.btnShowWhoYouFollow.UseVisualStyleBackColor = true;
            // 
            // btnShowNotFollowedBy
            // 
            this.btnShowNotFollowedBy.Location = new System.Drawing.Point(6, 122);
            this.btnShowNotFollowedBy.Name = "btnShowNotFollowedBy";
            this.btnShowNotFollowedBy.Size = new System.Drawing.Size(158, 52);
            this.btnShowNotFollowedBy.TabIndex = 2;
            this.btnShowNotFollowedBy.Text = "Who You Follow (but aren\'t followed by)";
            this.btnShowNotFollowedBy.UseVisualStyleBackColor = true;
            // 
            // btnShowNotFollowing
            // 
            this.btnShowNotFollowing.Location = new System.Drawing.Point(10, 180);
            this.btnShowNotFollowing.Name = "btnShowNotFollowing";
            this.btnShowNotFollowing.Size = new System.Drawing.Size(158, 52);
            this.btnShowNotFollowing.TabIndex = 3;
            this.btnShowNotFollowing.Text = "Who Follows You (but you are not following)";
            this.btnShowNotFollowing.UseVisualStyleBackColor = true;
            // 
            // btnShowUnfollowedBy
            // 
            this.btnShowUnfollowedBy.Location = new System.Drawing.Point(6, 238);
            this.btnShowUnfollowedBy.Name = "btnShowUnfollowedBy";
            this.btnShowUnfollowedBy.Size = new System.Drawing.Size(158, 52);
            this.btnShowUnfollowedBy.TabIndex = 4;
            this.btnShowUnfollowedBy.Text = "Who Unfollowed You";
            this.btnShowUnfollowedBy.UseVisualStyleBackColor = true;
            // 
            // btnShowYouUnfollowed
            // 
            this.btnShowYouUnfollowed.Location = new System.Drawing.Point(9, 296);
            this.btnShowYouUnfollowed.Name = "btnShowYouUnfollowed";
            this.btnShowYouUnfollowed.Size = new System.Drawing.Size(158, 52);
            this.btnShowYouUnfollowed.TabIndex = 5;
            this.btnShowYouUnfollowed.Text = "Who You Unfollowed";
            this.btnShowYouUnfollowed.UseVisualStyleBackColor = true;
            // 
            // TwitticideAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TwitticideAccountControl";
            this.Size = new System.Drawing.Size(695, 460);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowYouUnfollowed;
        private System.Windows.Forms.Button btnShowUnfollowedBy;
        private System.Windows.Forms.Button btnShowNotFollowing;
        private System.Windows.Forms.Button btnShowNotFollowedBy;
        private System.Windows.Forms.Button btnShowWhoYouFollow;
        private System.Windows.Forms.Button btnShowFollowers;
    }
}
