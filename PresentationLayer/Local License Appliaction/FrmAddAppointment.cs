using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;
using Shared;
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

namespace PresentationLayer.Local_DL_Appliaction {
    enum enTestMode { enFirstTimeTaken = 0, enRetake = 1 }

    public partial class FrmAddAppointment : Form {
        LocalLicenseApp licenseApp = null;
        TestAppointments appointment = null;
        TestType tType = null;
        AppType appType = null;
        enTestMode testMode = enTestMode.enFirstTimeTaken;
       
        public FrmAddAppointment(TestAppointments appointment ,LocalLicenseApp licenseApp, enTestType enType, int numberOfTrials) {
            InitializeComponent();
            tType = TestType.getTestTypeDetails(enType);
            this.licenseApp = licenseApp;
            testMode = numberOfTrials > 0 ? enTestMode.enRetake : enTestMode.enFirstTimeTaken;
            this.appointment = appointment;
            lblTestTrials.Text = numberOfTrials.ToString();
        }
        void _SetTestLbl(int testID) {
            switch (testID) {
                case 1: lblTestType.Text = "Schedule vision test"; break;
                case 2: lblTestType.Text = "Schedule written test"; break;
                case 3: lblTestType.Text = "Schedule street test"; break;
                default: lblTestType.Text = "Schedule vision test"; break;
            }
        }
        private void FrmAddAppointment_Load(object sender, EventArgs e) {
            _SetTestLbl(tType.TestTypeID);
            lblApplicationID.Text = licenseApp.LicenseAppID.ToString();
            lblLicenseClass.Text = licenseApp.LicenseClassInfo.className;
            lblApplicantName.Text = licenseApp.personInfo.FullName;
            
            if (testMode == enTestMode.enRetake && appointment.currentMode == enAppointmentMode.enAddAppointment) {
                gbRetakeTest.Visible = true;
                appType = AppType.getApplicationType(enApplicationType.RetakeTest);
                lblRetakeFees.Text = "$" + appType.AppTypeFees.ToString("0.##");
                lblTotalFees.Text = '$' + (tType.TestTypeFees + appType.AppTypeFees).ToString("0.##");
            } else { // taking the exam for the first time
                gbRetakeTest.Visible = false;
                txtDescription.Text = tType.TestTypeDescription.ToString();
            }
            if (appointment.currentMode == enAppointmentMode.enUpdateAppointment) {
                lblTestFees.Text = appointment.PaidFees.ToString("0.##");

                lblAppointmentID.Text = appointment.TestAppointmentID.ToString();

                if (appointment.AppointmentDate.Date < DateTime.Today) // if user created an appointment and the appointment date was passed
                    dpAppointmentDate.MinDate = appointment.AppointmentDate;
                else
                    dpAppointmentDate.MinDate = DateTime.Today;

                dpAppointmentDate.Value = appointment.AppointmentDate;

            } else {
                lblTestFees.Text = "$" + tType.TestTypeFees.ToString("0.##");

                dpAppointmentDate.MinDate = DateTime.Today;
            }
        }
     
        public void AppointentIsLocked() {
            lblAddApointment.ForeColor = Color.DimGray;
            lblAppointmentLocked.Visible = true;
            btnAddAppointment.Enabled = false;
            dpAppointmentDate.Enabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
        bool _RetakeAppSavedSuccessfully(Applications newRetakeApplication) {
            newRetakeApplication.personID = licenseApp.personID;
            newRetakeApplication.ApplicaitionTypeID = (int)enApplicationType.RetakeTest;
            newRetakeApplication.paidFees = appType.AppTypeFees;
            newRetakeApplication.createdByUserID = ImportantSessionData.user.userID;
            if (newRetakeApplication.SaveApplication()) {
                return true;
            }
            return false;
        }
        private void btnAddAppointment_Click(object sender, EventArgs e) {
            Applications newRetakeApplication = null;
            if (testMode == enTestMode.enRetake && appointment.currentMode == enAppointmentMode.enAddAppointment) {
                newRetakeApplication = new Applications();
                if (_RetakeAppSavedSuccessfully(newRetakeApplication)) {
                    appointment.RetakeTestApplicationID = newRetakeApplication.AppID;
                } 
                else {
                    Helpers.ShowErrorMessage("Error happend while saving retake app");
                }
            }

            if (appointment.currentMode == enAppointmentMode.enAddAppointment) {
                appointment.PaidFees = tType.TestTypeFees;
                appointment.TestTypeID = tType.TestTypeID;
                appointment.LocalDrivingLicenseApplicationID = licenseApp.LicenseAppID;
                appointment.CreatedByUserID = ImportantSessionData.user.userID;
                appointment.IsLocked = false;
            }

            if (dpAppointmentDate.Value.Date < DateTime.Today) {
                Helpers.ShowErrorMessage("The date cannot be chosen in the past");
                return;
            }
            appointment.AppointmentDate = dpAppointmentDate.Value;
            

            enAppointmentMode whatAppointmentModeWas = appointment.currentMode;

            if (appointment.Save()) {
                Helpers.SuccessfulMessage("Appointment saved successfully!");
                if (newRetakeApplication != null) {
                    lblRetakeID.Text = newRetakeApplication.AppID.ToString();
                    lblRetakeID.BackColor = Color.SpringGreen;
                }
                if (whatAppointmentModeWas == enAppointmentMode.enAddAppointment) {
                    lblAppointmentID.Text = appointment.TestAppointmentID.ToString();
                    lblAppointmentID.BackColor = Color.SpringGreen;
                }
                btnAddAppointment.Enabled = false;
            }
            else {
                Helpers.ShowErrorMessage("Error while saving");
            }
        }
    }
}
