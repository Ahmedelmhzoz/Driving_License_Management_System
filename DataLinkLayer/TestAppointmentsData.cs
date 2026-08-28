using Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public class TestAppointmentViewDTO {
        public int TestAppointmentID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public string TestTypeTitle { get; set; }
        public string ClassName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public string FullName { get; set; }
        public bool IsLocked { get; set; }
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
    }
}