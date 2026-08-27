using DataLinkLayer; 
using System;
using Shared;

namespace BusinessLayer {
    public class Licenses {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        // Parameterless Constructor (للإضافة الجديدة)
        public Licenses() {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = string.Empty;
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.enFirstTime;
            this.CreatedByUserID = -1;

            this.Mode = enMode.AddNew;
        }
        public Licenses(LicenseDTO dto) {
            if (dto != null) {
                this.LicenseID = dto.LicenseID;
                this.ApplicationID = dto.ApplicationID;
                this.DriverID = dto.DriverID;
                this.LicenseClassID = dto.LicenseClassID;
                this.IssueDate = dto.IssueDate;
                this.ExpirationDate = dto.ExpirationDate;
                this.Notes = dto.Notes;
                this.PaidFees = dto.PaidFees;
                this.IsActive = dto.IsActive;
                this.IssueReason = dto.IssueReason;
                this.CreatedByUserID = dto.CreatedByUserID;

                this.Mode = enMode.Update;
            }
        }
        public static bool didLicenseIssuedForApp(int appID) {
            return LicensesData.IsThereLicenseForApp(appID);
        }
    }
}