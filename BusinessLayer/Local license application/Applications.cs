using DataLinkLayer.License_Application_data;
using System;
using Shared;

namespace BusinessLayer {
    public class Applications {
        public int AppID { get; set; }
        public int personID { get; set; }
        public DateTime AppDate { get; set; }
        public int ApplicaitionTypeID { get; set; }
        public DateTime lastStatusDate { get; set; }
        public enApplicationStatus appStatus { get; set; }  
        public decimal paidFees { get; set; }
        public int createdByUserID { get; set; }
        public enAppMode currentMode { get; set; }
        public Person personInfo {
            get {
                return Person.findPerson(this.personID);
            }
        }
        public Applications() {
            AppID = -1; createdByUserID = -1; personID = -1;  ApplicaitionTypeID = -1;
            AppDate = DateTime.Now;
            lastStatusDate = DateTime.Now;
            appStatus = enApplicationStatus.enNew;
            paidFees = 0.0m;
            currentMode = enAppMode.addApp;
        }
        ApplicationDTO _toDTO() {
            return new ApplicationDTO {
                AppID = this.AppID,
                personID = this.personID,
                AppDate = this.AppDate,
                ApplicaitionTypeID = this.ApplicaitionTypeID,
                lastStatusDate = this.lastStatusDate,
                appStatus = this.appStatus,
                paidFees = this.paidFees,
                createdByUserID = this.createdByUserID,
            };
        }
        public Applications(ApplicationDTO dto) {
            if (dto != null) {
                this.AppID = dto.AppID;
                this.personID = dto.personID;
                this.AppDate = dto.AppDate;
                this.ApplicaitionTypeID = dto.ApplicaitionTypeID;
                this.lastStatusDate = dto.lastStatusDate;
                this.appStatus = dto.appStatus;
                this.paidFees = dto.paidFees;
                this.createdByUserID = dto.createdByUserID;
                this.currentMode = enAppMode.updateApp;
            }
        }
        bool _AddApplication() {
            ApplicationDTO appDTO = _toDTO();
            AppID = ApplicationsData.AddNewApplication(appDTO);
            return (AppID != -1);
        }
        bool _UpdateApplication() {
            return ApplicationsData.UpdateApplication(_toDTO());
        }
        public bool SaveApplication() {
            switch (currentMode) {
                case enAppMode.addApp:
                    if (_AddApplication()) {
                        currentMode = enAppMode.updateApp;
                        return true;
                    }
                    return false;
                default:
                    return _UpdateApplication();
            }
        }
        public Applications getBasicApplication() {
            return this;
        }
        protected static bool updateStatus(int appID, enApplicationStatus newStatus) {
            byte applicationStatus = (byte)newStatus;
            return ApplicationsData.UpdateStatus(appID, applicationStatus, DateTime.Now);
        }
        public static Applications getApplicationByID(int appID) { 
            ApplicationDTO dto = ApplicationsData.GetApplicationByID(appID);
            if (dto == null) return null;
            return new Applications(dto);
        }
    }
}