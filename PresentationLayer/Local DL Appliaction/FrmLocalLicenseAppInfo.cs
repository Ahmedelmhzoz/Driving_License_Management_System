using BusinessLayer.License_Applications;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmLocalLicenseAppInfo : Form {
        LocalLicenseApp licenseApp= null;
        public FrmLocalLicenseAppInfo(LocalLicenseApp licenseApp) {
            InitializeComponent();
            this.licenseApp = licenseApp;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmLocalLicenseAppInfo_Load(object sender, EventArgs e) {
            lblApplicationID.Text = licenseApp.LicenseAppID.ToString();
            lblLicenseClass.Text = licenseApp.LicenseClassID.ToString();
            LicenseClasses Class = LicenseClasses.getLicenseClassByID(licenseApp.LicenseClassID);
            lblLicenseClass.Text = Class != null ? Class.className : "Unknown";

            lblPassedExams.Text = LocalLicenseApp.getPassedExams(licenseApp.LicenseAppID).ToString();

            ucApplicationDetails1.loadData(licenseApp.getBasicApplication());

            if (licenseApp.appStatus == enApplicationStatus.enCompleted) {
                btnShowLicense.Enabled = true;
                lblLicense.ForeColor = Color.White;
            } 
        }

    }
}
