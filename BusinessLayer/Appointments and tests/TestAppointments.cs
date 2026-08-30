using System;
using System.Data;
using System.Net;
using BusinessLayer.License_Applications;
using DataLinkLayer;
using Shared;

namespace BusinessLayer {
    public enum enAppointmentMode { enAddAppointment = 0, enUpdateAppointment = 1}
    public class TestAppointments {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; }

        public TestType TestTypeInfo {
            get {
                return TestType.getTestType(this.TestTypeID);
            }
        }
        public LocalLicenseApp LocalLicenseAppInfo {
            get {
                return LocalLicenseApp.getLocalLicenseAppByID(this.LocalDrivingLicenseApplicationID);
            }
        }
        public enAppointmentMode currentMode = enAppointmentMode.enAddAppointment;

        public TestAppointments() {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = null;
            this.currentMode = enAppointmentMode.enAddAppointment;
        }

        public TestAppointments(TestAppointmentDTO dto) {
            if (dto != null) {
                this.TestAppointmentID = dto.TestAppointmentID;
                this.TestTypeID = dto.TestTypeID;
                this.LocalDrivingLicenseApplicationID = dto.LocalDrivingLicenseApplicationID;
                this.AppointmentDate = dto.AppointmentDate;
                this.PaidFees = dto.PaidFees;
                this.CreatedByUserID = dto.CreatedByUserID;
                this.IsLocked = dto.IsLocked;
                this.RetakeTestApplicationID = dto.RetakeTestApplicationID;
            }
        }

        public TestAppointmentDTO ToDTO() {
            return new TestAppointmentDTO {
                TestAppointmentID = this.TestAppointmentID,
                TestTypeID = this.TestTypeID,
                LocalDrivingLicenseApplicationID = this.LocalDrivingLicenseApplicationID,
                AppointmentDate = this.AppointmentDate,
                PaidFees = this.PaidFees,
                CreatedByUserID = this.CreatedByUserID,
                IsLocked = this.IsLocked,
                RetakeTestApplicationID = this.RetakeTestApplicationID
            };
        }
        private bool _AddNewAppointment() {
            this.TestAppointmentID = TestAppointmentsData.AddNewAppointment(this.ToDTO());
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateAppointment() {
            return TestAppointmentsData.UpdateAppointmentDate(this.ToDTO());
        }
        public bool Save() {
            switch (currentMode) {
                case enAppointmentMode.enAddAppointment:
                    if (_AddNewAppointment()) {
                        this.currentMode = enAppointmentMode.enUpdateAppointment;
                        return true;
                    }
                    return false;

                case enAppointmentMode.enUpdateAppointment:
                    return _UpdateAppointment();
            }

            return false;
        }
        public static DataTable getAppointmentsForTestType(int licenseAppID, enTestType testType) {
            TestType testTypeObject = TestType.getTestType((int)testType);
            return TestAppointmentsData.getAppointmentsForAppAndTestType(licenseAppID, testTypeObject.TestTypeTitle);
        }

        public static bool isThereAnActiveAppointment(int licenseAppID, enTestType testType) {
            TestType testTypeObject = TestType.getTestType((int)testType);
            return TestAppointmentsData.isThereAnActiveAppointment(licenseAppID, testTypeObject.TestTypeTitle);

        }
        public static TestAppointments FindAppointmentByID(int testAppointmentID) {
            TestAppointmentDTO dto = TestAppointmentsData.GetTestAppointmentInfoByID(testAppointmentID);
            if (dto != null) {
                TestAppointments appointment = new TestAppointments(dto);
                appointment.currentMode = enAppointmentMode.enUpdateAppointment;
                return appointment;
            }
            return null;
        }
    }
}