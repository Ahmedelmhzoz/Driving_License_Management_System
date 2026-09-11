namespace PresentationLayer.Detain_license {
    partial class FrmDetainLicense {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetainLicense));
            this.lblDetain = new System.Windows.Forms.Label();
            this.lblGoToDetainTab = new System.Windows.Forms.Label();
            this.tcDetainLicense = new System.Windows.Forms.TabControl();
            this.tbSelectLicense = new System.Windows.Forms.TabPage();
            this.btnGoToDetainTab = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.pbLicense = new System.Windows.Forms.PictureBox();
            this.ucLocalLicenseDetails = new PresentationLayer.Local_License.ucLocalLicenseDetails();
            this.tbDetain = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtDetainReason = new System.Windows.Forms.TextBox();
            this.nFine = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pbRenewalLicense = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnDetain = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tcDetainLicense.SuspendLayout();
            this.tbSelectLicense.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicense)).BeginInit();
            this.tbDetain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenewalLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetain
            // 
            this.lblDetain.AutoSize = true;
            this.lblDetain.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDetain.Location = new System.Drawing.Point(1967, 1536);
            this.lblDetain.Name = "lblDetain";
            this.lblDetain.Size = new System.Drawing.Size(119, 35);
            this.lblDetain.TabIndex = 81;
            this.lblDetain.Text = "Detain";
            // 
            // lblGoToDetainTab
            // 
            this.lblGoToDetainTab.AutoSize = true;
            this.lblGoToDetainTab.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblGoToDetainTab.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblGoToDetainTab.Location = new System.Drawing.Point(1955, 1535);
            this.lblGoToDetainTab.Name = "lblGoToDetainTab";
            this.lblGoToDetainTab.Size = new System.Drawing.Size(119, 35);
            this.lblGoToDetainTab.TabIndex = 27;
            this.lblGoToDetainTab.Text = "Detain";
            // 
            // tcDetainLicense
            // 
            this.tcDetainLicense.Controls.Add(this.tbSelectLicense);
            this.tcDetainLicense.Controls.Add(this.tbDetain);
            this.tcDetainLicense.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcDetainLicense.Location = new System.Drawing.Point(11, 135);
            this.tcDetainLicense.Name = "tcDetainLicense";
            this.tcDetainLicense.SelectedIndex = 0;
            this.tcDetainLicense.Size = new System.Drawing.Size(2202, 1782);
            this.tcDetainLicense.TabIndex = 28;
            this.tcDetainLicense.SelectedIndexChanged += new System.EventHandler(this.tcDetainLicense_SelectedIndexChanged);
            // 
            // tbSelectLicense
            // 
            this.tbSelectLicense.BackColor = System.Drawing.Color.Black;
            this.tbSelectLicense.Controls.Add(this.lblGoToDetainTab);
            this.tbSelectLicense.Controls.Add(this.btnGoToDetainTab);
            this.tbSelectLicense.Controls.Add(this.groupBox1);
            this.tbSelectLicense.Controls.Add(this.ucLocalLicenseDetails);
            this.tbSelectLicense.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectLicense.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbSelectLicense.Location = new System.Drawing.Point(10, 48);
            this.tbSelectLicense.Name = "tbSelectLicense";
            this.tbSelectLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tbSelectLicense.Size = new System.Drawing.Size(2182, 1724);
            this.tbSelectLicense.TabIndex = 0;
            this.tbSelectLicense.Text = "Select license";
            // 
            // btnGoToDetainTab
            // 
            this.btnGoToDetainTab.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnGoToDetainTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGoToDetainTab.Image = global::PresentationLayer.Properties.Resources.preventive__1_;
            this.btnGoToDetainTab.Location = new System.Drawing.Point(1921, 1580);
            this.btnGoToDetainTab.Name = "btnGoToDetainTab";
            this.btnGoToDetainTab.Size = new System.Drawing.Size(197, 85);
            this.btnGoToDetainTab.TabIndex = 26;
            this.btnGoToDetainTab.UseVisualStyleBackColor = false;
            this.btnGoToDetainTab.Click += new System.EventHandler(this.btnGoToDetainTab_Click);
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
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(1225, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 85);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(523, 87);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 38);
            this.txtSearch.TabIndex = 25;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
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
            // pbLicense
            // 
            this.pbLicense.Image = ((System.Drawing.Image)(resources.GetObject("pbLicense.Image")));
            this.pbLicense.Location = new System.Drawing.Point(435, 75);
            this.pbLicense.Name = "pbLicense";
            this.pbLicense.Size = new System.Drawing.Size(68, 55);
            this.pbLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLicense.TabIndex = 22;
            this.pbLicense.TabStop = false;
            // 
            // ucLocalLicenseDetails
            // 
            this.ucLocalLicenseDetails.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucLocalLicenseDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLocalLicenseDetails.Location = new System.Drawing.Point(3, 229);
            this.ucLocalLicenseDetails.Name = "ucLocalLicenseDetails";
            this.ucLocalLicenseDetails.Size = new System.Drawing.Size(2162, 1519);
            this.ucLocalLicenseDetails.TabIndex = 33;
            // 
            // tbDetain
            // 
            this.tbDetain.BackColor = System.Drawing.Color.Black;
            this.tbDetain.Controls.Add(this.groupBox2);
            this.tbDetain.Controls.Add(this.groupBox3);
            this.tbDetain.Controls.Add(this.lblDetain);
            this.tbDetain.Controls.Add(this.btnDetain);
            this.tbDetain.Location = new System.Drawing.Point(10, 48);
            this.tbDetain.Name = "tbDetain";
            this.tbDetain.Padding = new System.Windows.Forms.Padding(3);
            this.tbDetain.Size = new System.Drawing.Size(2182, 1724);
            this.tbDetain.TabIndex = 1;
            this.tbDetain.Text = "Release the driving license";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.txtDetainReason);
            this.groupBox2.Controls.Add(this.nFine);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.pictureBox8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Location = new System.Drawing.Point(55, 623);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2034, 652);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detain reason";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(111, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 46);
            this.label4.TabIndex = 102;
            this.label4.Text = "Detain reason:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.data;
            this.pictureBox1.Location = new System.Drawing.Point(442, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // txtDetainReason
            // 
            this.txtDetainReason.Location = new System.Drawing.Point(553, 112);
            this.txtDetainReason.Multiline = true;
            this.txtDetainReason.Name = "txtDetainReason";
            this.txtDetainReason.Size = new System.Drawing.Size(779, 212);
            this.txtDetainReason.TabIndex = 101;
            // 
            // nFine
            // 
            this.nFine.Location = new System.Drawing.Point(547, 468);
            this.nFine.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nFine.Name = "nFine";
            this.nFine.Size = new System.Drawing.Size(449, 38);
            this.nFine.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(75, 804);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(325, 46);
            this.label6.TabIndex = 87;
            this.label6.Text = "Detain reason:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.data;
            this.pictureBox3.Location = new System.Drawing.Point(406, 788);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(517, 800);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(779, 212);
            this.textBox1.TabIndex = 79;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::PresentationLayer.Properties.Resources.salary1;
            this.pictureBox8.Location = new System.Drawing.Point(442, 445);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(70, 75);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 91;
            this.pictureBox8.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(122, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(298, 46);
            this.label10.TabIndex = 90;
            this.label10.Text = "Fine amount:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.pictureBox4);
            this.groupBox3.Controls.Add(this.lblUsername);
            this.groupBox3.Controls.Add(this.lblDetainID);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblDetainDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblLicenseID);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.pbRenewalLicense);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox3.Location = new System.Drawing.Point(52, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(2034, 475);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detain details ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(186, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 46);
            this.label1.TabIndex = 30;
            this.label1.Text = "Detain ID:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.preventive__1_;
            this.pictureBox2.Location = new System.Drawing.Point(438, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(440, 263);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(72, 69);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 49;
            this.pictureBox4.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUsername.Location = new System.Drawing.Point(1588, 283);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(243, 51);
            this.lblUsername.TabIndex = 68;
            this.lblUsername.Text = "Unknown";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblDetainID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDetainID.Location = new System.Drawing.Point(526, 96);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(243, 51);
            this.lblDetainID.TabIndex = 31;
            this.lblDetainID.Text = "Unknown";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(1206, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 46);
            this.label9.TabIndex = 66;
            this.label9.Text = "Created by:";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblDetainDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDetainDate.Location = new System.Drawing.Point(526, 273);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(243, 51);
            this.lblDetainDate.TabIndex = 37;
            this.lblDetainDate.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(1240, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 46);
            this.label3.TabIndex = 33;
            this.label3.Text = "License ID:";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Bold);
            this.lblLicenseID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblLicenseID.Location = new System.Drawing.Point(1602, 91);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(243, 51);
            this.lblLicenseID.TabIndex = 34;
            this.lblLicenseID.Text = "Unknown";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(141, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(273, 46);
            this.label8.TabIndex = 47;
            this.label8.Text = "Detain date:";
            // 
            // pbRenewalLicense
            // 
            this.pbRenewalLicense.Image = ((System.Drawing.Image)(resources.GetObject("pbRenewalLicense.Image")));
            this.pbRenewalLicense.Location = new System.Drawing.Point(1515, 81);
            this.pbRenewalLicense.Name = "pbRenewalLicense";
            this.pbRenewalLicense.Size = new System.Drawing.Size(72, 71);
            this.pbRenewalLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRenewalLicense.TabIndex = 35;
            this.pbRenewalLicense.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(1501, 269);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(72, 68);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 67;
            this.pictureBox6.TabStop = false;
            // 
            // btnDetain
            // 
            this.btnDetain.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetain.Image = global::PresentationLayer.Properties.Resources.preventive__1_;
            this.btnDetain.Location = new System.Drawing.Point(1918, 1586);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(216, 85);
            this.btnDetain.TabIndex = 80;
            this.btnDetain.UseVisualStyleBackColor = false;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.lblProcess.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProcess.Location = new System.Drawing.Point(510, 35);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(1255, 77);
            this.lblProcess.TabIndex = 29;
            this.lblProcess.Text = "Detain license";
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PresentationLayer.Properties.Resources.refuse;
            this.pictureBox5.Location = new System.Drawing.Point(768, 19);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(130, 99);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // FrmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(2225, 1941);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.tcDetainLicense);
            this.Controls.Add(this.lblProcess);
            this.Name = "FrmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetainLicense";
            this.tcDetainLicense.ResumeLayout(false);
            this.tbSelectLicense.ResumeLayout(false);
            this.tbSelectLicense.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicense)).EndInit();
            this.tbDetain.ResumeLayout(false);
            this.tbDetain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenewalLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDetain;
        private System.Windows.Forms.Button btnGoToDetainTab;
        private System.Windows.Forms.Label lblGoToDetainTab;
        private System.Windows.Forms.TabControl tcDetainLicense;
        private System.Windows.Forms.TabPage tbSelectLicense;
        private Local_License.ucLocalLicenseDetails ucLocalLicenseDetails;
        private System.Windows.Forms.TabPage tbDetain;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.PictureBox pbLicense;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDetainReason;
        private System.Windows.Forms.NumericUpDown nFine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbRenewalLicense;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}