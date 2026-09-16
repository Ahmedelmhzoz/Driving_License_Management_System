using BusinessLayer;
using System;
using System.Windows.Forms;
using Global;

namespace PresentationLayer.Users {
    public partial class FrmChangePassword : Form {
        User currentUser = null;
        public FrmChangePassword(User user) {
            InitializeComponent();
            currentUser = user;
        }
        private void FrmChangePassword_Load(object sender, EventArgs e) {
            ucUserInformations1.loadData(currentUser);
        }

        bool _AreEveryThingValid() {
            bool isValid = true;
            errorProvider1.Clear();
            string OldPass = txtPasswordOld.Text.Trim();
            string newPass = txtPasswordNew.Text.Trim();
            string passwordConf = txtPasswordConf.Text.Trim();
            if (string.IsNullOrWhiteSpace(OldPass)) {
                errorProvider1.SetError(txtPasswordOld, "Old Username is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(newPass)) {
                errorProvider1.SetError(txtPasswordNew, "New Password is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(passwordConf)) {
                errorProvider1.SetError(txtPasswordConf, "Password confirmation is required!");
                isValid = false;
            }
            if (newPass != passwordConf) { 
                errorProvider1.SetError(txtPasswordConf, "Password Confirmation doesn't match the new password you set!");
                isValid = false;
            }
            if (!string.IsNullOrWhiteSpace(txtPasswordOld.Text)
                && currentUser.password != OldPass) {
                errorProvider1.SetError(txtPasswordOld, "The old password is wrong!");
                isValid = false;
            }
            if (!string.IsNullOrWhiteSpace(txtPasswordNew.Text) && User.IsPasswordTaken(newPass)) {
                errorProvider1.SetError(txtPasswordNew, "The new password is taken!");
                isValid = false;
            }
            return isValid;
        }
        private void btnSave_Click(object sender, EventArgs e) {
            if (!_AreEveryThingValid()) {
                return;
            }
            currentUser.password = txtPasswordNew.Text.Trim();
            if (currentUser.Save()) {
                Helpers.SuccessfulMessage("Password changed successfully!");
                txtPasswordConf.Text = "";
                txtPasswordNew.Text = "";
                txtPasswordOld.Text = "";
            } else {
                Helpers.ShowErrorMessage("Error happend while saving");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
