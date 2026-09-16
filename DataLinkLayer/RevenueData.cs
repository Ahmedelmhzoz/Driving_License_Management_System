using Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLinkLayer {
    public static class RevenueData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static RevenueStatistics GetRevenueStatistics() {
            RevenueStatistics revenueStatistics = new RevenueStatistics();

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"SELECT AT.ApplicationTypeID, COALESCE(SUM(A.PaidFees), 0) AS totalFeesPerApp FROM ApplicationTypes AT left join Applications A  
                                ON AT.ApplicationTypeID = A.ApplicationTypeID  
                                GROUP BY AT.ApplicationTypeID;  

                               SELECT
                                    TT.TestTypeID, 
                                    COALESCE(SUM(TA.PaidFees), 0) AS totalFeesPerTest 
                                FROM TestTypes TT 
                                LEFT JOIN TestAppointments TA 
                                    ON TT.TestTypeID = TA.TestTypeID 
                                GROUP BY TT.TestTypeID; 

                                SELECT COALESCE(SUM(PaidFees), 0) AS totalLicensesFees FROM Licenses; 

                                SELECT COALESCE(SUM(FineFees), 0) AS totalFines FROM DetainedLicenses;"; 

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) 
                            revenueStatistics.totalRevPerApp.Add((enApplicationType)reader["ApplicationTypeID"], (decimal)reader["totalFeesPerApp"]);

                        reader.NextResult();
                        while (reader.Read())
                            revenueStatistics.totalRevPerTest.Add((enTestType)reader["TestTypeID"], (decimal)reader["totalFeesPerTest"]);

                        reader.NextResult();
                        if (reader.Read())
                            revenueStatistics.totalRevPerProcess.Add(enFinancialProceesType.Licenses, ((decimal)reader["totalLicensesFees"], 0d));

                        reader.NextResult();
                        if (reader.Read())
                            revenueStatistics.totalRevPerProcess.Add(enFinancialProceesType.Fine, ((decimal)reader["totalFines"], 0d));
                    }
                }
            }
            return revenueStatistics;
        }
    }
}
