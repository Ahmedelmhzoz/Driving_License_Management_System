using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer {
    public class TestDTO {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public TestDTO() {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
        }

        public TestDTO(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID) {
            this.TestID = testID;
            this.TestAppointmentID = testAppointmentID;
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
        }
    }
    public static class TestsData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static bool isPersonPassedInExamType(int localLicenseID, int testTypeID) {
            string query = @"SELECT Found = 1 from TestAppointments ta inner join Tests t
                            on ta.TestAppointmentID = t.TestAppointmentID 
                            where ta.LocalDrivingLicenseApplicationID = @licenseID and ta.TestTypeID = @testType and t.TestResult = 1;";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@licenseID", localLicenseID);
                    command.Parameters.AddWithValue("@testType", testTypeID);
                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return (result != null);
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }
            }
        }
        public static int AddNewTest(TestDTO dto) {
            int newTestID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"INSERT INTO Tests 
                                 (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                                 VALUES 
                                 (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@TestAppointmentID", dto.TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", dto.TestResult);

                    if (string.IsNullOrWhiteSpace(dto.Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", dto.Notes.Trim());

                    command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);

                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID)) {
                            newTestID = insertedID;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        newTestID = -1;
                    }
                }
            }

            return newTestID;
        }

    }
}
