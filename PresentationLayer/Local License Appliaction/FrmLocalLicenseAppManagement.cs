using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;
using System;
using System.Collections.Generic;
using Shared;
using System.Windows.Forms;
using PresentationLayer.Local_License_Appliaction;
using PresentationLayer.Local_License;
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
        void _EnablityByStatus() {
            string status = (string)dgvLocalApplications.CurrentRow.Cells["ApplicationStatus"].Value;
            if (status == "Completed") {
                tmsiDeleteApp.Enabled = false;
                editApp.Enabled = false;
                tsmiCancelApp.Enabled = false;
                tmsiScheduleTest.Enabled = true;
            } else if (status == "New") {
                tmsiDeleteApp.Enabled = true;
                editApp.Enabled = true;
                tsmiCancelApp.Enabled = true;
                tmsiScheduleTest.Enabled = true;
            }
            else { // canceled
                tmsiDeleteApp.Enabled = true;
                editApp.Enabled = false;
                tsmiCancelApp.Enabled = false;
                tmsiScheduleTest.Enabled = false;
            }
        }
        void _DisableAllTestsMenu() {
            visionTestToolStripMenuItem.Enabled = false;
            writtenTestToolStripMenuItem.Enabled=false;
            streetTestToolStripMenuItem.Enabled = false;
            tmsiIssueLicense.Enabled = false;
            tmsiShowLicense.Enabled = false;
        }
        void _EnableProcessesUnderPersonProgress() {
            int passedExams = (int)dgvLocalApplications.CurrentRow.Cells["PassedExams"].Value;
            if (passedExams >= 0) {
                visionTestToolStripMenuItem.Enabled = true;
            }
            if (passedExams >= 1) {
                writtenTestToolStripMenuItem.Enabled = true;
            }
            if (passedExams >= 2) {
                streetTestToolStripMenuItem.Enabled = true;
            }
            string AppStatus = dgvLocalApplications.CurrentRow.Cells["ApplicationStatus"].Value.ToString();
            if (passedExams == 3 && AppStatus == "New") { 
                tmsiIssueLicense.Enabled = true;
            }
            if (passedExams == 3 && AppStatus == "Completed") {
                tmsiShowLicense.Enabled = true;
            }
        }
        private void cmsApp_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            _DisableAllTestsMenu();
            _EnablityByStatus();
            _EnableProcessesUnderPersonProgress();
        }

        void _ShowScheduledTestsForm(enTestType testType) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp != null) {
                FrmAppointments frm = new FrmAppointments(loaclLicenseApp, testType);
                frm.ShowDialog();
                _ReloadData();
            }
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e) {
            _ShowScheduledTestsForm(enTestType.enVision);
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e) {
            _ShowScheduledTestsForm(enTestType.enWritten);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e) {
            _ShowScheduledTestsForm(enTestType.enStreet);
        }

        private void tmsiIssueLicense_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp != null) {
                FrmIssueLocalLicense frm = new FrmIssueLocalLicense(loaclLicenseApp);
                frm.ShowDialog();
                _ReloadData();
            }
        }
        private void tmsiShowLicense_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;

            LocalLicenseApp loaclLicenseApp = LocalLicenseApp.getLocalLicenseAppByID(ID);
            if (loaclLicenseApp == null){ Helpers.ShowErrorMessage("Cant get loaclLicenseApp"); return; }

            LocalLicense license = LocalLicense.GetLicenseByApplicationID(loaclLicenseApp.AppID);
            if (license == null) { Helpers.ShowErrorMessage("Cant get license"); return; }

            FrmLocalLicenseDetails frm = new FrmLocalLicenseDetails(license);
            frm.ShowDialog();
        }
    }
}
