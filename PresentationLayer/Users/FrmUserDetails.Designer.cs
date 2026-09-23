namespace PresentationLayer.Users {
    partial class FrmUserDetails {
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
            this.ucUserInformations1 = new PresentationLayer.Users.ucUserInformation();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(739, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 85);
            this.label1.TabIndex = 21;
            this.label1.Text = "User details";
            // 
            // ucUserInformations1
            // 
            this.ucUserInformations1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ucUserInformations1.Location = new System.Drawing.Point(12, 145);
            this.ucUserInformations1.Name = "ucUserInformations1";
            this.ucUserInformations1.Size = new System.Drawing.Size(1945, 1098);
            this.ucUserInformations1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Font = new System.Drawing.Font("Georgia", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Image = global::PresentationLayer.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1708, 1233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 80);
            this.button1.TabIndex = 20;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1962, 1351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucUserInformations1);
            this.Name = "FrmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUserDetails";
            this.Load += new System.EventHandler(this.FrmUserDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucUserInformation ucUserInformations1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}