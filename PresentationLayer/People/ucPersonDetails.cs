using BusinessLayer;
using PresentationLayer.Properties;
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

namespace PresentationLayer {
    public partial class ucPersonDetails : UserControl {
        public ucPersonDetails() {
            InitializeComponent();
        }
        Person person = null;
        public ucPersonDetails(Person person) {
            InitializeComponent();
        }
        public void loadData(Person currentPerson) {
            btnUpdatePerson.Enabled = true;
            lblUpdate.ForeColor = Color.White;

            person = currentPerson;
            lblpersonID.Text = currentPerson.personID.ToString();
            lblName.Text = currentPerson.firstName + ' ' + currentPerson.secondName + ' '
                + currentPerson.thirdName + ' ' + currentPerson.lastName;
            lblNationalNum.Text = currentPerson.NationalNo;
            lblGender.Text = currentPerson.gender;
            if (currentPerson.email != "") lblEmail.Text = currentPerson.email;
            lblAddress.Text = currentPerson.Address;
            lblCountry.Text = currentPerson.country;
            lblPhone.Text = currentPerson.phone;
            lblDateOfBirth.Text = currentPerson.dateOfBirth.Month.ToString() + '/'
                + currentPerson.dateOfBirth.Day.ToString() + '/' + currentPerson.dateOfBirth.Year.ToString();
            if (currentPerson.imagePath != "" && System.IO.File.Exists(currentPerson.imagePath)) 
                pbProfileImg.Image = Image.FromFile(currentPerson.imagePath);
            else {
                if (currentPerson.gender == "Male")
                    pbProfileImg.Image = Resources.man;
                else
                    pbProfileImg.Image = Resources.woman;
                pbProfileImg.Tag = null;
            }
        } 
        public void returnToDefault() {
            btnUpdatePerson.Enabled = false;
            lblUpdate.ForeColor = Color.DimGray;

            lblpersonID.Text = "Unknown";
            lblName.Text = "Unknown";
            lblNationalNum.Text = "Unknown";
            lblGender.Text = "Unknown";
            lblEmail.Text = "Unknown";
            lblAddress.Text = "Unknown";
            lblDateOfBirth.Text = "Unknown";
            lblPhone.Text = "Unknown";
            lblCountry.Text = "Unknown";

            pbProfileImg.Image = Properties.Resources.man;
            pbProfileImg.Tag = null;
        }

        public int returnPersonID() {
                return Convert.ToInt32(lblpersonID.Text);
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e) {
            if (person != null) {
                FrmAddOrUpdatePerson frm = new FrmAddOrUpdatePerson(person);
                frm.ShowDialog();
                loadData(person);
            }
        }
    }
}
