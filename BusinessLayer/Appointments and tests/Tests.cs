using DataLinkLayer;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer {
    public class Tests {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; } // true = Pass, false = Fail
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public Tests() {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
        }

        public TestDTO ToDTO() {
            return new TestDTO(
                this.TestID,
                this.TestAppointmentID,
                this.TestResult,
                this.Notes,
                this.CreatedByUserID
            );
        }

        private bool _AddNewTest() {
            this.TestID = TestsData.AddNewTest(this.ToDTO());

            if (this.TestID != -1) {
                TestAppointments appointment = TestAppointments.FindAppointmentByID(this.TestAppointmentID);
                if (appointment != null) {
                    appointment.IsLocked = true;
                    appointment.Save();
                }
                return true;
            }

            return false;
        }

        public bool Save() {
            return _AddNewTest();
        }
        public static bool isPersonPassedInTestType(int licenseAppID, enTestType testType) {
            return TestsData.isPersonPassedInExamType(licenseAppID, (int)testType);
        }
    }
}
