using BusinessLayer.License_Applications;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmLocalLicenseAppInfo : Form {
        LocalLicenseApp licenseApp= null;
        public FrmLocalLicenseAppInfo(LocalLicenseApp licenseApp) {
            InitializeComponent();
            this.licenseApp = licenseApp;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmLocalLicenseAppInfo_Load(object sender, EventArgs e) {
            ucLocalDrivingLicenseDetails.loadData(licenseApp);
        }
    }
}
