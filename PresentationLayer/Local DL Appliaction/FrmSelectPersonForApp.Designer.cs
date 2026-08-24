namespace PresentationLayer.Local_DL_Appliaction {
    partial class FrmSelectPersonForApp {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectPersonForApp));
            this.lblProcess = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcApplicationManagement = new System.Windows.Forms.TabControl();
            this.tpPerson = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucPersonDetails = new PresentationLayer.ucPersonDetails();
            this.ucGetPersonWithFilter = new PresentationLayer.Users.ucGetPersonWithFilter();
            this.tpAppInfo = new System.Windows.Forms.TabPage();
            this.lblSubmit = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmitApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tcApplicationManagement.SuspendLayout();
            this.tpPerson.SuspendLayout();
            this.tpAppInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.lblProcess.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProcess.Location = new System.Drawing.Point(448, 54);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(1367, 77);
            this.lblProcess.TabIndex = 25;
            this.lblProcess.Text = "New Local Driving License Application";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tcApplicationManagement
            // 
            this.tcApplicationManagement.Controls.Add(this.tpPerson);
            this.tcApplicationManagement.Controls.Add(this.tpAppInfo);
            this.tcApplicationManagement.Location = new System.Drawing.Point(41, 166);
            this.tcApplicationManagement.Name = "tcApplicationManagement";
            this.tcApplicationManagement.SelectedIndex = 0;
            this.tcApplicationManagement.Size = new System.Drawing.Size(2087, 1325);
            this.tcApplicationManagement.TabIndex = 23;
            this.tcApplicationManagement.SelectedIndexChanged += new System.EventHandler(this.tcAddUser_SelectedIndexChanged);
            // 
            // tpPerson
            // 
            this.tpPerson.BackColor = System.Drawing.Color.Black;
            this.tpPerson.Controls.Add(this.btnNext);
            this.tpPerson.Controls.Add(this.ucPersonDetails);
            this.tpPerson.Controls.Add(this.ucGetPersonWithFilter);
            this.tpPerson.Location = new System.Drawing.Point(10, 48);
            this.tpPerson.Name = "tpPerson";
            this.tpPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tpPerson.Size = new System.Drawing.Size(2067, 1267);
            this.tpPerson.TabIndex = 0;
            this.tpPerson.Text = "Find person";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNext.Enabled = false;
            this.btnNext.ForeColor = System.Drawing.Color.Transparent;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(1798, 1144);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(230, 83);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Next ";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucPersonDetails
            // 
            this.ucPersonDetails.BackColor = System.Drawing.SystemColors.WindowText;
            this.ucPersonDetails.Location = new System.Drawing.Point(64, 151);
            this.ucPersonDetails.Name = "ucPersonDetails";
            this.ucPersonDetails.Size = new System.Drawing.Size(1922, 855);
            this.ucPersonDetails.TabIndex = 21;
            // 
            // ucGetPersonWithFilter
            // 
            this.ucGetPersonWithFilter.BackColor = System.Drawing.Color.Black;
            this.ucGetPersonWithFilter.Location = new System.Drawing.Point(81, 6);
            this.ucGetPersonWithFilter.Name = "ucGetPersonWithFilter";
            this.ucGetPersonWithFilter.Size = new System.Drawing.Size(1961, 1237);
            this.ucGetPersonWithFilter.TabIndex = 0;
            // 
            // tpAppInfo
            // 
            this.tpAppInfo.BackColor = System.Drawing.Color.Black;
            this.tpAppInfo.Controls.Add(this.lblSubmit);
            this.tpAppInfo.Controls.Add(this.lblUser);
            this.tpAppInfo.Controls.Add(this.label7);
            this.tpAppInfo.Controls.Add(this.cbLicenseClasses);
            this.tpAppInfo.Controls.Add(this.lblDate);
            this.tpAppInfo.Controls.Add(this.pictureBox5);
            this.tpAppInfo.Controls.Add(this.pictureBox4);
            this.tpAppInfo.Controls.Add(this.pictureBox3);
            this.tpAppInfo.Controls.Add(this.pictureBox1);
            this.tpAppInfo.Controls.Add(this.pictureBox2);
            this.tpAppInfo.Controls.Add(this.label5);
            this.tpAppInfo.Controls.Add(this.lblAppFees);
            this.tpAppInfo.Controls.Add(this.label3);
            this.tpAppInfo.Controls.Add(this.label2);
            this.tpAppInfo.Controls.Add(this.lblID);
            this.tpAppInfo.Controls.Add(this.label1);
            this.tpAppInfo.Controls.Add(this.btnSubmitApp);
            this.tpAppInfo.Location = new System.Drawing.Point(10, 48);
            this.tpAppInfo.Name = "tpAppInfo";
            this.tpAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpAppInfo.Size = new System.Drawing.Size(2067, 1267);
            this.tpAppInfo.TabIndex = 1;
            this.tpAppInfo.Text = "Application info.";
            // 
            // lblSubmit
            // 
            this.lblSubmit.AutoSize = true;
            this.lblSubmit.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSubmit.Location = new System.Drawing.Point(1672, 1083);
            this.lblSubmit.Name = "lblSubmit";
            this.lblSubmit.Size = new System.Drawing.Size(367, 35);
            this.lblSubmit.TabIndex = 46;
            this.lblSubmit.Text = "Submit the application";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUser.Location = new System.Drawing.Point(689, 649);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(259, 54);
            this.lblUser.TabIndex = 45;
            this.lblUser.Text = "Unknown";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label7.Location = new System.Drawing.Point(689, 530);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 54);
            this.label7.TabIndex = 44;
            this.label7.Text = "$15";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(698, 419);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(478, 39);
            this.cbLicenseClasses.TabIndex = 43;
            this.cbLicenseClasses.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClasses_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDate.Location = new System.Drawing.Point(689, 304);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(259, 54);
            this.lblDate.TabIndex = 42;
            this.lblDate.Text = "Unknown";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(608, 196);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 40;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(608, 649);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(55, 52);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(608, 530);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 53);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(608, 419);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(608, 304);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(277, 649);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 54);
            this.label5.TabIndex = 32;
            this.label5.Text = "Created by:";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppFees.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAppFees.Location = new System.Drawing.Point(145, 529);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(430, 54);
            this.lblAppFees.TabIndex = 30;
            this.lblAppFees.Text = "Application fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(213, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 54);
            this.label3.TabIndex = 28;
            this.label3.Text = "License Class:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(136, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(439, 54);
            this.label2.TabIndex = 26;
            this.label2.Text = "Application date:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblID.Location = new System.Drawing.Point(689, 181);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(259, 54);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "Unknown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(80, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 54);
            this.label1.TabIndex = 24;
            this.label1.Text = "D.L.Application ID:";
            // 
            // btnSubmitApp
            // 
            this.btnSubmitApp.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSubmitApp.BackgroundImage = global::PresentationLayer.Properties.Resources.job_application;
            this.btnSubmitApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubmitApp.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitApp.ForeColor = System.Drawing.Color.Transparent;
            this.btnSubmitApp.Location = new System.Drawing.Point(1752, 1134);
            this.btnSubmitApp.Name = "btnSubmitApp";
            this.btnSubmitApp.Size = new System.Drawing.Size(230, 83);
            this.btnSubmitApp.TabIndex = 20;
            this.btnSubmitApp.UseVisualStyleBackColor = false;
            this.btnSubmitApp.Click += new System.EventHandler(this.btnSubmitApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1988, 1510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 83);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmSelectPersonForApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2230, 1614);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcApplicationManagement);
            this.Name = "FrmSelectPersonForApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelectPersonForApp";
            this.Load += new System.EventHandler(this.FrmSelectPersonForApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tcApplicationManagement.ResumeLayout(false);
            this.tpPerson.ResumeLayout(false);
            this.tpAppInfo.ResumeLayout(false);
            this.tpAppInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tcApplicationManagement;
        private System.Windows.Forms.TabPage tpPerson;
        private System.Windows.Forms.Button btnNext;
        private Users.ucGetPersonWithFilter ucGetPersonWithFilter;
        private ucPersonDetails ucPersonDetails;
        private System.Windows.Forms.TabPage tpAppInfo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmitApp;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSubmit;
    }
}