namespace PresentationLayer.Local_License_Appliaction {
    partial class FrmIssueLocalLicense {
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
            this.ucLocalDrivingLicenseDetails1 = new PresentationLayer.Local_DL_Appliaction.ucLocalDrivingLicenseDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.pbDescription = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnIssueLicense = new System.Windows.Forms.Button();
            this.lblLicense = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucLocalDrivingLicenseDetails1
            // 
            this.ucLocalDrivingLicenseDetails1.BackColor = System.Drawing.SystemColors.ControlText;
            this.ucLocalDrivingLicenseDetails1.Location = new System.Drawing.Point(45, 122);
            this.ucLocalDrivingLicenseDetails1.Name = "ucLocalDrivingLicenseDetails1";
            this.ucLocalDrivingLicenseDetails1.Size = new System.Drawing.Size(2372, 1169);
            this.ucLocalDrivingLicenseDetails1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(499, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1366, 77);
            this.label1.TabIndex = 28;
            this.label1.Text = "Issuing a local license for the first time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(590, 1060);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(1365, 154);
            this.txtNotes.TabIndex = 78;
            // 
            // pbDescription
            // 
            this.pbDescription.Image = global::PresentationLayer.Properties.Resources.edit_info;
            this.pbDescription.Location = new System.Drawing.Point(458, 1104);
            this.pbDescription.Name = "pbDescription";
            this.pbDescription.Size = new System.Drawing.Size(80, 59);
            this.pbDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDescription.TabIndex = 77;
            this.pbDescription.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(305, 1124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 39);
            this.label12.TabIndex = 76;
            this.label12.Text = "Notes:";
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnIssueLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIssueLicense.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueLicense.ForeColor = System.Drawing.Color.Transparent;
            this.btnIssueLicense.Image = global::PresentationLayer.Properties.Resources.driving_license__2_;
            this.btnIssueLicense.Location = new System.Drawing.Point(2170, 1317);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(191, 89);
            this.btnIssueLicense.TabIndex = 79;
            this.btnIssueLicense.UseVisualStyleBackColor = false;
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblLicense.ForeColor = System.Drawing.Color.White;
            this.lblLicense.Location = new System.Drawing.Point(2125, 1283);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(262, 31);
            this.lblLicense.TabIndex = 80;
            this.lblLicense.Text = "Issue local license";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(72, 1333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(908, 46);
            this.label2.TabIndex = 82;
            this.label2.Text = "License issuance Fees for this licsens class:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblFees.ForeColor = System.Drawing.Color.Lime;
            this.lblFees.Location = new System.Drawing.Point(1069, 1339);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(186, 39);
            this.lblFees.TabIndex = 84;
            this.lblFees.Text = "Unknown";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.currency1;
            this.pictureBox3.Location = new System.Drawing.Point(986, 1318);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(77, 73);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 83;
            this.pictureBox3.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl.Location = new System.Drawing.Point(1341, 1333);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(253, 46);
            this.lbl.TabIndex = 85;
            this.lbl.Text = "License ID:";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblLicenseID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblLicenseID.Location = new System.Drawing.Point(1683, 1339);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(186, 39);
            this.lblLicenseID.TabIndex = 86;
            this.lblLicenseID.Text = "Unknown";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.icense__1_;
            this.pictureBox1.Location = new System.Drawing.Point(1600, 1317);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // FrmIssueLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(2447, 1463);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLicenseID);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblFees);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.pbDescription);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucLocalDrivingLicenseDetails1);
            this.Name = "FrmIssueLocalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIssueLocalLicense";
            this.Load += new System.EventHandler(this.FrmIssueLocalLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Local_DL_Appliaction.ucLocalDrivingLicenseDetails ucLocalDrivingLicenseDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.PictureBox pbDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnIssueLicense;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}