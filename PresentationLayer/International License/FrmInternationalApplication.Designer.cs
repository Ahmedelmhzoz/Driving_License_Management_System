namespace PresentationLayer.International_License {
    partial class FrmInternationalApplication {
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
            this.tcInternationApp = new System.Windows.Forms.TabControl();
            this.tbSelectLocalLic = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucGetLicenseWithFilter = new PresentationLayer.Licenses_and_drivers.ucGetLicenseWithFilter();
            this.tbInternationalIssuing = new System.Windows.Forms.TabPage();
            this.lblShowLic = new System.Windows.Forms.Label();
            this.lblShowHistory = new System.Windows.Forms.Label();
            this.lblLicenseIssuing = new System.Windows.Forms.Label();
            this.btnShowLicense = new System.Windows.Forms.Button();
            this.lblReleseDate = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.btnIssueLicense = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblFees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocalLicID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInterLicID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Personi = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.tcInternationApp.SuspendLayout();
            this.tbSelectLocalLic.SuspendLayout();
            this.tbInternationalIssuing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcInternationApp
            // 
            this.tcInternationApp.Controls.Add(this.tbSelectLocalLic);
            this.tcInternationApp.Controls.Add(this.tbInternationalIssuing);
            this.tcInternationApp.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcInternationApp.Location = new System.Drawing.Point(12, 136);
            this.tcInternationApp.Name = "tcInternationApp";
            this.tcInternationApp.SelectedIndex = 0;
            this.tcInternationApp.Size = new System.Drawing.Size(2202, 1782);
            this.tcInternationApp.TabIndex = 0;
            this.tcInternationApp.SelectedIndexChanged += new System.EventHandler(this.tcInternationApp_SelectedIndexChanged);
            // 
            // tbSelectLocalLic
            // 
            this.tbSelectLocalLic.BackColor = System.Drawing.Color.Black;
            this.tbSelectLocalLic.Controls.Add(this.btnNext);
            this.tbSelectLocalLic.Controls.Add(this.ucGetLicenseWithFilter);
            this.tbSelectLocalLic.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectLocalLic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbSelectLocalLic.Location = new System.Drawing.Point(10, 48);
            this.tbSelectLocalLic.Name = "tbSelectLocalLic";
            this.tbSelectLocalLic.Padding = new System.Windows.Forms.Padding(3);
            this.tbSelectLocalLic.Size = new System.Drawing.Size(2182, 1724);
            this.tbSelectLocalLic.TabIndex = 0;
            this.tbSelectLocalLic.Text = "Select local license";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNext.Enabled = false;
            this.btnNext.ForeColor = System.Drawing.Color.Transparent;
            this.btnNext.Image = global::PresentationLayer.Properties.Resources.next_2;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(1843, 100);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(230, 83);
            this.btnNext.TabIndex = 20;
            this.btnNext.Text = "Next ";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucGetLicenseWithFilter
            // 
            this.ucGetLicenseWithFilter.BackColor = System.Drawing.SystemColors.ControlText;
            this.ucGetLicenseWithFilter.Location = new System.Drawing.Point(22, 36);
            this.ucGetLicenseWithFilter.Name = "ucGetLicenseWithFilter";
            this.ucGetLicenseWithFilter.Size = new System.Drawing.Size(2174, 1672);
            this.ucGetLicenseWithFilter.TabIndex = 0;
            // 
            // tbInternationalIssuing
            // 
            this.tbInternationalIssuing.BackColor = System.Drawing.Color.Black;
            this.tbInternationalIssuing.Controls.Add(this.lblShowLic);
            this.tbInternationalIssuing.Controls.Add(this.lblShowHistory);
            this.tbInternationalIssuing.Controls.Add(this.lblLicenseIssuing);
            this.tbInternationalIssuing.Controls.Add(this.btnShowLicense);
            this.tbInternationalIssuing.Controls.Add(this.lblReleseDate);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox7);
            this.tbInternationalIssuing.Controls.Add(this.label12);
            this.tbInternationalIssuing.Controls.Add(this.btnShowHistory);
            this.tbInternationalIssuing.Controls.Add(this.btnIssueLicense);
            this.tbInternationalIssuing.Controls.Add(this.lblUsername);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox6);
            this.tbInternationalIssuing.Controls.Add(this.label9);
            this.tbInternationalIssuing.Controls.Add(this.lblExpireDate);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox5);
            this.tbInternationalIssuing.Controls.Add(this.lblFees);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox4);
            this.tbInternationalIssuing.Controls.Add(this.label6);
            this.tbInternationalIssuing.Controls.Add(this.label5);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox3);
            this.tbInternationalIssuing.Controls.Add(this.label3);
            this.tbInternationalIssuing.Controls.Add(this.lblLocalLicID);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox2);
            this.tbInternationalIssuing.Controls.Add(this.label1);
            this.tbInternationalIssuing.Controls.Add(this.lblInterLicID);
            this.tbInternationalIssuing.Controls.Add(this.pictureBox1);
            this.tbInternationalIssuing.Controls.Add(this.Personi);
            this.tbInternationalIssuing.Controls.Add(this.lblApplicationID);
            this.tbInternationalIssuing.Location = new System.Drawing.Point(10, 48);
            this.tbInternationalIssuing.Name = "tbInternationalIssuing";
            this.tbInternationalIssuing.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternationalIssuing.Size = new System.Drawing.Size(2182, 1724);
            this.tbInternationalIssuing.TabIndex = 1;
            this.tbInternationalIssuing.Text = "Issue an international driving license";
            // 
            // lblShowLic
            // 
            this.lblShowLic.AutoSize = true;
            this.lblShowLic.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblShowLic.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblShowLic.Location = new System.Drawing.Point(1544, 1500);
            this.lblShowLic.Name = "lblShowLic";
            this.lblShowLic.Size = new System.Drawing.Size(307, 31);
            this.lblShowLic.TabIndex = 50;
            this.lblShowLic.Text = "Show licenses details";
            // 
            // lblShowHistory
            // 
            this.lblShowHistory.AutoSize = true;
            this.lblShowHistory.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblShowHistory.ForeColor = System.Drawing.Color.DimGray;
            this.lblShowHistory.Location = new System.Drawing.Point(1167, 1500);
            this.lblShowHistory.Name = "lblShowHistory";
            this.lblShowHistory.Size = new System.Drawing.Size(313, 31);
            this.lblShowHistory.TabIndex = 49;
            this.lblShowHistory.Text = "Show licenses history";
            // 
            // lblLicenseIssuing
            // 
            this.lblLicenseIssuing.AutoSize = true;
            this.lblLicenseIssuing.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblLicenseIssuing.ForeColor = System.Drawing.Color.White;
            this.lblLicenseIssuing.Location = new System.Drawing.Point(1899, 1500);
            this.lblLicenseIssuing.Name = "lblLicenseIssuing";
            this.lblLicenseIssuing.Size = new System.Drawing.Size(241, 31);
            this.lblLicenseIssuing.TabIndex = 48;
            this.lblLicenseIssuing.Text = "Issue the license";
            // 
            // btnShowLicense
            // 
            this.btnShowLicense.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowLicense.Enabled = false;
            this.btnShowLicense.ForeColor = System.Drawing.Color.Transparent;
            this.btnShowLicense.Image = global::PresentationLayer.Properties.Resources.pilot_license1;
            this.btnShowLicense.Location = new System.Drawing.Point(1587, 1558);
            this.btnShowLicense.Name = "btnShowLicense";
            this.btnShowLicense.Size = new System.Drawing.Size(204, 112);
            this.btnShowLicense.TabIndex = 47;
            this.btnShowLicense.UseVisualStyleBackColor = false;
            this.btnShowLicense.Click += new System.EventHandler(this.btnShowLicense_Click);
            // 
            // lblReleseDate
            // 
            this.lblReleseDate.AutoSize = true;
            this.lblReleseDate.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblReleseDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblReleseDate.Location = new System.Drawing.Point(923, 629);
            this.lblReleseDate.Name = "lblReleseDate";
            this.lblReleseDate.Size = new System.Drawing.Size(243, 51);
            this.lblReleseDate.TabIndex = 46;
            this.lblReleseDate.Text = "Unknown";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::PresentationLayer.Properties.Resources.currency;
            this.pictureBox7.Location = new System.Drawing.Point(826, 1190);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(82, 81);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 45;
            this.pictureBox7.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(695, 1210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 46);
            this.label12.TabIndex = 44;
            this.label12.Text = "Fees:";
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowHistory.Enabled = false;
            this.btnShowHistory.ForeColor = System.Drawing.Color.Transparent;
            this.btnShowHistory.Image = global::PresentationLayer.Properties.Resources.history11;
            this.btnShowHistory.Location = new System.Drawing.Point(1221, 1558);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(204, 112);
            this.btnShowHistory.TabIndex = 43;
            this.btnShowHistory.UseVisualStyleBackColor = false;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnIssueLicense.ForeColor = System.Drawing.Color.Transparent;
            this.btnIssueLicense.Image = global::PresentationLayer.Properties.Resources.agreement;
            this.btnIssueLicense.Location = new System.Drawing.Point(1922, 1558);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(204, 112);
            this.btnIssueLicense.TabIndex = 42;
            this.btnIssueLicense.UseVisualStyleBackColor = false;
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUsername.Location = new System.Drawing.Point(925, 1008);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(243, 51);
            this.lblUsername.TabIndex = 41;
            this.lblUsername.Text = "Unknown";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::PresentationLayer.Properties.Resources.employee;
            this.pictureBox6.Location = new System.Drawing.Point(824, 978);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(82, 81);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 40;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(564, 1000);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 46);
            this.label9.TabIndex = 39;
            this.label9.Text = "Created by:";
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.AutoSize = true;
            this.lblExpireDate.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpireDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblExpireDate.Location = new System.Drawing.Point(925, 815);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(243, 51);
            this.lblExpireDate.TabIndex = 38;
            this.lblExpireDate.Text = "Unknown";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PresentationLayer.Properties.Resources.expired;
            this.pictureBox5.Location = new System.Drawing.Point(826, 793);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(82, 81);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 37;
            this.pictureBox5.TabStop = false;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblFees.ForeColor = System.Drawing.Color.Lime;
            this.lblFees.Location = new System.Drawing.Point(923, 1210);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(243, 51);
            this.lblFees.TabIndex = 36;
            this.lblFees.Text = "Unknown";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PresentationLayer.Properties.Resources.calendar;
            this.pictureBox4.Location = new System.Drawing.Point(826, 604);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(82, 81);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(456, 815);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(366, 46);
            this.label6.TabIndex = 34;
            this.label6.Text = "Expiration  date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(549, 634);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 46);
            this.label5.TabIndex = 33;
            this.label5.Text = "Relese date:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.icense__1_1;
            this.pictureBox3.Location = new System.Drawing.Point(824, 436);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(82, 81);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(457, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 46);
            this.label3.TabIndex = 30;
            this.label3.Text = "Local licenes ID:";
            // 
            // lblLocalLicID
            // 
            this.lblLocalLicID.AutoSize = true;
            this.lblLocalLicID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblLocalLicID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblLocalLicID.Location = new System.Drawing.Point(923, 466);
            this.lblLocalLicID.Name = "lblLocalLicID";
            this.lblLocalLicID.Size = new System.Drawing.Size(243, 51);
            this.lblLocalLicID.TabIndex = 31;
            this.lblLocalLicID.Text = "Unknown";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.pilot_license;
            this.pictureBox2.Location = new System.Drawing.Point(824, 107);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(289, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 46);
            this.label1.TabIndex = 27;
            this.label1.Text = "International license ID:";
            // 
            // lblInterLicID
            // 
            this.lblInterLicID.AutoSize = true;
            this.lblInterLicID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblInterLicID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblInterLicID.Location = new System.Drawing.Point(925, 127);
            this.lblInterLicID.Name = "lblInterLicID";
            this.lblInterLicID.Size = new System.Drawing.Size(243, 51);
            this.lblInterLicID.TabIndex = 28;
            this.lblInterLicID.Text = "Unknown";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.job_application;
            this.pictureBox1.Location = new System.Drawing.Point(824, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // Personi
            // 
            this.Personi.AutoSize = true;
            this.Personi.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.Personi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Personi.Location = new System.Drawing.Point(49, 293);
            this.Personi.Name = "Personi";
            this.Personi.Size = new System.Drawing.Size(771, 46);
            this.Personi.TabIndex = 24;
            this.Personi.Text = "International license application ID:";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblApplicationID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblApplicationID.Location = new System.Drawing.Point(925, 294);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(243, 51);
            this.lblApplicationID.TabIndex = 25;
            this.lblApplicationID.Text = "Unknown";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.lblProcess.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProcess.Location = new System.Drawing.Point(539, 27);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(1162, 77);
            this.lblProcess.TabIndex = 23;
            this.lblProcess.Text = "International license application";
            // 
            // FrmInternationalApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2225, 1941);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.tcInternationApp);
            this.Name = "FrmInternationalApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInternationalApplication";
            this.tcInternationApp.ResumeLayout(false);
            this.tbSelectLocalLic.ResumeLayout(false);
            this.tbInternationalIssuing.ResumeLayout(false);
            this.tbInternationalIssuing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcInternationApp;
        private System.Windows.Forms.TabPage tbSelectLocalLic;
        private System.Windows.Forms.TabPage tbInternationalIssuing;
        private Licenses_and_drivers.ucGetLicenseWithFilter ucGetLicenseWithFilter;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Personi;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInterLicID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocalLicID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Button btnIssueLicense;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.Button btnShowLicense;
        private System.Windows.Forms.Label lblReleseDate;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblShowLic;
        private System.Windows.Forms.Label lblShowHistory;
        private System.Windows.Forms.Label lblLicenseIssuing;
    }
}