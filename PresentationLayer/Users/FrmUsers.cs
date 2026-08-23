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
            if (cbFilterBy.Text == "None")
                {txtSearch.Text = "";
                txtSearch.Visible = false;
            }
            else 
                txtSearch.Visible = true;
            _FilterUsersWithState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            if (txtSearch.Text == "")
                dgvUsers.DataSource = User.getUsers();
            else
                dgvUsers.DataSource = User.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, currentStatue);
        }

        void _FilterUsersWithState() {
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
                _FilterUsersWithState();
            }
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e) {
            if (rbActive.Checked) {
                currentStatue = enUserStatus.enActive;
                _FilterUsersWithState();
            }
        }

        private void rbIsntActive_CheckedChanged(object sender, EventArgs e) {
            if (rbIsntActive.Checked) {
                currentStatue = enUserStatus.enNotActive;
                _FilterUsersWithState();
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
            FrmAddOrUpdateUser frm = new FrmAddOrUpdateUser();
            frm.ShowDialog();
            dgvUsers.DataSource = User.getUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            string username = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            User user = User.getUserByUserName(username);
            FrmAddOrUpdateUser frm = new FrmAddOrUpdateUser(user);
            frm.ShowDialog();
            dgvUsers.DataSource = User.getUsers();
        }

        private void showDetials_Click(object sender, EventArgs e) {
            string username = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            User user = User.getUserByUserName(username);
            FrmUserDetails frm = new FrmUserDetails(user);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            int userID = (int)dgvUsers.CurrentRow.Cells[0].Value;
           
            if (!User.didUserCreateApp(userID)) {
                if (User.deleteUser(userID)) {
                    Helpers.SuccessfulMessage($"The user with ID = {userID} was deleted successfully!");
                } else {
                    Helpers.ShowErrorMessage("Error happend while deleting");
                }
            } else {
                Helpers.ShowErrorMessage($"The user with ID = {userID} participated in creating an Application, you cant delete this user");
            }
            _FilterUsersWithState();
        }
    }
}
