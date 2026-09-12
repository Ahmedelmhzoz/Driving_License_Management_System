
using System;

namespace Shared
{
    public enum enDriverFilterColumn {
        DriverID = 1,
        PersonID = 2,
        NationalNo = 3,
        FullName = 4
    }

    public enum enInternationalLicenseEligibility {
        Eligible = 0,                  
        NotFound = 1,              
        NotOrdinaryLicenseCLass = 2,              
        NotActive = 3,             
        HasActiveInternational = 4  
    }
    public enum enLicenseRenewalResult {
        Success,
        BasicAppNotFound,
        PersonNotFound,
        Failed
    }
    public class LicenseRenewalResult {
        public enLicenseRenewalResult Result { get; set; }
        public int NewLicenseID { get; set; }
        public int RenewApplicationID { get; set; }
        public LicenseRenewalResult() {
            Result = enLicenseRenewalResult.Failed;
            NewLicenseID = -1;
            RenewApplicationID = -1;
        }
    }

    public enum enRenewalEligibility {  
        Eligible,
        LicenseNotEligibleActive,
        LicenseNotEligibleSuspended
    }

    public class DetainDetails { 
        public int LicenseID { get; set; }
        public DateTime detainDate {  get; set; }
        public decimal fineFees { get; set; }
        public string reason { get; set; }
        public int createdByUserID { get; set; }
        public int detainID { get; set; }
        public DetainDetails() { }
        public DetainDetails(int licID, DateTime date, decimal fine, string reason, int createdByUserID) {
            LicenseID = licID;
            detainDate = date;
            fineFees = fine;
            this.reason = reason;
            this.createdByUserID = createdByUserID;
            detainID = -1;
        }
        public DetainDetails(int licID, DateTime date, decimal fine, string reason, int createdByUserID, int detainID) { 
            LicenseID = licID;
            detainDate = date;
            fineFees = fine;
            this.reason = reason;
            this.createdByUserID = createdByUserID;
            this.detainID = detainID;
        }
    }
    public class ReleaseDetails {
        public int detainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime releaseDate { get; set; }
        public int createdByUserID { get; set; }
        public int applicationID { get; set; }
        public ReleaseDetails(int detainID, DateTime releaseDate, int createdByUserID) {
            this.detainID = detainID;
            this.releaseDate = releaseDate;
            this.createdByUserID = createdByUserID;
            applicationID = -1;
            LicenseID = -1;
        }
        public ReleaseDetails(int detainID, DateTime releaseDate, int createdByUserID, int LicenseID, int applicationID) {
            this.detainID = detainID;
            this.releaseDate = releaseDate;
            this.createdByUserID = createdByUserID;
            this.applicationID = applicationID;
            this.LicenseID = LicenseID;
        }
    }

    public enum enDetainResult {
        Success,
        AlreadyDetained,
        FineOutOfRange
    }
    public class DetainResult {
        public int detainRecordID {  get; set; } 
        public enDetainResult result { get; set; }
    }

    public class ReleaseResult {
        public int detainRecordID { get; set; }
        public enDetainResult result { get; set; }
    }

    public enum enLicenseEligibility {
        Active,
        Suspended,
        Expired,
        Detained ,
        NotFound
    }
    public enum enLicenseType {
        Local = 0,
        International = 1
    }

    public enum enLicenseStatus {
        All = 0,
        Active = 1,
        Suspended = 2, 
        Expired = 3
    }
    public enum enLicenseFilterBy {
        None = 0,
        InternationalLicenseID = 1,
        DriverID = 2,
        LicenseStatus = 3
    }
    public enum enDetainFilterBy {
        None,
        DetainID,
        LicenseID,
        Fullname,
        DetaintionStatus
    }
    public enum enDetaintionStatus { 
        Detained,
        Released
    }
    public enum enApplicationStatus { enNew = 1, enCanceled = 2, enCompleted = 3 }
    public enum enAppMode { addApp = 0, updateApp = 1 }
    public enum enTestType { enVision = 1, enWritten = 2, enStreet = 3}
    public enum enIssueReason {
        enFirstTime = 1,
        enRenew = 2,
        enReplacementForDamaged = 3,
        enReplacementForLost = 4
    }
    public enum enApplicationType {
        NewLocalDrivingLicense = 1,
        RenewDrivingLicense = 2,
        ReplaceLostDrivingLicense = 3,
        ReplaceDamagedDrivingLicense = 4,
        ReleaseDetainedDrivingLicense = 5,
        NewInternationalLicense = 6,
        RetakeTest = 8 // its ID in database = 8
    }
    public static class Utilities {

        public static int convertTestTypeToID(enTestType testType) {
            switch (testType) {
                case enTestType.enVision: return 1;
                case enTestType.enWritten: return 2;
                case enTestType.enStreet: return 3;
                default: return 1;
            }
        }
        public static string convertTestTypeToString(enTestType testType) {
            switch (testType) {
                case enTestType.enVision: return "Vision Test";
                case enTestType.enWritten: return "Written Test";
                case enTestType.enStreet: return "Street Test";
                default: return "Vision Test";
            }
        }

    }
}
