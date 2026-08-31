namespace PresentationLayer.Local_DL_Appliaction {
    partial class FrmAppointments {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAppointments));
            this.lblTestType = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.TestAppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmsiEditAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblRecordsNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.ucLocalDrivingLicenseDetails1 = new PresentationLayer.Local_DL_Appliaction.ucLocalDrivingLicenseDetails();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmsAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestType
            // 
            this.lblTestType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTestType.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.lblTestType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTestType.Location = new System.Drawing.Point(785, 202);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(914, 58);
            this.lblTestType.TabIndex = 29;
            this.lblTestType.Text = "Vision test appointments";
            this.lblTestType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Georgia", 10.1F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestAppointmentID,
            this.AppointmentDate,
            this.PaidFees,
            this.IsLocked});
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointment;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Georgia", 10.1F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAppointments.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvAppointments.Location = new System.Drawing.Point(59, 1335);
            this.dgvAppointments.Name = "dgvAppointments";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAppointments.RowHeadersWidth = 102;
            this.dgvAppointments.RowTemplate.Height = 40;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(2357, 502);
            this.dgvAppointments.TabIndex = 31;
            this.dgvAppointments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointments_CellFormatting);
            // 
            // TestAppointmentID
            // 
            this.TestAppointmentID.DataPropertyName = "TestAppointmentID";
            this.TestAppointmentID.HeaderText = "Appointment ID";
            this.TestAppointmentID.MinimumWidth = 12;
            this.TestAppointmentID.Name = "TestAppointmentID";
            // 
            // AppointmentDate
            // 
            this.AppointmentDate.DataPropertyName = "AppointmentDate";
            this.AppointmentDate.HeaderText = "Appointment date ";
            this.AppointmentDate.MinimumWidth = 12;
            this.AppointmentDate.Name = "AppointmentDate";
            // 
            // PaidFees
            // 
            this.PaidFees.DataPropertyName = "PaidFees";
            this.PaidFees.HeaderText = "Paid fees";
            this.PaidFees.MinimumWidth = 12;
            this.PaidFees.Name = "PaidFees";
            // 
            // IsLocked
            // 
            this.IsLocked.DataPropertyName = "IsLocked";
            this.IsLocked.HeaderText = "Is locked";
            this.IsLocked.MinimumWidth = 12;
            this.IsLocked.Name = "IsLocked";
            // 
            // cmsAppointment
            // 
            this.cmsAppointment.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.cmsAppointment.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsiEditAppointment,
            this.tmsiTakeTest});
            this.cmsAppointment.Name = "cmsApp";
            this.cmsAppointment.Size = new System.Drawing.Size(558, 124);
            // 
            // tmsiEditAppointment
            // 
            this.tmsiEditAppointment.Image = global::PresentationLayer.Properties.Resources.notes;
            this.tmsiEditAppointment.Name = "tmsiEditAppointment";
            this.tmsiEditAppointment.Size = new System.Drawing.Size(557, 60);
            this.tmsiEditAppointment.Text = "Edit appointment";
            this.tmsiEditAppointment.Click += new System.EventHandler(this.tmsiEditAppointment_Click);
            // 
            // tmsiTakeTest
            // 
            this.tmsiTakeTest.Image = global::PresentationLayer.Properties.Resources.test1;
            this.tmsiTakeTest.Name = "tmsiTakeTest";
            this.tmsiTakeTest.Size = new System.Drawing.Size(557, 60);
            this.tmsiTakeTest.Text = "Take test";
            this.tmsiTakeTest.Click += new System.EventHandler(this.tmsiTakeTest_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblLicense.ForeColor = System.Drawing.Color.White;
            this.lblLicense.Location = new System.Drawing.Point(2063, 1200);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(322, 31);
            this.lblLicense.TabIndex = 46;
            this.lblLicense.Text = "Add new appointment";
            // 
            // lblRecordsNo
            // 
            this.lblRecordsNo.AutoSize = true;
            this.lblRecordsNo.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRecordsNo.Location = new System.Drawing.Point(360, 1866);
            this.lblRecordsNo.Name = "lblRecordsNo";
            this.lblRecordsNo.Size = new System.Drawing.Size(186, 39);
            this.lblRecordsNo.TabIndex = 48;
            this.lblRecordsNo.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(52, 1866);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 39);
            this.label3.TabIndex = 47;
            this.label3.Text = "# Appointments: ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(2227, 1846);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 83);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Image = global::PresentationLayer.Properties.Resources.appointmentsAdd;
            this.btnAdd.Location = new System.Drawing.Point(2143, 1246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 83);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbTestType
            // 
            this.pbTestType.BackgroundImage = global::PresentationLayer.Properties.Resources.vision;
            this.pbTestType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestType.Location = new System.Drawing.Point(1148, 3);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(217, 196);
            this.pbTestType.TabIndex = 0;
            this.pbTestType.TabStop = false;
            // 
            // ucLocalDrivingLicenseDetails1
            // 
            this.ucLocalDrivingLicenseDetails1.BackColor = System.Drawing.SystemColors.ControlText;
            this.ucLocalDrivingLicenseDetails1.Location = new System.Drawing.Point(59, 288);
            this.ucLocalDrivingLicenseDetails1.Name = "ucLocalDrivingLicenseDetails1";
            this.ucLocalDrivingLicenseDetails1.Size = new System.Drawing.Size(2357, 943);
            this.ucLocalDrivingLicenseDetails1.TabIndex = 30;
            // 
            // FrmAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(2469, 1941);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.ucLocalDrivingLicenseDetails1);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.pbTestType);
            this.Name = "FrmAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAppointments";
            this.Load += new System.EventHandler(this.FrmAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.Label lblTestType;
        private ucLocalDrivingLicenseDetails ucLocalDrivingLicenseDetails1;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestAppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLocked;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblRecordsNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsAppointment;
        private System.Windows.Forms.ToolStripMenuItem tmsiEditAppointment;
        private System.Windows.Forms.ToolStripMenuItem tmsiTakeTest;
    }
}