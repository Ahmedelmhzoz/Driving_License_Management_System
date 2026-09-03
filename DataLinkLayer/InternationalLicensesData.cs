using Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataLinkLayer {
    public class InternationalLicenseDTO {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public InternationalLicenseDTO() {}
        public InternationalLicenseDTO(
            int internationalLicenseID,
            int applicationID,
            int driverID,
            int issuedUsingLocalLicenseID,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID) {
            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
        }
    }
    public static class InternationalLicenseData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static int getInternationalIDByDriverID(int DriverID) {
            string query = @"SELECT InternationalLicenseID FROM InternationalLicenses il  
                            WHERE il.DriverID = @ID AND il.IsActive = 1";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ID", DriverID);
                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int internationalID)) {
                            return internationalID;
                        } 
                        else {
                            return -1;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return -1;
        }
        public static int AddNewInternationalLicense(InternationalLicenseDTO dto) {
            string query = @"INSERT INTO InternationalLicenses 
                    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                    VALUES 
                    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                    SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", dto.DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", dto.IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", dto.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", dto.IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);

                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID)) {
                            return insertedID;
                        }
                        else {
                            return -1;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        return -1;
                    }
                }
            }
        }

        public static DataTable getInternationalLicHistoryForPerson(int personID) {
            DataTable dt = new DataTable();
            string query = @"SELECT Iv.InternationalLicenseID, 
                                Iv.ApplicationID,    
                                Iv.IssuedUsingLocalLicenseID,  
                                Iv.IssueDate, 
                                Iv.ExpirationDate , 
                                Iv.LicenseStatus 
                            FROM Internationl_Driving_Licenses Iv 
                            WHERE Iv.PersonID = @PersonID;"; 
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

        public static DataTable getAllInternationalLicenses() {
            DataTable dt = new DataTable();
            string query = @"SELECT Iv.InternationalLicenseID, 
                                Iv.DriverID,
                                Iv.ApplicationID,    
                                Iv.IssuedUsingLocalLicenseID,  
                                Iv.IssueDate, 
                                Iv.ExpirationDate , 
                                Iv.LicenseStatus 
                            FROM Internationl_Driving_Licenses Iv 
                            ORDER BY InternationalLicenseID DESC;";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
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

        public static DataTable GetLicensesByFilter(enLicenseFilterBy filterColumn, string filterValue) {
            DataTable dt = new DataTable();
            string actualColumnName = "";
            switch (filterColumn) {
                case enLicenseFilterBy.InternationalLicenseID:
                    actualColumnName = "InternationalLicenseID";
                    break;

                case enLicenseFilterBy.DriverID:
                    actualColumnName = "DriverID";
                    break;

                case enLicenseFilterBy.LicenseStatus:
                    actualColumnName = "LicenseStatus";
                    break;

                default:
                    actualColumnName = "InternationalLicenseID";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $@"SELECT Iv.InternationalLicenseID,  
                                Iv.DriverID, 
                                Iv.ApplicationID,     
                                Iv.IssuedUsingLocalLicenseID,  
                                Iv.IssueDate, 
                                Iv.ExpirationDate , 
                                Iv.LicenseStatus 
                                FROM Internationl_Driving_Licenses Iv 
                               WHERE {actualColumnName} LIKE @filterValue + '%' 
                               ORDER BY InternationalLicenseID DESC;";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@filterValue", filterValue.Trim());
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
        public static DataTable GetLicensesByStatus(enLicenseStatus filterColumn) {
            DataTable dt = new DataTable();
            string actualStatusText = "";
            switch (filterColumn) {
                case enLicenseStatus.Active:
                    actualStatusText = "Active";
                    break;

                case enLicenseStatus.Suspended:
                    actualStatusText = "Suspended";
                    break;

                case enLicenseStatus.Expired:
                    actualStatusText = "Expired";
                    break;

                default:
                    actualStatusText = "";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $@"SELECT Iv.InternationalLicenseID, 
                                Iv.DriverID,
                                Iv.ApplicationID,    
                                Iv.IssuedUsingLocalLicenseID,  
                                Iv.IssueDate, 
                                Iv.ExpirationDate , 
                                Iv.LicenseStatus 
                        FROM Internationl_Driving_Licenses Iv 
                       WHERE LicenseStatus LIKE  @filterValue + '%' 
                       ORDER BY InternationalLicenseID DESC;";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@filterValue", actualStatusText.Trim());
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
        public static InternationalLicenseDTO FindInternationalLicenseByID(int internationalLicenseID) {
            InternationalLicenseDTO license = null;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                license = new InternationalLicenseDTO();
                                license.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                                license.ApplicationID = (int)reader["ApplicationID"];
                                license.DriverID = (int)reader["DriverID"];
                                license.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                license.IssueDate = (DateTime)reader["IssueDate"];
                                license.ExpirationDate = (DateTime)reader["ExpirationDate"];
                                license.IsActive = (bool)reader["IsActive"]; 
                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        license = null;
                    }
                }
            }
            return license;
        }
        public static bool UpdateExpiredLicensesStatus() {
            int rowsAffected = -1;
            string query = @"UPDATE InternationalLicenses 
                    SET IsActive = 0 
                    WHERE ExpirationDate < GETDATE() AND IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
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
            return (rowsAffected >= 0);
        }
    }
}
