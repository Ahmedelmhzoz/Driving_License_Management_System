using BusinessLayer;
using Global;
using Shared;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Licenses_and_drivers {
    public partial class ucGetLicenseWithFilter : UserControl {
        public ucGetLicenseWithFilter() {
            InitializeComponent();
        }
        public int ValidLocalLicenseID {
            get {
                return Convert.ToInt32(txtSearch.Text);
            }
        }
        public event Action<bool> OnLicenseSelection;
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        bool _SearchTxTFilled() {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) {
                errorProvider1.SetError(txtSearch, "Please search for a local license by ID");
                return false;
            }
            return true;
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
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_SearchTxTFilled()) 
                return;

            int licenseID = Convert.ToInt32(txtSearch.Text);
            enInternationalLicenseEligibility response = 
                InternationalLicense.IsChossenLocalLicenseValid(licenseID, out int activeInternationalID, out LocalLicense validLicense);
            if (!_LicenseIDIsValid(response, activeInternationalID)) {
                ucLocalLicenseDetails1.ResetLicenseInfo();
                OnLicenseSelection?.Invoke(false);
                return;
            }

            ucLocalLicenseDetails1.loadData(validLicense);
            OnLicenseSelection?.Invoke(true);
        }  
    }
}
