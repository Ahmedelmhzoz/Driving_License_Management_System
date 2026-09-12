using BusinessLayer;
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

namespace PresentationLayer.Detain_license {
    public partial class FrmReleaseDetails : Form {
        ReleaseDetails releaseDetails = null;
        public FrmReleaseDetails(ReleaseDetails releaseDetails) {
            InitializeComponent();
            this.releaseDetails = releaseDetails;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmReleaseDetails_Load(object sender, EventArgs e) {
            lblApplicationDate.Text = releaseDetails.releaseDate.ToShortDateString();
            lblApplicationID.Text = releaseDetails.applicationID.ToString();
            lblLicenseID.Text = releaseDetails.LicenseID.ToString();
            User user = User.getUserByID(releaseDetails.createdByUserID);
            if (user == null) return;
            lblUsername.Text = user.Username;
        }
    }
}
