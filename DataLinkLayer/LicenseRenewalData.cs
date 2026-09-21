using DataLinkLayer.License_Application_data;
using Shared;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public static class LicenseRenewalData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        static void _bindLocalIDsInRenewalTable(int oldLocalLicenseID, int newLocalLicenseID, SqlConnection connection, SqlTransaction transaction) {
            string query = @"Insert Into LocalLicenseRenewals (OldLicenseID, NewLicenseID)  
                                VALUES (@OldLicenseID, @NewLicenseID);";
            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@OldLicenseID", oldLocalLicenseID);
                command.Parameters.AddWithValue("@NewLicenseID", newLocalLicenseID);
                command.ExecuteNonQuery();
            }
        }
        public static LicenseRenewalResult RenewLicense(ApplicationDTO appDTO, LocalLicenseDTO licenseDTO) { // For Local License
            LicenseRenewalResult result = new LicenseRenewalResult();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try {
                    int renewAppID = ApplicationsData.addApplicationInTransaction(appDTO, connection, transaction);

                    int expiredLicenseID = licenseDTO.LicenseID;
                    licenseDTO.ApplicationID = renewAppID;

                    int newLicenseID = LocalLicensesData.addLocalLicenseInTransaction(licenseDTO, connection, transaction);

                    _bindLocalIDsInRenewalTable(expiredLicenseID, newLicenseID, connection, transaction);

                    transaction.Commit();
                    return new LicenseRenewalResult {
                        Result = enLicenseRenewalResult.Success,
                        NewLicenseID = newLicenseID,
                        RenewApplicationID = renewAppID
                    };
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    return new LicenseRenewalResult {
                        Result = enLicenseRenewalResult.Failed,
                        NewLicenseID = -1,
                        RenewApplicationID = -1
                    };
                }
            }
        }
        static int _createRenewalInternationalLicense(InternationalLicenseDTO interLicenseDTO, SqlConnection connection, SqlTransaction transaction) {
            string query = @"INSERT INTO InternationalLicenses 
                    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                    VALUES 
                    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID) 
                    SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@ApplicationID", interLicenseDTO.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", interLicenseDTO.DriverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", interLicenseDTO.IssuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", interLicenseDTO.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", interLicenseDTO.ExpirationDate);
                command.Parameters.AddWithValue("@IsActive", interLicenseDTO.NotSuspended);
                command.Parameters.AddWithValue("@CreatedByUserID", interLicenseDTO.CreatedByUserID);
                object result = command.ExecuteScalar();
                if (result == null) throw new Exception("Failed to create Internationl license.");
                
                return Convert.ToInt32(result);
            }
         }

        static void _bindInterIDsInRenewalTable(int oldInterLicenseID, int newInterLicenseID, SqlConnection connection, SqlTransaction transaction) {
            string query = @"Insert Into InternationalLicenseRenewals (OldLicenseID, NewLicenseID)  
                                VALUES (@OldLicenseID, @NewLicenseID);";
            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@OldLicenseID", oldInterLicenseID);
                command.Parameters.AddWithValue("@NewLicenseID", newInterLicenseID);
                command.ExecuteNonQuery();
            }
        }
        public static LicenseRenewalResult RenewLicense(ApplicationDTO appDTO, InternationalLicenseDTO licenseDTO) {// For Internationa lLicense
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try {
                    int renewAppID = ApplicationsData.addApplicationInTransaction(appDTO, connection, transaction);

                    int expiredLicenseID = licenseDTO.InternationalLicenseID;
                    licenseDTO.ApplicationID = renewAppID;
                    int newLicenseID = _createRenewalInternationalLicense(licenseDTO, connection, transaction);

                    _bindInterIDsInRenewalTable(expiredLicenseID, newLicenseID, connection, transaction);
                    transaction.Commit();
                    return new LicenseRenewalResult {
                        Result = enLicenseRenewalResult.Success,
                        NewLicenseID = newLicenseID,
                        RenewApplicationID = renewAppID
                    };
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    return new LicenseRenewalResult {
                        Result = enLicenseRenewalResult.Failed,
                        NewLicenseID = -1,
                        RenewApplicationID = -1
                    };
                }
            }
        }
       
    }
}
