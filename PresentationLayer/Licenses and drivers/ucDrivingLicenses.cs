using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.Licenses {
    public partial class ucDrivingLicenses : UserControl {
        public ucDrivingLicenses() {
            InitializeComponent();
        }

       public void loadLicensesForPerson(int personID) {
            dgvLocalLicenses.DataSource = LocalLicense.getLicensesHistoryForPerosn(personID);
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
                }
            }
        }
        private void ucDrivingLicenses_Load(object sender, EventArgs e) {
            dgvLocalLicenses.Columns["IssueDate"].DefaultCellStyle.Format = "MM-dd-yyyy";
            dgvLocalLicenses.Columns["ExpirationDate"].DefaultCellStyle.Format = "MM-dd-yyyy";
            dgvLocalLicenses.RowTemplate.Height = 65;
        }
    }
}
