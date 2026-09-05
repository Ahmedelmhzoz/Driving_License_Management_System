using BusinessLayer;
using Shared;
using System;
using System.Windows.Forms;
namespace PresentationLayer.Renew_license {
    public partial class FrmRenewLicense : Form {
        public FrmRenewLicense() {
            InitializeComponent();
        }

        private void rbLocal_CheckedChanged(object sender, EventArgs e) {
            ucGetLicenseWithFilter.SearchLicenseMode(enLicenseType.Local);
        }

        private void rbInternational_CheckedChanged(object sender, EventArgs e) {
            ucGetLicenseWithFilter.SearchLicenseMode(enLicenseType.International);
        }
        private void FrmRenewLicense_Load(object sender, EventArgs e) {
           // ucGetLicenseWithFilter.OnButtonSearchClick += _CheckLicenseIdValidity;
        }

        //void _CheckLicenseIdValidity(int licenseID) {
        //    enInternationalLicenseEligibility response =
        //        InternationalLicense.IsChossenLocalLicenseValid(licenseID, out int activeInternationalID, out LocalLicense validLicense);
        //    if (!_LicenseIDIsValid(response, activeInternationalID)) {
        //        ucGetLicenseWithFilter.ResetControl();
        //        btnNext.Enabled = false;
        //        licenseWasFound = false;
        //        return;
        //    }
        //    btnNext.Enabled = true;
        //    licenseWasFound = true;
        //}
    }
}
