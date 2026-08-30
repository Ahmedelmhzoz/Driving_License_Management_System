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
        public static int AddNewLicense(LicenseDTO dto) {
            int newLicenseID = -1;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"INSERT INTO Licenses 
                                  (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                                  VALUES 
                                  (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                                  SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", dto.DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", dto.LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", dto.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);

                    if (string.IsNullOrWhiteSpace(dto.Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", dto.Notes.Trim());

                    command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", dto.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (byte)dto.IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);

                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID)) {
                            newLicenseID = insertedID;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        newLicenseID = -1;
                    }
                }
            }

            return newLicenseID;
        }
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
        public static LicenseDTO GetLicenseInfoByApplicationID(int applicationID) {
            LicenseDTO dto = null;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClass, 
                                        IssueDate, ExpirationDate, Notes, PaidFees, 
                                        IsActive, IssueReason, CreatedByUserID 
                                 FROM Licenses 
                                 WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                dto = new LicenseDTO {
                                    LicenseID = (int)reader["LicenseID"],
                                    ApplicationID = (int)reader["ApplicationID"],
                                    DriverID = (int)reader["DriverID"],
                                    LicenseClassID = (int)reader["LicenseClass"],
                                    IssueDate = (DateTime)reader["IssueDate"],
                                    ExpirationDate = (DateTime)reader["ExpirationDate"],
                                    Notes = reader["Notes"] == DBNull.Value ? string.Empty : (string)reader["Notes"],
                                    PaidFees = (decimal)reader["PaidFees"],
                                    IsActive = (bool)reader["IsActive"],
                                    IssueReason = (enIssueReason)Convert.ToByte(reader["IssueReason"]),
                                    CreatedByUserID = (int)reader["CreatedByUserID"]
                                };
                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return dto;
        }
    }
}
