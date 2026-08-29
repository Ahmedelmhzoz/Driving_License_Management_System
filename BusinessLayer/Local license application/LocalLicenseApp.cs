using DataLinkLayer.License_Application_data;
using System;
using System.Data;
using Shared;
namespace BusinessLayer.License_Applications {
    public enum enHowDidSavingGo { enSaved = 1, enErrorWhileSavingLicenseApp = 2, enErrorWhileSavingOriginalApp = 3,
        enNotAllowedAge = 4
    }
    public class LocalLicenseApp : Applications{
        public int LicenseAppID { get; set; }
        public int LicenseClassID { get; set; }
        public LicenseClasses LicenseClassInfo {
            get {
               return LicenseClasses.getLicenseClassByID(this.LicenseClassID);
            }
        }
        public Person personInfo {
            get {
                return Person.findPerson(this.personID);
            }
        }
        public LocalLicenseApp(){
            LicenseAppID = -1;
            LicenseClassID = -1;
        }
        LocalLicenseApp(LicenseApplicationDTO licenseDTO) {
            this.AppID = licenseDTO.AppID;
            this.personID = licenseDTO.personID;
            this.AppDate = licenseDTO.AppDate;
            this.ApplicaitionTypeID = licenseDTO.ApplicaitionTypeID;
            this.lastStatusDate = licenseDTO.lastStatusDate;
            this.appStatus = licenseDTO.appStatus;
            this.paidFees = licenseDTO.paidFees;
            this.createdByUserID = licenseDTO.createdByUserID;
            this.LicenseClassID = licenseDTO.LicenseClassID;
            this.LicenseAppID = licenseDTO.LocalDrivingLicenseApplicationID;
            this.currentMode = enAppMode.updateApp;
        }
        public LicenseApplicationDTO _toDTO() {
            return new LicenseApplicationDTO {
                LocalDrivingLicenseApplicationID = this.LicenseAppID,
                LicenseClassID = this.LicenseClassID,
                AppID = this.AppID,
            };
        }
        public static int DidPersonMakeSameApplication(int personID, int LicenseClassID) {
            return LocalLicenseAppsData.didPersonMakeSameApplication(personID, LicenseClassID);
        }
        int _AddLicenseApplicationInDB() {
            return LocalLicenseAppsData.AddLicenseApplication(_toDTO());
        }

        public static DataTable getAllApplications() {
            return LocalLicenseAppsData.GetAllLocalDrivingLicenseApplications();
        }
        private bool _IsPersonAgeValid() {
            Person person = Person.findPerson(this.personID);
            LicenseClasses licenseClass = LicenseClasses.getLicenseClassByID(this.LicenseClassID);

            int personAge = DateTime.Now.Year - person.dateOfBirth.Year;
            if (person.dateOfBirth.Date > DateTime.Now.AddYears(-personAge)) {
                --personAge;
            }

            return personAge >= licenseClass.minimumAllowedAge;
        }
        enHowDidSavingGo _AddLicenseApp() {
            if (!_IsPersonAgeValid())
                return enHowDidSavingGo.enNotAllowedAge;
            if (!base.Save()) {
                return enHowDidSavingGo.enErrorWhileSavingOriginalApp;
            }

            int appID;
            if ((appID = _AddLicenseApplicationInDB()) != -1) {
                this.LicenseAppID = appID;
                currentMode = enAppMode.updateApp;
                return enHowDidSavingGo.enSaved;
            }
            else {
                return enHowDidSavingGo.enErrorWhileSavingLicenseApp;
            }
        }
        enHowDidSavingGo _UpdateLicenseApp() {
            if (LocalLicenseAppsData.updateLicenseApplication(_toDTO())) {
                return enHowDidSavingGo.enSaved;
            }else {
                return enHowDidSavingGo.enErrorWhileSavingLicenseApp;
            }
        }
        public enHowDidSavingGo SaveLicenseApp() {
            switch (currentMode) {
                case enAppMode.addApp:
                    return _AddLicenseApp();
                default:
                    return _UpdateLicenseApp();
            }
        }
        public static LocalLicenseApp getLocalLicenseAppByID(int id) {
            LicenseApplicationDTO LicenseDto = LocalLicenseAppsData.GetLocalLicenseAppByID(id);
            if (LicenseDto == null) return null;
            return new LocalLicenseApp(LicenseDto);
        }

        private static enLocalAppSearchCategory _ConvertCategoryToEnum(string category) {
            switch (category) {
                case "L.D Application ID":
                    return enLocalAppSearchCategory.enLDApplicationID;
                case "National No.":
                    return enLocalAppSearchCategory.enNationalNo;
                case "Full Name":
                    return enLocalAppSearchCategory.enFullName;
                case "Status":
                    return enLocalAppSearchCategory.enStatus;
                default:
                    return enLocalAppSearchCategory.enLDApplicationID;
            }
        }

        public static DataTable GetApplicationsSearchResult(string currentTxt, string category) {
            // instead of passing directly the name of column in data base that we want to search, we passing enum this is more secured  
            enLocalAppSearchCategory searchCategory = _ConvertCategoryToEnum(category);
            return LocalLicenseAppsData.GetApplicationsSearchResult(currentTxt, searchCategory);
        }

        public static int getPassedExams(int localLicenseApp) {
            return LocalLicenseAppsData.getPassedExams(localLicenseApp);
        }
        public static bool deleteLocalLicenseApp(int localLicenseAppID) { 
            return LocalLicenseAppsData.deleteLocalLicenseApplication(localLicenseAppID);
        }
        public  bool cancelApplication() {
            return updateStatus(this.AppID, enApplicationStatus.enCanceled);
        }
    }
}
