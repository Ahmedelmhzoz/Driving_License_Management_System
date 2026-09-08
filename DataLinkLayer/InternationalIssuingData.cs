using DataLinkLayer.License_Application_data;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public static class InternationalLicenseIssuingData {
        static string connectionString =
            ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;

        public static int addInternationalLicense(
            ApplicationDTO applicationDTO,
            InternationalLicenseDTO internationalLicense) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction()) {
                    try {
                        int internationAppID =
                            ApplicationsData.addApplicationInTransaction(
                                applicationDTO,
                                connection,
                                transaction);

                        internationalLicense.ApplicationID = internationAppID;

                        int newLicenseID =
                            InternationalLicenseData.addInternationalLicenseInTransaction(
                                internationalLicense,
                                connection,
                                transaction);

                        transaction.Commit();

                        return newLicenseID;
                    }
                    catch (Exception ex) {
                        transaction.Rollback();

                        System.Diagnostics.EventLog.WriteEntry(
                            "Application",
                            ex.ToString(),
                            System.Diagnostics.EventLogEntryType.Error);

                        throw;
                    }
                }
            }
        }
    }
}