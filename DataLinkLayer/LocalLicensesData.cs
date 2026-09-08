using Shared;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using static System.Net.Mime.MediaTypeNames;


namespace DataLinkLayer {
    public class LocalLicenseDTO {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool NotSuspended { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
    }
    public static class LocalLicensesData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;

        static LocalLicenseDTO _MapReaderToLicenseDTO(SqlDataReader reader) {
            return new LocalLicenseDTO {
                LicenseID = (int)reader["LicenseID"],
                ApplicationID = (int)reader["ApplicationID"],
                DriverID = (int)reader["DriverID"],
                LicenseClassID = (int)reader["LicenseClass"],
                IssueDate = (DateTime)reader["IssueDate"],
                ExpirationDate = (DateTime)reader["ExpirationDate"],
                Notes = reader["Notes"] == DBNull.Value ? string.Empty : (string)reader["Notes"],
                PaidFees = (decimal)reader["PaidFees"],
                NotSuspended = (bool)reader["IsActive"],
                IssueReason = (enIssueReason)Convert.ToByte(reader["IssueReason"]),
                CreatedByUserID = (int)reader["CreatedByUserID"]
            };
        }
        public static int AddNewLicense(LocalLicenseDTO dto) {
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
                    command.Parameters.AddWithValue("@IsActive", dto.NotSuspended);
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
        public static LocalLicenseDTO GetLicenseInfoByApplicationID(int applicationID) {
            LocalLicenseDTO dto = null;
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
                                dto = _MapReaderToLicenseDTO(reader);
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
        public static LocalLicenseDTO GetLicenseInfoByID(int licenseID) {
            LocalLicenseDTO dto = null;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClass, 
                                        IssueDate, ExpirationDate, Notes, PaidFees, 
                                        IsActive, IssueReason, CreatedByUserID 
                                 FROM Licenses 
                                 WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                dto = _MapReaderToLicenseDTO(reader);
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
        public static DataTable getLocalLicensesHistoryForPerson(int personID) {
            DataTable dt = new DataTable();
            string query = @"SELECT l.LicenseID, 
                            l.ApplicationID, 
                            LTRIM(SUBSTRING(lc.ClassName, CHARINDEX('-', lc.ClassName) + 1, LEN(lc.ClassName))) as ClassName, 
                            CAST(l.IssueDate AS DATE) as IssueDate, 
                            CAST (l.ExpirationDate AS DATE) as ExpirationDate, 
                            CASE 
                                WHEN l.ExpirationDate < CAST(GETDATE() AS DATE) THEN 'Expired'
                                WHEN l.IsActive = 0 THEN 'Suspended'
                                WHEN l.IsActive = 1 THEN 'Active'
                            END AS LicenseStatus
                            FROM Licenses l inner join LicenseClasses lc on l.LicenseClass = lc.LicenseClassID 
                            inner join Applications a on a.ApplicationID = l.ApplicationID 
                            WHERE a.ApplicantPersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return dt;
        }
        public static int getRenewalLicenseID(int oldLicense) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand("SELECT NewLicenseID FROM LocalLicenseRenewals WHERE OldLicenseID = @OldLicenseID", connection)) {
                    try {
                        command.Parameters.AddWithValue("@OldLicenseID", oldLicense);
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null) {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        return -1;
                    }
                }
            }
            return -1;
        }
        public static int addLocalLicenseInTransaction(LocalLicenseDTO localLicenseDTO, SqlConnection connection, SqlTransaction transaction) {
            const string query = @"INSERT INTO Licenses
                                (
                                    ApplicationID,
                                    DriverID,
                                    LicenseClass,
                                    IssueDate,
                                    ExpirationDate,
                                    Notes,
                                    PaidFees,
                                    IsActive,
                                    IssueReason,
                                    CreatedByUserID
                                )
                                VALUES
                                (
                                    @ApplicationID,
                                    @DriverID,
                                    @LicenseClassID,
                                    @IssueDate,
                                    @ExpirationDate,
                                    @Notes,
                                    @PaidFees,
                                    @IsActive,
                                    @IssueReason,
                                    @CreatedByUserID
                                );
                                SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@ApplicationID", localLicenseDTO.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", localLicenseDTO.DriverID);
                command.Parameters.AddWithValue("@LicenseClassID", localLicenseDTO.LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", localLicenseDTO.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", localLicenseDTO.ExpirationDate);
                command.Parameters.AddWithValue("@Notes", localLicenseDTO.Notes == string.Empty ? DBNull.Value : (object)localLicenseDTO.Notes);
                command.Parameters.AddWithValue("@PaidFees", localLicenseDTO.PaidFees);
                command.Parameters.AddWithValue("@IsActive", localLicenseDTO.NotSuspended);
                command.Parameters.AddWithValue("@IssueReason", (byte)localLicenseDTO.IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", localLicenseDTO.CreatedByUserID);

                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new Exception("Failed to create local license.");

                return Convert.ToInt32(result);
            }
        }
        public static void suspendLocalLicense(int licenseID, SqlConnection connection, SqlTransaction transaction) {
            using (SqlCommand command = new SqlCommand("UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @licenseID", connection, transaction)) {
                command.Parameters.AddWithValue("@licenseID", licenseID);

                if (command.ExecuteNonQuery() <= 0) throw new Exception("Failed to deactivate the license.");
            }
        }
    } 
}
