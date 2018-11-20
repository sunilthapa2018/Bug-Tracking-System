namespace Bug_Tracking_Application
{
    partial class formUserReportBug
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAppName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImportScreenshot = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBugName = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.picScreenshot = new System.Windows.Forms.PictureBox();
            this.lblImageSelected = new System.Windows.Forms.Label();
            this.cboBugName = new System.Windows.Forms.ComboBox();
            this.btnAddNewBug = new System.Windows.Forms.Button();
            this.btnAddNewError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(251, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Enter A New Bug and Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bug Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "App Name";
            // 
            // cboAppName
            // 
            this.cboAppName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAppName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAppName.FormattingEnabled = true;
            this.cboAppName.Items.AddRange(new object[] {
            "--Select--"});
            this.cboAppName.Location = new System.Drawing.Point(115, 88);
            this.cboAppName.Name = "cboAppName";
            this.cboAppName.Size = new System.Drawing.Size(287, 27);
            this.cboAppName.TabIndex = 0;
            this.cboAppName.SelectedIndexChanged += new System.EventHandler(this.cboAppName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(115, 170);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(672, 164);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Screenshot";
            // 
            // btnImportScreenshot
            // 
            this.btnImportScreenshot.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportScreenshot.Location = new System.Drawing.Point(115, 349);
            this.btnImportScreenshot.Name = "btnImportScreenshot";
            this.btnImportScreenshot.Size = new System.Drawing.Size(79, 29);
            this.btnImportScreenshot.TabIndex = 3;
            this.btnImportScreenshot.Text = "Import";
            this.btnImportScreenshot.UseVisualStyleBackColor = true;
            this.btnImportScreenshot.Click += new System.EventHandler(this.btnImportScreenshot_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnSave.Location = new System.Drawing.Point(115, 639);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 45);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnCancel.Location = new System.Drawing.Point(215, 639);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBugName
            // 
            this.txtBugName.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtBugName.Location = new System.Drawing.Point(115, 128);
            this.txtBugName.Name = "txtBugName";
            this.txtBugName.Size = new System.Drawing.Size(287, 27);
            this.txtBugName.TabIndex = 11;
            this.txtBugName.TextChanged += new System.EventHandler(this.txtBugName_TextChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.picScreenshot);
            this.panel1.Controls.Add(this.lblImageSelected);
            this.panel1.Controls.Add(this.cboBugName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.cboAppName);
            this.panel1.Controls.Add(this.txtBugName);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnImportScreenshot);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 703);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picScreenshot
            // 
            this.picScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picScreenshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreenshot.Location = new System.Drawing.Point(115, 396);
            this.picScreenshot.MinimumSize = new System.Drawing.Size(400, 225);
            this.picScreenshot.Name = "picScreenshot";
            this.picScreenshot.Size = new System.Drawing.Size(672, 225);
            this.picScreenshot.TabIndex = 14;
            this.picScreenshot.TabStop = false;
            // 
            // lblImageSelected
            // 
            this.lblImageSelected.AutoSize = true;
            this.lblImageSelected.BackColor = System.Drawing.Color.White;
            this.lblImageSelected.Font = new System.Drawing.Font("Calibri", 12F);
            this.lblImageSelected.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblImageSelected.Location = new System.Drawing.Point(200, 354);
            this.lblImageSelected.Name = "lblImageSelected";
            this.lblImageSelected.Size = new System.Drawing.Size(108, 19);
            this.lblImageSelected.TabIndex = 13;
            this.lblImageSelected.Text = "Image Selected";
            this.lblImageSelected.Visible = false;
            // 
            // cboBugName
            // 
            this.cboBugName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBugName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBugName.FormattingEnabled = true;
            this.cboBugName.Items.AddRange(new object[] {
            "--Select--"});
            this.cboBugName.Location = new System.Drawing.Point(115, 128);
            this.cboBugName.Name = "cboBugName";
            this.cboBugName.Size = new System.Drawing.Size(287, 27);
            this.cboBugName.TabIndex = 1;
            // 
            // btnAddNewBug
            // 
            this.btnAddNewBug.Location = new System.Drawing.Point(12, 11);
            this.btnAddNewBug.Name = "btnAddNewBug";
            this.btnAddNewBug.Size = new System.Drawing.Size(140, 25);
            this.btnAddNewBug.TabIndex = 13;
            this.btnAddNewBug.Text = "Add New Bug and Report";
            this.btnAddNewBug.UseVisualStyleBackColor = true;
            this.btnAddNewBug.Click += new System.EventHandler(this.btnAddNewBug_Click);
            // 
            // btnAddNewError
            // 
            this.btnAddNewError.Location = new System.Drawing.Point(158, 11);
            this.btnAddNewError.Name = "btnAddNewError";
            this.btnAddNewError.Size = new System.Drawing.Size(140, 25);
            this.btnAddNewError.TabIndex = 13;
            this.btnAddNewError.Text = "Add New Error to Old Bug";
            this.btnAddNewError.UseVisualStyleBackColor = true;
            this.btnAddNewError.Click += new System.EventHandler(this.btnAddNewError_Click);
            // 
            // formUserReportBug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 755);
            this.Controls.Add(this.btnAddNewError);
            this.Controls.Add(this.btnAddNewBug);
            this.Controls.Add(this.panel1);
            this.Name = "formUserReportBug";
            this.Text = "Report Bug";
            this.Load += new System.EventHandler(this.formUserReportBug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAppName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImportScreenshot;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBugName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboBugName;
        private System.Windows.Forms.Button btnAddNewError;
        private System.Windows.Forms.Button btnAddNewBug;
        private System.Windows.Forms.Label lblImageSelected;
        private System.Windows.Forms.PictureBox picScreenshot;
    }
}