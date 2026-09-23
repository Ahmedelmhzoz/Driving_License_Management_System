using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.Users {
    public partial class FrmUserDetails : Form {
        User currentUser = null;
        public FrmUserDetails(User user) {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmUserDetails_Load(object sender, EventArgs e) {
            ucUserInformation1.loadData(currentUser);
            UserActivity userActivity = UserActivity.getUserActivity(currentUser.userID);
            if (userActivity != null) {
                lblApplications.Text = userActivity.ApplicationsCount.ToString();
                lblTests.Text = userActivity.TestsCount.ToString();
                lblLicenses.Text = userActivity.LicensesCount.ToString();
                lblDetainment.Text = userActivity.DetainedLicensesCount.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
