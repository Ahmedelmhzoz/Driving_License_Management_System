using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;
using System;
using System.Collections.Generic;
using Shared;
using System.Windows.Forms;
namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmLocalLicenseAppManagement : Form {
        public FrmLocalLicenseAppManagement() {
            InitializeComponent();
        }
        void _ReloadData() {
            dgvLocalApplications.DataSource = LocalLicenseApp.getAllApplications();
            lblRecordsNo.Text = dgvLocalApplications.Rows.Count.ToString();
        }
        private void FrmLocalLicenseAppManagement_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvLocalApplications.RowTemplate.Height = 70;
            _ReloadData();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterBy.Text == "None") {
                txtSearch.Visible = false;
                _ReloadData();
            }
            else {
                txtSearch.Visible = true;
                dgvLocalApplications.DataSource = LocalLicenseApp.GetApplicationsSearchResult(txtSearch.Text, cbFilterBy.Text);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            if (txtSearch.Text == "")
                _ReloadData();
            else
                dgvLocalApplications.DataSource = LocalLicenseApp.GetApplicationsSearchResult(txtSearch.Text, cbFilterBy.Text);
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbFilterBy.Text == "L.D Application ID") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            FrmSelectPersonForApp frm = new FrmSelectPersonForApp();
            frm.ShowDialog();
            _ReloadData();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp != null) {
                FrmLocalLicenseAppInfo frm = new FrmLocalLicenseAppInfo(loaclLicenseApp);
                frm.ShowDialog();
            }
        }

        private void editApp_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp != null) {
                FrmSelectPersonForApp frm = new FrmSelectPersonForApp(loaclLicenseApp);
                frm.ShowDialog();
                _ReloadData();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            if (LocalLicenseApp.deleteLocalLicenseApp(ID)) {
                Helpers.SuccessfulMessage("Local driving license application was deleted successfully!");
                _ReloadData();
            }
            else
                Helpers.ShowErrorMessage("Error happend while deleting");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp.cancelApplication()) {
                Helpers.SuccessfulMessage("Local driving license application was canceled successfully!");
                _ReloadData();
            }
            else
                Helpers.ShowErrorMessage("Error happend while canceling");
        }

        private void cmsApp_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp == null) return;
            if (loaclLicenseApp.appStatus != enApplicationStatus.enNew)
                tsmiCancelApp.Enabled = false;
            else
                tsmiCancelApp.Enabled = true;
        }
    }
}
