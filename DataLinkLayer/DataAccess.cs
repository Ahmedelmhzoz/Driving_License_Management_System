using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer {
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
            "LastName", "CountryName", "Gender", "Phone", "Email"};
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
    }
}
