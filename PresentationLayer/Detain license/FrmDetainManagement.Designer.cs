namespace PresentationLayer.Detain_license {
    partial class FrmDetainManagement {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvDetain = new System.Windows.Forms.DataGridView();
            this.DetainID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetainDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetaintionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDetainment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.licenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmsiRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmsiDetainDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiReleaseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmsiHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.cbDetaintionStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetain)).BeginInit();
            this.cmsDetainment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(657, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1141, 77);
            this.label1.TabIndex = 28;
            this.label1.Text = "Detain and release management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(34, 523);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 54);
            this.label5.TabIndex = 40;
            this.label5.Text = "Filter By:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(660, 539);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 38);
            this.txtSearch.TabIndex = 39;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D Application ID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(281, 538);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(352, 39);
            this.cbFilterBy.TabIndex = 38;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvDetain
            // 
            this.dgvDetain.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvDetain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetain.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Georgia", 10.1F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetainID,
            this.LicenseID,
            this.DriverName,
            this.DetainDate,
            this.DetaintionStatus});
            this.dgvDetain.ContextMenuStrip = this.cmsDetainment;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetain.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetain.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDetain.Location = new System.Drawing.Point(27, 598);
            this.dgvDetain.Name = "dgvDetain";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetain.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetain.RowHeadersWidth = 102;
            this.dgvDetain.RowTemplate.Height = 40;
            this.dgvDetain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetain.Size = new System.Drawing.Size(2439, 843);
            this.dgvDetain.TabIndex = 41;
            // 
            // DetainID
            // 
            this.DetainID.DataPropertyName = "DetainID";
            this.DetainID.HeaderText = "Detain ID";
            this.DetainID.MinimumWidth = 12;
            this.DetainID.Name = "DetainID";
            // 
            // LicenseID
            // 
            this.LicenseID.DataPropertyName = "LicenseID";
            this.LicenseID.HeaderText = "License ID";
            this.LicenseID.MinimumWidth = 12;
            this.LicenseID.Name = "LicenseID";
            // 
            // DriverName
            // 
            this.DriverName.DataPropertyName = "DriverName";
            this.DriverName.HeaderText = "Driver\'s name";
            this.DriverName.MinimumWidth = 12;
            this.DriverName.Name = "DriverName";
            // 
            // DetainDate
            // 
            this.DetainDate.DataPropertyName = "DetainDate";
            this.DetainDate.HeaderText = "Detain date";
            this.DetainDate.MinimumWidth = 12;
            this.DetainDate.Name = "DetainDate";
            // 
            // DetaintionStatus
            // 
            this.DetaintionStatus.DataPropertyName = "DetaintionStatus";
            this.DetaintionStatus.HeaderText = "Detainment status";
            this.DetaintionStatus.MinimumWidth = 12;
            this.DetaintionStatus.Name = "DetaintionStatus";
            // 
            // cmsDetainment
            // 
            this.cmsDetainment.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.cmsDetainment.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsDetainment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.tmsiRelease,
            this.toolStripMenuItem1,
            this.tmsiDetainDetails,
            this.tmsiReleaseDetails,
            this.toolStripMenuItem2,
            this.tmsiHistory});
            this.cmsDetainment.Name = "cmsApp";
            this.cmsDetainment.Size = new System.Drawing.Size(641, 342);
            this.cmsDetainment.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDetainment_Opening);
            // 
            // licenseDetailsToolStripMenuItem
            // 
            this.licenseDetailsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.icense__1_2;
            this.licenseDetailsToolStripMenuItem.Name = "licenseDetailsToolStripMenuItem";
            this.licenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(640, 64);
            this.licenseDetailsToolStripMenuItem.Text = "License details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(637, 6);
            // 
            // tmsiRelease
            // 
            this.tmsiRelease.Image = global::PresentationLayer.Properties.Resources.validation;
            this.tmsiRelease.Name = "tmsiRelease";
            this.tmsiRelease.Size = new System.Drawing.Size(640, 64);
            this.tmsiRelease.Text = "Release";
            this.tmsiRelease.Click += new System.EventHandler(this.tmsiRelease_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(637, 6);
            // 
            // tmsiDetainDetails
            // 
            this.tmsiDetainDetails.Image = global::PresentationLayer.Properties.Resources.fraud_prevention;
            this.tmsiDetainDetails.Name = "tmsiDetainDetails";
            this.tmsiDetainDetails.Size = new System.Drawing.Size(640, 64);
            this.tmsiDetainDetails.Text = "Detain details";
            this.tmsiDetainDetails.Click += new System.EventHandler(this.tmsiDetainDetails_Click);
            // 
            // tmsiReleaseDetails
            // 
            this.tmsiReleaseDetails.Image = global::PresentationLayer.Properties.Resources.approval;
            this.tmsiReleaseDetails.Name = "tmsiReleaseDetails";
            this.tmsiReleaseDetails.Size = new System.Drawing.Size(640, 64);
            this.tmsiReleaseDetails.Text = "Release details";
            this.tmsiReleaseDetails.Click += new System.EventHandler(this.tmsiReleaseDetails_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(637, 6);
            // 
            // tmsiHistory
            // 
            this.tmsiHistory.Image = global::PresentationLayer.Properties.Resources.data_loss_prevention;
            this.tmsiHistory.Name = "tmsiHistory";
            this.tmsiHistory.Size = new System.Drawing.Size(640, 64);
            this.tmsiHistory.Text = "Detainment history";
            // 
            // lblRecordsNo
            // 
            this.lblRecordsNo.AutoSize = true;
            this.lblRecordsNo.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRecordsNo.Location = new System.Drawing.Point(455, 1469);
            this.lblRecordsNo.Name = "lblRecordsNo";
            this.lblRecordsNo.Size = new System.Drawing.Size(186, 39);
            this.lblRecordsNo.TabIndex = 44;
            this.lblRecordsNo.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(39, 1469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(422, 39);
            this.label4.TabIndex = 43;
            this.label4.Text = "# Detainment Records:";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblLicense.ForeColor = System.Drawing.Color.White;
            this.lblLicense.Location = new System.Drawing.Point(2229, 447);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(211, 31);
            this.lblLicense.TabIndex = 47;
            this.lblLicense.Text = "Detain license";
            // 
            // cbDetaintionStatus
            // 
            this.cbDetaintionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDetaintionStatus.FormattingEnabled = true;
            this.cbDetaintionStatus.Items.AddRange(new object[] {
            "None",
            "L.D Application ID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbDetaintionStatus.Location = new System.Drawing.Point(660, 539);
            this.cbDetaintionStatus.Name = "cbDetaintionStatus";
            this.cbDetaintionStatus.Size = new System.Drawing.Size(352, 39);
            this.cbDetaintionStatus.TabIndex = 50;
            this.cbDetaintionStatus.SelectedIndexChanged += new System.EventHandler(this.cbDetaintionStatus_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.BackgroundImage = global::PresentationLayer.Properties.Resources.preventive__1_;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(2261, 494);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 83);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(2253, 1459);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 49);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.reject;
            this.pictureBox1.Location = new System.Drawing.Point(1090, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 287);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDetainManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2478, 1541);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblRecordsNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDetain);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbDetaintionStatus);
            this.Name = "FrmDetainManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetainManagement";
            this.Load += new System.EventHandler(this.FrmDetainManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetain)).EndInit();
            this.cmsDetainment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dgvDetain;
        private System.Windows.Forms.Label lblRecordsNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbDetaintionStatus;
        private System.Windows.Forms.ContextMenuStrip cmsDetainment;
        private System.Windows.Forms.ToolStripMenuItem tmsiRelease;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tmsiHistory;
        private System.Windows.Forms.ToolStripMenuItem tmsiReleaseDetails;
        private System.Windows.Forms.ToolStripMenuItem tmsiDetainDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem licenseDetailsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetainID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetainDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetaintionStatus;
    }
}