using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;
using PresentationLayer.Local_License;
using Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Licenses {
    public partial class ucDrivingLicenses : UserControl {
        public ucDrivingLicenses() {
            InitializeComponent();
        }

        public void loadLicensesHistoryForPerson(int personID) {
            dgvLocalLicenses.DataSource = LocalLicense.getLocalLicensesHistoryForPerosn(personID);
            dgvInternationalLic.DataSource = InternationalLicense.getIntLicenseHistoryForPersonID(personID);

        }
        private void dgvLocalLicenses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvLocalLicenses.Columns[e.ColumnIndex].Name == "licenseStatus") {
                if (e.Value != DBNull.Value) {
                    if (e.Value.ToString() == "Suspended") {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.Pink;
                        e.CellStyle.SelectionForeColor = Color.Red;
                    } else if (e.Value.ToString() == "Active") {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                    }
                    else if (e.Value.ToString() == "Expired") {
                        e.CellStyle.ForeColor = Color.DimGray;
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.SelectionForeColor = Color.DimGray;
                    }
                }
            }
        }
        private void ucDrivingLicenses_Load(object sender, EventArgs e) {
            dgvLocalLicenses.RowTemplate.Height = 80;
            dgvInternationalLic.RowTemplate.Height = 80;
        }

        private void dgvInternationalLic_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvInternationalLic.Columns[e.ColumnIndex].Name == "licenseStatusForInt") {
                if (e.Value != DBNull.Value) {
                    if (e.Value.ToString() == "Suspended") {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.Pink;
                        e.CellStyle.SelectionForeColor = Color.Red;
                    }
                    else if (e.Value.ToString() == "Active") {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                    }
                    else if (e.Value.ToString() == "Expired") {
                        e.CellStyle.ForeColor = Color.DimGray;
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.SelectionForeColor = Color.DimGray;
                    }
                }
            }
        }

        private void tmsiShowLicense_Click(object sender, EventArgs e) {
            int ID = (int)dgvLocalLicenses.CurrentRow.Cells[0].Value;

            LocalLicense license = LocalLicense.GetLicenseByID(ID);
            if (license == null) { Helpers.ShowErrorMessage("Cant get license"); return; }

            FrmLocalLicenseDetails frm = new FrmLocalLicenseDetails(license);
            frm.ShowDialog();
        }
    }
}
