namespace PresentationLayer.Local_License {
    partial class FrmLocalLicenseDetails {
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
            this.lblTestType = new System.Windows.Forms.Label();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucLocalLicenseDetails1 = new PresentationLayer.Local_License.ucLocalLicenseDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestType
            // 
            this.lblTestType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTestType.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
            this.lblTestType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTestType.Location = new System.Drawing.Point(579, 154);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(971, 58);
            this.lblTestType.TabIndex = 37;
            this.lblTestType.Text = "Local driving license details";
            this.lblTestType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbTestType
            // 
            this.pbTestType.BackgroundImage = global::PresentationLayer.Properties.Resources.driving_license__3_;
            this.pbTestType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestType.Location = new System.Drawing.Point(941, -19);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(231, 196);
            this.pbTestType.TabIndex = 36;
            this.pbTestType.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1909, 1720);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(226, 49);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucLocalLicenseDetails1
            // 
            this.ucLocalLicenseDetails1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucLocalLicenseDetails1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLocalLicenseDetails1.Location = new System.Drawing.Point(-4, 236);
            this.ucLocalLicenseDetails1.Name = "ucLocalLicenseDetails1";
            this.ucLocalLicenseDetails1.Size = new System.Drawing.Size(2165, 1506);
            this.ucLocalLicenseDetails1.TabIndex = 0;
            // 
            // FrmLocalLicenseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(2152, 1787);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucLocalLicenseDetails1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmLocalLicenseDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLocalLicenseDetails";
            this.Load += new System.EventHandler(this.FrmLocalLicenseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucLocalLicenseDetails ucLocalLicenseDetails1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.PictureBox pbTestType;
    }
}