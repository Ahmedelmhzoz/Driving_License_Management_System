using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Users {
    public partial class ucUserInformation : UserControl {
        public ucUserInformation() {
            InitializeComponent();
        }
        void _ShowData(User user) {

            Person person = Person.findPerson(user.personID);

            ucPersonDetails1.loadData(person);

            lblName.Text = user.Username;

            lblUserID.Text = user.userID.ToString();

            lblActive.Text = user.isActive ? "Yes" : "No";

        }

        public void loadData(User user) { 
            if (user != null) {
                _ShowData(user);
            }
        }
    }
}
