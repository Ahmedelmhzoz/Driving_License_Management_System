using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLinkLayer {
    public class UsersData {
        static string connectionSettings = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public enum enSearchCategoryUsers {
            enUserID = 0, enUserName = 1, enPersonID = 2, enFullName = 3, enGeneral = 4
        };
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
        public static bool findUser(string username, ref string password, ref int userID, ref int personID, ref bool isActive) {
            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                    using (SqlCommand command = new SqlCommand("Select * FROM Users WHERE UserName = @Username", connection)) {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                userID = (int)reader[0];
                                personID = (int)reader[1];
                                username = reader[2].ToString();
                                password = reader[3].ToString();
                                isActive = (bool)reader[4];
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
        
        public static DataTable searchResultByCategory(string currentText, enSearchCategoryUsers mode, string activeOrNot) {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionSettings);
            string[] searchModes = { "UserID = @CurrentText", "UserName Like @CurrentText + '%'", "PersonID = @CurrentText", "FullName Like @CurrentText + '%'" };
            string cat = searchModes[(int)mode];
            string query = $"Select * from Users_View where {cat} and IsActive like @activeOrNotOrGeneral + '%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CurrentText", currentText);
            cmd.Parameters.AddWithValue("@activeOrNotOrGeneral", activeOrNot);
            try {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                conn.Close();
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
                Console.WriteLine(ex.Message);
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
    }
        
    
}
