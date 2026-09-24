using BusinessLayer;
using Shared;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmTakeTest : Form {
        TestAppointments appointment = null;
        Tests scheduledTest = null; 
        public event Action<bool> OnPassExam;
        public FrmTakeTest(TestAppointments appointment) {
            InitializeComponent();
            this.appointment = appointment;
        }
        bool _HasTheExamDatePassed() {
            if (appointment.AppointmentDate.Date < DateTime.Today) {
                return true;
            }
            return false;
        }

        private void FrmTakeTest_Load(object sender, EventArgs e) {
            rbPass.Checked = true; 
            lblAppointmentID.Text = appointment.TestAppointmentID.ToString();
            lblTestTitle.Text = appointment.TestTypeInfo.TestTypeTitle;
            lblLicenseClass.Text = appointment.LocalLicenseAppInfo.LicenseClassInfo.className;
            lblApplicantName.Text = appointment.LocalLicenseAppInfo.personInfo.FullName;
            lblUsername.Text = ImportantSessionData.user.Username;
            lblTestFees.Text = appointment.PaidFees.ToString("0.##");

            scheduledTest = new Tests();
            scheduledTest.TestAppointmentID = appointment.TestAppointmentID;
            scheduledTest.CreatedByUserID = ImportantSessionData.user.userID;
            if (_HasTheExamDatePassed()) {
                Alert.ShowErrorMessage("The exam time has passed, schedule a new test");
                scheduledTest.TestResult = false;
                scheduledTest.Notes = "Applicant was absent";
                scheduledTest.Save();
                this.Close();
                return;
            }
        }
        private void btnAddAppointment_Click(object sender, EventArgs e) {
            scheduledTest.TestResult = rbPass.Checked;
            scheduledTest.Notes = txtNotes.Text.Trim();

            if (Alert.ShowConfirmation("Are you sure you want to save this result? After that you cannot change the pass/fail result") == DialogResult.Yes) {
                if (scheduledTest.Save()) {
                    Alert.SuccessfulMessage("Test result saved successfully!");
                     OnPassExam?.Invoke(rbPass.Checked);
                } else {
                    Alert.ShowErrorMessage("Error happend while saving");
                }
                this.Close();
            }
        }
    }
}
