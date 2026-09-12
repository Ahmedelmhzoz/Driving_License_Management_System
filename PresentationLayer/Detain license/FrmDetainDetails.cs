using Shared;
using System;
using System.Windows.Forms;
using BusinessLayer;
namespace PresentationLayer.Detain_license {
    public partial class FrmDetainDetails : Form {
        DetainDetails detainDetails = null;
        public FrmDetainDetails(DetainDetails detainDetails) {
            InitializeComponent();
            this.detainDetails = detainDetails; 
        }

        private void FrmDetainDetails_Load(object sender, EventArgs e) {
            lblDetainID.Text = detainDetails.detainID.ToString();
            lblDetainDate.Text = detainDetails.detainDate.ToShortDateString();
            lblLicenseID.Text = detainDetails.LicenseID.ToString();
            User user = User.getUserByID(detainDetails.createdByUserID);
            if (user == null) return;
            lblUsername.Text = user.Username;
            lblFineAmount.Text = '$' + detainDetails.fineFees.ToString("0.##");
            txtReason.Text = detainDetails.reason.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
