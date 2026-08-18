using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer {
    public class UsersData {
        static string connectionSettings = "Server=.;Database=DVLD;User ID = sa;password=123456;";

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
