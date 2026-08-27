using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class ucApplicationDetails : UserControl {
        Applications BasicApp = null;
        public ucApplicationDetails() {
            InitializeComponent();
        }
     
        void _ShowData() {
            if (BasicApp != null) {
                lblApplicationID.Text = BasicApp.AppID.ToString();
                lblStatus.Text = Helpers._ConverStatusEnumToString(BasicApp.appStatus);
                lblFees.Text = BasicApp.paidFees.ToString("0.##");
                lblDate.Text = BasicApp.AppDate.ToShortDateString();
                lblLastStatusDate.Text = BasicApp.lastStatusDate.ToShortDateString();

                AppType appType = AppType.getApplicationType(BasicApp.ApplicaitionTypeID);
                lblAppType.Text = (appType != null) ? appType.AppTypeTitle : "Unknown";

                User user = User.getUserByID(BasicApp.createdByUserID);
                lblUser.Text = (user != null) ? user.Username : "Unknown";

                Person person = Person.findPerson(BasicApp.personID);
                if (person != null) 
                    lblApplicantName.Text = person.firstName + " " + person.secondName + " " + person.thirdName + " " + person.lastName;
                else
                    lblApplicantName.Text = "Unknown";
            }
        }

        public void loadData(Applications basicApp) {
            if (basicApp != null) {
                BasicApp = basicApp;
                _ShowData();
                btnUpdatePerson.Enabled = true;
                lblUpdate.ForeColor = Color.White;
            }
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e) {
            if (BasicApp != null) {

                Person person = Person.findPerson(BasicApp.personID);
                if (person == null) return;

                string oldPersonName = lblApplicantName.Text;

                FrmAddOrUpdatePerson frm = new FrmAddOrUpdatePerson(person);
                frm.ShowDialog();

                string newName = person.firstName + " " + person.secondName + " " + person.thirdName + " " + person.lastName;
                if (newName != oldPersonName) 
                    lblApplicantName.Text = newName;
            }
        }
    }
}
