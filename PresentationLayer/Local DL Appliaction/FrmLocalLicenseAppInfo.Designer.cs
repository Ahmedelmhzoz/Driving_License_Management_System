namespace PresentationLayer.Local_DL_Appliaction {
    partial class FrmLocalLicenseAppInfo {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalLicenseAppInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucLocalDrivingLicenseDetails = new PresentationLayer.Local_DL_Appliaction.ucLocalDrivingLicenseDetails();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(515, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1433, 77);
            this.label1.TabIndex = 28;
            this.label1.Text = "Local driving license applications details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(2189, 1308);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 83);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucLocalDrivingLicenseDetails
            // 
            this.ucLocalDrivingLicenseDetails.BackColor = System.Drawing.SystemColors.ControlText;
            this.ucLocalDrivingLicenseDetails.Location = new System.Drawing.Point(50, 140);
            this.ucLocalDrivingLicenseDetails.Name = "ucLocalDrivingLicenseDetails";
            this.ucLocalDrivingLicenseDetails.Size = new System.Drawing.Size(2369, 1151);
            this.ucLocalDrivingLicenseDetails.TabIndex = 32;
            // 
            // FrmLocalLicenseAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(2447, 1413);
            this.Controls.Add(this.ucLocalDrivingLicenseDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "FrmLocalLicenseAppInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLocalLicenseAppInfo";
            this.Load += new System.EventHandler(this.FrmLocalLicenseAppInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private ucLocalDrivingLicenseDetails ucLocalDrivingLicenseDetails;
    }
}