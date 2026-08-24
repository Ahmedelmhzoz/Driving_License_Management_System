using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Global;

namespace PresentationLayer {
    public partial class FrmLogin : Form {
        public FrmLogin() {
            InitializeComponent();
        }
        private string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "RememberMe.txt"); 


        private void FrmLogin_Load(object sender, EventArgs e) {
            if (File.Exists(filePath)) {
                try {
                    string[] lines = File.ReadAllLines(filePath);
                    if (lines.Length == 2) {
                        txtUsername.Text = lines[0];
                        txtPassword.Text = Encoding.UTF8.GetString(Convert.FromBase64String(lines[1])); // if lines[1] not Base64String with throw FormtException
                        chkActive.Checked = true;
                    }
                }
                catch { 
                    _ClearFile();
                }
              
            }
        }
        void _SaveUserData() {
            string username = txtUsername.Text.Trim();
            byte[] password = Encoding.UTF8.GetBytes(txtPassword.Text.Trim());
            File.WriteAllLines(filePath, new string[] { username, Convert.ToBase64String(password) });
        }
        void _ClearFile() {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }
        }
        bool _UsernameNotFound() {
            if (!User.IsUsernameTaken(txtUsername.Text.Trim())) {
                Helpers.ShowErrorMessage("The username you entered is not exists");
                lblErrorMessage.Visible = true;
                return true;
            }
            return false;
        }
        bool _UserNotActive(bool isActive) {
            if (!isActive) {
                lblErrorMessage.Visible = false;
                Helpers.ShowErrorMessage("This account is not activeted, please contact your admin");
                return true;
            }
            return false;
        }

        bool _AreTxtBoxexFilled() {
            bool isValid = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) {
                errorProvider1.SetError(txtUsername, "Username is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) {
                errorProvider1.SetError(txtPassword, "Password is required!");
                isValid = false;
            }
            return isValid;
        }

        void _LoginProcess() {
            if (!_AreTxtBoxexFilled()) 
                return;
            if (_UsernameNotFound())
                return;
            User user = User.getUserByUserName(txtUsername.Text.Trim());
            if (txtPassword.Text.Trim() == user.password) {
                if (_UserNotActive(user.isActive)) 
                    return;
                else {
                    lblErrorMessage.Visible = false;
                    Helpers.SuccessfulMessage($"Welcome, " + user.Username + " (-:");

                    if (chkActive.Checked) {
                        _SaveUserData();
                    }
                    else {
                        _ClearFile();
                    }

                    ImportantSessionData.user = user;
                    FrmMainForm Frm = new FrmMainForm();
                    this.Hide();
                    Frm.ShowDialog();
                    this.Close();
                }
            }
            else {
                lblErrorMessage.Visible = true;
                string message = "Wrong Password or Username" + Environment.NewLine + "Please enter user data correctly";
                Helpers.ShowErrorMessage(message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            _LoginProcess();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
