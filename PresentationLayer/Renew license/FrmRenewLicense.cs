using BusinessLayer;
using Global;
using PresentationLayer.Properties;
using Shared;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
namespace PresentationLayer.Renew_license {
    public partial class FrmRenewLicense : Form {
        public FrmRenewLicense() {
            InitializeComponent();
        }
        LocalLicense selectedLocalLicense = null;
        InternationalLicense selectedInternationalLicense = null;

        void _LocalLicenseMode() {
            lblLicenseType.Text = "Local driving license";
            pbLicense.Image = Resources.icense__1_;
            pbRenewalLicense.Image = Resources.icense__1_; 
            pbOldLicense.Image = Resources.icense__1_;
            ucLocalLicenseDetails.Visible = true;
            ucInternationalLicenseDetails.Visible = false;
            lblNote.Visible = true;
            pbNote.Visible = true;
            txtNote.Visible = true;
        }
        void _InternationalLicenseMode() {
            lblLicenseType.Text = "International driving license";
            pbLicense.Image = Resources.pilot_license;
            pbRenewalLicense.Image = Resources.pilot_license; ;
            pbOldLicense.Image = Resources.pilot_license; ;     
            ucLocalLicenseDetails.Visible = false;
            ucInternationalLicenseDetails.Visible = true;
            lblNote.Visible = false;
            pbNote.Visible = false;
            txtNote.Visible = false;
        }
        private void rbLocal_CheckedChanged_2(object sender, EventArgs e) {
            if (rbLocal.Checked) {
                _LocalLicenseMode();
                selectedLocalLicense = null;
                selectedInternationalLicense = null;
                txtSearch.Text = string.Empty;
                ucLocalLicenseDetails.ResetLicenseInfo();
                _RenewalEnablity(false);
            }
        }
        private void rbInternational_CheckedChanged_1(object sender, EventArgs e) {
            if (rbInternational.Checked) {
                _InternationalLicenseMode();
                selectedLocalLicense = null;
                selectedInternationalLicense = null;
                txtSearch.Text = string.Empty;
                ucInternationalLicenseDetails.ResetLicenseInfo();
                _RenewalEnablity(false);
            }
        }
        private void FrmRenewLicense_Load(object sender, EventArgs e) {
            rbLocal.Checked = true;
        }
        bool _isTxtBoxFilled() {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) {
                errorProvider1.SetError(txtSearch, "Please enter license ID");
                return false;
            }
            return true;
        }
        void _RenewalEnablity(bool thereIsLicense) {
            btnGoToRenewTab.Enabled = thereIsLicense;
            lblGoToRenewTab.ForeColor = thereIsLicense ? Color.White : Color.DimGray;
        }
        private bool _HandleRenewalResult(enLicenseRenewalResult result) {
            switch (result) {
                case enLicenseRenewalResult.Success:
          
                    return true;

                case enLicenseRenewalResult.BasicAppNotFound:
                    Helpers.ShowErrorMessage("The original application for this license was not found.");
                    return false;

                case enLicenseRenewalResult.PersonNotFound:
                    Helpers.ShowErrorMessage("The license holder's information was not found.");
                    return false;

                case enLicenseRenewalResult.Failed:
                    Helpers.ShowErrorMessage("An error occurred while renewing the license.");
                    return false;

                default:
                    Helpers.ShowErrorMessage("Unexpected renewal result.");
                    return false;
            }
        }
        void _NoResultSettings() {
            ucLocalLicenseDetails.ResetLicenseInfo();
            _RenewalEnablity(false);
        }
        bool _DoseLicenseAbleToRenew() {
            if (rbLocal.Checked) {
                if (selectedLocalLicense != null) {
                    if (selectedLocalLicense.getLicenseStatus() == enLicenseStatus.Expired && !selectedLocalLicense.HasBeenRenewed()) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            else {
                if (selectedInternationalLicense != null) {
                    if (selectedInternationalLicense.licenseStatus() == enLicenseStatus.Expired && !selectedInternationalLicense.HasBeenRenewed()) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            return false;
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_isTxtBoxFilled()) return;

            int licenseID = Convert.ToInt32(txtSearch.Text.Trim());
            if (rbLocal.Checked) {
                selectedLocalLicense = LocalLicense.GetLicenseByID(licenseID);
                if (selectedLocalLicense != null) {
                    ucLocalLicenseDetails.loadData(selectedLocalLicense);
                    _RenewalEnablity(true);
                }
                else {
                    Helpers.ShowErrorMessage($"There is no license has ID = {licenseID}");
                    _NoResultSettings();
                    txtSearch.Text = string.Empty;
                }
            }
            else {
                selectedInternationalLicense = InternationalLicense.GetInternationalLicenseByID(licenseID);
                if (selectedInternationalLicense != null) {
                    ucInternationalLicenseDetails.loadData(selectedInternationalLicense);
                    _RenewalEnablity(true);
                }
                else {
                    Helpers.ShowErrorMessage($"There is no license has ID = {licenseID}");
                    _NoResultSettings();
                    txtSearch.Text = string.Empty;
                }
            }
        }
        int _getRenewalLicenseID() {
            if (rbLocal.Checked) {
                if (selectedLocalLicense != null) {
                    return selectedLocalLicense.getRenewalLicenseID();
                }
            }
            else {
                if (selectedInternationalLicense != null) {
                    return selectedInternationalLicense.getRenewalLicenseID();
                }
            }
            return -1; // DB Problem 
        }
        private void _reasonOfRejection(enLicenseStatus status) {
            switch (status) {
                case enLicenseStatus.Active:
                    Helpers.ShowErrorMessage("The license is active, Only expired licenses can be renewed.");
                    break;
                case enLicenseStatus.Suspended:
                    Helpers.ShowErrorMessage("A suspended license cannot be renewed.");
                    break;
                case enLicenseStatus.Expired: // as long as it had been expired and rejected, it had renewed already 
                    Helpers.ShowErrorMessage($"The license Has been renewed already and the new Renewal license ID = {_getRenewalLicenseID()}");
                    break;
            }
        }
        private void btnGoToRenewTab_Click(object sender, EventArgs e) {
            if (rbLocal.Checked) {
                if (selectedLocalLicense != null) {
                    if (_DoseLicenseAbleToRenew()) {
                        tcRenewalApp.SelectedTab = tbRenewalApp;
                    }
                    else {
                        _reasonOfRejection(selectedLocalLicense.getLicenseStatus());
                    }
                }
            }
            else {
                if (selectedInternationalLicense != null) {
                    if (_DoseLicenseAbleToRenew()) {
                        tcRenewalApp.SelectedTab = tbRenewalApp;
                    }
                    else {
                        _reasonOfRejection(selectedInternationalLicense.licenseStatus());
                    }
                }
            }
        }
        void _ResetRenewalTab() {
            DateTime today = DateTime.Today;
            decimal applicationFees = AppType.getAppFees(enApplicationType.RenewDrivingLicense);

            decimal licenseFees = 0m;
            int oldLicenseID;
            int validityLength;

            if (rbLocal.Checked && selectedLocalLicense != null) {
                LicenseClass licenseClass = selectedLocalLicense.licenseInfo;
                if (licenseClass == null) {
                    Helpers.ShowErrorMessage(
                        "Could not load the selected license class information.");
                    return;
                }
                oldLicenseID = selectedLocalLicense.LicenseID;
                licenseFees = licenseClass.classFees;
                validityLength = licenseClass.DefaultValidityLength;
            }
            else if (rbInternational.Checked && selectedInternationalLicense != null) {
                oldLicenseID = selectedInternationalLicense.InternationalLicenseID;
                validityLength = 1;
            }
            else {
                return;
            }

            lblRenewalAppID.Text = "Unknown";
            lblNewLicenseID.Text = "Unknown";

            lblOldLicenseID.Text = oldLicenseID.ToString();
            lblReleseDate.Text = today.ToShortDateString();
            lblExpireDate.Text = today.AddYears(validityLength).ToShortDateString();

            lblAppFees.Text = '$' + applicationFees.ToString("0.##");
            lblLicenseFees.Text = '$' + licenseFees.ToString("0.##");
            lblTotalFees.Text = '$' + (applicationFees + licenseFees).ToString("0.##");

            lblUsername.Text = ImportantSessionData.user.Username;
            txtNote.Text = string.Empty;
        }
        void _ColoringLblsAndButtonsEnablityByStatus(bool IsDefault) {
            if (IsDefault == true) {
                lblNewLicenseID.BackColor = Color.Black;
                lblRenewalAppID.BackColor = Color.Black;
                lblRenew.ForeColor = Color.White;
            }
            else {
                lblNewLicenseID.BackColor = Color.SpringGreen;
                lblRenewalAppID.BackColor = Color.SpringGreen;
                lblRenew.ForeColor = Color.DimGray;
            }
            btnRenewLicense.Enabled = IsDefault;
        }
        private void tcRenewalApp_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcRenewalApp.SelectedTab == tbRenewalApp && !_DoseLicenseAbleToRenew()) {
                tcRenewalApp.SelectedTab = tbSelectLicense;
                Helpers.ShowErrorMessage("Please enter an (Expired) License ID");
            }
            else if (tcRenewalApp.SelectedTab == tbRenewalApp && _DoseLicenseAbleToRenew()) {
                _ResetRenewalTab();
                _ColoringLblsAndButtonsEnablityByStatus(true);
            }
        }
        private void btnRenewLicense_Click(object sender, EventArgs e) {
            if (rbLocal.Checked) {
                LicenseRenewalResult result = selectedLocalLicense.Renew(ImportantSessionData.user.userID, txtNote.Text);
                if (_HandleRenewalResult(result.Result)) {
                    Helpers.SuccessfulMessage($"License renewed successfully, Your new License ID: {result.NewLicenseID}");
                    lblNewLicenseID.Text = result.NewLicenseID.ToString();
                    lblRenewalAppID.Text = result.RenewApplicationID.ToString();
                    _ColoringLblsAndButtonsEnablityByStatus(false);
                } 
            } 
            else {
                LicenseRenewalResult result = selectedInternationalLicense.Renew(ImportantSessionData.user.userID);
                if (_HandleRenewalResult(result.Result)) {
                    Helpers.SuccessfulMessage($"License renewed successfully, Your new License ID: {result.NewLicenseID}");
                    lblNewLicenseID.Text = result.NewLicenseID.ToString();
                    lblRenewalAppID.Text = result.RenewApplicationID.ToString();
                    _ColoringLblsAndButtonsEnablityByStatus(false);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _RenewalEnablity(false);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
