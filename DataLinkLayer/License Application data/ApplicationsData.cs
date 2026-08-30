using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Shared;

namespace DataLinkLayer.License_Application_data {
   

    public class ApplicationDTO {
        public ApplicationDTO() {
            AppID = -1; createdByUserID = -1; personID = -1; ApplicaitionTypeID = -1;
            AppDate = DateTime.Now;
            lastStatusDate = DateTime.Now;
            appStatus = enApplicationStatus.enNew;
            paidFees = 0.0m;
        }

        public int AppID;
        public int personID { get; set; }
        public DateTime AppDate { get; set; }
        public int ApplicaitionTypeID { get; set; }
        public DateTime lastStatusDate { get; set; }
        public enApplicationStatus appStatus;
        public decimal paidFees { get; set; }
        public int createdByUserID { get; set; }

    }

    public static class ApplicationsData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static int AddNewApplication(ApplicationDTO appDTO) {
            int insertedApplicationID = -1;

            string query = @"INSERT INTO Applications 
                    (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                    VALUES 
                    (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                    SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicantPersonID", appDTO.personID);
                    command.Parameters.AddWithValue("@ApplicationDate", appDTO.AppDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", appDTO.ApplicaitionTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", (byte)appDTO.appStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", appDTO.lastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", appDTO.paidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", appDTO.createdByUserID);

                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newID)) {
                            insertedApplicationID = newID;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return insertedApplicationID;
        }

        public static ApplicationDTO GetApplicationInfoByID(int applicationID) {
            ApplicationDTO dto = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT ApplicationID, ApplicantPersonID, ApplicationDate, 
                                        ApplicationTypeID, ApplicationStatus, LastStatusDate, 
                                        PaidFees, CreatedByUserID
                                 FROM Applications 
                                 WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                dto = new ApplicationDTO {
                                    AppID = (int)reader["ApplicationID"],
                                    personID = (int)reader["ApplicantPersonID"],
                                    AppDate = (DateTime)reader["ApplicationDate"],
                                    ApplicaitionTypeID = (int)reader["ApplicationTypeID"],
                                    appStatus = (enApplicationStatus)reader["ApplicationStatus"],
                                    lastStatusDate = (DateTime)reader["LastStatusDate"],
                                    paidFees = (decimal)reader["PaidFees"],
                                    createdByUserID = (int)reader["CreatedByUserID"]
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
        public static ApplicationDTO GetApplicationByID(int appID) {
            ApplicationDTO appDTO = null;
            string query = "SELECT * FROM Applications WHERE ApplicationID = @AppID";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@AppID", appID);
                    try {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                appDTO = new ApplicationDTO {
                                    AppID = (int)reader["ApplicationID"],
                                    personID = (int)reader["ApplicantPersonID"],
                                    AppDate = (DateTime)reader["ApplicationDate"],
                                    ApplicaitionTypeID = (int)reader["ApplicationTypeID"],
                                    appStatus = (enApplicationStatus)Convert.ToByte(reader["ApplicationStatus"]),
                                    lastStatusDate = (DateTime)reader["LastStatusDate"],
                                    paidFees = (decimal)reader["PaidFees"],
                                    createdByUserID = (int)reader["CreatedByUserID"]
                                };
                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return appDTO;
        }
        public static bool UpdateStatus(int applicationID, byte newStatus, DateTime lastStatusDate) {
            string query = @"UPDATE Applications 
                    SET ApplicationStatus = @Status, LastStatusDate = @LastStatusDate 
                       WHERE ApplicationID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
                    cmd.Parameters.AddWithValue("@ID", applicationID);

                    try {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }
            }
        }
        public static bool UpdateApplication(ApplicationDTO dto) {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"UPDATE Applications
                         SET ApplicantPersonID = @ApplicantPersonID,
                             ApplicationDate   = @ApplicationDate,
                             ApplicationTypeID = @ApplicationTypeID,
                             ApplicationStatus = @ApplicationStatus,
                             LastStatusDate    = @LastStatusDate,
                             PaidFees          = @PaidFees,
                             CreatedByUserID   = @CreatedByUserID
                         WHERE ApplicationID   = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationID", dto.AppID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", dto.personID);
                    command.Parameters.AddWithValue("@ApplicationDate", dto.AppDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", dto.ApplicaitionTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", dto.appStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", dto.lastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", dto.paidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", dto.createdByUserID);

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
    }
}
