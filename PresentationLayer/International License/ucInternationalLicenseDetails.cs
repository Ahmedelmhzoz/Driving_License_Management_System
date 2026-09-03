using BusinessLayer;
using BusinessLayer.Licenses;
using Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.International_License {
    public partial class ucInternationalLicenseDetails : UserControl {
        public void ResetLicenseInfo() {
            lblInternationalLic.Text = "Unknown";
            lblDriverID.Text = "Unknown";
            lblReleaseDate.Text = "Unknown";
            lblExpiteDate.Text = "Unknown";
            lblIsActive.Text = "Unknown";
            lblLocalLic.Text = "Unknown";
            lblAdmin.Text = "Unknown";
        }
        public ucInternationalLicenseDetails() {
            InitializeComponent();
        }
        void _ShowData(InternationalLicense intLicense) {
            lblInternationalLic.Text = intLicense.InternationalLicenseID.ToString();
            lblLocalLic.Text = intLicense.IssuedUsingLocalLicenseID.ToString();
            lblDriverID.Text = intLicense.DriverID.ToString();
            lblReleaseDate.Text = intLicense.IssueDate.ToShortDateString();
            lblExpiteDate.Text = intLicense.ExpirationDate.ToShortDateString();
            lblIsActive.Text = intLicense.IsActive ? "Yes" : "No";

            lblAdmin.Text = intLicense.CreatorUserInfo != null ? intLicense.CreatorUserInfo.Username : "Unknown";

            Applications licenseBasicApp = intLicense.ApplicationInfo;

            if (licenseBasicApp == null) { Helpers.ShowErrorMessage("Error while geting application"); return; }

            if (licenseBasicApp.personInfo == null) { Helpers.ShowErrorMessage("Error while getting person info!"); return; }

            ucPersonDetails.loadData(licenseBasicApp.personInfo);
        }

        public void loadData(InternationalLicense intLicense) {
            if (intLicense == null) {
                ResetLicenseInfo();
                return;
            }
            _ShowData(intLicense);
        }

    }
}
