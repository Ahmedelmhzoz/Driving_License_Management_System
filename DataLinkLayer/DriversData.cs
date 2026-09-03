using System;
using System.Configuration;
using Shared;
using System.Data;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public class DriverDTO {
        public int driverID { get; set; }
        public int createdByUserID { get; set; }
        public DateTime creationDate { get; set; }
        public int personID { get; set; }
    }
    public static class clsDriverData {
        static string connectionSettings = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;

        public static DataTable GetAllDrivers() {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = @"SELECT * FROM Drivers_View ORDER BY DriverID DESC;";

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

        public static int AddNewDriver(DriverDTO dto) {
            int newDriverID = -1;

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                                 VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@PersonID", dto.personID);
                    command.Parameters.AddWithValue("@CreatedByUserID", dto.createdByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", dto.creationDate);

                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID)) {
                            newDriverID = insertedID;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        newDriverID = -1;
                    }
                }
            }
            return newDriverID;
        }
        public static bool isPesonAlreadyDriver(int personID) {
            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = @"select found = 1 from Drivers
                                    where PersonID = @personID";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@personID", personID);
                    try {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        return result != null;
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }
            }
        }
        public static DriverDTO findDriverByPersonID(int personID) {
            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = @"Select DriverID, PersonID, CreatedByUserID, CreatedDate From Drivers 
                                  WHERE PersonID = @PersonID;";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                return new DriverDTO {
                                    driverID = (int)reader["DriverID"],
                                    personID = (int)reader["PersonID"],
                                    createdByUserID = (int)reader["CreatedByUserID"],
                                    creationDate = (DateTime)reader["CreatedDate"]
                                };
                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return null;
        }
        public static DataTable GetDriversByFilter(enDriverFilterColumn filterColumn, string filterValue) {
            DataTable dt = new DataTable();
            string actualColumnName = "";
            switch (filterColumn) {
                case enDriverFilterColumn.DriverID:
                    actualColumnName = "DriverID";
                    break;

                case enDriverFilterColumn.PersonID:
                    actualColumnName = "PersonID";
                    break;

                case enDriverFilterColumn.NationalNo:
                    actualColumnName = "NationalNo";
                    break;

                default :
                    actualColumnName = "FullName";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = $@"SELECT * FROM Drivers_View 
                       WHERE {actualColumnName} LIKE '%' + @filterValue + '%' 
                       ORDER BY DriverID DESC;";
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
        public static DriverDTO FindDriverByID(int driverID) {
            DriverDTO driver = null;
            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@DriverID", driverID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) { 
                                driver = new DriverDTO();
                                driver.driverID = (int)reader["DriverID"];
                                driver.personID = (int)reader["PersonID"];
                                driver.createdByUserID = (int)reader["CreatedByUserID"];
                                driver.creationDate = (DateTime)reader["CreatedDate"];

                            }
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        driver = null;
                    }
                }
            }
            return driver; 
        }
    }
}