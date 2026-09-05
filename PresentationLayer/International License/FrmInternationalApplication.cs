using BusinessLayer;
using Global;
using PresentationLayer.Licenses;
using PresentationLayer.Local_License;
using Shared;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.International_License {
    public partial class FrmInternationalApplication : Form {
        bool ValidLicenseWasFound = false;
        bool licenseWasIssuedSuccessfully = false;
        private InternationalLicense intLicnesesCreatedForCurrPerson = null;
        public FrmInternationalApplication() {
            InitializeComponent();
        }

        bool _LicenseIDIsValid(enInternationalLicenseEligibility status, int activeInternationalLicenseID) {
            switch (status) {
                case enInternationalLicenseEligibility.NotFound:
                    Helpers.ShowErrorMessage("Local License ID is not found in the system!");
                    return false;

                case enInternationalLicenseEligibility.NotOrdinaryLicenseCLass:
                    Helpers.ShowErrorMessage("License must be Class 3 (Ordinary Driving License) to issue an International License.");
                    return false;

                case enInternationalLicenseEligibility.NotActive:
                    Helpers.ShowErrorMessage("Selected Local License is NOT Active. Cannot issue International License.");
                    return false;

                case enInternationalLicenseEligibility.HasActiveInternational:
                    Helpers.ShowErrorMessage($"Person already has an Active International License with ID = {activeInternationalLicenseID}");
                    return false;

                case enInternationalLicenseEligibility.Valid:
                    return true;
            }
            return false;
        }
        void _ColoringLblsAndButtonsEnablityByStatus(bool IsDefault) {
            if (IsDefault == true) {
                lblApplicationID.BackColor = Color.Black;
                lblInterLicID.BackColor = Color.Black;
                lblLicenseIssuing.ForeColor = Color.White;
                lblShowHistory.ForeColor = Color.DimGray;
                lblShowLic.ForeColor = Color.DimGray;
                btnIssueLicense.Enabled = true;
                btnShowLicense.Enabled = false;
                btnShowHistory.Enabled = false;
            } else {
                lblApplicationID.BackColor = Color.SpringGreen;
                lblInterLicID.BackColor = Color.SpringGreen;
                lblShowHistory.ForeColor = Color.White;
                lblShowLic.ForeColor = Color.White;
                lblLicenseIssuing.ForeColor = Color.DimGray;
                btnIssueLicense.Enabled = false;
                btnShowLicense.Enabled = true;
                btnShowHistory.Enabled = true;
            }
        }
        void _ResetInternatioalLicTab() {
            lblApplicationID.Text = "Unknown";
            lblInterLicID.Text = "Unknown";
            lblLocalLicID.Text = txtSearch.Text;

            DateTime today = DateTime.Today;
            lblReleseDate.Text = today.ToShortDateString();
            lblExpireDate.Text = today.AddYears(1).ToShortDateString();
            lblUsername.Text = ImportantSessionData.user.Username;
            lblFees.Text = '$' + AppType.getAppFees(enApplicationType.NewInternationalLicense).ToString("0.##");
             
            _ColoringLblsAndButtonsEnablityByStatus(true);
        }
        private void tcInternationApp_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcInternationApp.SelectedTab == tbInternationalIssuing && !ValidLicenseWasFound) { 
                tcInternationApp.SelectedIndex = 0;
                Helpers.ShowErrorMessage("You cant move to the next tap before you select a valid license");
            }
            else if (tcInternationApp.SelectedTab == tbInternationalIssuing && ValidLicenseWasFound) {
                _ResetInternatioalLicTab();
            }
            else if (tcInternationApp.SelectedTab == tbSelectLocalLic && licenseWasIssuedSuccessfully) {
                ucLocalLicenseDetails.ResetLicenseInfo();
                txtSearch.Text = string.Empty;
                licenseWasIssuedSuccessfully = false;
                ValidLicenseWasFound = false;
            }
        }
        private void btnIssueLicense_Click(object sender, EventArgs e) {
            int localLicenseID = Convert.ToInt32(txtSearch.Text);
            InternationalLicense intLicense = InternationalLicense.issueInternationaLicense(localLicenseID, ImportantSessionData.user.userID);

            if (intLicense != null) {
                Helpers.SuccessfulMessage($"International driving license issued successfully");
                licenseWasIssuedSuccessfully = true;
                lblApplicationID.Text = intLicense.ApplicationID.ToString();
                lblInterLicID.Text = intLicense.InternationalLicenseID.ToString();
                _ColoringLblsAndButtonsEnablityByStatus(false);
                intLicnesesCreatedForCurrPerson = intLicense;
            }
            else {
                Helpers.ShowErrorMessage("Error Happend while saving international license");
            }
        }

        private void btnShowHistory_Click(object sender, EventArgs e) {
            Person currPerson = intLicnesesCreatedForCurrPerson.ApplicationInfo.personInfo;

            if (currPerson != null) {
                FrmLicensesHistory frm = new FrmLicensesHistory(currPerson);
                frm.ShowDialog();
            }
        }

        private void btnShowLicense_Click(object sender, EventArgs e) {
            if (intLicnesesCreatedForCurrPerson != null) {
                FrmInternationalLicenseDetails frm = new FrmInternationalLicenseDetails(intLicnesesCreatedForCurrPerson);
                frm.ShowDialog();
            }
        }

        private void btnApplyForApp_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) return;

            int licenseID = Convert.ToInt32(txtSearch.Text.Trim());
            enInternationalLicenseEligibility response =
               InternationalLicense.IsChossenLocalLicenseValid(licenseID, out int activeInternationalID, out LocalLicense validLicense);
            if (_LicenseIDIsValid(response, activeInternationalID)) {
                ValidLicenseWasFound = true;
                tcInternationApp.SelectedTab = tbInternationalIssuing;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) {
                errorProvider1.SetError(txtSearch, "Please search for a ID for local license with CLass 3 (Ordinary driving licene) and active");
                return;
            }
            int licenseID = Convert.ToInt32(txtSearch.Text.Trim());

            LocalLicense validLicense = LocalLicense.GetLicenseByID(licenseID);
            if (validLicense != null) {
                btnApplyForApp.Enabled = true;
                lblApply.ForeColor = Color.White;
                ucLocalLicenseDetails.loadData(validLicense);
            }
            else {
                Helpers.ShowErrorMessage($"There is no licese with ID: {licenseID}");
                txtSearch.Text = string.Empty;
                ucLocalLicenseDetails.ResetLicenseInfo();
                lblApply.ForeColor = Color.DimGray;
                btnApplyForApp.Enabled = false;
                ValidLicenseWasFound = false;
            }
        }
    }
}
