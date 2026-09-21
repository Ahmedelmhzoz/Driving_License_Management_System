using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    public class TestResultDTO {
        public int TestID { get; set; }
        public string TestTypeTitle { get; set; }
        public string ApplicantName { get; set; }
        public string TesterUsername { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int attemptNumber { get; set; }

        public TestResultDTO() {
            this.TestID = -1;
            this.TestTypeTitle = string.Empty;
            this.ApplicantName = string.Empty;
            this.TesterUsername = string.Empty;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.attemptNumber = -1;
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
        public static TestResultDTO getTestResults(int appointmentID) {
            string query = @"SELECT 
                            T.TestID, 
                            TT.TestTypeTitle, 
                            ApplicantName = p. FirstName + ' ' + p. SecondName + ' ' + ISNULL(p. ThirdName,'') + ' ' + p. LastName, 
                            U.UserName, 
                            T.TestResult, 
                            T.Notes  
                            FROM Tests T 
                            inner JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                            inner join TestTypes TT ON TT.TestTypeID = TA.TestTypeID
                            Inner Join LocalDrivingLicenseApplications l ON l.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                            inner join Applications A ON A.ApplicationID = l.ApplicationID 
                            Inner join People p ON P.PersonID = A.ApplicantPersonID
                            inner join Users u ON u.UserID = T.CreatedByUserID
                            WHERE TA.TestAppointmentID = @TestAppointmentID;


                            select AttemptNumber from (
	                            select TestAppointmentID , 
	                            ROW_NUMBER() over (
		                            order by AppointmentDate, TestAppointmentID
	                            ) as AttemptNumber
	                            from TestAppointments_View tv 
	                            where tv.LocalDrivingLicenseApplicationID = ( 
				                            select LocalDrivingLicenseApplicationID from TestAppointments_View where 
				                            TestAppointmentID = @TestAppointmentID
     		                            ) 
	                            and tv.TestTypeTitle = (
				                            select TestTypeTitle from TestAppointments_View where 
				                            TestAppointmentID = @TestAppointmentID
	                            )
	                            and tv.IsLocked = 1
                            ) S
                            where S.TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@TestAppointmentID", appointmentID);

  
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    TestResultDTO dto = null;
                    if (reader.Read()) {
                        dto = new TestResultDTO();
                        dto.TestID = Convert.ToInt32(reader["TestID"]);
                        dto.TestTypeTitle = reader["TestTypeTitle"].ToString();
                        dto.ApplicantName = reader["ApplicantName"].ToString();
                        dto.TesterUsername = reader["UserName"].ToString();
                        dto.TestResult = Convert.ToBoolean(reader["TestResult"]);

                        if (reader["Notes"] != DBNull.Value)
                            dto.Notes = reader["Notes"].ToString();

                    }
                    reader.NextResult();
                    if (reader.Read()) {
                        dto.attemptNumber = Convert.ToInt32(reader["AttemptNumber"]);
                    }
                    return dto;
                }
            }
        }
    }
}
    