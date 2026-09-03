using BusinessLayer;
using Global;
using System;
using System.Windows.Forms;
using Shared;
using System.Drawing;
using PresentationLayer.Licenses;

namespace PresentationLayer.International_License {
    public partial class FrmInternationalApplication : Form {
        bool licenseWasFound = false;
        private InternationalLicense intLicnesesCreatedForCurrPerson = null;
        public FrmInternationalApplication() {
            InitializeComponent();
            ucGetLicenseWithFilter.OnLicenseSelection += _ButtonActivation;
        }
        void _ButtonActivation(bool IsSelected) {
            btnNext.Enabled = IsSelected;
            licenseWasFound = IsSelected;
        }

        private void btnNext_Click(object sender, EventArgs e) {
            tcInternationApp.SelectedIndex = 1;
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
            lblLocalLicID.Text = ucGetLicenseWithFilter.ValidLocalLicenseID.ToString();

            DateTime today = DateTime.Today;
            lblReleseDate.Text = today.ToShortDateString();
            lblExpireDate.Text = today.AddYears(1).ToShortDateString();
            lblUsername.Text = ImportantSessionData.user.Username;
            lblFees.Text = '$' + AppType.getAppFees(enApplicationType.NewInternationalLicense).ToString("0.##");
             
            _ColoringLblsAndButtonsEnablityByStatus(true);
        }
        private void tcInternationApp_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcInternationApp.SelectedTab == tbInternationalIssuing && !licenseWasFound) { 
                tcInternationApp.SelectedIndex = 0;
                Helpers.ShowErrorMessage("You cant move to the next tap before you select a license");
            }
            else if (tcInternationApp.SelectedTab == tbInternationalIssuing && licenseWasFound) {
                _ResetInternatioalLicTab();
            }
            else if (tcInternationApp.SelectedTab == tbSelectLocalLic && licenseWasFound) {
                _ButtonActivation(false);
            }
        }
        private void btnIssueLicense_Click(object sender, EventArgs e) {
            int localLicenseID = ucGetLicenseWithFilter.ValidLocalLicenseID;
            InternationalLicense intLicense = InternationalLicense.issueInternationaLicense(localLicenseID, ImportantSessionData.user.userID);

            if (intLicense != null) {
                Helpers.SuccessfulMessage($"International driving license issued successfully");
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
    }
}
