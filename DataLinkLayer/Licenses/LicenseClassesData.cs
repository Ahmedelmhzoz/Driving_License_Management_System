using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataLinkLayer.License_Application_data {
    public class LicenseClassDTO {
        public int LicenseClassID { get; set; }
        public string className { get; set; }
        public byte minimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal classFees { get; set; }
    }
    public static class LicenseClassesData {
        static string connectionSettings = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static DataTable getAllLicenseClasses() {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                using (SqlCommand command = new SqlCommand("SELECT * FROM LicenseClasses", connection)) {
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
        public static LicenseClassDTO GetLicenseClassByID(int licenseClassID) {
            string query = @"SELECT LicenseClassID, ClassName, MinimumAllowedAge, DefaultValidityLength, ClassFees 
                    FROM LicenseClasses 
                    WHERE LicenseClassID = @LicenseClassID";

            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings))
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            return new LicenseClassDTO {
                                LicenseClassID = (int)reader["LicenseClassID"],
                                className = (string)reader["ClassName"],
                                minimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                                classFees = (decimal)reader["ClassFees"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }

            return null;
        }

    }
}
