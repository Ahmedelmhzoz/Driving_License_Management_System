using BusinessLayer;
using BusinessLayer.License_Applications;
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

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class ucLocalDrivingLicenseDetails : UserControl {
        public ucLocalDrivingLicenseDetails() {
            InitializeComponent();
        }
        public void loadData(LocalLicenseApp licenseApp) {
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
