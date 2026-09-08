using BusinessLayer;
using BusinessLayer.Licenses;
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

namespace PresentationLayer.Local_License {
    public partial class ucLocalLicenseDetails : UserControl {
        public void ResetLicenseInfo() {
            lblLicenseID.Text = "Unknown";
            lblDriverID.Text = "Unknown";
            lblLicenseClass.Text = "Unknown";
            lblReleaseDate.Text = "Unknown";
            lblReleaseReason.Text = "Unknown";
            lblExpiteDate.Text = "Unknown";
            lblIsActive.Text = "Unknown";
            lblIsDetained.Text = "Unknown";
            lblNotes.Text = "No Notes";
            lblAdmin.Text = "Unknown";

            lblIsDetained.ForeColor = Color.DeepSkyBlue;
            lblIsActive.ForeColor = Color.DeepSkyBlue;
            ucPersonDetails.returnToDefault();
        }
        public ucLocalLicenseDetails() {
            InitializeComponent();
        }
        private string _GetIssueReasonText(enIssueReason issueReason) {
            switch (issueReason) {
                case enIssueReason.enFirstTime:
                    return "First Time";
                case enIssueReason.enRenew:
                    return "Renew";
                case enIssueReason.enReplacementForDamaged:
                    return "Replacement for Damaged";
                case enIssueReason.enReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "Unknown";
            }
        }
        void _changeLblByStatus(LocalLicense license) {
            enLicenseStatus status = license.getLicenseStatus();
            if (status == enLicenseStatus.Suspended) {
                lblIsActive.Text = "Suspended for damage or lost";
                lblIsActive.ForeColor = Color.Red;
            } else if (status == enLicenseStatus.Expired){
                lblIsActive.Text = "Expired";
                lblIsActive.ForeColor = Color.DimGray;
            } else {
                lblIsActive.Text = "Active";
                lblIsActive.ForeColor = Color.SpringGreen;
            }
        }
        void _changeLbLByDenied(LocalLicense license) {
            if (license.isLicenseDenied()) {
                lblIsDetained.Text = "Denied";
                lblIsDetained.ForeColor = Color.Red;
            } else {
                lblIsDetained.Text = "Approved";
                lblIsDetained.ForeColor = Color.SpringGreen;
            }
        }
        void _ShowData(LocalLicense license) {
            lblLicenseID.Text = license.LicenseID.ToString();
            lblDriverID.Text = license.DriverID.ToString();
            lblLicenseClass.Text = (license.licenseInfo != null) ? license.licenseInfo.className : "Unknown";
            lblReleaseDate.Text = license.IssueDate.ToShortDateString();
            lblReleaseReason.Text = _GetIssueReasonText(license.IssueReason);
            lblExpiteDate.Text = license.ExpirationDate.ToShortDateString();
            _changeLblByStatus(license);
            lblNotes.Text = string.IsNullOrWhiteSpace(license.Notes) ? "No Notes" : license.Notes;
            _changeLbLByDenied(license);

            lblAdmin.Text = license.issuerUserInfo != null ? license.issuerUserInfo.Username : "Unknown";

            Applications licenseBasicApp = license.applicationInfo;

            if (licenseBasicApp == null) { Helpers.ShowErrorMessage("Error while geting application"); return; }

            if (licenseBasicApp.personInfo == null) { Helpers.ShowErrorMessage("Error while getting person info!"); return; }

            ucPersonDetails.loadData(licenseBasicApp.personInfo);
        }
        public void loadData(LocalLicense license) {
            if (license == null) {
                ResetLicenseInfo();
                return;
            }
            _ShowData(license);
        }
        public void SuspendLicense() {
            lblIsActive.Text = "Suspended for damage or lost";
            lblIsActive.ForeColor = Color.Red;
        }
        public void DenieLicense() {
            //
        }
    }
}
