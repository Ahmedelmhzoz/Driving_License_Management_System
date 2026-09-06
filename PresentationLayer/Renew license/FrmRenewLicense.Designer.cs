namespace PresentationLayer.Renew_license {
    partial class FrmRenewLicense {
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
            this.lblProcess = new System.Windows.Forms.Label();
            this.tcRenewalApp = new System.Windows.Forms.TabControl();
            this.tbSelectLicense = new System.Windows.Forms.TabPage();
            this.lblGoToRenewTab = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbInternational = new System.Windows.Forms.RadioButton();
            this.rbLocal = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRenewalApp = new System.Windows.Forms.TabPage();
            this.lblRenew = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblReleseDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNewLicenseID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRenewalAppID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnGoToRenewTab = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbLicense = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnRenewLicense = new System.Windows.Forms.Button();
            this.pbNote = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pbOldLicense = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbRenewalLicense = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ucLocalLicenseDetails = new PresentationLayer.Local_License.ucLocalLicenseDetails();
            this.ucInternationalLicenseDetails = new PresentationLayer.International_License.ucInternationalLicenseDetails();
            this.tcRenewalApp.SuspendLayout();
            this.tbSelectLicense.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbRenewalApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenewalLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.lblProcess.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProcess.Location = new System.Drawing.Point(594, 26);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(993, 77);
            this.lblProcess.TabIndex = 25;
            this.lblProcess.Text = "Renewal license application";
            // 
            // tcRenewalApp
            // 
            this.tcRenewalApp.Controls.Add(this.tbSelectLicense);
            this.tcRenewalApp.Controls.Add(this.tbRenewalApp);
            this.tcRenewalApp.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcRenewalApp.Location = new System.Drawing.Point(11, 134);
            this.tcRenewalApp.Name = "tcRenewalApp";
            this.tcRenewalApp.SelectedIndex = 0;
            this.tcRenewalApp.Size = new System.Drawing.Size(2202, 1782);
            this.tcRenewalApp.TabIndex = 24;
            this.tcRenewalApp.SelectedIndexChanged += new System.EventHandler(this.tcRenewalApp_SelectedIndexChanged);
            // 
            // tbSelectLicense
            // 
            this.tbSelectLicense.BackColor = System.Drawing.Color.Black;
            this.tbSelectLicense.Controls.Add(this.lblGoToRenewTab);
            this.tbSelectLicense.Controls.Add(this.btnGoToRenewTab);
            this.tbSelectLicense.Controls.Add(this.groupBox1);
            this.tbSelectLicense.Controls.Add(this.groupBox2);
            this.tbSelectLicense.Controls.Add(this.ucLocalLicenseDetails);
            this.tbSelectLicense.Controls.Add(this.ucInternationalLicenseDetails);
            this.tbSelectLicense.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectLicense.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbSelectLicense.Location = new System.Drawing.Point(10, 48);
            this.tbSelectLicense.Name = "tbSelectLicense";
            this.tbSelectLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tbSelectLicense.Size = new System.Drawing.Size(2182, 1724);
            this.tbSelectLicense.TabIndex = 0;
            this.tbSelectLicense.Text = "Select license";
            // 
            // lblGoToRenewTab
            // 
            this.lblGoToRenewTab.AutoSize = true;
            this.lblGoToRenewTab.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblGoToRenewTab.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblGoToRenewTab.Location = new System.Drawing.Point(1957, 1562);
            this.lblGoToRenewTab.Name = "lblGoToRenewTab";
            this.lblGoToRenewTab.Size = new System.Drawing.Size(120, 35);
            this.lblGoToRenewTab.TabIndex = 27;
            this.lblGoToRenewTab.Text = "Renew";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblLicenseType);
            this.groupBox1.Controls.Add(this.pbLicense);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(29, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1483, 186);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search for local license";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(523, 87);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 38);
            this.txtSearch.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1270, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 35);
            this.label2.TabIndex = 24;
            this.label2.Text = "Search";
            // 
            // lblLicenseType
            // 
            this.lblLicenseType.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblLicenseType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLicenseType.Location = new System.Drawing.Point(6, 85);
            this.lblLicenseType.Name = "lblLicenseType";
            this.lblLicenseType.Size = new System.Drawing.Size(423, 39);
            this.lblLicenseType.TabIndex = 21;
            this.lblLicenseType.Text = "Local driving license:";
            this.lblLicenseType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox9);
            this.groupBox2.Controls.Add(this.pictureBox8);
            this.groupBox2.Controls.Add(this.rbInternational);
            this.groupBox2.Controls.Add(this.rbLocal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Location = new System.Drawing.Point(1584, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 186);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driving license type";
            // 
            // rbInternational
            // 
            this.rbInternational.AutoSize = true;
            this.rbInternational.Font = new System.Drawing.Font("Georgia", 7.1F, System.Drawing.FontStyle.Bold);
            this.rbInternational.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.rbInternational.Location = new System.Drawing.Point(158, 115);
            this.rbInternational.Name = "rbInternational";
            this.rbInternational.Size = new System.Drawing.Size(217, 33);
            this.rbInternational.TabIndex = 26;
            this.rbInternational.TabStop = true;
            this.rbInternational.Text = "International";
            this.rbInternational.UseVisualStyleBackColor = true;
            this.rbInternational.CheckedChanged += new System.EventHandler(this.rbInternational_CheckedChanged_1);
            // 
            // rbLocal
            // 
            this.rbLocal.AutoSize = true;
            this.rbLocal.Font = new System.Drawing.Font("Georgia", 7.2F, System.Drawing.FontStyle.Bold);
            this.rbLocal.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.rbLocal.Location = new System.Drawing.Point(158, 62);
            this.rbLocal.Name = "rbLocal";
            this.rbLocal.Size = new System.Drawing.Size(116, 33);
            this.rbLocal.TabIndex = 25;
            this.rbLocal.TabStop = true;
            this.rbLocal.Text = "Local";
            this.rbLocal.UseVisualStyleBackColor = true;
            this.rbLocal.CheckedChanged += new System.EventHandler(this.rbLocal_CheckedChanged_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(1270, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 35);
            this.label4.TabIndex = 24;
            this.label4.Text = "Search";
            // 
            // tbRenewalApp
            // 
            this.tbRenewalApp.BackColor = System.Drawing.Color.Black;
            this.tbRenewalApp.Controls.Add(this.lblRenew);
            this.tbRenewalApp.Controls.Add(this.btnRenewLicense);
            this.tbRenewalApp.Controls.Add(this.txtNote);
            this.tbRenewalApp.Controls.Add(this.pbNote);
            this.tbRenewalApp.Controls.Add(this.lblNote);
            this.tbRenewalApp.Controls.Add(this.lblUsername);
            this.tbRenewalApp.Controls.Add(this.label9);
            this.tbRenewalApp.Controls.Add(this.pictureBox6);
            this.tbRenewalApp.Controls.Add(this.lblTotalFees);
            this.tbRenewalApp.Controls.Add(this.pictureBox3);
            this.tbRenewalApp.Controls.Add(this.label13);
            this.tbRenewalApp.Controls.Add(this.lblLicenseFees);
            this.tbRenewalApp.Controls.Add(this.pictureBox10);
            this.tbRenewalApp.Controls.Add(this.label10);
            this.tbRenewalApp.Controls.Add(this.label12);
            this.tbRenewalApp.Controls.Add(this.lblAppFees);
            this.tbRenewalApp.Controls.Add(this.pictureBox7);
            this.tbRenewalApp.Controls.Add(this.pbOldLicense);
            this.tbRenewalApp.Controls.Add(this.label5);
            this.tbRenewalApp.Controls.Add(this.lblOldLicenseID);
            this.tbRenewalApp.Controls.Add(this.lblExpireDate);
            this.tbRenewalApp.Controls.Add(this.label7);
            this.tbRenewalApp.Controls.Add(this.label8);
            this.tbRenewalApp.Controls.Add(this.pictureBox5);
            this.tbRenewalApp.Controls.Add(this.pictureBox4);
            this.tbRenewalApp.Controls.Add(this.lblReleseDate);
            this.tbRenewalApp.Controls.Add(this.label3);
            this.tbRenewalApp.Controls.Add(this.lblNewLicenseID);
            this.tbRenewalApp.Controls.Add(this.pbRenewalLicense);
            this.tbRenewalApp.Controls.Add(this.label1);
            this.tbRenewalApp.Controls.Add(this.lblRenewalAppID);
            this.tbRenewalApp.Controls.Add(this.pictureBox2);
            this.tbRenewalApp.Location = new System.Drawing.Point(10, 48);
            this.tbRenewalApp.Name = "tbRenewalApp";
            this.tbRenewalApp.Padding = new System.Windows.Forms.Padding(3);
            this.tbRenewalApp.Size = new System.Drawing.Size(2182, 1724);
            this.tbRenewalApp.TabIndex = 1;
            this.tbRenewalApp.Text = "Renew the driving license";
            // 
            // lblRenew
            // 
            this.lblRenew.AutoSize = true;
            this.lblRenew.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblRenew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRenew.Location = new System.Drawing.Point(1957, 1534);
            this.lblRenew.Name = "lblRenew";
            this.lblRenew.Size = new System.Drawing.Size(120, 35);
            this.lblRenew.TabIndex = 81;
            this.lblRenew.Text = "Renew";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(732, 934);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(1239, 154);
            this.txtNote.TabIndex = 79;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.lblNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNote.Location = new System.Drawing.Point(447, 986);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(154, 46);
            this.lblNote.TabIndex = 77;
            this.lblNote.Text = "Notes:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUsername.Location = new System.Drawing.Point(687, 757);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(243, 51);
            this.lblUsername.TabIndex = 68;
            this.lblUsername.Text = "Unknown";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(335, 757);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 46);
            this.label9.TabIndex = 66;
            this.label9.Text = "Created by:";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalFees.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalFees.Location = new System.Drawing.Point(1728, 571);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(243, 51);
            this.lblTotalFees.TabIndex = 64;
            this.lblTotalFees.Text = "Unknown";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(1336, 574);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(245, 46);
            this.label13.TabIndex = 63;
            this.label13.Text = "Total Fees:";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblLicenseFees.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblLicenseFees.Location = new System.Drawing.Point(697, 574);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(243, 51);
            this.lblLicenseFees.TabIndex = 61;
            this.lblLicenseFees.Text = "Unknown";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(295, 576);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(296, 46);
            this.label10.TabIndex = 60;
            this.label10.Text = "License Fees:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(1255, 409);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(377, 46);
            this.label12.TabIndex = 58;
            this.label12.Text = "Application Fees:";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppFees.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblAppFees.Location = new System.Drawing.Point(1728, 409);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(243, 51);
            this.lblAppFees.TabIndex = 57;
            this.lblAppFees.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(1308, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 46);
            this.label5.TabIndex = 53;
            this.label5.Text = "Old license ID:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblOldLicenseID.Location = new System.Drawing.Point(1728, 246);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(243, 51);
            this.lblOldLicenseID.TabIndex = 52;
            this.lblOldLicenseID.Text = "Unknown";
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.AutoSize = true;
            this.lblExpireDate.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpireDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblExpireDate.Location = new System.Drawing.Point(697, 412);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(243, 51);
            this.lblExpireDate.TabIndex = 51;
            this.lblExpireDate.Text = "Unknown";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(235, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(366, 46);
            this.label7.TabIndex = 48;
            this.label7.Text = "Expiration  date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(320, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(271, 46);
            this.label8.TabIndex = 47;
            this.label8.Text = "Relese date:";
            // 
            // lblReleseDate
            // 
            this.lblReleseDate.AutoSize = true;
            this.lblReleseDate.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblReleseDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblReleseDate.Location = new System.Drawing.Point(697, 244);
            this.lblReleseDate.Name = "lblReleseDate";
            this.lblReleseDate.Size = new System.Drawing.Size(243, 51);
            this.lblReleseDate.TabIndex = 37;
            this.lblReleseDate.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(1290, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 46);
            this.label3.TabIndex = 33;
            this.label3.Text = "New license ID:";
            // 
            // lblNewLicenseID
            // 
            this.lblNewLicenseID.AutoSize = true;
            this.lblNewLicenseID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblNewLicenseID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblNewLicenseID.Location = new System.Drawing.Point(1728, 92);
            this.lblNewLicenseID.Name = "lblNewLicenseID";
            this.lblNewLicenseID.Size = new System.Drawing.Size(243, 51);
            this.lblNewLicenseID.TabIndex = 34;
            this.lblNewLicenseID.Text = "Unknown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(74, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 46);
            this.label1.TabIndex = 30;
            this.label1.Text = "Renewal application ID:";
            // 
            // lblRenewalAppID
            // 
            this.lblRenewalAppID.AutoSize = true;
            this.lblRenewalAppID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblRenewalAppID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRenewalAppID.Location = new System.Drawing.Point(697, 92);
            this.lblRenewalAppID.Name = "lblRenewalAppID";
            this.lblRenewalAppID.Size = new System.Drawing.Size(243, 51);
            this.lblRenewalAppID.TabIndex = 31;
            this.lblRenewalAppID.Text = "Unknown";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnGoToRenewTab
            // 
            this.btnGoToRenewTab.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnGoToRenewTab.BackgroundImage = global::PresentationLayer.Properties.Resources.renewal;
            this.btnGoToRenewTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGoToRenewTab.Location = new System.Drawing.Point(1921, 1605);
            this.btnGoToRenewTab.Name = "btnGoToRenewTab";
            this.btnGoToRenewTab.Size = new System.Drawing.Size(197, 85);
            this.btnGoToRenewTab.TabIndex = 26;
            this.btnGoToRenewTab.UseVisualStyleBackColor = false;
            this.btnGoToRenewTab.Click += new System.EventHandler(this.btnGoToRenewTab_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.BackgroundImage = global::PresentationLayer.Properties.Resources.looking_for_answer;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(1225, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 85);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pbLicense
            // 
            this.pbLicense.Image = global::PresentationLayer.Properties.Resources.icense__1_3;
            this.pbLicense.Location = new System.Drawing.Point(435, 75);
            this.pbLicense.Name = "pbLicense";
            this.pbLicense.Size = new System.Drawing.Size(68, 55);
            this.pbLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLicense.TabIndex = 22;
            this.pbLicense.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::PresentationLayer.Properties.Resources.pilot_license;
            this.pictureBox9.Location = new System.Drawing.Point(74, 114);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(63, 39);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 27;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::PresentationLayer.Properties.Resources.icense__1_3;
            this.pictureBox8.Location = new System.Drawing.Point(74, 56);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(63, 39);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 26;
            this.pictureBox8.TabStop = false;
            // 
            // btnRenewLicense
            // 
            this.btnRenewLicense.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRenewLicense.BackgroundImage = global::PresentationLayer.Properties.Resources.renewal;
            this.btnRenewLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRenewLicense.Location = new System.Drawing.Point(1905, 1586);
            this.btnRenewLicense.Name = "btnRenewLicense";
            this.btnRenewLicense.Size = new System.Drawing.Size(216, 85);
            this.btnRenewLicense.TabIndex = 80;
            this.btnRenewLicense.UseVisualStyleBackColor = false;
            this.btnRenewLicense.Click += new System.EventHandler(this.btnRenewLicense_Click);
            // 
            // pbNote
            // 
            this.pbNote.Image = global::PresentationLayer.Properties.Resources.edit_info;
            this.pbNote.Location = new System.Drawing.Point(611, 959);
            this.pbNote.Name = "pbNote";
            this.pbNote.Size = new System.Drawing.Size(80, 82);
            this.pbNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNote.TabIndex = 78;
            this.pbNote.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::PresentationLayer.Properties.Resources.employee;
            this.pictureBox6.Location = new System.Drawing.Point(609, 740);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(72, 68);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 67;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.currency;
            this.pictureBox3.Location = new System.Drawing.Point(1650, 559);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 74);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 65;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::PresentationLayer.Properties.Resources.currency;
            this.pictureBox10.Location = new System.Drawing.Point(619, 559);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(72, 74);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 62;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::PresentationLayer.Properties.Resources.currency;
            this.pictureBox7.Location = new System.Drawing.Point(1650, 394);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(72, 74);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 59;
            this.pictureBox7.TabStop = false;
            // 
            // pbOldLicense
            // 
            this.pbOldLicense.Image = global::PresentationLayer.Properties.Resources.icense__1_;
            this.pbOldLicense.Location = new System.Drawing.Point(1650, 232);
            this.pbOldLicense.Name = "pbOldLicense";
            this.pbOldLicense.Size = new System.Drawing.Size(72, 71);
            this.pbOldLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOldLicense.TabIndex = 56;
            this.pbOldLicense.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PresentationLayer.Properties.Resources.expired;
            this.pictureBox5.Location = new System.Drawing.Point(619, 394);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(72, 81);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 50;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PresentationLayer.Properties.Resources.calendar;
            this.pictureBox4.Location = new System.Drawing.Point(619, 226);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(72, 69);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 49;
            this.pictureBox4.TabStop = false;
            // 
            // pbRenewalLicense
            // 
            this.pbRenewalLicense.Image = global::PresentationLayer.Properties.Resources.icense__1_;
            this.pbRenewalLicense.Location = new System.Drawing.Point(1650, 82);
            this.pbRenewalLicense.Name = "pbRenewalLicense";
            this.pbRenewalLicense.Size = new System.Drawing.Size(72, 71);
            this.pbRenewalLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRenewalLicense.TabIndex = 35;
            this.pbRenewalLicense.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.renewal1;
            this.pictureBox2.Location = new System.Drawing.Point(609, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // ucLocalLicenseDetails
            // 
            this.ucLocalLicenseDetails.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucLocalLicenseDetails.Location = new System.Drawing.Point(-29, 228);
            this.ucLocalLicenseDetails.Name = "ucLocalLicenseDetails";
            this.ucLocalLicenseDetails.Size = new System.Drawing.Size(2192, 1519);
            this.ucLocalLicenseDetails.TabIndex = 32;
            // 
            // ucInternationalLicenseDetails
            // 
            this.ucInternationalLicenseDetails.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucInternationalLicenseDetails.Location = new System.Drawing.Point(9, 221);
            this.ucInternationalLicenseDetails.Name = "ucInternationalLicenseDetails";
            this.ucInternationalLicenseDetails.Size = new System.Drawing.Size(2154, 1616);
            this.ucInternationalLicenseDetails.TabIndex = 33;
            // 
            // FrmRenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2225, 1941);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.tcRenewalApp);
            this.Name = "FrmRenewLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRenewLicense";
            this.Load += new System.EventHandler(this.FrmRenewLicense_Load);
            this.tcRenewalApp.ResumeLayout(false);
            this.tbSelectLicense.ResumeLayout(false);
            this.tbSelectLicense.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbRenewalApp.ResumeLayout(false);
            this.tbRenewalApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenewalLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.TabControl tcRenewalApp;
        private System.Windows.Forms.TabPage tbRenewalApp;
        private System.Windows.Forms.TabPage tbSelectLicense;
        private System.Windows.Forms.Label lblGoToRenewTab;
        private System.Windows.Forms.Button btnGoToRenewTab;
        private Local_License.ucLocalLicenseDetails ucLocalLicenseDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.PictureBox pbLicense;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.RadioButton rbInternational;
        private System.Windows.Forms.RadioButton rbLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRenewalAppID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNewLicenseID;
        private System.Windows.Forms.PictureBox pbRenewalLicense;
        private System.Windows.Forms.Label lblReleseDate;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbOldLicense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.PictureBox pbNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnRenewLicense;
        private System.Windows.Forms.Label lblRenew;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private International_License.ucInternationalLicenseDetails ucInternationalLicenseDetails;
        private International_License.ucInternationalLicenseDetails ucInternationalLicenseDetails1;
    }
}
