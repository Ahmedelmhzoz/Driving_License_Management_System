using BusinessLayer;
using Global;
using System;
using System.Drawing;
using System.Windows.Forms;
using Shared;
using PresentationLayer.Local_License;
using PresentationLayer.Licenses;

namespace PresentationLayer.Replacement_app {
    public partial class FrmReplacementApp : Form {
        public FrmReplacementApp() {
            InitializeComponent();
        }
        LocalLicense selectedLocalLicense = null;
        LocalLicense replacerLocalLicense = null;
        private void FrmReplacementApp_Load(object sender, EventArgs e) {
            rbDamage.Checked = true;
        }
        void _ReplaceBtnEnablity(bool thereIsLicense) {
            btnGoToRepalceTab.Enabled = thereIsLicense;
            lblGoToRenewTab.ForeColor = thereIsLicense ? Color.White : Color.DimGray;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReplaceBtnEnablity(false);
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
                _ReplaceBtnEnablity(true);
            }
            else {
                Helpers.ShowErrorMessage($"There is no license has ID = {licenseID}");
                selectedLocalLicense = null;
                ucLocalLicenseDetails.ResetLicenseInfo();
                _ReplaceBtnEnablity(false);
            }
        }

        void _RejectionReason(enReplacementEligibility rejection) {
            switch (rejection) {
                case enReplacementEligibility.Suspended:
                    Helpers.ShowErrorMessage("This license is suspended and cannot be replaced.");
                    break;
                case enReplacementEligibility.Expired:
                    Helpers.ShowErrorMessage("This license is expired and cannot be replaced.");
                    break;
                case enReplacementEligibility.Denied:
                    Helpers.ShowErrorMessage("Replacement for this license is denied.");
                    break;
                case enReplacementEligibility.NotFound:
                    Helpers.ShowErrorMessage("license not found.");
                    break;
            }
        }
        enReplacementEligibility _DoseLicenseEligible() {
            if (selectedLocalLicense == null) return enReplacementEligibility.NotFound;

            return selectedLocalLicense.replacementEligibility();
        }
        private void btnGoToRepalceTab_Click(object sender, EventArgs e) {
            enReplacementEligibility eligibility = _DoseLicenseEligible();
            if (eligibility == enReplacementEligibility.Eligible) {
                tcReplaceApp.SelectedTab = tbReplacementApp;
            } 
            else {
                _RejectionReason(eligibility);
            }
        }
        void _ChangeLblsColorAndBtnsEnability(bool change) {
            lblReplacementAppID.BackColor = change ? Color.SpringGreen : Color.Black;
            lblNewLicenseID.BackColor = change ? Color.SpringGreen : Color.Black;
            lblRepalce.ForeColor = change ? Color.DimGray : Color.White;
            lblShowNewLicense.ForeColor = change ? Color.White : Color.DimGray;
            lblHistory.ForeColor = change ? Color.White : Color.DimGray;
            lblRepalce.ForeColor = change ? Color.DimGray : Color.White;
            btnReplace.Enabled = !change;
            btnShowNewLicense.Enabled = change;
            btnHistory.Enabled = change;
        }
        void _ResetReplacementTab() {
            if (selectedLocalLicense == null) return;

            _ChangeLblsColorAndBtnsEnability(false);
            DateTime today = DateTime.Today;
            lblReplacementAppID.Text = "Unknown";
            lblNewLicenseID.Text = "Unknown";

            lblReleseDate.Text = today.ToShortDateString();
            lblOldLicenseID.Text = selectedLocalLicense.LicenseID.ToString();

            if (selectedLocalLicense.licenseInfo == null) return;
            int ValidityLength = selectedLocalLicense.licenseInfo.DefaultValidityLength;
            lblExpireDate.Text = today.AddYears(ValidityLength).ToShortDateString();

            lblAppFees.Text = '$' + AppType.getAppFees(enApplicationType.RenewDrivingLicense).ToString("0.##");
            lblUsername.Text = ImportantSessionData.user.Username;
            txtNote.Text = string.Empty;
        }
        private void tcReplaceApp_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcReplaceApp.SelectedTab == tbReplacementApp && _DoseLicenseEligible() != enReplacementEligibility.Eligible) {
                tcReplaceApp.SelectedTab = tbSelectLicense;
                Helpers.ShowErrorMessage("Please enter an (Active) License ID");
            }
            else if (tcReplaceApp.SelectedTab == tbReplacementApp && _DoseLicenseEligible() == enReplacementEligibility.Eligible) {
                _ResetReplacementTab();
            }
        }
        void _PrintException(Exception ex) {
            Helpers.ShowErrorMessage(ex.Message);
        }
        private void brnReplace_Click(object sender, EventArgs e) {
            if (selectedLocalLicense == null) return;

            LocalLicense replacerLicense = null; 
            if (rbDamage.Checked) {
                try {
                    replacerLicense = selectedLocalLicense.issueReplacerForDamage(ImportantSessionData.user.userID, txtNote.Text);
                }
                catch (Exception ex){
                    _PrintException(ex);
                    return;
                }
            } 
            else {
                try {
                    replacerLicense = selectedLocalLicense.issueReplacerForLost(ImportantSessionData.user.userID, txtNote.Text);
                }
                catch (Exception ex) {
                    _PrintException(ex);
                    return;
                }
            }
            selectedLocalLicense.NotSuspended = false;
            Helpers.SuccessfulMessage("The replacer license was issued successfully");
            lblReplacementAppID.Text = replacerLicense.ApplicationID.ToString();
            lblNewLicenseID.Text = replacerLicense.LicenseID.ToString();
            _ChangeLblsColorAndBtnsEnability(true);
            ucLocalLicenseDetails.SuspendLicense();
            replacerLocalLicense = replacerLicense;
        }
        private void btnShowNewLicense_Click(object sender, EventArgs e) {
            if (replacerLocalLicense == null) return;
            FrmLocalLicenseDetails frm = new FrmLocalLicenseDetails(replacerLocalLicense);
            frm.ShowDialog();
        }
        private void btnHistory_Click(object sender, EventArgs e) {
            if (selectedLocalLicense == null || selectedLocalLicense.applicationInfo == null || selectedLocalLicense.applicationInfo.personInfo == null)
                return;

            Person person = selectedLocalLicense.applicationInfo.personInfo;
            FrmLicensesHistory frm = new FrmLicensesHistory(person);
            frm.ShowDialog();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}