using BusinessLayer;
using Global;
using PresentationLayer.Licenses;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer.International_License {
    public partial class FrmInternationalLicensesManagement : Form {
        public FrmInternationalLicensesManagement() {
            InitializeComponent();
        }
        private void _ApplyGridFormatting() {
            foreach (DataGridViewRow row in dgvInternationalLic.Rows) {
                if (row.Cells["licenseStatus"].Value != null) {
                    string status = row.Cells["licenseStatus"].Value.ToString();

                    if (status == "Suspended" || status == "Expired") {
                        row.Cells["licenseStatus"].Style.ForeColor = Color.Red;
                        row.Cells["licenseStatus"].Style.BackColor = Color.Pink;
                    }
                    else if (status == "Active") {
                         row.Cells["licenseStatus"].Style.ForeColor = Color.Green;
                        row.Cells["licenseStatus"].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        void _LoadAllLicensese() {
            dgvInternationalLic.DataSource = InternationalLicense.getAllInternationalLicenses();
            lblRecordsNo.Text = dgvInternationalLic.Rows.Count.ToString();
            _ApplyGridFormatting();
        }
        void _fillFiltersComboBox() {
            cbFilterBy.DataSource = Enum.GetValues(typeof(enLicenseFilterBy));
        }
        void _fillStatusComboBox() {
            cbLicenseStatus.DataSource = Enum.GetValues(typeof(enLicenseStatus));
        }
        private void FrmInternationalLicensesManagement_Load(object sender, EventArgs e) {
            _fillFiltersComboBox();
            _fillStatusComboBox();
            dgvInternationalLic.RowTemplate.Height = 70;
            _LoadAllLicensese();
        }
        private enLicenseFilterBy _GetSelectedFilter() {
            enLicenseFilterBy selectedFilterEnum = (enLicenseFilterBy)cbFilterBy.SelectedValue;
            return selectedFilterEnum;
        }
        private enLicenseStatus _GetSelectedStatus() {
            return (enLicenseStatus)cbLicenseStatus.SelectedValue;
        }
        void _ReloadData() {

            enLicenseFilterBy selectedFilterEnum = _GetSelectedFilter();

            if (selectedFilterEnum == enLicenseFilterBy.LicenseStatus) {
                dgvInternationalLic.DataSource = InternationalLicense.getLicensesByStatus(_GetSelectedStatus());
            }
            else if (selectedFilterEnum == enLicenseFilterBy.None || string.IsNullOrWhiteSpace(txtSearch.Text)) {
                _LoadAllLicensese();
            }
            else if (selectedFilterEnum != enLicenseFilterBy.LicenseStatus) {
                dgvInternationalLic.DataSource = InternationalLicense.getLicensesByFilter(selectedFilterEnum, txtSearch.Text);
            }

            _ApplyGridFormatting();
            lblRecordsNo.Text = dgvInternationalLic.Rows.Count.ToString();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            enLicenseFilterBy selectedFilterEnum = _GetSelectedFilter();
            if (selectedFilterEnum == enLicenseFilterBy.None) {
                txtSearch.Visible = false;
                cbLicenseStatus.Visible = false;
            }
            else if (selectedFilterEnum == enLicenseFilterBy.LicenseStatus) {
                txtSearch.Visible = false;
                cbLicenseStatus.Visible = true;
            }
            else {
                txtSearch.Visible = true;
                cbLicenseStatus.Visible = false;
            }
            txtSearch.Text = "";
            _ReloadData();
        }
        private void cbLicenseStatus_SelectedIndexChanged(object sender, EventArgs e) {
            _ReloadData();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReloadData();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
        Person _getSelectedDriverRowPersonality() {
            int DriverID = (int)dgvInternationalLic.CurrentRow.Cells["DriverID"].Value;
            Driver driver = Driver.findDriverByID(DriverID);
            if (driver == null) { Helpers.ShowErrorMessage("Cant get Driver"); return null; }

            Person person = driver.personInfo;
            if (person == null) { Helpers.ShowErrorMessage("Cant get Person"); return null; }

            return person;
        }
        private void showDriversPersonalDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            Person person = _getSelectedDriverRowPersonality();
            if (person == null) return;

            FrmPersonDetails personDetails = new FrmPersonDetails(person);
            personDetails.ShowDialog();
        }
        private void tmsiShowLicense_Click(object sender, EventArgs e) {
            int LicenseID = (int)dgvInternationalLic.CurrentRow.Cells["InternationalLicenseID"].Value;
            InternationalLicense License = InternationalLicense.GetInternationalLicenseByID(LicenseID);
            if (License == null) { Helpers.ShowErrorMessage("Cant get international license"); return; }

            FrmInternationalLicenseDetails frm = new FrmInternationalLicenseDetails(License);
            frm.ShowDialog();
        }

        private void tmsiHistory_Click(object sender, EventArgs e) {
            Person person = _getSelectedDriverRowPersonality();
            if (person == null) return;

            FrmLicensesHistory personDetails = new FrmLicensesHistory(person);
            personDetails.ShowDialog();
        }
    }
}
