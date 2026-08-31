using BusinessLayer;
using BusinessLayer.License_Applications;
using PresentationLayer.Properties;
using Shared;
using System;
using System.Windows.Forms;
using BusinessLayer;
using Global;
using System.Drawing;
namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmAppointments : Form {
        LocalLicenseApp licenseApp = null;
        enTestType testType = enTestType.enVision;
        public FrmAppointments(LocalLicenseApp licenseApp, enTestType testType) {
            InitializeComponent();
            this.licenseApp = licenseApp;
            this.testType = testType;
        }
        void _setTestImageAndLable() {
            if (testType == enTestType.enVision) 
                pbTestType.Image = Resources.vision;
            else if (testType == enTestType.enWritten) 
                pbTestType.Image = Resources.writtenTest;
            else 
                pbTestType.Image = Resources.streets;
            pbTestType.SizeMode = PictureBoxSizeMode.Zoom;
            lblTestType.Text = Utilities.convertTestTypeToString(testType) + " Appointments";
        }
        void _fillDgvWithAppropraitData() {
                dgvAppointments.DataSource = TestAppointments.getAppointmentsForTestType(licenseApp.LicenseAppID, testType);
            lblRecordsNo.Text = dgvAppointments.Rows.Count.ToString();
        }
        private void FrmAppointments_Load(object sender, EventArgs e) {
            dgvAppointments.RowTemplate.Height = 85;
            _setTestImageAndLable();
            ucLocalDrivingLicenseDetails1.loadData(licenseApp);
            _fillDgvWithAppropraitData();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (TestAppointments.isThereAnActiveAppointment(licenseApp.LicenseAppID, testType)) {
                Helpers.ShowErrorMessage("This person already have an active appointment for this test, you cannot add new appointment!");
                return;
            }
            if (Tests.isPersonPassedInTestType(licenseApp.LicenseAppID, testType)) {
                Helpers.ShowErrorMessage("This person already passed this test before!");
                return;
            }
            TestAppointments appointment = new TestAppointments();
            int testTakingTrials = dgvAppointments.Rows.Count;
            FrmAddAppointment frm = new FrmAddAppointment(appointment, licenseApp, testType, testTakingTrials);
            frm.ShowDialog();
            _fillDgvWithAppropraitData();
        }

        private void tmsiEditAppointment_Click(object sender, EventArgs e) {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value;
            TestAppointments selectedAppointment = TestAppointments.FindAppointmentByID(AppointmentID);
            FrmAddAppointment frm = new FrmAddAppointment(selectedAppointment, licenseApp, testType, dgvAppointments.Rows.Count);
            if (selectedAppointment.IsLocked) {
                frm.AppointentIsLocked();
            }

            frm.ShowDialog();
            _fillDgvWithAppropraitData();
        }

        void WasApplicantPassTheExam(bool ApplicantPassTheExam) {
            if (ApplicantPassTheExam) {
                ucLocalDrivingLicenseDetails1.AnExamWasPassed();
            }
        }
        
        bool _HasTheExamDatePassed(TestAppointments appointment) {
            if (appointment.AppointmentDate.Date < DateTime.Today) {
                Helpers.ShowErrorMessage("The exam time has passed, schedule a new test");
                return true;
            }
            return false;
        }

        bool _TestDayDidntCome(TestAppointments appointment) {
            if (appointment.AppointmentDate.Date > DateTime.Today) {
                Helpers.ShowErrorMessage("It's still time for the exam to start, please wait");
                return true;
            }
            return false;
        }

        private void tmsiTakeTest_Click(object sender, EventArgs e) {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value;
            TestAppointments selectedAppointment = TestAppointments.FindAppointmentByID(AppointmentID);


           
            if (selectedAppointment.IsLocked) {
                Helpers.ShowErrorMessage("The test is already taken");
                return;
            }

            if (_HasTheExamDatePassed(selectedAppointment)) {
                selectedAppointment.IsLocked = true;
                selectedAppointment.Save();
                dgvAppointments.CurrentRow.Cells["IsLocked"].Value = true;
                return;
            }

            if (_TestDayDidntCome(selectedAppointment)) {
                return;
            }

            FrmTakeTest TakeTestFrm = new FrmTakeTest(selectedAppointment);
            TakeTestFrm.OnPassExam += WasApplicantPassTheExam;
            TakeTestFrm.ShowDialog();
            _fillDgvWithAppropraitData();
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvAppointments.Columns[e.ColumnIndex].Name == "TestResult") {
                if (e.Value != DBNull.Value) {
                    string status = e.Value.ToString();

                    switch (status) {
                        case "Passed":
                            e.CellStyle.ForeColor = Color.Green;
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.SelectionForeColor = Color.Green;

                            break;

                        case "Failed":
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.BackColor = Color.Pink;
                            e.CellStyle.SelectionForeColor = Color.Red;
                            break;

                        case "Not Taken Yet":
                            e.CellStyle.ForeColor = Color.Orange;
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.SelectionForeColor = Color.Orange;
                            break;
                    }
                }
            }
        }
    }
}
