using BusinessLayer;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PresentationLayer {
    public partial class FrmAddOrUpdatePerson : Form {
        Person currentPerson = null;
        public FrmAddOrUpdatePerson(Person person) {
            InitializeComponent();
            currentPerson=  person;
        }
        void FillCountriesInComboBox() {
            DataTable dtCountries = County.getCountries();
            cbCountries.DataSource = dtCountries;
            cbCountries.DisplayMember = "CountryName"; 
            cbCountries.ValueMember = "CountryID";     
        }
        private void FrmAddOrUpdatePerson_Load(object sender, EventArgs e) {
            FillCountriesInComboBox();
            if (currentPerson.currentMode == enPersonMode.addPerson) {
                dtPersonBirth.MaxDate = DateTime.Today.AddYears(-18);
                rbMale.Checked = true;
                cbCountries.Text = "Egypt";
            }
            else {
                lblOperation.Text = "Update a person";
                lblpersonID.Text = currentPerson.personID.ToString();
                txtFirst.Text = currentPerson.firstName;
                txtSecond.Text = currentPerson.secondName;
                txtThird.Text = currentPerson.thirdName;
                txtLast.Text = currentPerson.lastName;
                txtNatNo.Text = currentPerson.NationalNo;
                txtPhone.Text = currentPerson.phone;
                txtEmail.Text = currentPerson.email;
                txtAddress.Text = currentPerson.Address;
                dtPersonBirth.Value = currentPerson.dateOfBirth;
                if (currentPerson.gender == "Male")
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
                if (currentPerson.imagePath != "" && System.IO.File.Exists(currentPerson.imagePath)) { // if the image available in the device
                    pbProfileImg.Image = Image.FromFile(currentPerson.imagePath);
                    btnRemove.Enabled = true;
                    lblRemove.ForeColor = Color.White;
                }
                cbCountries.Text = currentPerson.country;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e) {
            if (currentPerson.imagePath == "" && rbMale.Checked == true) {
                pbProfileImg.Image = Resources.man;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e) {
            if (currentPerson.imagePath == "" &&  rbFemale.Checked == true) {
                pbProfileImg.Image = Resources.woman;
            }
        }

        bool areTxTBoxesFilled() {
            bool isValid = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtFirst.Text)) {
                errorProvider1.SetError(txtFirst, "First name is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtSecond.Text)) {
                errorProvider1.SetError(txtSecond, "Last name is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtLast.Text)) {
                errorProvider1.SetError(txtLast, "Last name is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtNatNo.Text)) {
                errorProvider1.SetError(txtNatNo, "National No is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text)) {
                errorProvider1.SetError(txtPhone, "Phone number is required!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) {
                errorProvider1.SetError(txtAddress, "Address is required!");
                isValid = false;
            }
            return isValid;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void txtNatNo_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtNatNo.Text)) 
                return;
            if (currentPerson.currentMode == enPersonMode.updatePerson && txtNatNo.Text == currentPerson.NationalNo)
                // if he in update mode and he let the national no, we won't consider validation
                return; 
            if (Person.isNationalNumExists(txtNatNo.Text)) { 
                e.Cancel = true;
                errorProvider1.SetError(txtNatNo, "There is another person have this national number!");
            } else {
                e.Cancel = false;
                errorProvider1.SetError(txtNatNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtEmail.Text)) {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
                return;
            } 
            try {
                var email = new System.Net.Mail.MailAddress(txtEmail.Text);
                if (email.Address == txtEmail.Text.Trim()) {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, "");
                } else {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Email format is wrong, format: (e.g. example@domain.com");
                }
            }
            catch {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email format is wrong, format: (e.g. example@domain.com");
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!areTxTBoxesFilled()) {
                Helpers.ShowErrorMessage("Please fill the required fields");
                return;
            }
            enPersonMode WhatPersonModeWas = currentPerson.currentMode;
            currentPerson.firstName = txtFirst.Text.Trim();
            currentPerson.secondName = txtSecond.Text.Trim();
            currentPerson.thirdName = txtThird.Text.Trim();
            currentPerson.lastName = txtLast.Text.Trim();
            currentPerson.NationalNo = txtNatNo.Text.Trim();
            currentPerson.dateOfBirth = dtPersonBirth.Value;
            currentPerson.gender = rbMale.Checked ? "Male" : "Female";
            currentPerson.phone = txtPhone.Text.Trim();
            currentPerson.email = txtEmail.Text.Trim();
            currentPerson.Address = txtAddress.Text.Trim();
            currentPerson.NationalityCountryID = Convert.ToInt32(cbCountries.SelectedValue);
            if (currentPerson.Save()) {
                Helpers.SuccessfulMessage("Person saves successfully!");
                if (WhatPersonModeWas == enPersonMode.addPerson) {
                    lblpersonID.Text = currentPerson.personID.ToString();
                    lblpersonID.BackColor = Color.SpringGreen;
                }
               
            } else {
                Helpers.ShowErrorMessage("something went wrong");
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = @"C:/";
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Title = "Choose image";
            openFileDialog1.Filter = "PNG images (*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName)) {
                    pbProfileImg.Image = Image.FromFile(openFileDialog1.FileName);
                    currentPerson.imagePath = openFileDialog1.FileName;
                    btnRemove.Enabled = true;
                    lblRemove.ForeColor = Color.White;

                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            pbProfileImg.Image = rbMale.Checked == true ? Resources.man : Resources.woman;
            currentPerson.imagePath = "";
            btnRemove.Enabled = false;
            lblRemove.ForeColor = Color.DarkGray;
        }
    }
}
