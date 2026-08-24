using BusinessLayer;
using BusinessLayer.License_Applications;
using System;
using System.Collections.Generic;
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
    }
}
