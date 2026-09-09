using DataLinkLayer; 
using DataLinkLayer.License_Application_data;
using Shared;
using System;
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
        public bool NotSuspended { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        private LicenseClass _licenseInfo;
        private User _IssuerUser;
        public User issuerUserInfo {
            get {
                if (_IssuerUser == null) {
                    _IssuerUser = User.getUserByID(CreatedByUserID);
                }
                return _IssuerUser;
            }
        }
        public LicenseClass licenseInfo {
            get {
                if (_licenseInfo == null) {
                    _licenseInfo = LicenseClass.getLicenseClassByID(LicenseClassID);
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
            this.NotSuspended = true;
            this.IssueReason = enIssueReason.enFirstTime;
            this.CreatedByUserID = -1;
        }
        public LocalLicense(LocalLicenseDTO dto) {
            if (dto != null) {
                this.LicenseID = dto.LicenseID;
                this.ApplicationID = dto.ApplicationID;
                this.DriverID = dto.DriverID;
                this.LicenseClassID = dto.LicenseClassID;
                this.IssueDate = dto.IssueDate;
                this.ExpirationDate = dto.ExpirationDate;
                this.Notes = dto.Notes;
                this.PaidFees = dto.PaidFees;
                this.NotSuspended = dto.NotSuspended;
                this.IssueReason = dto.IssueReason;
                this.CreatedByUserID = dto.CreatedByUserID;
            }
        }
        public LocalLicenseDTO ToDTO() {
            return new LocalLicenseDTO {
                LicenseID = this.LicenseID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = this.PaidFees,
                NotSuspended = this.NotSuspended,
                IssueReason = this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };
        }
        public static LocalLicense GetLicenseByApplicationID(int applicationID) {
            LocalLicenseDTO dto = LocalLicensesData.GetLicenseInfoByApplicationID(applicationID);
            if (dto == null) return null;
            return new LocalLicense(dto);
        }
        public static LocalLicense GetLicenseByID(int licenseID) {
            LocalLicenseDTO dto = LocalLicensesData.GetLicenseInfoByID(licenseID);
            if (dto == null) return null;
            return new LocalLicense(dto);
        }
        private bool _AddNewLicense() {
            this.LicenseID = LocalLicensesData.AddNewLicense(this.ToDTO());
            return (this.LicenseID != -1);
        }
        public bool Save() {
            return _AddNewLicense();
        }
        public static DataTable getLocalLicensesHistoryForPerosn(int perosnID) {
            return LocalLicensesData.getLocalLicensesHistoryForPerson(perosnID);
        }
        public enLicenseStatus getLicenseStatus() {
            if (!this.NotSuspended) return enLicenseStatus.Suspended;
            else if (this.ExpirationDate.Date < DateTime.Today) return enLicenseStatus.Expired;
            else return enLicenseStatus.Active;
        }
        public bool canRenew() {
            return getLicenseStatus() == enLicenseStatus.Expired && LocalLicensesData.getRenewalLicenseID(this.LicenseID) == -1;
        }
        LocalLicenseDTO _createRenewalLocalLicenseDTO(int userID, string Notes) {
            LocalLicenseDTO localLicenseDTO = new LocalLicenseDTO();
            localLicenseDTO.LicenseID = this.LicenseID; // will updated from LicenseRenewalData
            localLicenseDTO.DriverID = this.DriverID;
            localLicenseDTO.LicenseClassID = this.LicenseClassID;
            localLicenseDTO.IssueDate = DateTime.Now;

            if (licenseInfo == null) return null;
            localLicenseDTO.ExpirationDate = localLicenseDTO.IssueDate.AddYears(licenseInfo.DefaultValidityLength);
            localLicenseDTO.Notes = Notes;
            localLicenseDTO.PaidFees = this.PaidFees;
            localLicenseDTO.NotSuspended = true;
            localLicenseDTO.IssueReason = enIssueReason.enRenew;
            localLicenseDTO.CreatedByUserID = userID;
            return localLicenseDTO;
        }
        LocalLicenseDTO _createReplacerLocalLicenseDTO(int userID, string Notes, enIssueReason reason) {
            LocalLicenseDTO localLicenseDTO = new LocalLicenseDTO();
            localLicenseDTO.LicenseID = this.LicenseID; // will need the old app ID to update IsActive = 0
            localLicenseDTO.DriverID = this.DriverID;
            localLicenseDTO.LicenseClassID = this.LicenseClassID;
            localLicenseDTO.IssueDate = DateTime.Now;

            if (licenseInfo == null) return null;
            localLicenseDTO.ExpirationDate = localLicenseDTO.IssueDate.AddYears(licenseInfo.DefaultValidityLength);
            localLicenseDTO.Notes = Notes;
            localLicenseDTO.PaidFees = 0m;
            localLicenseDTO.NotSuspended = true;
            localLicenseDTO.IssueReason = reason;
            localLicenseDTO.CreatedByUserID = userID;
            return localLicenseDTO;
        }
        public LicenseRenewalResult Renew(int userID, string Notes) {
            LicenseRenewalResult result = new LicenseRenewalResult();
            if (!canRenew()) { result.Result = enLicenseRenewalResult.Failed; return result; }

            if (this.applicationInfo == null) { result.Result = enLicenseRenewalResult.BasicAppNotFound; return result; }
            

            Person personOwnsLicense = this.applicationInfo.personInfo;
            if (personOwnsLicense == null) { result.Result = enLicenseRenewalResult.PersonNotFound; return result; }

            ApplicationDTO renewalApplication = Applications.createAppOfSomeKind(userID, personOwnsLicense.personID, enApplicationType.RenewDrivingLicense);
            if (renewalApplication == null) { result.Result = enLicenseRenewalResult.Failed; return result; }

            LocalLicenseDTO Renewallicense = _createRenewalLocalLicenseDTO(userID, Notes);
            if (Renewallicense == null) { result.Result = enLicenseRenewalResult.Failed; return result; }


            return LicenseRenewalData.RenewLicense(renewalApplication, Renewallicense);
        }
        public int getRenewalLicenseID() {
            return LocalLicensesData.getRenewalLicenseID(this.LicenseID);
        }
        public bool isLicenseDenied() {
            return DetainLicense.isLicenseDetained(this.LicenseID);
        }

        public enLicenseEligibility licenseEligibility() {
            enLicenseStatus status = getLicenseStatus();
            if (isLicenseDenied()) {
                return enLicenseEligibility.Detained;
            } 
            else if (status == enLicenseStatus.Expired) {
                return enLicenseEligibility.Expired;
            } 
            else if (status == enLicenseStatus.Suspended) {
                return enLicenseEligibility.Suspended;
            } 
            else {
                return enLicenseEligibility.Eligible;
            }
        }
        public LocalLicense _IssueReplacement(int userID, string Notes, enApplicationType applicationType) {
            enIssueReason issueReason = enIssueReason.enReplacementForDamaged;

            if (applicationType == enApplicationType.ReplaceDamagedDrivingLicense) 
                issueReason = enIssueReason.enReplacementForDamaged;
            else
                issueReason = enIssueReason.enReplacementForLost;

            if (this.applicationInfo == null) { throw new Exception("Failed to fetch applicationInfo form DB"); }

            Person personOwnsLicense = this.applicationInfo.personInfo;
            if(personOwnsLicense == null) { throw new Exception("Failed to fetch applicationInfo form DB"); }

            ApplicationDTO replacementApplication = Applications.createAppOfSomeKind(userID, personOwnsLicense.personID, applicationType);
            if (replacementApplication == null) { throw new Exception("Failed to create replacemet new app"); }

            LocalLicenseDTO replacerLicense = _createReplacerLocalLicenseDTO(userID, Notes, issueReason);
            if (replacerLicense == null) { throw new Exception("Failed to create replacemet license"); }

            return GetLicenseByID(ReplacementIssuingData.issueReplacer(replacementApplication, replacerLicense));
        }

        public LocalLicense issueReplacerForDamage(int userID, string Notes) {
            return _IssueReplacement(userID, Notes, enApplicationType.ReplaceDamagedDrivingLicense);
        }
        public LocalLicense issueReplacerForLost(int userID, string Notes) {
            return _IssueReplacement(userID, Notes, enApplicationType.ReplaceLostDrivingLicense);
        }
        public DetainResult Detain(InputtedDetainDetails inputedData) {
            inputedData.LicenseID = this.LicenseID;
            return DetainLicense.detainLicense(inputedData);
        }
    }
}