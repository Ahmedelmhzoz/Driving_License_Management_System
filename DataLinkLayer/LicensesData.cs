using Shared;
using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DataLinkLayer {
    public class LicenseDTO {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
    }
    public static class LicensesData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static bool IsThereLicenseForApp(int applicationID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand("SELECT found = 1 FROM Licenses where ApplicationID = @AppID", connection)) {
                    command.Parameters.AddWithValue("@AppID", applicationID);
                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return (result != null);
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return false;
        }

    }
}
