namespace PresentationLayer {
    partial class FrmPeople {
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsNo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.personID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThirdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(1230, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 77);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage people";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personID,
            this.NationalNo,
            this.firstName,
            this.secondName,
            this.ThirdName,
            this.LastName,
            this.Gender,
            this.DateOfBirth,
            this.Nationality,
            this.Phone,
            this.Email});
            this.dgvPeople.Location = new System.Drawing.Point(30, 638);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.RowHeadersWidth = 102;
            this.dgvPeople.RowTemplate.Height = 40;
            this.dgvPeople.Size = new System.Drawing.Size(2851, 843);
            this.dgvPeople.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(49, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(315, 577);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(352, 39);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(704, 578);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 38);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(51, 1505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Records: ";
            // 
            // lblRecordsNo
            // 
            this.lblRecordsNo.AutoSize = true;
            this.lblRecordsNo.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRecordsNo.Location = new System.Drawing.Point(251, 1505);
            this.lblRecordsNo.Name = "lblRecordsNo";
            this.lblRecordsNo.Size = new System.Drawing.Size(186, 39);
            this.lblRecordsNo.TabIndex = 7;
            this.lblRecordsNo.Text = "Unknown";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Image = global::PresentationLayer.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(2659, 1495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddPerson.Image = global::PresentationLayer.Properties.Resources.AddPerson;
            this.btnAddPerson.Location = new System.Drawing.Point(2678, 512);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(159, 104);
            this.btnAddPerson.TabIndex = 8;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.management;
            this.pictureBox1.Location = new System.Drawing.Point(1354, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // personID
            // 
            this.personID.DataPropertyName = "PersonID";
            this.personID.HeaderText = "Person ID";
            this.personID.MinimumWidth = 12;
            this.personID.Name = "personID";
            // 
            // NationalNo
            // 
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.HeaderText = "Nationa No.";
            this.NationalNo.MinimumWidth = 12;
            this.NationalNo.Name = "NationalNo";
            // 
            // firstName
            // 
            this.firstName.DataPropertyName = "FirstName";
            this.firstName.HeaderText = "First Name";
            this.firstName.MinimumWidth = 12;
            this.firstName.Name = "firstName";
            // 
            // secondName
            // 
            this.secondName.DataPropertyName = "SecondName";
            this.secondName.HeaderText = "Second Name";
            this.secondName.MinimumWidth = 12;
            this.secondName.Name = "secondName";
            // 
            // ThirdName
            // 
            this.ThirdName.DataPropertyName = "ThirdName";
            this.ThirdName.HeaderText = "Third Name";
            this.ThirdName.MinimumWidth = 12;
            this.ThirdName.Name = "ThirdName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.MinimumWidth = 12;
            this.LastName.Name = "LastName";
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 12;
            this.Gender.Name = "Gender";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "Date Of Birth";
            this.DateOfBirth.MinimumWidth = 12;
            this.DateOfBirth.Name = "DateOfBirth";
            // 
            // Nationality
            // 
            this.Nationality.DataPropertyName = "CountryName";
            this.Nationality.HeaderText = "Nationality";
            this.Nationality.MinimumWidth = 12;
            this.Nationality.Name = "Nationality";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 12;
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 12;
            this.Email.Name = "Email";
            // 
            // FrmPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2893, 1566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.lblRecordsNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage people";
            this.Load += new System.EventHandler(this.FrmPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsNo;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn personID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThirdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}