using System;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.International_License {
    public partial class FrmInternationalLicenseDetails : Form {
        InternationalLicense internationalLicense = null;
        public FrmInternationalLicenseDetails(InternationalLicense internationalLicense) {
            InitializeComponent();
            this.internationalLicense = internationalLicense;
        }

        private void FrmInternationalLicenseDetails_Load(object sender, EventArgs e) {
            ucInternationalLicenseDetails.loadData(this.internationalLicense);
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
