using DataLinkLayer.License_Application_data;
using Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DataLinkLayer {
    public class DetainDTO {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public string Reason { get; set; }
        public int CreatedByUserID { get; set; }

        public DetainDTO() { }
        public DetainDTO(DetainDetails detainInputedData) {
            LicenseID = detainInputedData.LicenseID;
            DetainDate = detainInputedData.detainDate;
            FineFees = detainInputedData.fineFees;
            Reason = detainInputedData.reason;
            CreatedByUserID = detainInputedData.createdByUserID;
        }
    }
    public class ReleaseDTO {
        public int detainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime releaseDate { get; set; }
        public int createdByUserID { get; set; }
        public int applicationID { get; set; }

        public ReleaseDTO() { }

        public ReleaseDTO(ReleaseDetails releaseInputedData) {
            detainID = releaseInputedData.detainID;
            LicenseID = releaseInputedData.LicenseID;
            releaseDate = releaseInputedData.releaseDate;
            createdByUserID = releaseInputedData.createdByUserID;
            applicationID = releaseInputedData.applicationID;
        }
    }
    public static class DetainedLicensesData {
        static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DB"].ConnectionString;
        public static bool IsLicenseDetained(int licenseID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT Found = 1 
                                 FROM DetainedLicenses 
                                 WHERE LicenseID = @LicenseID AND IsReleased = 0;";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                   
                    connection.Open();
                    object result = command.ExecuteScalar();

                    return (result != null);
                }
            }
        }
        public static int detainLicense(DetainDTO detainDTO) {

            string query = @"INSERT INTO DetainedLicenses ( 
                            LicenseID,
                            DetainDate,
                            FineFees,
                            CreatedByUserID,
                            IsReleased,
                            ReleaseDate,
                            ReleasedByUserID,
                            ReleaseApplicationID, 
                            Reason
                        )   
                        VALUES ( 
                            @LicenseID,
                            @DetainDate,
                            @FineFees,
                            @CreatedByUserID,
                            0,
                            NULL,
                            NULL,
                            NULL, 
                            @Reason
                        );

                        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@LicenseID", detainDTO.LicenseID);
                command.Parameters.AddWithValue("@DetainDate", detainDTO.DetainDate);
                command.Parameters.AddWithValue("@FineFees", detainDTO.FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", detainDTO.CreatedByUserID);
                command.Parameters.AddWithValue("@Reason", detainDTO.Reason);

                connection.Open();

                object result = command.ExecuteScalar();



                if (result == null || !int.TryParse(result.ToString(), out int id))
                    throw new Exception("Failed to retrieve the Detain ID.");

                return id;
            }
        }
        public static DetainDTO getDetainDetails(int licenseID) {
            DetainDTO detainDTO = new DetainDTO();
            string query = @"SELECT 
                            d.DetainID, 
                            d.DetainDate, 
                            d.CreatedByUserID, 
                            d.FineFees, 
                            d.Reason 
                            From DetainedLicenses d 
                            WHERE LicenseID = @LicenseID AND IsReleased = 0"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@LicenseID", licenseID);
                
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    detainDTO.DetainID = (int)reader["DetainID"];
                    detainDTO.DetainDate = (DateTime)reader["DetainDate"];
                    detainDTO.CreatedByUserID = (int)reader["CreatedByUserID"];
                    detainDTO.FineFees = (decimal)reader["FineFees"];
                    detainDTO.Reason = reader["Reason"].ToString();
                } 
                else {
                    return null;
                }

                return detainDTO;
            }
        }
        static void _ReleaseDetainRecord(ReleaseDTO releaseDTO, SqlConnection connection, SqlTransaction transaction) {
            const string query = @"Update DetainedLicenses   
                                        SET IsReleased = 1, 
                                        ReleaseApplicationID = @AppID, 
                                        ReleaseDate = @ReleaseDate, 
                                        ReleasedByUserID = @userID 
                                        WHERE DetainID = @DetainID;";

            using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                command.Parameters.AddWithValue("@AppID", releaseDTO.applicationID);
                command.Parameters.AddWithValue("@ReleaseDate", releaseDTO.releaseDate);
                command.Parameters.AddWithValue("@userID", releaseDTO.createdByUserID);
                command.Parameters.AddWithValue("@DetainID", releaseDTO.detainID);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows <= 0)
                    throw new Exception();
            }
        }
        public static void releaseLicense(ApplicationDTO applicationDTO, ref ReleaseDTO releaseDTO) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlTransaction  transaction = connection.BeginTransaction()) {
                    try {
                        int internationAppID = ApplicationsData.addApplicationInTransaction(applicationDTO, connection, transaction);
                        releaseDTO.applicationID = internationAppID;

                        _ReleaseDetainRecord(releaseDTO, connection, transaction);
                        transaction.Commit();
                    }
                    catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public static DataTable getAllDetainedLicenses() {
            DataTable dt = new DataTable();

            string query = @"SELECT 
                        DetainID,
                        LicenseID,
                        DriverName,
                        DetainDate,
                        FineFees,
                        DetaintionStatus
                     FROM Detained_Licensese_View 
                     ORDER BY DetainID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public static string _MapEnumToColumn(enDetainFilterBy filterColumn) {
            switch (filterColumn) {

                case enDetainFilterBy.DetainID:
                    return "DetainID";

                case enDetainFilterBy.LicenseID:
                    return "LicenseID";

                case enDetainFilterBy.Fullname:
                    return "DriverName";

                case enDetainFilterBy.DetaintionStatus:
                    return "DetaintionStatus";

                default:
                    return "DetainID";
            }
        }
        public static DataTable getByFilter(enDetainFilterBy filterColumn, string filterValue) {
            DataTable dt = new DataTable();
            string actualColumnName = _MapEnumToColumn(filterColumn);
            string query = $@"SELECT  
                            DetainID, 
                            LicenseID, 
                            DriverName, 
                            DetainDate, 
                            FineFees, 
                            DetaintionStatus 
                            FROM Detained_Licensese_View
                            WHERE {actualColumnName} LIKE @filterValue + '%'  
                            ORDER BY DetainID DESC;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@filterValue", filterValue.Trim());
                try {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) 
                        dt.Load(reader);
                }
                catch {
                    throw;
                }
            }
             return dt;
        }
    }
}