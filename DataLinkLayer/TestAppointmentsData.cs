using Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public class TestAppointmentDTO {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; } 
    }

    public static class TestAppointmentsData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;

        public static DataTable getAppointmentsForAppAndTestType(int licenseAppID, string testTypeTitle) {
            DataTable dt = new DataTable();

            string query = @"SELECT tv.TestAppointmentID,
                            tv.AppointmentDate,
                            tv.PaidFees,
                            tv.IsLocked
                     FROM TestAppointments_View tv
                     WHERE tv.LocalDrivingLicenseApplicationID = @licenseID 
                       AND tv.TestTypeTitle = @TestTitle";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@licenseID", licenseAppID);
                    command.Parameters.AddWithValue("@TestTitle", testTypeTitle);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dt;
        }
        public static int AddNewAppointment(TestAppointmentDTO dto) {
            int newAppointmentID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"INSERT INTO TestAppointments 
                             (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                             VALUES 
                             (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@TestTypeID", dto.TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", dto.LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", dto.AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", dto.IsLocked);
                    
                    if (dto.RetakeTestApplicationID.HasValue)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", dto.RetakeTestApplicationID.Value);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID)) {
                            newAppointmentID = insertedID;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        newAppointmentID = -1;
                    }
                }
            }

            return newAppointmentID;
        }
        public static bool UpdateAppointmentDate(TestAppointmentDTO testAppointmentDTO) {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"UPDATE TestAppointments 
                             SET AppointmentDate = @AppointmentDate, IsLocked = @isLocked
                             WHERE TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentDTO.TestAppointmentID);
                    command.Parameters.AddWithValue("@AppointmentDate", testAppointmentDTO.AppointmentDate);
                    command.Parameters.AddWithValue("@isLocked", testAppointmentDTO.IsLocked);

                    try {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool isThereAnActiveAppointment(int licenseAppID, string testTypeTitle) {
            DataTable dt = new DataTable();

            string query = @"SELECT Found = 1 FROM TestAppointments_View tv
                     WHERE tv.LocalDrivingLicenseApplicationID = @licenseID 
                       AND tv.TestTypeTitle = @TestTypeTitle AND IsLocked = 0";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@licenseID", licenseAppID);
                    command.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);

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
        public static TestAppointmentDTO GetTestAppointmentInfoByID(int testAppointmentID) {
            TestAppointmentDTO dto = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT * FROM TestAppointments 
                         WHERE TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                dto = new TestAppointmentDTO {
                                    TestAppointmentID = (int)reader["TestAppointmentID"],
                                    TestTypeID = (int)reader["TestTypeID"],
                                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"],
                                    AppointmentDate = (DateTime)reader["AppointmentDate"],
                                    PaidFees = (decimal)reader["PaidFees"],
                                    CreatedByUserID = (int)reader["CreatedByUserID"],
                                    IsLocked = (bool)reader["IsLocked"],
                                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value
                                        ? (int?)reader["RetakeTestApplicationID"] : null
                                };
                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        dto = null;
                    }
                }
            }

            return dto;
        }
    }
}