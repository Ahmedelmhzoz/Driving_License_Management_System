using DataLinkLayer.License_Application_data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.License_Applications {
    public enum enHowDidSavingGo { enSaved = 1, enErrorWhileSavingLicenseApp = 2, enErrorWhileSavingOriginalApp = 3,
        enNotAllowedAge = 4
    }
    public class LocalLicenseApp : Applications{
        public int LicenseAppID { get; set; }
        public int LicenseClassID { get; set; }
        public LocalLicenseApp(){
            LicenseAppID = -1;
            LicenseClassID = -1;
        }
        LocalLicenseApp(ApplicationDTO appDTO, LicenseApplicationDTO licenseDTO) {
            this.AppID = appDTO.AppID;
            this.personID = appDTO.personID;
            this.AppDate = appDTO.AppDate;
            this.ApplicaitionTypeID = appDTO.ApplicaitionTypeID;
            this.lastStatusDate = appDTO.lastStatusDate;
            this.appStatus = appDTO.appStatus;
            this.paidFees = appDTO.paidFees;
            this.createdByUserID = appDTO.createdByUserID;
            this.LicenseAppID = licenseDTO.LicenseClassID;
            this.LicenseAppID = licenseDTO.LocalDrivingLicenseApplicationID;
            this.currentMode = enAppMode.updateApp;
        }
        public LicenseApplicationDTO _toDTO() {
            return new LicenseApplicationDTO {
                LicenseClassID = this.LicenseClassID,
                appID = this.AppID,
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

        // update license لآ
        public enHowDidSavingGo SaveLicenseApp() {

            switch (currentMode) {
                case enAppMode.addApp:
                    return _AddLicenseApp();
                default:
                    return enHowDidSavingGo.enSaved;
                    
            }
        }
        public static LocalLicenseApp getLocalLicenseAppByID(int id) {
            LicenseApplicationDTO LicenseDto;
            if ((LicenseDto = LocalLicenseAppsData.GetLocalLicenseAppByID(id)) != null) {
                ApplicationDTO appDto;
                if ((appDto = Applications.getPrimaryApplication(LicenseDto.appID)) != null) {
                    return new LocalLicenseApp(appDto, LicenseDto);
                }
            }
            return null;
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

    }
}
