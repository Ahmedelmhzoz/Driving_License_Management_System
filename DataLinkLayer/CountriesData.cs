using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public class CountriesData {
        static string connectionSettings = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;

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
    }
}
