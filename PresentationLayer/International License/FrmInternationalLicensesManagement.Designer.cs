namespace PresentationLayer.International_License {
    partial class FrmInternationalLicensesManagement {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecordsNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvInternationalLic = new System.Windows.Forms.DataGridView();
            this.InternationalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuedUsingLocalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licenseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbLicenseStatus = new System.Windows.Forms.ComboBox();
            this.cmsInterApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showDriversPersonalDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLic)).BeginInit();
            this.cmsInterApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsNo
            // 
            this.lblRecordsNo.AutoSize = true;
            this.lblRecordsNo.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRecordsNo.Location = new System.Drawing.Point(469, 1395);
            this.lblRecordsNo.Name = "lblRecordsNo";
            this.lblRecordsNo.Size = new System.Drawing.Size(186, 39);
            this.lblRecordsNo.TabIndex = 62;
            this.lblRecordsNo.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(30, 1395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(443, 39);
            this.label4.TabIndex = 61;
            this.label4.Text = "# International licenses:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 17F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(249, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1776, 77);
            this.label1.TabIndex = 57;
            this.label1.Text = "International driving licenses management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(28, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 54);
            this.label5.TabIndex = 64;
            this.label5.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(275, 442);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(352, 39);
            this.cbFilterBy.TabIndex = 63;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(651, 443);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 38);
            this.txtSearch.TabIndex = 59;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // dgvInternationalLic
            // 
            this.dgvInternationalLic.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvInternationalLic.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInternationalLic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLic.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InternationalLicenseID,
            this.DriverID,
            this.dataGridViewTextBoxColumn32,
            this.IssuedUsingLocalLicenseID,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.licenseStatus});
            this.dgvInternationalLic.ContextMenuStrip = this.cmsInterApp;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLic.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalLic.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvInternationalLic.Location = new System.Drawing.Point(23, 529);
            this.dgvInternationalLic.Name = "dgvInternationalLic";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLic.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalLic.RowHeadersWidth = 102;
            this.dgvInternationalLic.RowTemplate.Height = 40;
            this.dgvInternationalLic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLic.Size = new System.Drawing.Size(2273, 842);
            this.dgvInternationalLic.TabIndex = 65;
            // 
            // InternationalLicenseID
            // 
            this.InternationalLicenseID.DataPropertyName = "InternationalLicenseID";
            this.InternationalLicenseID.HeaderText = "Int.License ID";
            this.InternationalLicenseID.MinimumWidth = 12;
            this.InternationalLicenseID.Name = "InternationalLicenseID";
            // 
            // DriverID
            // 
            this.DriverID.DataPropertyName = "DriverID";
            this.DriverID.HeaderText = "Driver ID";
            this.DriverID.MinimumWidth = 12;
            this.DriverID.Name = "DriverID";
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "ApplicationID";
            this.dataGridViewTextBoxColumn32.HeaderText = "App.ID";
            this.dataGridViewTextBoxColumn32.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            // 
            // IssuedUsingLocalLicenseID
            // 
            this.IssuedUsingLocalLicenseID.DataPropertyName = "IssuedUsingLocalLicenseID";
            this.IssuedUsingLocalLicenseID.HeaderText = "L.License ID";
            this.IssuedUsingLocalLicenseID.MinimumWidth = 12;
            this.IssuedUsingLocalLicenseID.Name = "IssuedUsingLocalLicenseID";
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "IssueDate";
            this.dataGridViewTextBoxColumn34.HeaderText = "Issue date";
            this.dataGridViewTextBoxColumn34.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "ExpirationDate";
            this.dataGridViewTextBoxColumn35.HeaderText = "Expiration date";
            this.dataGridViewTextBoxColumn35.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            // 
            // licenseStatus
            // 
            this.licenseStatus.DataPropertyName = "licenseStatus";
            this.licenseStatus.HeaderText = "License status";
            this.licenseStatus.MinimumWidth = 12;
            this.licenseStatus.Name = "licenseStatus";
            // 
            // cbLicenseStatus
            // 
            this.cbLicenseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseStatus.FormattingEnabled = true;
            this.cbLicenseStatus.Location = new System.Drawing.Point(651, 443);
            this.cbLicenseStatus.Name = "cbLicenseStatus";
            this.cbLicenseStatus.Size = new System.Drawing.Size(352, 39);
            this.cbLicenseStatus.TabIndex = 66;
            this.cbLicenseStatus.Visible = false;
            this.cbLicenseStatus.SelectedIndexChanged += new System.EventHandler(this.cbLicenseStatus_SelectedIndexChanged);
            // 
            // cmsInterApp
            // 
            this.cmsInterApp.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.cmsInterApp.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsInterApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDriversPersonalDetailsToolStripMenuItem,
            this.tmsiShowLicense,
            this.tmsiHistory});
            this.cmsInterApp.Name = "cmsApp";
            this.cmsInterApp.Size = new System.Drawing.Size(965, 184);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(2083, 1392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 49);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.driving_license__4_;
            this.pictureBox1.Location = new System.Drawing.Point(969, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // showDriversPersonalDetailsToolStripMenuItem
            // 
            this.showDriversPersonalDetailsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.driver1;
            this.showDriversPersonalDetailsToolStripMenuItem.Name = "showDriversPersonalDetailsToolStripMenuItem";
            this.showDriversPersonalDetailsToolStripMenuItem.Size = new System.Drawing.Size(964, 60);
            this.showDriversPersonalDetailsToolStripMenuItem.Text = "Show driver\'s personal details";
            this.showDriversPersonalDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDriversPersonalDetailsToolStripMenuItem_Click);
            // 
            // tmsiShowLicense
            // 
            this.tmsiShowLicense.Image = global::PresentationLayer.Properties.Resources.pilot_license;
            this.tmsiShowLicense.Name = "tmsiShowLicense";
            this.tmsiShowLicense.Size = new System.Drawing.Size(964, 60);
            this.tmsiShowLicense.Text = "Show international driving license";
            this.tmsiShowLicense.Click += new System.EventHandler(this.tmsiShowLicense_Click);
            // 
            // tmsiHistory
            // 
            this.tmsiHistory.Image = global::PresentationLayer.Properties.Resources.history;
            this.tmsiHistory.Name = "tmsiHistory";
            this.tmsiHistory.Size = new System.Drawing.Size(964, 60);
            this.tmsiHistory.Text = "Show license history";
            this.tmsiHistory.Click += new System.EventHandler(this.tmsiHistory_Click);
            // 
            // FrmInternationalLicensesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2315, 1463);
            this.Controls.Add(this.dgvInternationalLic);
            this.Controls.Add(this.lblRecordsNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbLicenseStatus);
            this.Name = "FrmInternationalLicensesManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInternationalLicensesManagement";
            this.Load += new System.EventHandler(this.FrmInternationalLicensesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLic)).EndInit();
            this.cmsInterApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvInternationalLic;
        private System.Windows.Forms.ComboBox cbLicenseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternationalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuedUsingLocalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn licenseStatus;
        private System.Windows.Forms.ContextMenuStrip cmsInterApp;
        private System.Windows.Forms.ToolStripMenuItem showDriversPersonalDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmsiShowLicense;
        private System.Windows.Forms.ToolStripMenuItem tmsiHistory;
    }
}