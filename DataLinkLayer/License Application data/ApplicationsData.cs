using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer.License_Application_data {
    public enum enApplicationStatus { enNew = 1, enCanceled = 2, enCompleted = 3 }
    public class ApplicationDTO {
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
    }
}
