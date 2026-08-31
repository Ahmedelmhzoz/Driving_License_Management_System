using DataLinkLayer; 
using System;
using Shared;
using System.Data;

namespace BusinessLayer {
    public class LocalLicense {
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
        private LicenseClasses _licenseInfo;
        private User _IssuerUser;
        public User issuerUserInfo {
            get {
                if (_IssuerUser == null) {
                    _IssuerUser = User.getUserByID(CreatedByUserID);
                }
                return _IssuerUser;
            }
        }
        public LicenseClasses licenseInfo {
            get {
                if (_licenseInfo == null) {
                    _licenseInfo = LicenseClasses.getLicenseClassByID(LicenseClassID);
                }
                return _licenseInfo;
            }
        }
        private Applications _applicationInfo;
        public Applications applicationInfo {
            get {
                if (_applicationInfo == null) {
                    _applicationInfo = Applications.getApplicationByID(ApplicationID);
                }
                return _applicationInfo;
            }
        }
        public LocalLicense() {
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
        }
        public LocalLicense(LicenseDTO dto) {
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
            }
        }
        public LicenseDTO ToDTO() {
            return new LicenseDTO {
                LicenseID = this.LicenseID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = this.PaidFees,
                IsActive = this.IsActive,
                IssueReason = this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };
        }
        public static bool didLicenseIssuedForApp(int appID) {
            return LicensesData.IsThereLicenseForApp(appID);
        }
        public static LocalLicense GetLicenseByApplicationID(int applicationID) {
            LicenseDTO dto = LicensesData.GetLicenseInfoByApplicationID(applicationID);
            if (dto == null) return null;
            return new LocalLicense(dto);
        }
        private bool _AddNewLicense() {
            this.LicenseID = LicensesData.AddNewLicense(this.ToDTO());
            return (this.LicenseID != -1);
        }
        public bool Save() {
            return _AddNewLicense();
        }
        public static DataTable getLicensesHistoryForPerosn(int perosnID) {
            return LicensesData.getLicensesHistoryForPerson(perosnID);
        }
    }
}