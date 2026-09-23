using BusinessLayer;
using PresentationLayer.Users;
using System;
using System.Windows.Forms;
using Shared;
using System.Drawing;
namespace PresentationLayer {
    public partial class FrmUsersManagement : Form {
        public FrmUsersManagement() {
            InitializeComponent();
        }

        private void _ApplyGridFormatting() {
            foreach (DataGridViewRow row in dgvUsers.Rows) {
                if (row.Cells["Activation"].Value != null) {
                    string status = row.Cells["Activation"].Value.ToString();

                    if (status == "Active") {
                        row.Cells["Activation"].Style.ForeColor = Color.Green;
                        row.Cells["Activation"].Style.BackColor = Color.LightGreen;
                    }
                    else if (status == "Not active") {
                        row.Cells["Activation"].Style.ForeColor = Color.Red;
                        row.Cells["Activation"].Style.BackColor = Color.Pink;
                    }
                }
            }
            dgvUsers.Columns["IsActive"].Visible = false;
        }
        private void FrmUsers_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvUsers.RowTemplate.Height = 65;
            rbGeneral.Checked = true;
            cbFilterBy.Text = "None";
            txtSearch.Text = string.Empty;

            _ReloadDate();
        }

        private void _ReloadDate() {
            enUserStatus activation = enUserStatus.enGeneral;
            if (rbActive.Checked) 
                activation = enUserStatus.enActive;
            else if (rbNotActive.Checked) 
                activation = enUserStatus.enNotActive;
            else 
                activation = enUserStatus.enGeneral;

            dgvUsers.DataSource = User.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, activation);
            _ApplyGridFormatting();
            lblRecordsNo.Text = dgvUsers.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            txtSearch.Text = string.Empty;
            if (cbFilterBy.Text == "None")
                {txtSearch.Text = "";
                txtSearch.Visible = false;
            }
            else 
                txtSearch.Visible = true;

            _ReloadDate();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReloadDate();
        }
        private void rbGeneral_CheckedChanged(object sender, EventArgs e) {
            _ReloadDate();
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e) {
            _ReloadDate();
        }

        private void rbIsntActive_CheckedChanged(object sender, EventArgs e) {
            _ReloadDate();
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
                    Alert.SuccessfulMessage($"The user with ID = {userID} was deleted successfully!");
                } else {
                    Alert.ShowErrorMessage("Error happend while deleting");
                }
            } else {
                Alert.ShowErrorMessage($"The user with ID = {userID} participated in creating an Application, you cant delete this user");
            }
            _ReloadDate();
        }
    }
}
