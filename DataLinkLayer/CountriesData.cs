using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer {
    public class CountriesData {
        static string connectionSettings = "Server=.;Database=DVLD;User ID = sa;password=123456;";

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
