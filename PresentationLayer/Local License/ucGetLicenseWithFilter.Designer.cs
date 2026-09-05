namespace PresentationLayer.Licenses_and_drivers {
    partial class ucGetLicenseWithFilter {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.pbLicense = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucLocalLicenseDetails1 = new PresentationLayer.Local_License.ucLocalLicenseDetails();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblLicenseType);
            this.groupBox1.Controls.Add(this.pbLicense);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(15, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1483, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search for local license";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(523, 87);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 38);
            this.txtSearch.TabIndex = 25;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(1270, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 35);
            this.label1.TabIndex = 24;
            this.label1.Text = "Search";
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
            this.pbLicense.Image = global::PresentationLayer.Properties.Resources.icense__1_3;
            this.pbLicense.Location = new System.Drawing.Point(435, 75);
            this.pbLicense.Name = "pbLicense";
            this.pbLicense.Size = new System.Drawing.Size(68, 55);
            this.pbLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLicense.TabIndex = 22;
            this.pbLicense.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucLocalLicenseDetails1
            // 
            this.ucLocalLicenseDetails1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucLocalLicenseDetails1.Location = new System.Drawing.Point(-33, 185);
            this.ucLocalLicenseDetails1.Name = "ucLocalLicenseDetails1";
            this.ucLocalLicenseDetails1.Size = new System.Drawing.Size(1953, 1562);
            this.ucLocalLicenseDetails1.TabIndex = 0;
            // 
            // ucGetLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucLocalLicenseDetails1);
            this.Name = "ucGetLicenseWithFilter";
            this.Size = new System.Drawing.Size(1910, 1659);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Local_License.ucLocalLicenseDetails ucLocalLicenseDetails1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.PictureBox pbLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
