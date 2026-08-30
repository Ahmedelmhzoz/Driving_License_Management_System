using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public class DetainedLicenseDTO {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }
    }
    public static class DetainedLicensesData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static bool IsLicenseDetained(int licenseID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT Found = 1 
                                 FROM DetainedLicenses 
                                 WHERE LicenseID = @LicenseID AND IsReleased = 0;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

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
    }
}