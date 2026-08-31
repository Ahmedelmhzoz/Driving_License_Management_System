using BusinessLayer;
using BusinessLayer.License_Applications;
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

namespace PresentationLayer.Licenses_and_drivers {
    public partial class FrmDrivers : Form {
        public FrmDrivers() {
            InitializeComponent();
        }
        void _LoadAllDrivers() {
            dgvDrivers.DataSource = Drivers.GetAllDrivers();
            lblRecordsNo.Text = dgvDrivers.Rows.Count.ToString();
        }
        private void FrmDrivers_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvDrivers.RowTemplate.Height = 70;
            _LoadAllDrivers();
        }
        private enDriverFilterColumn _GetSelectedFilter() {
            switch (cbFilterBy.Text) {
                case "Driver ID": return enDriverFilterColumn.DriverID;
                case "Person ID": return enDriverFilterColumn.PersonID;
                case "National No": return enDriverFilterColumn.NationalNo;
                default: return enDriverFilterColumn.FullName;
            }
        }
        void _ReloadData() {
            if (cbFilterBy.Text == "None" || string.IsNullOrWhiteSpace(txtSearch.Text)) {
                _LoadAllDrivers();
            }
            else {
                dgvDrivers.DataSource = Drivers.GetDriversByFilter(_GetSelectedFilter(), txtSearch.Text);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterBy.Text == "None") {
                txtSearch.Text = "";
                txtSearch.Visible = false;
                _ReloadData();
            }
            else {
                txtSearch.Visible = true;
                _ReloadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReloadData();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Driver ID") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
