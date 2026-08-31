using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;
using Shared;

namespace PresentationLayer.Local_License_Appliaction {
    public partial class FrmIssueLocalLicense : Form {
        LocalLicenseApp licenseApp = null;
        public FrmIssueLocalLicense(LocalLicenseApp licenseApp) {
            InitializeComponent();
            this.licenseApp = licenseApp;
        }
        private void FrmIssueLocalLicense_Load(object sender, EventArgs e) {
            ucLocalDrivingLicenseDetails1.loadData(licenseApp);
            lblFees.Text = '$' + licenseApp.LicenseClassInfo.classFees.ToString("0.##");
        }
        private void btnIssueLicense_Click(object sender, EventArgs e) {
            Drivers Driver = null;
            if (!Drivers.isPersonAlreadyDriver(licenseApp.personID)) {
                Driver = new Drivers();
                Driver.creationDate = DateTime.Now;
                Driver.createdByUserID = ImportantSessionData.user.userID;
                Driver.personID = licenseApp.personID;
                if (!Driver.Save()) {
                    Helpers.ShowErrorMessage("Error happend while saving driver");
                    return;
                }
            } else {
                Driver = Drivers.findDriverByPersonID(licenseApp.personID);
            }
        

            LocalLicense newLicense = new LocalLicense();
            newLicense.ApplicationID = licenseApp.AppID;
            newLicense.DriverID = Driver.driverID;
            newLicense.LicenseClassID = licenseApp.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;

            byte validityLength = licenseApp.LicenseClassInfo.DefaultValidityLength;
            newLicense.ExpirationDate = DateTime.Now.AddYears(validityLength);

            newLicense.Notes = txtNotes.Text;
            newLicense.PaidFees = licenseApp.LicenseClassInfo.classFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = enIssueReason.enFirstTime;
            newLicense.CreatedByUserID = ImportantSessionData.user.userID;
            if (newLicense.Save()) {
                Helpers.SuccessfulMessage("License issued successfully!");
                licenseApp.appStatus = enApplicationStatus.enCompleted;
                licenseApp.lastStatusDate = DateTime.Now;
                if (!licenseApp.SaveApplication()) {
                    Helpers.ShowErrorMessage("Error happend while saving license app status!");
                    return;
                }

                lblLicenseID.Text = newLicense.LicenseID.ToString();
                lblLicenseID.BackColor = Color.SpringGreen;
                btnIssueLicense.Enabled = false;
            }
            else {
                Helpers.ShowErrorMessage("Error happend while saving license!");
            }
        }
    }
}
