using DataLinkLayer.License_Application_data;
using Shared;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataLinkLayer {
    public static class LicenseRenewalData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;

        static int _createApp (ApplicationDTO appDTO, SqlConnection connection, SqlTransaction transaction) {
            string query = @"INSERT INTO Applications   
                    (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                    VALUES 
                    (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                    SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@ApplicantPersonID", appDTO.personID);
                command.Parameters.AddWithValue("@ApplicationDate", appDTO.AppDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", appDTO.ApplicaitionTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", (byte)enApplicationStatus.enCompleted);
                command.Parameters.AddWithValue("@LastStatusDate", appDTO.lastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", appDTO.paidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", appDTO.createdByUserID);
                object result = command.ExecuteScalar();
                if (result != null) return Convert.ToInt32(result);
                return -1;
            }
        }

        static int _createRenewalLocalLicense(LicenseDTO licenseDTO, SqlConnection connection, SqlTransaction transaction) {
            string query = @"INSERT INTO Licenses 
                                  (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                                  VALUES 
                                  (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID) 
                                  SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@ApplicationID", licenseDTO.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", licenseDTO.DriverID);
                command.Parameters.AddWithValue("@LicenseClassID", licenseDTO.LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", licenseDTO.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", licenseDTO.ExpirationDate);
                if (string.IsNullOrWhiteSpace(licenseDTO.Notes))
                    command.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Notes", licenseDTO.Notes.Trim());
                command.Parameters.AddWithValue("@PaidFees", licenseDTO.PaidFees);
                command.Parameters.AddWithValue("@IsActive", licenseDTO.NotSuspended);
                command.Parameters.AddWithValue("@IssueReason", (byte)licenseDTO.IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", licenseDTO.CreatedByUserID);
                object result = command.ExecuteScalar();
                if (result != null) {
                    return Convert.ToInt32(result);
                }
                return -1;
            }
        }
        static void _bindLocalIDsInRenewalTable(int oldLocalLicenseID, int newLocalLicenseID, SqlConnection connection, SqlTransaction transaction) {
            string query = @"Insert Into LocalLicenseRenewals (OldLicenseID, NewLicenseID)  
                                VALUES (@OldLicenseID, @NewLicenseID);";
            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@OldLicenseID", oldLocalLicenseID);
                command.Parameters.AddWithValue("@NewLicenseID", newLocalLicenseID);
                command.ExecuteNonQuery();
            }
        }
        public static LicenseRenewalResult RenewLicense(ApplicationDTO appDTO, LicenseDTO licenseDTO) { // For Local License
            LicenseRenewalResult result = new LicenseRenewalResult();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try {
                    int renewAppID = _createApp(appDTO, connection, transaction);
                    if (renewAppID == -1) throw new Exception("Failed to create renewal application.");

                    int expiredLicenseID = licenseDTO.LicenseID;
                    licenseDTO.ApplicationID = renewAppID;
                    
                    int newLicenseID = _createRenewalLocalLicense(licenseDTO, connection, transaction);
                    if (newLicenseID == -1) throw new Exception("Failed to create renewal license.");

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
                if (result != null) {
                    return Convert.ToInt32(result); // assign the renewed license ID
                }
                return -1;
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
                    int renewAppID = _createApp(appDTO, connection, transaction);
                    if (renewAppID == -1) throw new Exception("Failed to create renewal application.");

                    int expiredLicenseID = licenseDTO.InternationalLicenseID;
                    licenseDTO.ApplicationID = renewAppID;
                    int newLicenseID = _createRenewalInternationalLicense(licenseDTO, connection, transaction);

                    if (newLicenseID == -1) throw new Exception("Failed to create renewal license.");
                    _bindInterIDsInRenewalTable(expiredLicenseID, newLicenseID, connection, transaction);
                    throw new Exception("TEST TRANSACTION ROLLBACK");
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
