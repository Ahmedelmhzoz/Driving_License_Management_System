
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shared
{
    public enum enDriverFilterColumn {
        DriverID = 1,
        PersonID = 2,
        NationalNo = 3,
        FullName = 4
    }
    public enum enUserStatus { enActive = 0, enNotActive = 1, enGeneral = 2 }

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

    public enum enLocalLicenseStatus {
        All = 0,
        Active = 1,
        Suspended = 2, 
        Expired = 3
    }

    public enum enInternationalLicenseStatus {
        All = 0,
        Active = 1,
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
    public enum enTestType { Vision = 1, Theoretical = 2, Street = 3}
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
    public enum enLicenseClass {
        SmallMotorcycle = 1,
        HeavyMotorcycle = 2,
        Ordinary = 3,
        Commercial = 4,
        Agricultural = 5,
        SmallMediumBus = 6,
        TruckHeavyVehicle = 7
    }
    public enum enPeriod { 
        Day,
        Week,
        Month,
        Year,
        Lifetime
    }
    public enum enFinancialProceesType { 
        Applications,
        Tests,
        Licenses,
        Fine
    }
    public class AppointmentsStatistics {
        public Dictionary<enTestType, int> takenTestsPerType; 
        public Dictionary<enTestType, int> todayAppointmentsPerType; 
        public Dictionary<enTestType, (double passRate, double failRate)> PassFailTestRatesPerType; 
        public int totalPassedTests { get; set; }
        public AppointmentsStatistics() {
            takenTestsPerType = new Dictionary<enTestType, int>();
            todayAppointmentsPerType = new Dictionary<enTestType, int>();
            PassFailTestRatesPerType = new Dictionary<enTestType, (double passRate, double failRate)>();
        }
    }
    public class RevenueStatistics {
        public Dictionary<enFinancialProceesType, (decimal amount, double percentage)> totalRevPerProcess;
        public Dictionary<enApplicationType, decimal> totalRevPerApp;
        public Dictionary<enTestType, decimal> totalRevPerTest;
        public RevenueStatistics() {
            totalRevPerProcess = new Dictionary<enFinancialProceesType, (decimal amount, double percentage)>();
            totalRevPerApp = new Dictionary<enApplicationType, decimal>();
            totalRevPerTest = new Dictionary<enTestType, decimal>();
        }
    }
    public static class Utilities {

        public static int convertTestTypeToID(enTestType testType) {
            switch (testType) {
                case enTestType.Vision: return 1;
                case enTestType.Theoretical: return 2;
                case enTestType.Street: return 3;
                default: return 1;
            }
        }
        public static string convertTestTypeToString(enTestType testType) {
            switch (testType) {
                case enTestType.Vision: return "Vision Test";
                case enTestType.Theoretical: return "Written Test";
                case enTestType.Street: return "Street Test";
                default: return "Vision Test";
            }
        }
        public static DateTime? returnStartPoint(enPeriod period) {
            switch (period) {
                case enPeriod.Day: return DateTime.Today;
                case enPeriod.Week: return DateTime.Today.AddDays(-6);
                case enPeriod.Month: return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                case enPeriod.Year: return new DateTime(DateTime.Today.Year, 1, 1);
                default: return null;
            }
        }
        public static string getApplicationTypeName(enApplicationType applicationType) {
            switch (applicationType) {
                case enApplicationType.NewLocalDrivingLicense:
                    return "New Local License";

                case enApplicationType.RenewDrivingLicense:
                    return "Renew License";

                case enApplicationType.ReplaceLostDrivingLicense:
                    return "Replace Lost License";

                case enApplicationType.ReplaceDamagedDrivingLicense:
                    return "Replace Damaged License";

                case enApplicationType.ReleaseDetainedDrivingLicense:
                    return "Release Detained License";

                case enApplicationType.NewInternationalLicense:
                    return "New International License";

                case enApplicationType.RetakeTest:
                    return "Retake Test";

                default:
                    return "Unknown";
            }
        }
        public static string getLicenseClassName(enLicenseClass licenseClass) {
            switch (licenseClass) {
                case enLicenseClass.SmallMotorcycle:
                    return "Small Motorcycle";

                case enLicenseClass.HeavyMotorcycle:
                    return "Heavy Motorcycle";

                case enLicenseClass.Ordinary:
                    return "Ordinary";

                case enLicenseClass.Commercial:
                    return "Commercial";

                case enLicenseClass.Agricultural:
                    return "Agricultural";

                case enLicenseClass.SmallMediumBus:
                    return "Small & Medium Bus";

                case enLicenseClass.TruckHeavyVehicle:
                    return "Truck & Heavy Vehicle";

                default:
                    return "Unknown";
            }
        }
    }
}
