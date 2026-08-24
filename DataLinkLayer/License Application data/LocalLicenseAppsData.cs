using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLinkLayer.PeopleData;

namespace DataLinkLayer.License_Application_data {
    public enum enLocalAppSearchCategory {
        enLDApplicationID = 1,
        enNationalNo = 2,
        enFullName = 3,
        enStatus = 4
    }
    public class LicenseApplicationDTO {
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int LicenseClassID { get; set; }
        public int appID { get; set; }

    }
    public static class LocalLicenseAppsData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static int didPersonMakeSameApplication(int personID, int LicenseClassID) {
            string query = @"select a.ApplicationID from People p inner join Applications a on a.ApplicantPersonID = p.PersonID
                            inner join LocalDrivingLicenseApplications ld on ld.ApplicationID = a.ApplicationID
                            inner join LicenseClasses lc on lc.LicenseClassID = ld.LicenseClassID
                            where p.PersonID = @PersonID and lc.LicenseClassID = @LicenseClassID and a.ApplicationStatus <> '2';";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int appID))
                           return appID;
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return -1;
        }


        public static int AddLicenseApplication(LicenseApplicationDTO localDTO) {
            int insertedLocalApplicationID = -1;

            string query = @"INSERT INTO LocalDrivingLicenseApplications 
                    (ApplicationID, LicenseClassID)
                    VALUES 
                    (@ApplicantID, @LicenseClassID);
                    SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicantID", localDTO.appID);
                    command.Parameters.AddWithValue("@LicenseClassID", localDTO.LicenseClassID);
                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newID)) {
                            insertedLocalApplicationID = newID;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
                return insertedLocalApplicationID;
            }
        }
        public static DataTable GetAllLocalDrivingLicenseApplications() {
            DataTable dt = new DataTable();

            string query = @"SELECT LocalDrivingLicenseApplicationID, 
                                    ClassName, 
                                    NationalNo, 
                                    FullName, 
                                    ApplicationDate, 
                                    PassedExams, 
                                    ApplicationStatus 
                             FROM Local_Driving_license_Application;";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
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

        static string _convertEnumToColumn(enLocalAppSearchCategory category) {
            switch (category) {
                case enLocalAppSearchCategory.enNationalNo:
                    return "NationalNo";
                case enLocalAppSearchCategory.enFullName:
                    return "FullName";
                case enLocalAppSearchCategory.enStatus:
                    return "ApplicationStatus";
                default:
                    return "LocalDrivingLicenseApplicationID";
            }
        }
        public static DataTable GetApplicationsSearchResult(string searchText, enLocalAppSearchCategory category) { 
            DataTable dt = new DataTable();
            string query;
            string columnName = _convertEnumToColumn(category);
            if (columnName == "LocalDrivingLicenseApplicationID") {
                query = "Select * FROM Local_Driving_license_Application where LocalDrivingLicenseApplicationID = @searchText";
            } 
            else {
                query = $"Select * FROM Local_Driving_license_Application where {columnName} like @searchText + '%'";
            }
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    try {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
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
        public static LicenseApplicationDTO GetLocalLicenseAppByID(int localDrivingLicenseApplicationID) {
            LicenseApplicationDTO dto = null;

            string query = @"SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID 
                     FROM LocalDrivingLicenseApplications 
                     WHERE LocalDrivingLicenseApplicationID = @LocalAppID";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@LocalAppID", localDrivingLicenseApplicationID);

                    try {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                dto = new LicenseApplicationDTO {
                                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"],
                                    appID = (int)reader["ApplicationID"],
                                    LicenseClassID = (int)reader["LicenseClassID"]
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
