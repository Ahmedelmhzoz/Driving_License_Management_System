namespace PresentationLayer.Local_DL_Appliaction {
    partial class FrmAddAppointment {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddAppointment));
            this.lblTestType = new System.Windows.Forms.Label();
            this.lblAppointmentLocked = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.Personi = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTestTrials = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblTestFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAddApointment = new System.Windows.Forms.Label();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblRetakeFees = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRetakeID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pbDescription = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbRetakeTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestType
            // 
            this.lblTestType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTestType.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.lblTestType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTestType.Location = new System.Drawing.Point(294, 286);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(675, 58);
            this.lblTestType.TabIndex = 30;
            this.lblTestType.Text = "Schedule vision test";
            this.lblTestType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAppointmentLocked
            // 
            this.lblAppointmentLocked.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAppointmentLocked.BackColor = System.Drawing.Color.Red;
            this.lblAppointmentLocked.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblAppointmentLocked.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAppointmentLocked.Location = new System.Drawing.Point(106, 344);
            this.lblAppointmentLocked.Name = "lblAppointmentLocked";
            this.lblAppointmentLocked.Size = new System.Drawing.Size(1029, 66);
            this.lblAppointmentLocked.TabIndex = 31;
            this.lblAppointmentLocked.Text = "person already sat for this test, appointment is locked";
            this.lblAppointmentLocked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppointmentLocked.Visible = false;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblApplicationID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblApplicationID.Location = new System.Drawing.Point(539, 526);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(167, 35);
            this.lblApplicationID.TabIndex = 33;
            this.lblApplicationID.Text = "Unknown";
            // 
            // Personi
            // 
            this.Personi.AutoSize = true;
            this.Personi.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.Personi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Personi.Location = new System.Drawing.Point(210, 526);
            this.Personi.Name = "Personi";
            this.Personi.Size = new System.Drawing.Size(226, 39);
            this.Personi.TabIndex = 32;
            this.Personi.Text = "D.L.App.ID:";
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblLicenseClass.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblLicenseClass.Location = new System.Drawing.Point(539, 728);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(167, 35);
            this.lblLicenseClass.TabIndex = 37;
            this.lblLicenseClass.Text = "Unknown";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(49, 724);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 39);
            this.label2.TabIndex = 35;
            this.label2.Text = "Applied license class:";
            // 
            // lblApplicantName
            // 
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblApplicantName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblApplicantName.Location = new System.Drawing.Point(539, 831);
            this.lblApplicantName.Name = "lblApplicantName";
            this.lblApplicantName.Size = new System.Drawing.Size(167, 35);
            this.lblApplicantName.TabIndex = 49;
            this.lblApplicantName.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(143, 830);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 39);
            this.label5.TabIndex = 48;
            this.label5.Text = "Applicant name:";
            // 
            // lblTestTrials
            // 
            this.lblTestTrials.AutoSize = true;
            this.lblTestTrials.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblTestTrials.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTestTrials.Location = new System.Drawing.Point(539, 939);
            this.lblTestTrials.Name = "lblTestTrials";
            this.lblTestTrials.Size = new System.Drawing.Size(167, 35);
            this.lblTestTrials.TabIndex = 52;
            this.lblTestTrials.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(232, 935);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 39);
            this.label4.TabIndex = 51;
            this.label4.Text = "Test trials:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(326, 622);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 39);
            this.label7.TabIndex = 54;
            this.label7.Text = "Date:";
            // 
            // dpAppointmentDate
            // 
            this.dpAppointmentDate.Location = new System.Drawing.Point(545, 623);
            this.dpAppointmentDate.Name = "dpAppointmentDate";
            this.dpAppointmentDate.Size = new System.Drawing.Size(531, 38);
            this.dpAppointmentDate.TabIndex = 57;
            // 
            // lblTestFees
            // 
            this.lblTestFees.AutoSize = true;
            this.lblTestFees.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblTestFees.ForeColor = System.Drawing.Color.Lime;
            this.lblTestFees.Location = new System.Drawing.Point(539, 1051);
            this.lblTestFees.Name = "lblTestFees";
            this.lblTestFees.Size = new System.Drawing.Size(167, 35);
            this.lblTestFees.TabIndex = 60;
            this.lblTestFees.Text = "Unknown";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(329, 1050);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 39);
            this.label6.TabIndex = 58;
            this.label6.Text = "Fees:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDescription.Location = new System.Drawing.Point(202, 1200);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(234, 39);
            this.lblDescription.TabIndex = 61;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(545, 1202);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(600, 254);
            this.txtDescription.TabIndex = 64;
            // 
            // lblAddApointment
            // 
            this.lblAddApointment.AutoSize = true;
            this.lblAddApointment.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold);
            this.lblAddApointment.ForeColor = System.Drawing.Color.White;
            this.lblAddApointment.Location = new System.Drawing.Point(1009, 1486);
            this.lblAddApointment.Name = "lblAddApointment";
            this.lblAddApointment.Size = new System.Drawing.Size(266, 31);
            this.lblAddApointment.TabIndex = 66;
            this.lblAddApointment.Text = "Save appointment";
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lblTotalFees);
            this.gbRetakeTest.Controls.Add(this.lblRetakeFees);
            this.gbRetakeTest.Controls.Add(this.pictureBox10);
            this.gbRetakeTest.Controls.Add(this.pictureBox7);
            this.gbRetakeTest.Controls.Add(this.label12);
            this.gbRetakeTest.Controls.Add(this.pictureBox8);
            this.gbRetakeTest.Controls.Add(this.label9);
            this.gbRetakeTest.Controls.Add(this.lblRetakeID);
            this.gbRetakeTest.Controls.Add(this.label10);
            this.gbRetakeTest.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRetakeTest.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gbRetakeTest.Location = new System.Drawing.Point(56, 1134);
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.Size = new System.Drawing.Size(1176, 349);
            this.gbRetakeTest.TabIndex = 68;
            this.gbRetakeTest.TabStop = false;
            this.gbRetakeTest.Text = "Retake test info.";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalFees.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalFees.Location = new System.Drawing.Point(310, 240);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(167, 35);
            this.lblTotalFees.TabIndex = 71;
            this.lblTotalFees.Text = "Unknown";
            // 
            // lblRetakeFees
            // 
            this.lblRetakeFees.AutoSize = true;
            this.lblRetakeFees.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetakeFees.ForeColor = System.Drawing.Color.Lime;
            this.lblRetakeFees.Location = new System.Drawing.Point(1085, 84);
            this.lblRetakeFees.Name = "lblRetakeFees";
            this.lblRetakeFees.Size = new System.Drawing.Size(52, 35);
            this.lblRetakeFees.TabIndex = 71;
            this.lblRetakeFees.Text = "$5";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::PresentationLayer.Properties.Resources.currency1;
            this.pictureBox10.Location = new System.Drawing.Point(236, 220);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(68, 59);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 70;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::PresentationLayer.Properties.Resources.test__1_;
            this.pictureBox7.Location = new System.Drawing.Point(236, 66);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(68, 55);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 71;
            this.pictureBox7.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(23, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 39);
            this.label12.TabIndex = 69;
            this.label12.Text = "Total Fees:";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::PresentationLayer.Properties.Resources.currency1;
            this.pictureBox8.Location = new System.Drawing.Point(1011, 66);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(68, 59);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 70;
            this.pictureBox8.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(23, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 39);
            this.label9.TabIndex = 69;
            this.label9.Text = "R.App.ID:";
            // 
            // lblRetakeID
            // 
            this.lblRetakeID.AutoSize = true;
            this.lblRetakeID.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetakeID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRetakeID.Location = new System.Drawing.Point(310, 85);
            this.lblRetakeID.Name = "lblRetakeID";
            this.lblRetakeID.Size = new System.Drawing.Size(167, 35);
            this.lblRetakeID.TabIndex = 70;
            this.lblRetakeID.Text = "Unknown";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(645, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(360, 39);
            this.label10.TabIndex = 69;
            this.label10.Text = "Retake test app fees";
            // 
            // pbDescription
            // 
            this.pbDescription.Image = global::PresentationLayer.Properties.Resources.edit_info;
            this.pbDescription.Location = new System.Drawing.Point(461, 1189);
            this.pbDescription.Name = "pbDescription";
            this.pbDescription.Size = new System.Drawing.Size(68, 59);
            this.pbDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDescription.TabIndex = 63;
            this.pbDescription.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(123, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 69;
            this.label1.Text = "Appointment ID:";
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.lblAppointmentID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblAppointmentID.Location = new System.Drawing.Point(539, 437);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(167, 35);
            this.lblAppointmentID.TabIndex = 71;
            this.lblAppointmentID.Text = "Unknown";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::PresentationLayer.Properties.Resources.calendar;
            this.pictureBox11.Location = new System.Drawing.Point(461, 413);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(68, 60);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 70;
            this.pictureBox11.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(559, 1535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 83);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAppointment.Image = global::PresentationLayer.Properties.Resources.save;
            this.btnAddAppointment.Location = new System.Drawing.Point(1080, 1535);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(152, 83);
            this.btnAddAppointment.TabIndex = 65;
            this.btnAddAppointment.UseVisualStyleBackColor = false;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PresentationLayer.Properties.Resources.currency1;
            this.pictureBox5.Location = new System.Drawing.Point(461, 1031);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(68, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::PresentationLayer.Properties.Resources.calendar;
            this.pictureBox6.Location = new System.Drawing.Point(461, 602);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(68, 60);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 56;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PresentationLayer.Properties.Resources.counter;
            this.pictureBox4.Location = new System.Drawing.Point(461, 914);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 60);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 53;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::PresentationLayer.Properties.Resources.application;
            this.pictureBox9.Location = new System.Drawing.Point(461, 810);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(68, 60);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 50;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.steering_wheel;
            this.pictureBox3.Location = new System.Drawing.Point(461, 709);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.job_application;
            this.pictureBox2.Location = new System.Drawing.Point(461, 510);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PresentationLayer.Properties.Resources.exam_time1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(524, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 280);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1287, 1643);
            this.Controls.Add(this.gbRetakeTest);
            this.Controls.Add(this.lblAppointmentID);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAddApointment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.pbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTestFees);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dpAppointmentDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblTestTrials);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLicenseClass);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblApplicationID);
            this.Controls.Add(this.Personi);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAppointmentLocked);
            this.Name = "FrmAddAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddAppointment";
            this.Load += new System.EventHandler(this.FrmAddAppointment_Load);
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.Label lblAppointmentLocked;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label Personi;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblTestTrials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dpAppointmentDate;
        private System.Windows.Forms.Label lblTestFees;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox pbDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Label lblAddApointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRetakeID;
        private System.Windows.Forms.Label lblRetakeFees;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lblAppointmentID;
    }
}