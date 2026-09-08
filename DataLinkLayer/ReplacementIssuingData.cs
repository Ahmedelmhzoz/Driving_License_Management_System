using System;
using DataLinkLayer.License_Application_data;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public static class ReplacementIssuingData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static int issueReplacer(ApplicationDTO applicationDTO, LocalLicenseDTO localLicenseDTO) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction()) {
                    try  {
                        int replacementAppID = ApplicationsData.addApplicationInTransaction(applicationDTO, connection, transaction);
                        LocalLicensesData.suspendLocalLicense(localLicenseDTO.LicenseID, connection, transaction);
                        localLicenseDTO.ApplicationID = replacementAppID;
                        int replacerLicenseID = LocalLicensesData.addLocalLicenseInTransaction(localLicenseDTO, connection, transaction);
                        transaction.Commit();
                        return replacerLicenseID;
                    }
                    catch {
                        transaction.Rollback();
                        throw new Exception("Failad To make replacer license due to connection loss");
                    }
                }
            }
        }
    }
}
