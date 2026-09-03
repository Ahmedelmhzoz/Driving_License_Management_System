using BusinessLayer;
using BusinessLayer.License_Applications;
using PresentationLayer.Local_License;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class ucLocalLicenseAppDetails : UserControl {
        public ucLocalLicenseAppDetails() {
            InitializeComponent();
        }
        LocalLicenseApp licenseApp = null;
        public void loadData(LocalLicenseApp licenseApp) {
            this.licenseApp = licenseApp;

            lblApplicationID.Text = licenseApp.LicenseAppID.ToString();
            lblLicenseClass.Text = licenseApp.LicenseClassID.ToString();
            LicenseClass Class = LicenseClass.getLicenseClassByID(licenseApp.LicenseClassID);
            lblLicenseClass.Text = Class != null ? Class.className : "Unknown";

            lblPassedExams.Text = LocalLicenseApp.getPassedExams(licenseApp.LicenseAppID).ToString();

            ucApplicationDetails1.loadData(licenseApp.getBasicApplication());

            if (licenseApp.appStatus == enApplicationStatus.enCompleted) {
                btnShowLicense.Enabled = true;
                lblLicense.ForeColor = Color.White;
            }
        }
        public void AnExamWasPassed() {
            int passedExams = Convert.ToInt32(lblPassedExams.Text);
            passedExams++;
            lblPassedExams.Text = passedExams.ToString();
        }

        private void btnShowLicense_Click(object sender, EventArgs e) {
            LocalLicense license = LocalLicense.GetLicenseByApplicationID(licenseApp.AppID);
            if (license == null) return;

            FrmLocalLicenseDetails frm = new FrmLocalLicenseDetails(license);
            frm.ShowDialog();
        }
    }
}
