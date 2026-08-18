using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer {
    public class PersonDTO {
        public int personID { get; set; }
        public string NationalNo { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string imagePath { get; set; }
        public string Address { get; set; }
        public int NationalityCountryID { get; set; }
    }
    public static class DataAccess {
        static string connectionSettings = "Server=.;Database=DVLD;User ID = sa;password=123456;";
        public enum enSearchCategory {
            enPersonID = 0, enNationalNo = 1, enFirst = 2, enSecond = 3, enThird = 4,
            enLast = 5, enNationality = 6, enGender = 7, enPhone = 8, enEmail = 9
        };
        public static DataTable getPeople() {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionSettings);
            string query = "select * from People_View";
            SqlCommand cmd = new SqlCommand(query, conn);
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
        public static DataTable searchResultByCategory(enSearchCategory mode, string currentText) {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionSettings);
            string[] searchModes = { "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                "LastName", "CountryName", "Gender", "Phone", "Email" };
            string searchMode = searchModes[(int)mode];
            string query = $"Select * from People_View where {searchMode} Like @CurrentText + '%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CurrentText", currentText);
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

        public static PersonDTO getPerson(string nationalNum) {
            PersonDTO person = null;
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = "select * from People_View where NationalNo = @NN";
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@NN", nationalNum);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                person = new PersonDTO();
                                person.personID = (int)reader["PersonID"];
                                person.NationalNo = reader["NationalNo"].ToString();
                                person.firstName = reader["FirstName"].ToString();
                                person.secondName = reader["SecondName"].ToString();
                                person.thirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"].ToString();
                                person.lastName = reader["LastName"].ToString();
                                person.gender = reader["Gender"].ToString();
                                person.dateOfBirth = (DateTime)reader["DateOfBirth"];
                                person.phone = reader["Phone"].ToString();
                                person.country = reader["CountryName"].ToString();
                                person.email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                                person.imagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString();
                                person.Address = reader["Address"].ToString();
                                person.NationalityCountryID = (int)reader["NationalityCountryID"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                person = null;
            }
            return person;
        }
        public static int addAPerson(PersonDTO dto) {
            int ID = -1;
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = @"INSERT INTO People 
                    (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                 VALUES 
                    (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                 SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@NationalNo", dto.NationalNo);
                        cmd.Parameters.AddWithValue("@FirstName", dto.firstName);
                        cmd.Parameters.AddWithValue("@SecondName", dto.secondName);
                        cmd.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(dto.thirdName) ? DBNull.Value : (object)dto.thirdName);
                        cmd.Parameters.AddWithValue("@LastName", dto.lastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dto.dateOfBirth);
                        cmd.Parameters.AddWithValue("@Gendor", dto.gender == "Male" ? 0 : 1);
                        cmd.Parameters.AddWithValue("@Address", dto.Address);
                        cmd.Parameters.AddWithValue("@Phone", dto.phone);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(dto.email) ? DBNull.Value : (object)dto.email);
                        cmd.Parameters.AddWithValue("@NationalityCountryID", dto.NationalityCountryID); // ID الدولة
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(dto.imagePath) ? DBNull.Value : (object)dto.imagePath);
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
        public static bool updateAPerson(PersonDTO dto) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = @"UPDATE People 
                     SET 
                        NationalNo = @NationalNo,
                        FirstName = @FirstName,
                        SecondName = @SecondName,
                        ThirdName = @ThirdName,
                        LastName = @LastName,
                        DateOfBirth = @DateOfBirth,
                        Gendor = @Gendor,
                        Address = @Address,
                        Phone = @Phone,
                        Email = @Email,
                        NationalityCountryID = @NationalityCountryID,
                        ImagePath = @ImagePath
                        WHERE PersonID = @PersonID;";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@PersonID", dto.personID);
                        cmd.Parameters.AddWithValue("@NationalNo", dto.NationalNo);
                        cmd.Parameters.AddWithValue("@FirstName", dto.firstName);
                        cmd.Parameters.AddWithValue("@SecondName", dto.secondName);
                        cmd.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(dto.thirdName) ? DBNull.Value : (object)dto.thirdName);
                        cmd.Parameters.AddWithValue("@LastName", dto.lastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dto.dateOfBirth);
                        cmd.Parameters.AddWithValue("@Gendor", dto.gender == "Male" ? 0 : 1);
                        cmd.Parameters.AddWithValue("@Address", dto.Address);
                        cmd.Parameters.AddWithValue("@Phone", dto.phone);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(dto.email) ? DBNull.Value : (object)dto.email);
                        cmd.Parameters.AddWithValue("@NationalityCountryID", dto.NationalityCountryID);
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(dto.imagePath) ? DBNull.Value : (object)dto.imagePath);
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

        public static DataTable getAllCountries() {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = "Select * from Countries";
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
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
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            return dt;
        }
        public static bool IsNationalExists(string NatNo) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionSettings)) {
                    string query = "Select Found = 1 from People where NationalNo = @NN";
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@NN", NatNo);
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
        public static bool deleteAPerson(int personID) {
            int rowsAffected = 0;

            try {
                using (SqlConnection connection = new SqlConnection(connectionSettings)) {
                    using (SqlCommand command = new SqlCommand("DELETE FROM People WHERE PersonID = @PersonID", connection)) {
                        command.Parameters.AddWithValue("@PersonID", personID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

            return (rowsAffected > 0);
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
    }

}
