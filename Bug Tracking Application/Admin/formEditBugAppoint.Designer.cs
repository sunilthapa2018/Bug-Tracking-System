﻿namespace Bug_Tracking_Application.Admin
{
    partial class formEditBugAppoint
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAppointBug = new System.Windows.Forms.Button();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 33);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Add Bug Appointment";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAppointBug
            // 
            this.btnAppointBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointBug.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnAppointBug.Location = new System.Drawing.Point(158, 96);
            this.btnAppointBug.Name = "btnAppointBug";
            this.btnAppointBug.Size = new System.Drawing.Size(119, 54);
            this.btnAppointBug.TabIndex = 1;
            this.btnAppointBug.Text = "Appoint Bug";
            this.btnAppointBug.UseVisualStyleBackColor = true;
            this.btnAppointBug.Click += new System.EventHandler(this.btnAppointBug_Click);
            // 
            // cboName
            // 
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.Font = new System.Drawing.Font("Calibri", 12F);
            this.cboName.FormattingEnabled = true;
            this.cboName.Items.AddRange(new object[] {
            "--Select--"});
            this.cboName.Location = new System.Drawing.Point(80, 63);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(197, 27);
            this.cboName.TabIndex = 0;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F);
            this.label2.Location = new System.Drawing.Point(27, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // formEditBugAppoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(309, 161);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAppointBug);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.label2);
            this.Name = "formEditBugAppoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Bug Appointment";
            this.Load += new System.EventHandler(this.formEditBugAppoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAppointBug;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}