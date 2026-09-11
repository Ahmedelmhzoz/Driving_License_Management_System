using BusinessLayer;
using Global;
using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Detain_license {
    public partial class FrmDetainManagement : Form {
        public FrmDetainManagement() {
            InitializeComponent();
        }
        private void _ApplyGridFormatting() {
            foreach (DataGridViewRow row in dgvDetain.Rows) {
                if (row.Cells["DetaintionStatus"].Value != null) {
                    string status = row.Cells["DetaintionStatus"].Value.ToString();

                    if (status == "Detained") {
                        row.Cells["DetaintionStatus"].Style.ForeColor = Color.Red;
                        row.Cells["DetaintionStatus"].Style.BackColor = Color.Pink;
                    }
                    else if (status == "Released") {
                        row.Cells["DetaintionStatus"].Style.ForeColor = Color.Green;
                        row.Cells["DetaintionStatus"].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        void _LoadMainComboBox() {
            Dictionary<enDetainFilterBy, string> filters = new Dictionary<enDetainFilterBy, string>{
                {enDetainFilterBy.None , "None" },
                {enDetainFilterBy.DetainID, "Detain ID" },
                {enDetainFilterBy.LicenseID, "License ID" },
                {enDetainFilterBy.Fullname, "Driver's name" },
                {enDetainFilterBy.DetaintionStatus, "Detainment status" },
            };
            cbFilterBy.DataSource = new BindingSource(filters, null);
            cbFilterBy.DisplayMember = "Value";
            cbFilterBy.ValueMember = "Key";
        }
        void _LoadDetaintionStatusComboBox() {
            Dictionary<enDetaintionStatus, string> detentionStatusFilter = new Dictionary<enDetaintionStatus, string>{
                {enDetaintionStatus.Detained , "Detained" },
                {enDetaintionStatus.Released, "Released" },
            };
            cbDetaintionStatus.DataSource = new BindingSource(detentionStatusFilter, null);
            cbDetaintionStatus.DisplayMember = "Value";
            cbDetaintionStatus.ValueMember = "Key";
        }
        private void FrmDetainManagement_Load(object sender, EventArgs e) {
            dgvDetain.RowTemplate.Height = 70;
            _LoadMainComboBox();
            _LoadDetaintionStatusComboBox();
            _ReloadData();
            _ApplyGridFormatting();
        }
        private enDetainFilterBy _GetSelectedFilter() {
            var selected = (KeyValuePair<enDetainFilterBy, string>)cbFilterBy.SelectedItem;
            return selected.Key;
        }
        private enDetaintionStatus _GetSelectedStatus() {
            var selected = (KeyValuePair<enDetaintionStatus, string>)cbDetaintionStatus.SelectedItem;
            return selected.Key;
        }
        void _ExceptionHappend() {
            Helpers.ShowErrorMessage("Unexpected error happend");
        }
        void _ReloadData() {
            enDetainFilterBy filter = _GetSelectedFilter();
            try {
                if (filter == enDetainFilterBy.DetaintionStatus)
                    dgvDetain.DataSource = DetainLicense.getDetentionsByDetaintionStatus(_GetSelectedStatus());
                else
                    dgvDetain.DataSource = DetainLicense.getDetentionsByFilter(filter, txtSearch.Text);
                _ApplyGridFormatting();
                lblRecordsNo.Text = dgvDetain.Rows.Count.ToString();
            }
            catch {
                _ExceptionHappend();
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            enDetainFilterBy selectedFilterEnum = _GetSelectedFilter();
            if (selectedFilterEnum == enDetainFilterBy.None) {
                txtSearch.Visible = false;
                cbDetaintionStatus.Visible = false;
            }
            else if (selectedFilterEnum == enDetainFilterBy.DetaintionStatus) {
                txtSearch.Visible = false;
                cbDetaintionStatus.Visible = true;
            }
            else {
                txtSearch.Visible = true;
                cbDetaintionStatus.Visible = false;
            }
            txtSearch.Text = "";
            _ReloadData();
        }
        private void cbDetaintionStatus_SelectedIndexChanged(object sender, EventArgs e) {
            _ReloadData();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReloadData();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            enDetainFilterBy selectedFilter = _GetSelectedFilter();
            if (selectedFilter == enDetainFilterBy.LicenseID || selectedFilter == enDetainFilterBy.DetainID) {
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
