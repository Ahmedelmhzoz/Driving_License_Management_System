using Shared;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public class DetainDTO {
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public string Reason { get; set; }
        public int CreatedByUserID { get; set; }

        public DetainDTO(InputtedDetainDetails detainInputedData) {
            LicenseID = detainInputedData.LicenseID;
            DetainDate = detainInputedData.detainDate;
            FineFees = detainInputedData.fineFees;
            Reason = detainInputedData.reason;
            CreatedByUserID = detainInputedData.createdByUserID;
        }
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
        public static int detainLicense(DetainDTO detainDTO) {
            int detainID = -1;

            string query = @"INSERT INTO DetainedLicenses ( 
                            LicenseID,
                            DetainDate,
                            FineFees,
                            CreatedByUserID,
                            IsReleased,
                            ReleaseDate,
                            ReleasedByUserID,
                            ReleaseApplicationID, 
                            Reason
                        )   
                        VALUES ( 
                            @LicenseID,
                            @DetainDate,
                            @FineFees,
                            @CreatedByUserID,
                            0,
                            NULL,
                            NULL,
                            NULL, 
                            @Reason
                        );

                        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@LicenseID", detainDTO.LicenseID);
                command.Parameters.AddWithValue("@DetainDate", detainDTO.DetainDate);
                command.Parameters.AddWithValue("@FineFees", detainDTO.FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", detainDTO.CreatedByUserID);
                command.Parameters.AddWithValue("@Reason", detainDTO.Reason);

                connection.Open();

                object result = command.ExecuteScalar();

                

                if (result == null || !int.TryParse(result.ToString(), out int id)) 
                    throw new Exception("Failed to retrieve the Detain ID.");

                detainID = id;
            }

            return detainID;
        }
    }
}