namespace PresentationLayer.Users {
    partial class FrmAddOrUpdateUser {
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
            this.tcAddUser = new System.Windows.Forms.TabControl();
            this.tpPerson = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucGetPersonWithFilter = new PresentationLayer.Users.ucGetPersonWithFilter();
            this.ucPersonDetails = new PresentationLayer.ucPersonDetails();
            this.tpCreateUser = new System.Windows.Forms.TabPage();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPasswordConf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.tcAddUser.SuspendLayout();
            this.tpPerson.SuspendLayout();
            this.tpCreateUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAddUser
            // 
            this.tcAddUser.Controls.Add(this.tpPerson);
            this.tcAddUser.Controls.Add(this.tpCreateUser);
            this.tcAddUser.Location = new System.Drawing.Point(70, 163);
            this.tcAddUser.Name = "tcAddUser";
            this.tcAddUser.SelectedIndex = 0;
            this.tcAddUser.Size = new System.Drawing.Size(2087, 1325);
            this.tcAddUser.TabIndex = 0;
            this.tcAddUser.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            this.btnNext.Image = global::PresentationLayer.Properties.Resources.next_2;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(1798, 1144);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(230, 83);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Next ";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucGetPersonWithFilter
            // 
            this.ucGetPersonWithFilter.BackColor = System.Drawing.Color.Black;
            this.ucGetPersonWithFilter.Location = new System.Drawing.Point(81, 6);
            this.ucGetPersonWithFilter.Name = "ucGetPersonWithFilter";
            this.ucGetPersonWithFilter.Size = new System.Drawing.Size(1961, 1237);
            this.ucGetPersonWithFilter.TabIndex = 0;
            // 
            // ucPersonDetails
            // 
            this.ucPersonDetails.BackColor = System.Drawing.SystemColors.WindowText;
            this.ucPersonDetails.Location = new System.Drawing.Point(69, 155);
            this.ucPersonDetails.Name = "ucPersonDetails";
            this.ucPersonDetails.Size = new System.Drawing.Size(1922, 855);
            this.ucPersonDetails.TabIndex = 21;
            // 
            // tpCreateUser
            // 
            this.tpCreateUser.BackColor = System.Drawing.Color.Black;
            this.tpCreateUser.Controls.Add(this.pictureBox6);
            this.tpCreateUser.Controls.Add(this.pictureBox5);
            this.tpCreateUser.Controls.Add(this.pictureBox4);
            this.tpCreateUser.Controls.Add(this.pictureBox3);
            this.tpCreateUser.Controls.Add(this.pictureBox1);
            this.tpCreateUser.Controls.Add(this.pictureBox2);
            this.tpCreateUser.Controls.Add(this.lblPersonID);
            this.tpCreateUser.Controls.Add(this.label6);
            this.tpCreateUser.Controls.Add(this.chkActive);
            this.tpCreateUser.Controls.Add(this.label5);
            this.tpCreateUser.Controls.Add(this.txtPasswordConf);
            this.tpCreateUser.Controls.Add(this.label4);
            this.tpCreateUser.Controls.Add(this.txtPassword);
            this.tpCreateUser.Controls.Add(this.label3);
            this.tpCreateUser.Controls.Add(this.txtUsername);
            this.tpCreateUser.Controls.Add(this.label2);
            this.tpCreateUser.Controls.Add(this.lblID);
            this.tpCreateUser.Controls.Add(this.label1);
            this.tpCreateUser.Controls.Add(this.btnSave);
            this.tpCreateUser.Location = new System.Drawing.Point(10, 48);
            this.tpCreateUser.Name = "tpCreateUser";
            this.tpCreateUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreateUser.Size = new System.Drawing.Size(2067, 1267);
            this.tpCreateUser.TabIndex = 1;
            this.tpCreateUser.Text = "Create user";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::PresentationLayer.Properties.Resources.id_card;
            this.pictureBox6.Location = new System.Drawing.Point(1574, 157);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(64, 39);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 41;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PresentationLayer.Properties.Resources.id_card;
            this.pictureBox5.Location = new System.Drawing.Point(586, 157);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 40;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PresentationLayer.Properties.Resources.employee;
            this.pictureBox4.Location = new System.Drawing.Point(586, 610);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(55, 52);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.passwordConfirm;
            this.pictureBox3.Location = new System.Drawing.Point(586, 489);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.padlock;
            this.pictureBox1.Location = new System.Drawing.Point(586, 380);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.name;
            this.pictureBox2.Location = new System.Drawing.Point(586, 265);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblPersonID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPersonID.Location = new System.Drawing.Point(1644, 142);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(259, 54);
            this.lblPersonID.TabIndex = 35;
            this.lblPersonID.Text = "Unknown";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(1286, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(282, 54);
            this.label6.TabIndex = 34;
            this.label6.Text = "Person ID:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(676, 626);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(191, 36);
            this.chkActive.TabIndex = 33;
            this.chkActive.Text = "checkBox1";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(330, 610);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 54);
            this.label5.TabIndex = 32;
            this.label5.Text = "Is active:";
            // 
            // txtPasswordConf
            // 
            this.txtPasswordConf.Location = new System.Drawing.Point(676, 505);
            this.txtPasswordConf.Name = "txtPasswordConf";
            this.txtPasswordConf.PasswordChar = '*';
            this.txtPasswordConf.Size = new System.Drawing.Size(366, 38);
            this.txtPasswordConf.TabIndex = 31;
            this.txtPasswordConf.TextChanged += new System.EventHandler(this.AnyChangeInInput);
            this.txtPasswordConf.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasswordConf_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(82, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 54);
            this.label4.TabIndex = 30;
            this.label4.Text = "Confirm password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(676, 381);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(366, 38);
            this.txtPassword.TabIndex = 29;
            this.txtPassword.TextChanged += new System.EventHandler(this.AnyChangeInInput);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(295, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 54);
            this.label3.TabIndex = 28;
            this.label3.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(676, 265);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(366, 38);
            this.txtUsername.TabIndex = 27;
            this.txtUsername.TextChanged += new System.EventHandler(this.AnyChangeInInput);
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(281, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 54);
            this.label2.TabIndex = 26;
            this.label2.Text = "Username:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblID.Location = new System.Drawing.Point(667, 142);
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
            this.label1.Location = new System.Drawing.Point(470, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 54);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = global::PresentationLayer.Properties.Resources.save1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1795, 1146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 83);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.lblProcess.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProcess.Location = new System.Drawing.Point(910, 62);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(500, 77);
            this.lblProcess.TabIndex = 22;
            this.lblProcess.Text = "Add new user";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::PresentationLayer.Properties.Resources.close1;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1988, 1506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 83);
            this.button2.TabIndex = 21;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmAddOrUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2230, 1614);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tcAddUser);
            this.Name = "FrmAddOrUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddUser";
            this.Load += new System.EventHandler(this.FrmAddUser_Load);
            this.tcAddUser.ResumeLayout(false);
            this.tpPerson.ResumeLayout(false);
            this.tpCreateUser.ResumeLayout(false);
            this.tpCreateUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcAddUser;
        private System.Windows.Forms.TabPage tpPerson;
        private ucGetPersonWithFilter ucGetPersonWithFilter;
        private System.Windows.Forms.TabPage tpCreateUser;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPasswordConf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private ucPersonDetails ucPersonDetails;
    }
}