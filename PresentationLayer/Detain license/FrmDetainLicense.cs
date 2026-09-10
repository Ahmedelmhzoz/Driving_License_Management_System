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
    public partial class FrmDetainLicense : Form {
        public FrmDetainLicense() {
            InitializeComponent();
        }
        LocalLicense selectedLocalLicense = null;
        void _DetainBtnEnibility(bool thereIsLicense) {
            btnGoToDetainTab.Enabled = thereIsLicense;
            lblGoToDetainTab.ForeColor = thereIsLicense ? Color.White : Color.DimGray;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _DetainBtnEnibility(false);
        }
        bool _isTxtBoxFilled() {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) {
                errorProvider1.SetError(txtSearch, "Please enter license ID");
                return false;
            }
            return true;
        }
        bool _DetainReasonSpecified() {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtDetainReason.Text)) {
                errorProvider1.SetError(txtDetainReason, "Please enter detain reason");
                return false;
            }
            return true;
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_isTxtBoxFilled()) return;
            int licenseID = Convert.ToInt32(txtSearch.Text);
            LocalLicense license = LocalLicense.GetLicenseByID(licenseID);
            if (license != null) {
                selectedLocalLicense = license;
                ucLocalLicenseDetails.loadData(license);
                _DetainBtnEnibility(true);
            }
            else {
                Helpers.ShowErrorMessage($"There is no license has ID = {licenseID}");
                selectedLocalLicense = null;
                ucLocalLicenseDetails.ResetLicenseInfo();
                _DetainBtnEnibility(false);
            }
        }
        bool _CanDetainLicense() {
            if (selectedLocalLicense == null) return false;

            enLicenseStatus status = selectedLocalLicense.getLicenseStatus();
            if (selectedLocalLicense.isLicenseDenied()) {
                Helpers.ShowErrorMessage("This license is already detained.");
                return false;
            }
            else if (status == enLicenseStatus.Expired) {
                Helpers.ShowErrorMessage("This license is expired and cannot be detained.");
                return false;
            }
            else if (status == enLicenseStatus.Suspended) {
                Helpers.ShowErrorMessage("This license is suspended and cannot be detained.");
                return false;
            }
            else {
                return true;
            }
        }

        private void btnGoToDetainTab_Click(object sender, EventArgs e) {
            if (_CanDetainLicense()) {
                tcDetainLicense.SelectedTab = tbRelease;
            }
        }

        void _ChangeLblsColorAndBtnsEnability(bool change) {
            lblDetainID.BackColor = change ? Color.SpringGreen : Color.Black;
            lblDetain.ForeColor = change ? Color.DimGray : Color.White;
            btnDetain.Enabled = !change;
        }
        void _ResetDetainTab() {
            if (selectedLocalLicense == null) return;

            _ChangeLblsColorAndBtnsEnability(false);

            lblDetainID.Text = "Unknown";
            lblLicenseID.Text = selectedLocalLicense.LicenseID.ToString();
            lblDetainDate.Text = DateTime.Today.ToShortDateString();
            lblUsername.Text = ImportantSessionData.user.Username;

            txtDetainReason.Text = string.Empty;
            nFine.Value = 1;
        }
        private void tcDetainLicense_SelectedIndexChanged(object sender, EventArgs e) {
            _ResetDetainTab();
            if (tcDetainLicense.SelectedTab == tbRelease && !_CanDetainLicense()) {
                tcDetainLicense.SelectedTab = tbSelectLicense;
            }
        }
        void _PrintException(Exception ex) {
            Helpers.ShowErrorMessage(ex.Message);
        }
        void _HandelDetaintionResult(DetainResult detainResult) {
            if (detainResult.result == enDetainResult.FineOutOfRange) {
                Helpers.ShowErrorMessage("The fine aount should be Between $1 to $1000");
                return;
            }
            else if (detainResult.result == enDetainResult.Success) {
                Helpers.SuccessfulMessage("The detaintion process done successfully");
                lblDetainID.Text = detainResult.detainRecordID.ToString();
                _ChangeLblsColorAndBtnsEnability(true);
                ucLocalLicenseDetails.DenieLicense();
            }
        }
        private void btnDetain_Click(object sender, EventArgs e) {
            if (!_DetainReasonSpecified() || selectedLocalLicense == null)
                return;
            int LicenseID = selectedLocalLicense.LicenseID;
            int userID = ImportantSessionData.user.userID;
            string reasonOfDetaintion = txtDetainReason.Text;
            DetainDetails inputtedDetainDetails = new DetainDetails(LicenseID, DateTime.Now, nFine.Value, reasonOfDetaintion, userID);
            DetainResult detainResult = new DetainResult();
            try {
                detainResult = selectedLocalLicense.Detain(inputtedDetainDetails);
            }
            catch (Exception ex) {
                _PrintException(ex);
                return;
            }
            _HandelDetaintionResult(detainResult);
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
