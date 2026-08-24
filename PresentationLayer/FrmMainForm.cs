using PresentationLayer.Local_DL_Appliaction;
using PresentationLayer.Manage_types;
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

namespace PresentationLayer {
    public partial class FrmMainForm : Form {
        public FrmMainForm() {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmPeople frm = new FrmPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmUsers frm = new FrmUsers();
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmUserDetails frm = new FrmUserDetails(ImportantSessionData.user);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmChangePassword frm = new FrmChangePassword(ImportantSessionData.user);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmApplicationTypes frm = new FrmApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmTestTypes frm = new FrmTestTypes();
            frm.ShowDialog();
        }

        private void LocalLicense_Click(object sender, EventArgs e) {
            FrmSelectPersonForApp frm = new FrmSelectPersonForApp();
            frm.ShowDialog();
        }


        private void localLicenseManagement_Click(object sender, EventArgs e) {
            FrmLocalLicenseAppManagement frm = new FrmLocalLicenseAppManagement();
            frm.ShowDialog();
        }
    }
}
