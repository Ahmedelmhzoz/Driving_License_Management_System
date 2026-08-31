using System;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer.Licenses;

namespace PresentationLayer.Local_License {
    public partial class FrmLocalLicenseDetails : Form {
        LocalLicense license = null;
        public FrmLocalLicenseDetails(LocalLicense license) {
            InitializeComponent();
            this.license = license;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmLocalLicenseDetails_Load(object sender, EventArgs e) {
            if (license != null)
                ucLocalLicenseDetails1.loadData(license);
        }
    }
}
