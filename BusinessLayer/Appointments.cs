using System;
using System.Data;
using DataLinkLayer;
using Shared;

namespace BusinessLayer {
    public class TestAppointments {
        public int TestAppointmentID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public string TestTypeTitle { get; set; }
        public string ClassName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public string FullName { get; set; }
        public bool IsLocked { get; set; }

        public TestAppointments() {
            this.TestAppointmentID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.TestTypeTitle = string.Empty;
            this.ClassName = string.Empty;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.FullName = string.Empty;
            this.IsLocked = false;
        }
        TestAppointments(TestAppointmentViewDTO dto) {
            if (dto != null) {
                this.TestAppointmentID = dto.TestAppointmentID;
                this.LocalDrivingLicenseApplicationID = dto.LocalDrivingLicenseApplicationID;
                this.TestTypeTitle = dto.TestTypeTitle;
                this.ClassName = dto.ClassName;
                this.AppointmentDate = dto.AppointmentDate;
                this.PaidFees = dto.PaidFees;
                this.FullName = dto.FullName;
                this.IsLocked = dto.IsLocked;
            }
        }
        public static DataTable getAppointmentsForTestType(int licenseAppID, enTestType testType) {
            TestType testTypeObject = TestType.getTestType(Utilities.convertTestTypeToID(testType));
            return TestAppointmentsData.getAppointmentsForAppAndTestType(licenseAppID, testTypeObject.TestTypeTitle);
        }
    }
}