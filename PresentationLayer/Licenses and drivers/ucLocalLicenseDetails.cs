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
        public void loadData(LocalLicense license) {
            if (license == null) {
                ResetLicenseInfo();
                return;
            }
            lblLicenseID.Text = license.LicenseID.ToString();
            lblDriverID.Text = license.DriverID.ToString();
            lblLicenseClass.Text = (license.licenseInfo != null) ? license.licenseInfo.className : "Unknown";
            lblReleaseDate.Text = license.IssueDate.ToShortDateString();
            lblReleaseReason.Text = _GetIssueReasonText(license.IssueReason);
            lblExpiteDate.Text = license.ExpirationDate.ToShortDateString();
            lblIsActive.Text = license.IsActive ? "Yes" : "No";
            lblNotes.Text = string.IsNullOrWhiteSpace(license.Notes) ? "No Notes" : license.Notes;
            lblIsDetained.Text = DetainedLicense.IsLicenseDetained(license.LicenseID) ? "Yes" : "No";

            lblAdmin.Text = license.issuerUserInfo != null ? license.issuerUserInfo.Username : "Unknown";

            Applications licenseBasicApp = license.applicationInfo;

            if (licenseBasicApp == null) {  Helpers.ShowErrorMessage("Error while geting application"); return; }

            if (licenseBasicApp.personInfo == null) { Helpers.ShowErrorMessage("Error while getting person info!"); return; }

            ucPersonDetails.loadData(licenseBasicApp.personInfo);
        }
    }
}
