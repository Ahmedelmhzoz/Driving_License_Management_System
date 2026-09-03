namespace PresentationLayer.International_License {
    partial class FrmInternationalLicenseDetails {
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
            this.ucInternationalLicenseDetails = new PresentationLayer.International_License.ucInternationalLicenseDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTestType = new System.Windows.Forms.Label();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // ucInternationalLicenseDetails
            // 
            this.ucInternationalLicenseDetails.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucInternationalLicenseDetails.Location = new System.Drawing.Point(9, 256);
            this.ucInternationalLicenseDetails.Name = "ucInternationalLicenseDetails";
            this.ucInternationalLicenseDetails.Size = new System.Drawing.Size(1920, 1389);
            this.ucInternationalLicenseDetails.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1716, 1649);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 49);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTestType
            // 
            this.lblTestType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTestType.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.lblTestType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTestType.Location = new System.Drawing.Point(503, 211);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(914, 58);
            this.lblTestType.TabIndex = 39;
            this.lblTestType.Text = "International driving license details";
            this.lblTestType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbTestType
            // 
            this.pbTestType.BackgroundImage = global::PresentationLayer.Properties.Resources.pilot_license;
            this.pbTestType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestType.Location = new System.Drawing.Point(879, 12);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(217, 196);
            this.pbTestType.TabIndex = 38;
            this.pbTestType.TabStop = false;
            // 
            // FrmInternationalLicenseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1941, 1710);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucInternationalLicenseDetails);
            this.Name = "FrmInternationalLicenseDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInternationalLicenseDetails";
            this.Load += new System.EventHandler(this.FrmInternationalLicenseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucInternationalLicenseDetails ucInternationalLicenseDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.PictureBox pbTestType;
    }
}