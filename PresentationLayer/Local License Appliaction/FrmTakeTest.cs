using BusinessLayer;
using Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmTakeTest : Form {
        TestAppointments appointment = null;
        public event Action<bool> OnPassExam;
        public FrmTakeTest(TestAppointments appointment) {
            InitializeComponent();
            this.appointment = appointment;
        }

        private void FrmTakeTest_Load(object sender, EventArgs e) {
            lblAppointmentID.Text = appointment.TestAppointmentID.ToString();
            lblTestTitle.Text = appointment.TestTypeInfo.TestTypeTitle;
            lblLicenseClass.Text = appointment.LocalLicenseAppInfo.LicenseClassInfo.className;
            lblApplicantName.Text = appointment.LocalLicenseAppInfo.personInfo.FullName;
            lblUsername.Text = ImportantSessionData.user.Username;
            lblTestFees.Text = appointment.PaidFees.ToString("0.##");
            rbPass.Checked = true;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e) {
            Tests test = new Tests();
            test.TestAppointmentID = appointment.TestAppointmentID;
            test.TestResult = rbPass.Checked;
            test.Notes = txtNotes.Text.Trim();
            test.CreatedByUserID = ImportantSessionData.user.userID;
            OnPassExam?.Invoke(rbPass.Checked);
            
            if (Helpers.ShowConfirmation("Are you sure you want to save this result? After that you cannot change the pass/fail result") == DialogResult.Yes) {
                if (test.Save()) {
                    Helpers.SuccessfulMessage("Test result saved successfully!");
                } else {
                    Helpers.ShowErrorMessage("Error happend while saving");
                }
                this.Close();
            }
        }
    }
}
