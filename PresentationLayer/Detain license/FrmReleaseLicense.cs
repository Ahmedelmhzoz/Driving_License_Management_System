using BusinessLayer;
using Global;
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

namespace PresentationLayer.Detain_license {
    public partial class FrmReleaseLicense : Form {
        public FrmReleaseLicense() {
            InitializeComponent();
        }
        LocalLicense selectedLocalLicense = null;
        void _ReleaseBtnEnibility(bool thereIsLicense) {
            btnGoToReleaseTab.Enabled = thereIsLicense;
            lblGoToReleaseTab.ForeColor = thereIsLicense ? Color.White : Color.DimGray;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReleaseBtnEnibility(false);
        }
        bool _isTxtBoxFilled() {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtSearch.Text)) {
                errorProvider1.SetError(txtSearch, "Please enter license ID");
                return false;
            }

            return true;
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_isTxtBoxFilled())
                return;

            int licenseID = Convert.ToInt32(txtSearch.Text);

            LocalLicense license = LocalLicense.GetLicenseByID(licenseID);

            if (license != null) {
                selectedLocalLicense = license;
                ucLocalLicenseDetails.loadData(license);
                _ReleaseBtnEnibility(true);
            }
            else {
                Helpers.ShowErrorMessage($"There is no license has ID = {licenseID}");

                selectedLocalLicense = null;
                ucLocalLicenseDetails.ResetLicenseInfo();
                _ReleaseBtnEnibility(false);
            }
        }
        bool _CanReleaseLicense() {
            if (selectedLocalLicense == null)
                return false;
            bool isDetained = selectedLocalLicense.isLicenseDenied();
            if (selectedLocalLicense.getLicenseStatus() == Shared.enLicenseStatus.Expired) {
                Helpers.ShowErrorMessage("This license has expired.");
                return false;
            } 
            else if (!isDetained) {
                Helpers.ShowErrorMessage("This license is not detained, so it cannot be released.");
                return false;
            }
            else {
                return true;
            }
        }
        private void btnGoToReleaseTab_Click(object sender, EventArgs e) {
            if (_CanReleaseLicense()) {
                tcDetainLicense.SelectedTab = tbRelease;
            }
        }
        void _ChangeLblsColorAndBtnsEnability(bool change) {
            lblApplicationID.BackColor = change ? Color.SpringGreen : Color.Black;

            lblRelease.ForeColor = change ? Color.DimGray : Color.White;
            btnRelease.Enabled = !change;
        }
        void _ExceptionHappend() {
            Helpers.ShowErrorMessage("Unexpected error happend");
        }
        void _ResetReleaseTab() {
            if (selectedLocalLicense == null || selectedLocalLicense.currentDetainInfo == null)
                return;

            decimal fine = 0.0m;
            decimal appFees = 0.0m;

            _ChangeLblsColorAndBtnsEnability(false);
            DateTime today = DateTime.Today;

            lblApplicationID.Text = "Unknown";
            lblLicenseID.Text = selectedLocalLicense.LicenseID.ToString();
            lblApplicationDate.Text = today.ToShortDateString();
            appFees = AppType.getAppFees(enApplicationType.ReleaseDetainedDrivingLicense);

            lblApplicationFees.Text = "$" + appFees.ToString("0.##");

            lblUsername.Text = ImportantSessionData.user.Username;

            try {
                fine = selectedLocalLicense.currentDetainInfo.fineFees;
                lblFineAmount.Text = "$" + fine.ToString("0.##");
                txtReason.Text = selectedLocalLicense.currentDetainInfo.reason;
                lblTotalFees.Text = "$" + (appFees + fine).ToString("0.##");
            } 
            catch {
                _ExceptionHappend();
            }
        }
        private void tcDetainLicense_SelectedIndexChanged(object sender, EventArgs e) {
            _ResetReleaseTab();
            if (tcDetainLicense.SelectedTab == tbRelease && !_CanReleaseLicense()) {
                tcDetainLicense.SelectedTab = tbSelectLicense;
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e) {
            if (selectedLocalLicense == null) return;
            
            try {
                ReleaseDetails releaseDetails = new ReleaseDetails(selectedLocalLicense.currentDetainInfo.detainID, DateTime.Now, ImportantSessionData.user.userID);
                selectedLocalLicense.Release(ref releaseDetails);
                Helpers.SuccessfulMessage("The license has been successfully released");
                lblApplicationID.Text = releaseDetails.applicationID.ToString();
                _ChangeLblsColorAndBtnsEnability(true);
                ucLocalLicenseDetails.approveLicense();
            }
            catch {
                _ExceptionHappend();
                return;
            }
        }
    }
}
