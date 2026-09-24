using Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer.License_Application_data {
    public class TestTypeDTO {                 
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public decimal TestTypeFees { get; set; }
        public string description { get; set; }
    }
    public static class AppAndTestTypes {
        static string connectionSettings = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static DataTable GetAllApplicationTypes() {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                using (SqlCommand command = new SqlCommand("SELECT * FROM ApplicationTypes", connection)) {
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
        public static DataTable GetAllTestTypes() {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = "SELECT * FROM TestTypes";

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
        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees) {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                isFound = true;
                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);
                            }
                        }
                    }
                    catch (Exception ex) {
                        isFound = false;
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }
        public static bool GetTestTypeInfoByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees) {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                using (SqlCommand command = new SqlCommand("SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID", connection)) {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                isFound = true;
                                TestTypeTitle = (string)reader["TestTypeTitle"];
                                TestTypeDescription = (string)reader["TestTypeDescription"];
                                TestTypeFees = Convert.ToDecimal(reader["TestTypeFees"]);
                            }
                        }
                    }
                    catch (Exception ex) {
                        isFound = false;
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees) {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = @"UPDATE ApplicationTypes
                             SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                 ApplicationFees = @ApplicationFees
                             WHERE ApplicationTypeID = @ApplicationTypeID";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
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
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees) {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                string query = @"UPDATE TestTypes
                     SET TestTypeTitle = @TestTypeTitle,
                         TestTypeDescription = @TestTypeDescription,
                         TestTypeFees = @TestTypeFees
                     WHERE TestTypeID = @TestTypeID";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                    command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                    command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
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

        public static TestTypeDTO getTestType(enTestType testType) {
            int testID = Utilities.convertTestTypeToID(testType);

            string query = @"SELECT TestTypeID, TestTypeTitle, TestTypeFees , TestTypeDescription
                    FROM TestTypes 
                    WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@TestTypeID", testID);

                    try {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                return new TestTypeDTO {
                                    TestTypeID = (int)reader["TestTypeID"],
                                    TestTypeTitle = (string)reader["TestTypeTitle"],
                                    TestTypeFees = Convert.ToDecimal(reader["TestTypeFees"]),
                                    description = (string)reader["TestTypeDescription"]
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
        public static decimal GetFees(enApplicationType applicationType) {
            decimal fees = 0;
            string query = "SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeId = @ApplicationTypeId";

            using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    try {
                        command.Parameters.AddWithValue("@ApplicationTypeId", (int)applicationType);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal decimalResult)) {
                            fees = decimalResult;
                        }
                    }
                    catch (Exception ex) {
                        System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return fees;
        }
    }
}
