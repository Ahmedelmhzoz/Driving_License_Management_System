namespace PresentationLayer.Local_DL_Appliaction {
    partial class FrmLocalLicenseAppManagement {
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
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvLocalApplications = new System.Windows.Forms.DataGridView();
            this.LocalDrivingLicenseApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassedExams = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.editApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecordsNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).BeginInit();
            this.cmsApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D Application ID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(288, 499);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(352, 39);
            this.cbFilterBy.TabIndex = 30;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(667, 500);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 38);
            this.txtSearch.TabIndex = 31;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // dgvLocalApplications
            // 
            this.dgvLocalApplications.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvLocalApplications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalApplications.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Georgia", 10.1F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalApplications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocalDrivingLicenseApplicationID,
            this.ClassName,
            this.NationalNo,
            this.fullName,
            this.ApplicationDate,
            this.PassedExams,
            this.ApplicationStatus});
            this.dgvLocalApplications.ContextMenuStrip = this.cmsApp;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalApplications.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocalApplications.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvLocalApplications.Location = new System.Drawing.Point(32, 556);
            this.dgvLocalApplications.Name = "dgvLocalApplications";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalApplications.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLocalApplications.RowHeadersWidth = 102;
            this.dgvLocalApplications.RowTemplate.Height = 40;
            this.dgvLocalApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalApplications.Size = new System.Drawing.Size(2318, 843);
            this.dgvLocalApplications.TabIndex = 28;
            // 
            // LocalDrivingLicenseApplicationID
            // 
            this.LocalDrivingLicenseApplicationID.DataPropertyName = "LocalDrivingLicenseApplicationID";
            this.LocalDrivingLicenseApplicationID.HeaderText = "L.D ApplicationID";
            this.LocalDrivingLicenseApplicationID.MinimumWidth = 12;
            this.LocalDrivingLicenseApplicationID.Name = "LocalDrivingLicenseApplicationID";
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "Driving class";
            this.ClassName.MinimumWidth = 12;
            this.ClassName.Name = "ClassName";
            // 
            // NationalNo
            // 
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.HeaderText = "National No.";
            this.NationalNo.MinimumWidth = 12;
            this.NationalNo.Name = "NationalNo";
            // 
            // fullName
            // 
            this.fullName.DataPropertyName = "FullName";
            this.fullName.HeaderText = "Full Name";
            this.fullName.MinimumWidth = 12;
            this.fullName.Name = "fullName";
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.DataPropertyName = "ApplicationDate";
            this.ApplicationDate.HeaderText = "Application Date";
            this.ApplicationDate.MinimumWidth = 12;
            this.ApplicationDate.Name = "ApplicationDate";
            // 
            // PassedExams
            // 
            this.PassedExams.DataPropertyName = "PassedExams";
            this.PassedExams.HeaderText = "Passed Exams";
            this.PassedExams.MinimumWidth = 12;
            this.PassedExams.Name = "PassedExams";
            // 
            // ApplicationStatus
            // 
            this.ApplicationStatus.DataPropertyName = "ApplicationStatus";
            this.ApplicationStatus.HeaderText = "Application Status";
            this.ApplicationStatus.MinimumWidth = 12;
            this.ApplicationStatus.Name = "ApplicationStatus";
            // 
            // cmsApp
            // 
            this.cmsApp.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.cmsApp.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.editApp,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.tsmiCancelApp});
            this.cmsApp.Name = "cmsApp";
            this.cmsApp.Size = new System.Drawing.Size(725, 311);
            this.cmsApp.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApp_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.job_application;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(724, 60);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show application details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(721, 6);
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // editApp
            // 
            this.editApp.Image = global::PresentationLayer.Properties.Resources.editApplication;
            this.editApp.Name = "editApp";
            this.editApp.Size = new System.Drawing.Size(724, 60);
            this.editApp.Text = "Edit application";
            this.editApp.Click += new System.EventHandler(this.editApp_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PresentationLayer.Properties.Resources.cut_paper;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(724, 60);
            this.toolStripMenuItem1.Text = "Delete application";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(721, 6);
            // 
            // tsmiCancelApp
            // 
            this.tsmiCancelApp.Image = global::PresentationLayer.Properties.Resources.cancel;
            this.tsmiCancelApp.Name = "tsmiCancelApp";
            this.tsmiCancelApp.Size = new System.Drawing.Size(724, 60);
            this.tsmiCancelApp.Text = "Cancel application";
            this.tsmiCancelApp.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(597, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1186, 77);
            this.label1.TabIndex = 27;
            this.label1.Text = "Local driving license applications";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(43, 1435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(642, 39);
            this.label4.TabIndex = 35;
            this.label4.Text = "# Local Driving license application: ";
            // 
            // lblRecordsNo
            // 
            this.lblRecordsNo.AutoSize = true;
            this.lblRecordsNo.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRecordsNo.Location = new System.Drawing.Point(678, 1435);
            this.lblRecordsNo.Name = "lblRecordsNo";
            this.lblRecordsNo.Size = new System.Drawing.Size(186, 39);
            this.lblRecordsNo.TabIndex = 36;
            this.lblRecordsNo.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(41, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 54);
            this.label5.TabIndex = 37;
            this.label5.Text = "Filter By:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(2151, 1435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 49);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.BackgroundImage = global::PresentationLayer.Properties.Resources.addApplication;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(2169, 452);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 83);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.ManageTestTypes1;
            this.pictureBox1.Location = new System.Drawing.Point(1071, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 287);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLocalLicenseAppManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2376, 1505);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRecordsNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocalApplications);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmLocalLicenseAppManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLocalLicenseAppManagement";
            this.Load += new System.EventHandler(this.FrmLocalLicenseAppManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).EndInit();
            this.cmsApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvLocalApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecordsNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalDrivingLicenseApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassedExams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationStatus;
        private System.Windows.Forms.ContextMenuStrip cmsApp;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editApp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelApp;
    }
}