using DataLinkLayer;
using Shared;
using System;
using System.Data;

namespace BusinessLayer {
    public class InternationalLicense {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        // Private Backing Fields for Lazy Loading
        private Applications _application = null;
        private User _createdByUser = null;


        // Lazy Loaded Navigation Property: Application
        public Applications ApplicationInfo {
            get {
                if (_application == null && this.ApplicationID != -1) {
                    _application = Applications.getApplicationByID(this.ApplicationID);
                }
                return _application;
            }
        }

        // Lazy Loaded Navigation Property: CreatedByUser
        public User CreatorUserInfo {
            get {
                if (_createdByUser == null && this.CreatedByUserID != -1) {
                    _createdByUser = User.getUserByID(this.CreatedByUserID);
                }
                return _createdByUser;
            }
        }

        public InternationalLicenseDTO ToDTO() {
            return new InternationalLicenseDTO(
                this.InternationalLicenseID,
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID
            );
        }
        public InternationalLicense() {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = this.IssueDate.AddYears(1);
            this.IsActive = true;
            this.CreatedByUserID = -1;  
        }
        public InternationalLicense(InternationalLicenseDTO DTO) {
            this.InternationalLicenseID = DTO.InternationalLicenseID;
            this.ApplicationID = DTO.ApplicationID;
            this.DriverID = DTO.DriverID;
            this.IssuedUsingLocalLicenseID = DTO.IssuedUsingLocalLicenseID;
            this.IssueDate = DTO.IssueDate;
            this.ExpirationDate = DTO.ExpirationDate;
            this.IsActive = DTO.IsActive;
            this.CreatedByUserID = DTO.CreatedByUserID;
        }
        public static int getInternationalIDByDriverID(int DriverID) {
            return InternationalLicenseData.getInternationalIDByDriverID(DriverID);
        }

        bool _AddNewInternationalLicense() {
            this.InternationalLicenseID = InternationalLicenseData.AddNewInternationalLicense(ToDTO());
            return this.InternationalLicenseID != -1;
        }

        public bool Save() {
            return _AddNewInternationalLicense();
        }

        public static DataTable getIntLicenseHistoryForPersonID(int personID) {
            return InternationalLicenseData.getInternationalLicHistoryForPerson(personID);
        }

        public static enInternationalLicenseEligibility IsChossenLocalLicenseValid(int localLicenseID, out int internationalLicenseID,
           out LocalLicense validLicense) {
            validLicense = null;
            internationalLicenseID = -1;

            LocalLicense localLicense = LocalLicense.GetLicenseByID(localLicenseID);
            if (localLicense == null)
                return enInternationalLicenseEligibility.NotFound;

            if (!localLicense.IsActive)
                return enInternationalLicenseEligibility.NotActive;

            if (localLicense.LicenseClassID != 3)
                return enInternationalLicenseEligibility.NotOrdinaryLicenseCLass;

            internationalLicenseID = InternationalLicense.getInternationalIDByDriverID(localLicense.DriverID);

            if (internationalLicenseID != -1)
                return enInternationalLicenseEligibility.HasActiveInternational;

            validLicense = localLicense;
            return enInternationalLicenseEligibility.Valid;
        }
        static Applications _CreateNewApp(LocalLicense localLicense, int userID) {
            Applications newInternationalApp = new Applications();
            newInternationalApp.personID = localLicense.applicationInfo.personID;
            newInternationalApp.AppDate = DateTime.Now;
            newInternationalApp.lastStatusDate = DateTime.Now;
            newInternationalApp.ApplicaitionTypeID = (int)enApplicationType.NewInternationalLicense;
            newInternationalApp.appStatus = enApplicationStatus.enNew;
            newInternationalApp.paidFees = AppType.getAppFees(enApplicationType.NewInternationalLicense);
            newInternationalApp.createdByUserID = userID;
            if (!newInternationalApp.SaveApplication()) { return null; }
            return newInternationalApp;
        }

        static InternationalLicense _CreateInternationalLicense(Applications newInternationalApp, LocalLicense localLicense, int userID) {
            InternationalLicense internationalLicense = new InternationalLicense();
            internationalLicense.ApplicationID = newInternationalApp.AppID;
            internationalLicense.DriverID = localLicense.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = localLicense.LicenseID;
            internationalLicense.CreatedByUserID = userID;

            if (!internationalLicense.Save()) { return null; }
            return internationalLicense;
        }

        public static InternationalLicense issueInternationaLicense(int localLicenseID, int userID) {

            LocalLicense localLicense = LocalLicense.GetLicenseByID(localLicenseID);

            if (localLicense == null) { return null; }

            Applications newInternationalApp = null;
            if ((newInternationalApp =_CreateNewApp(localLicense, userID)) == null) return null;

            InternationalLicense intLicense = null;
            if ((intLicense = _CreateInternationalLicense(newInternationalApp, localLicense, userID)) == null) return null;
            return intLicense;
        }

        public static DataTable getAllInternationalLicenses() {
            return InternationalLicenseData.getAllInternationalLicenses();
        }

        public static DataTable getLicensesByFilter(enLicenseFilterBy filterColumn, string filterValue) {
            return InternationalLicenseData.GetLicensesByFilter(filterColumn, filterValue);
        }
        public static DataTable getLicensesByStatus(enLicenseStatus filterStatus) {
            string actualStatusText = "";
            switch (filterStatus) {
                case enLicenseStatus.Active:
                    actualStatusText = "Active";
                    break;

                case enLicenseStatus.Suspended:
                    actualStatusText = "Suspended";
                    break;

                case enLicenseStatus.Expired:
                    actualStatusText = "Expired";
                    break;

                default:
                    actualStatusText = "";
                    break;
            }
            return InternationalLicenseData.GetLicensesByFilter(enLicenseFilterBy.LicenseStatus, actualStatusText);
        }
        public static InternationalLicense GetInternationalLicenseByID(int internationalLicenseID) {
            InternationalLicenseDTO dto = InternationalLicenseData.FindInternationalLicenseByID(internationalLicenseID);
            if (dto != null) {
                return new InternationalLicense(dto);
            }
            return null;
        }
        public static bool AutoUpdateExpiredLicenses() {
            return InternationalLicenseData.UpdateExpiredLicensesStatus();
        }
    }
}
