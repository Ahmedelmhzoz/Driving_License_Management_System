using BusinessLayer;
using BusinessLayer;
using PresentationLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.User;

namespace PresentationLayer {
    public partial class FrmUsers : Form {
        public FrmUsers() {
            InitializeComponent();
        }
        enUserStatus currentStatue = enUserStatus.enGeneral;
        private void FrmUsers_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvUsers.RowTemplate.Height = 65;
            dgvUsers.DataSource = User.getUsers();
            lblRecordsNo.Text = dgvUsers.Rows.Count.ToString();
            rbGeneral.Checked = true;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterBy.Text == "None") {
                txtSearch.Visible = false;
                dgvUsers.DataSource = User.getUsers();
            }
            else {
                txtSearch.Visible = true;
                dgvUsers.DataSource = User.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, currentStatue);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            if (txtSearch.Text == "")
                dgvUsers.DataSource = User.getUsers();
            else
                dgvUsers.DataSource = User.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, currentStatue);
        }

        void filterUsersWithState() {
            if (cbFilterBy.Text == "None" || txtSearch.Text == "") {
                dgvUsers.DataSource = User.selectUsersByState(currentStatue);
            }
            else {
                dgvUsers.DataSource = User.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, currentStatue);
            }
        }
        private void rbGeneral_CheckedChanged(object sender, EventArgs e) {
            if (rbGeneral.Checked) {
                currentStatue = enUserStatus.enGeneral;
                filterUsersWithState();
            }
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e) {
            if (rbActive.Checked) {
                currentStatue = enUserStatus.enActive;
                filterUsersWithState();
            }
        }

        private void rbIsntActive_CheckedChanged(object sender, EventArgs e) {
            if (rbIsntActive.Checked) {
                currentStatue = enUserStatus.enNotActive;
                filterUsersWithState();
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbFilterBy.Text.Trim() == "Person ID" || cbFilterBy.Text.Trim() == "User ID") {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                    e.Handled = true;
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e) {
            FrmAddUser frm = new FrmAddUser();
            frm.ShowDialog();
            dgvUsers.DataSource = User.getUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            string username = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            User user = User.getUserByUserName(username);
            FrmAddUser frm = new FrmAddUser(user);
            frm.ShowDialog();
            dgvUsers.DataSource = User.getUsers();
        }
    }
}
