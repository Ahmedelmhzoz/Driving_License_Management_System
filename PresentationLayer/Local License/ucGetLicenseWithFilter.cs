using BusinessLayer;
using Global;
using PresentationLayer.Properties;
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
        public event Action<int> OnButtonSearchClick;
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

        public void SearchLicenseMode(enLicenseType licenseType) {
            if (licenseType == enLicenseType.Local) {
                lblLicenseType.Text = "Local license ID:";
                pbLicense.Image = Resources.icense__1_;
            } else {
                lblLicenseType.Text = "International license ID:";
                pbLicense.Image = Resources.pilot_license;
            }
        }

        public void ResetControl() {
            ucLocalLicenseDetails1.ResetLicenseInfo();
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_SearchTxTFilled()) 
                return;

            OnButtonSearchClick?.Invoke(Convert.ToInt32(txtSearch.Text));
        }  

        public void LoadValidLicenseData(LocalLicense validLicense) {
            ucLocalLicenseDetails1.loadData(validLicense);
        }
    }
}
