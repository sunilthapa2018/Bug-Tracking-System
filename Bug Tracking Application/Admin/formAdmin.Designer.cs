﻿namespace Bug_Tracking_Application.Admin
{
    partial class formAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAdmin));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointBugsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugAppointedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugsReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.userDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.repoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(60, 17);
            this.lblWelcome.Text = "Welcome!";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.repoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.Image")));
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("signOutToolStripMenuItem.Image")));
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.appointBugsToolStripMenuItem,
            this.projectsToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.usersToolStripMenuItem.Text = "Other Admin";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // appointBugsToolStripMenuItem
            // 
            this.appointBugsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("appointBugsToolStripMenuItem.Image")));
            this.appointBugsToolStripMenuItem.Name = "appointBugsToolStripMenuItem";
            this.appointBugsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.appointBugsToolStripMenuItem.Text = "Bug Appointment";
            this.appointBugsToolStripMenuItem.Click += new System.EventHandler(this.appointBugsToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("projectsToolStripMenuItem.Image")));
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.projectsToolStripMenuItem.Text = "Project Names";
            this.projectsToolStripMenuItem.Click += new System.EventHandler(this.projectsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bugHistoryToolStripMenuItem,
            this.bugAppointedToolStripMenuItem,
            this.projectsToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // bugHistoryToolStripMenuItem
            // 
            this.bugHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bugHistoryToolStripMenuItem.Image")));
            this.bugHistoryToolStripMenuItem.Name = "bugHistoryToolStripMenuItem";
            this.bugHistoryToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bugHistoryToolStripMenuItem.Text = "Bug Audit History";
            this.bugHistoryToolStripMenuItem.Click += new System.EventHandler(this.bugHistoryToolStripMenuItem_Click);
            // 
            // bugAppointedToolStripMenuItem
            // 
            this.bugAppointedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bugAppointedToolStripMenuItem.Image")));
            this.bugAppointedToolStripMenuItem.Name = "bugAppointedToolStripMenuItem";
            this.bugAppointedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bugAppointedToolStripMenuItem.Text = "Bug Appointed";
            this.bugAppointedToolStripMenuItem.Click += new System.EventHandler(this.bugAppointedToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem1
            // 
            this.projectsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("projectsToolStripMenuItem1.Image")));
            this.projectsToolStripMenuItem1.Name = "projectsToolStripMenuItem1";
            this.projectsToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.projectsToolStripMenuItem1.Text = "Project Names";
            this.projectsToolStripMenuItem1.Click += new System.EventHandler(this.projectsToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bugsReportsToolStripMenuItem,
            this.projectsToolStripMenuItem2,
            this.userDetailsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // bugsReportsToolStripMenuItem
            // 
            this.bugsReportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bugsReportsToolStripMenuItem.Image")));
            this.bugsReportsToolStripMenuItem.Name = "bugsReportsToolStripMenuItem";
            this.bugsReportsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.bugsReportsToolStripMenuItem.Text = "Bug Appointment";
            this.bugsReportsToolStripMenuItem.Click += new System.EventHandler(this.bugsReportsToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem2
            // 
            this.projectsToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("projectsToolStripMenuItem2.Image")));
            this.projectsToolStripMenuItem2.Name = "projectsToolStripMenuItem2";
            this.projectsToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.projectsToolStripMenuItem2.Text = "Project Names";
            this.projectsToolStripMenuItem2.Click += new System.EventHandler(this.projectsToolStripMenuItem2_Click);
            // 
            // userDetailsToolStripMenuItem
            // 
            this.userDetailsToolStripMenuItem.Image = global::Bug_Tracking_Application.Properties.Resources.key;
            this.userDetailsToolStripMenuItem.Name = "userDetailsToolStripMenuItem";
            this.userDetailsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.userDetailsToolStripMenuItem.Text = "Password";
            this.userDetailsToolStripMenuItem.Click += new System.EventHandler(this.userDetailsToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem1});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.Image = global::Bug_Tracking_Application.Properties.Resources.user2;
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.usersToolStripMenuItem1.Text = "Users";
            this.usersToolStripMenuItem1.Click += new System.EventHandler(this.usersToolStripMenuItem1_Click);
            // 
            // repoToolStripMenuItem
            // 
            this.repoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liveRepoToolStripMenuItem});
            this.repoToolStripMenuItem.Name = "repoToolStripMenuItem";
            this.repoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.repoToolStripMenuItem.Text = "Repo";
            // 
            // liveRepoToolStripMenuItem
            // 
            this.liveRepoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("liveRepoToolStripMenuItem.Image")));
            this.liveRepoToolStripMenuItem.Name = "liveRepoToolStripMenuItem";
            this.liveRepoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.liveRepoToolStripMenuItem.Text = "Live Repo";
            this.liveRepoToolStripMenuItem.Click += new System.EventHandler(this.liveRepoToolStripMenuItem_Click);
            // 
            // formAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "formAdmin";
            this.Text = "Bug Tracking Application";
            this.Load += new System.EventHandler(this.formAdmin_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointBugsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bugsReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugAppointedToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem repoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveRepoToolStripMenuItem;
    }
}