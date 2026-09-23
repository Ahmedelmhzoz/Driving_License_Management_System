using Shared;
using System;
using System.Collections.Generic;
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
                            tv.IsLocked,
                            tv.TestResult
                     FROM TestAppointments_View tv
                     WHERE tv.LocalDrivingLicenseApplicationID = @licenseID 
                       AND tv.TestTypeTitle = @TestTitle ORDER BY TestAppointmentID DESC";


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
        public static int getPendingAppointmentsNum() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT COUNT(TA.TestAppointmentID) FROM TestAppointments TA WHERE TA.IsLocked = 0";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static AppointmentsStatistics getAppintmentsStatistics() {
            AppointmentsStatistics appointmentsStatistics = new AppointmentsStatistics();

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"SELECT TT.TestTypeID, COUNT(TA.TestAppointmentID) AS TestsNumber FROM  TestTypes TT LEFT JOIN TestAppointments TA 
                                ON Ta.TestTypeID = TT.TestTypeID WHERE TA.IsLocked = 1
                                GROUP BY TT.TestTypeID;

                                SELECT TA.TestTypeID, COALESCE(CAST(SUM(CASE WHEN T.TestResult = 1 THEN 1 ELSE 0 END) AS Float) / NULLIF(COUNT(*), 0), 0) AS PassRate
                                FROM TestAppointments TA INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID 
                                WHERE TA.IsLocked = 1 
                                GROUP By TA.TestTypeID;

                                SELECT TT.TestTypeID , COUNT(TA.TestAppointmentID) AS TodayTests FROM TestTypes TT LEFT JOIN TestAppointments TA  
                                ON TT.TestTypeID = TA.TestTypeID AND TA.IsLocked = 0 AND CAST(TA.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)  
                                GROUP BY TT.TestTypeID";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) { 
                        while (reader.Read()) 
                            appointmentsStatistics.takenTestsPerType.Add((enTestType)reader["TestTypeID"], (int)reader["TestsNumber"]);
                        reader.NextResult();
                        while (reader.Read()) 
                            appointmentsStatistics.PassFailTestRatesPerType.Add((enTestType)reader["TestTypeID"], ((double)reader["PassRate"], 1 - (double)reader["PassRate"]));
                        reader.NextResult();
                        while (reader.Read()) 
                            appointmentsStatistics.todayAppointmentsPerType.Add((enTestType)reader["TestTypeID"], (int)reader["TodayTests"]);
                    }
                }
                return appointmentsStatistics;
            }
        }
    }
}