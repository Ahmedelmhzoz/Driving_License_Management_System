using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Shared;

namespace DataLinkLayer {
    public class UsersData {
        static string connectionSettings = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public enum enSearchCategoryUsers {
            enUserID = 0, enUserName = 1, enPersonID = 2, enFullName = 3, enGeneral = 4
        };
        public class UserActivityDTO {
            public int ApplicationsCount { get; set; }
            public int TestsCount { get; set; }
            public int LicensesCount { get; set; }
            public int DetainedLicensesCount { get; set; }
        }
        public static DataTable getAllUsers() {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    using (SqlCommand cmd = new SqlCommand("Select * from Users_View", conn)) {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                dt.Load(reader);
                            }
                        }

                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public static bool isUserExistsForPerson(int personId) {
            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                    using (SqlCommand command = new SqlCommand("Select found = 1 FROM Users WHERE PersonID = @PersonID", connection)) {
                        command.Parameters.AddWithValue("@PersonID", personId);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return (result != null);
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
        public static bool findUserByUserName(string username, ref string password, ref int userID, ref int personID, ref bool isActive) {
            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                    using (SqlCommand command = new SqlCommand("Select * FROM Users WHERE UserName = @Username", connection)) {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                userID = (int)reader["UserID"];
                                personID = (int)reader["PersonID"];
                                username = reader["UserName"].ToString();
                                password = reader["Password"].ToString();
                                isActive = (bool)reader["IsActive"];
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
        public static bool findUserByID(ref string username, ref string password, int userID, ref int personID, ref bool isActive) {
            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                    using (SqlCommand command = new SqlCommand("Select * FROM Users WHERE UserID = @ID", connection)) {
                        command.Parameters.AddWithValue("@ID", userID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                userID = (int)reader["UserID"];
                                personID = (int)reader["PersonID"];
                                username = reader["UserName"].ToString();
                                password = reader["Password"].ToString();
                                isActive = (bool)reader["IsActive"];
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
        public static bool isPassOrUsernameTaken(string password, bool isPassword) {
            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                    string passOrUser = (isPassword ? "Password" : "UserName");
                    using (SqlCommand command = new SqlCommand($"Select found = 1 FROM Users WHERE {passOrUser} = @pass", connection)) {
                        command.Parameters.AddWithValue("@pass", password);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return (result != null);
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public static DataTable searchResultByCategory(string currentText, enSearchCategoryUsers mode, enUserStatus status) {
            DataTable dt = new DataTable();

            string actualColumnName = string.Empty;
            switch (mode) {
                case enSearchCategoryUsers.enUserID:
                    actualColumnName = "UserID"; break;
                case enSearchCategoryUsers.enUserName:
                    actualColumnName = "UserName"; break;
                case enSearchCategoryUsers.enPersonID:
                    actualColumnName = "PersonID"; break;
                case enSearchCategoryUsers.enFullName:
                    actualColumnName = "FullName";
                    break;
                default:
                    actualColumnName = "UserID";
                    break;
            }

            char StatusInBitToSearch = '\0';
            switch (status) {
                case enUserStatus.enActive: StatusInBitToSearch = '1'; break;
                case enUserStatus.enNotActive: StatusInBitToSearch = '0'; break;
                default: StatusInBitToSearch = '\0'; break;
            }

            string query = $@"Select * from Users_View where {actualColumnName} Like @CurrentText + '%' and IsActive like @activeOrNotOrGeneral + '%'
                        ORDER BY UserID DESC";
            using (SqlConnection conn = new SqlConnection(connectionSettings))

            using (SqlCommand cmd = new SqlCommand(query, conn)) {
                cmd.Parameters.AddWithValue("@CurrentText", currentText);
                cmd.Parameters.AddWithValue("@activeOrNotOrGeneral", StatusInBitToSearch);
                try {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                catch (Exception ex) {
                    System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                }

            }
            return dt;
        }
        public static DataTable getUsersByState(bool isActive) {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionSettings);
            string query = $"Select * from Users_View where IsActive = @Active";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Active", isActive);
            try {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            finally {
                conn.Close();
            }
            return dt;
        }
        public static bool updateAUser(int UserID, string username, string password, bool isActive) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = @"UPDATE Users  
                      SET 
                        UserName = @UN,
                        Password = @Pass,
                        IsActive = @isActive
                        WHERE UserID = @ID;";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@UN", username);
                        cmd.Parameters.AddWithValue("@Pass", password);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        cmd.Parameters.AddWithValue("@ID", UserID);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected > 0);
                    }
                }

            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return false;
        }
        public static int addAUser(string username, string password, int PersonID, bool isActive) {
            int ID = -1;
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = @"insert into Users(UserName, Password, PersonID, IsActive)
                      VALUES (@UN, @Pass, @ID, @isActive)
                      SELECT SCOPE_IDENTITY()
                    ";
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@UN", username);
                        cmd.Parameters.AddWithValue("@Pass", password);
                        cmd.Parameters.AddWithValue("@ID", PersonID);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null) {
                            ID = Convert.ToInt32(result);
                        }
                    }
                }

            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return ID;
        }
        public static bool isUserFree(int ID) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    using (SqlCommand cmd = new SqlCommand("Select found = 1 from Applications where CreatedByUserID = @ID", conn)) {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return false;
        }
        public static bool deleteAUser(int ID) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    using (SqlCommand cmd = new SqlCommand("delete from Users where UserID = @ID", conn)) {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        conn.Open();
                        int affectedRows = cmd.ExecuteNonQuery();
                        return affectedRows > 0;
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return false;
        }
        public static int getUsersNumber() {
            using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                string query = "SELECT COUNT(U.UserID) FROM Users U";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public static UserActivityDTO GetUserActivity(int userID) {
            string query = @"SELECT COUNT(*) AS ApplicationsCount
                            FROM Applications
                            WHERE CreatedByUserID = @UserID;

                            SELECT COUNT(*) AS TestsCount
                            FROM Tests
                            WHERE CreatedByUserID = @UserID;

                            SELECT COUNT(*) AS LicensesCount
                            FROM Licenses
                            WHERE CreatedByUserID = @UserID;

                            SELECT COUNT(*) AS DetainedLicensesCount
                            FROM DetainedLicenses
                            WHERE CreatedByUserID = @UserID;";

            using (SqlConnection connection = new SqlConnection(connectionSettings))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    UserActivityDTO dto = new UserActivityDTO();

                    // Applications
                    if (reader.Read()) {
                        dto.ApplicationsCount =
                            Convert.ToInt32(reader["ApplicationsCount"]);
                    }

                    // Tests
                    reader.NextResult();

                    if (reader.Read()) {
                        dto.TestsCount =
                            Convert.ToInt32(reader["TestsCount"]);
                    }

                    // Licenses
                    reader.NextResult();

                    if (reader.Read()) {
                        dto.LicensesCount =
                            Convert.ToInt32(reader["LicensesCount"]);
                    }

                    // Detained Licenses
                    reader.NextResult();

                    if (reader.Read()) {
                        dto.DetainedLicensesCount =
                            Convert.ToInt32(reader["DetainedLicensesCount"]);
                    }

                    return dto;
                }
            }
        }
    }
}