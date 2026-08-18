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
            person = currentPerson;
            lblpersonID.Text = currentPerson.personID.ToString();
            lblName.Text = currentPerson.firstName + ' ' + currentPerson.secondName + ' '
                + currentPerson.thirdName + ' ' + currentPerson.lastName;
            lblNationalNum.Text = currentPerson.NationalNo;
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
        public bool isThereImage() {
            return pbProfileImg.Tag != null;
        }
        public void setImage(string imagePath) {
            pbProfileImg.Image = Image.FromFile(imagePath);
            person.imagePath = imagePath;
            person.Save();
        }
    }
}
