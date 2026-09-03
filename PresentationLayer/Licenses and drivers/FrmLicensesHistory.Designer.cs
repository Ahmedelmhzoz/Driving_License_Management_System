namespace PresentationLayer.Licenses {
    partial class FrmLicensesHistory {
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
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucDrivingLicenses = new PresentationLayer.Licenses.ucDrivingLicenses();
            this.ucPersonDetails = new PresentationLayer.ucPersonDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(712, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 77);
            this.label1.TabIndex = 38;
            this.label1.Text = "Licenses history";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTestType
            // 
            this.pbTestType.BackgroundImage = global::PresentationLayer.Properties.Resources.history2;
            this.pbTestType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestType.Location = new System.Drawing.Point(810, -41);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(414, 288);
            this.pbTestType.TabIndex = 37;
            this.pbTestType.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1773, 1874);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 49);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucDrivingLicenses
            // 
            this.ucDrivingLicenses.BackColor = System.Drawing.SystemColors.ControlText;
            this.ucDrivingLicenses.Location = new System.Drawing.Point(53, 1153);
            this.ucDrivingLicenses.Name = "ucDrivingLicenses";
            this.ucDrivingLicenses.Size = new System.Drawing.Size(1922, 783);
            this.ucDrivingLicenses.TabIndex = 40;
            // 
            // ucPersonDetails
            // 
            this.ucPersonDetails.BackColor = System.Drawing.SystemColors.WindowText;
            this.ucPersonDetails.Location = new System.Drawing.Point(39, 304);
            this.ucPersonDetails.Name = "ucPersonDetails";
            this.ucPersonDetails.Size = new System.Drawing.Size(1922, 855);
            this.ucPersonDetails.TabIndex = 39;
            // 
            // FrmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1998, 1934);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDrivingLicenses);
            this.Controls.Add(this.ucPersonDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTestType);
            this.Name = "FrmLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLicensesHistory";
            this.Load += new System.EventHandler(this.FrmLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.Label label1;
        private ucPersonDetails ucPersonDetails;
        private ucDrivingLicenses ucDrivingLicenses;
        private System.Windows.Forms.Button btnClose;
    }
}