using System;
using System.Collections.Generic;

namespace Shared {
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
    public class DetainDetails {
        public int LicenseID { get; set; }
        public DateTime detainDate { get; set; }
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
    public class DetainResult {
        public int detainRecordID { get; set; }
        public enDetainResult result { get; set; }
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
}
