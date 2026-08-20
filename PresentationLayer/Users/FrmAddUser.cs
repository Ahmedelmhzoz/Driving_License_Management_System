using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  BusinessLayer;

namespace PresentationLayer.Users {
    public partial class FrmAddUser : Form {
        User currentUser = null;
        bool personIsFounded = false;
        public FrmAddUser() {
            InitializeComponent();
            ucGetPersonWithFilter.OnPersonSelection += _ButtonActivation;
            currentUser = new User();
        }

        public FrmAddUser(User user) {
            InitializeComponent();
            currentUser = user;
        }
        private void FrmAddUser_Load(object sender, EventArgs e) {
            if (currentUser.currentMode == enUserMode.addUser) {
                lblProcess.Text = "Add new user";
                tpPerson.Text = "Find Person";
                ucGetPersonWithFilter.Visible = true;
                ucPersonDetails.Visible = false;
            } else {
                lblProcess.Text = "Update user";
                tpPerson.Text = "Person details";
                personIsFounded = true;
                ucPersonDetails.Visible = true;
                Person person = Person.findPerson(currentUser.personID);
                ucPersonDetails.loadData(person);
                btnNext.Enabled = true;
                ucGetPersonWithFilter.Visible = false;
            }
        }

        void _ButtonActivation(bool IsSelected) {
            btnNext.Enabled = IsSelected;
            personIsFounded = IsSelected;
        }
        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            tcAddUser.SelectedIndex = 1;
        }   

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcAddUser.SelectedIndex == 1 && !personIsFounded) { // if he went to next tab before finding a person
                tcAddUser.SelectedIndex = 0;
                Helpers.ShowErrorMessage("You cant move to the next tap before you select a person");
            }
            else if (tcAddUser.SelectedIndex == 1 && personIsFounded && currentUser.currentMode == enUserMode.addUser) { // if he went to the user tab after finding a person
                _LoginDataControlsEnablity(true);
                lblID.BackColor = Color.Black;
                lblPersonID.Text = ucGetPersonWithFilter.getPersonID().ToString();
                txtPassword.Text = "";
                txtUsername.Text = "";
                txtPasswordConf.Text = "";
                chkActive.Checked = false;
                lblID.Text = "Unknown";
            }
            else if (tcAddUser.SelectedIndex == 0 && currentUser.currentMode == enUserMode.addUser) { // if he went to the find person in add mode
                if (ucGetPersonWithFilter.thereIsPersonSelected())
                    ucGetPersonWithFilter.refrechResult();
            }
            else if (tcAddUser.SelectedIndex == 1 && currentUser.currentMode == enUserMode.updateUser) { // if he went to the user tab in update mode
                lblPersonID.Text = ucPersonDetails.returnPersonID().ToString();
                txtUsername.Text = currentUser.Username;
                txtPassword.Text = currentUser.password;
                txtPasswordConf.Text = currentUser.password;
                chkActive.Checked = currentUser.isActive;
            }
        }
        private void txtUsername_Validating(object sender, CancelEventArgs e) {
            bool isTheSameAsOld = currentUser.currentMode == enUserMode.updateUser && currentUser.Username == txtUsername.Text.Trim();
            if (User.IsUsernameTaken(txtUsername.Text) && !isTheSameAsOld) {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "This username is taken");
            }
            else {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e) {
            bool isTheSameAsOld = currentUser.currentMode == enUserMode.updateUser && currentUser.password == txtPassword.Text.Trim();
            if (User.IsPasswordTaken(txtPassword.Text) && !isTheSameAsOld) {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This password is taken");
            }
            else {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtPasswordConf_Validating(object sender, CancelEventArgs e) {
            if (txtPasswordConf.Text != txtPassword.Text) {
                errorProvider1.SetError(txtPasswordConf, "Its not the same as password");
            }
            else {
                e.Cancel = false;
                errorProvider1.SetError(txtPasswordConf, "");
            }
        }

        bool _AreEveryThingValid() {
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
            if (string.IsNullOrWhiteSpace(txtPasswordConf.Text)) {
                errorProvider1.SetError(txtPasswordConf, "Password confirmation is required!");
                isValid = false;
            }
            if (txtPasswordConf.Text != txtPassword.Text) { // we check again because we let the user go out of confirmation box even if its not valid
                                                            // so we check again to avoid pressing save and save despite wrong confirmation
                errorProvider1.SetError(txtPasswordConf, "Password confirmation is required!");
                isValid = false;
            }
            return isValid;
        }

        void _LoginDataControlsEnablity(bool EnableOrNot) {
            btnSave.Enabled = EnableOrNot;
            txtPassword.Enabled = EnableOrNot;
            txtUsername.Enabled = EnableOrNot;
            txtPasswordConf.Enabled = EnableOrNot;
            chkActive.Enabled = EnableOrNot;
        } 
        
        private void btnSave_Click(object sender, EventArgs e) {
            if (!_AreEveryThingValid()) {
                Helpers.ShowErrorMessage("Please fill all text boxes correctly!");
                return;
            }
            enUserMode WhatPersonModeWas = currentUser.currentMode;
            currentUser.Username = txtUsername.Text.Trim();
            currentUser.password = txtPassword.Text.Trim();

            currentUser.personID = (currentUser.currentMode == enUserMode.addUser ? ucGetPersonWithFilter.getPersonID() : currentUser.personID); // in update mode we dont change it
            currentUser.isActive = chkActive.Checked;
            if (currentUser.Save()) {
                Helpers.SuccessfulMessage("User saves successfully!");
                if (WhatPersonModeWas == enUserMode.addUser) {
                    lblID.Text = currentUser.userID.ToString();
                    lblID.BackColor = Color.SpringGreen;
                    
                    _LoginDataControlsEnablity(false);
                    currentUser = new User();
                } else {
                    this.Close();
                }
                
            }
            else {
                Helpers.ShowErrorMessage("something went wrong");
            }
        }
        private void AnyChangeInInput(object sender, EventArgs e) {
            btnSave.Enabled = true;
        }

        private void tabPage2_Click(object sender, EventArgs e) {

        }
    }
}
