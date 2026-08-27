using DataLinkLayer.License_Application_data;
using System;
using Shared;
using System.Net;

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
        protected Applications() {
            AppID = -1; createdByUserID = -1; personID = -1;  ApplicaitionTypeID = -1;
            AppDate = DateTime.Now;
            lastStatusDate = DateTime.Now;
            appStatus = enApplicationStatus.enNew;
            paidFees = 0.0m;
            currentMode = enAppMode.addApp;
        }
        ApplicationDTO _toDTO() {
            return new ApplicationDTO {
                personID = this.personID,
                AppDate = this.AppDate,
                ApplicaitionTypeID = this.ApplicaitionTypeID,
                lastStatusDate = this.lastStatusDate,
                appStatus = this.appStatus,
                paidFees = this.paidFees,
                createdByUserID = this.createdByUserID,
            };
        }

        int _addApplication() {
            ApplicationDTO appDTO = _toDTO();
            return ApplicationsData.AddNewApplication(appDTO);
        }

        protected bool Save() {
            switch (currentMode) {
                case enAppMode.addApp:
                    int appID;
                    if ((appID = _addApplication()) != -1) {
                        this.AppID = appID;
                        currentMode = enAppMode.updateApp;
                        return true;
                    }
                    return false;
                default:
                    return true;
                    //code
            }
        }
    
        protected static ApplicationDTO getPrimaryApplication(int appID) {
            ApplicationDTO dto = ApplicationsData.GetApplicationByID(appID);

            
            return dto;
        }

        public Applications getBasicApplication() {
            return this;
        }
        protected static bool updateStatus(int appID, enApplicationStatus newStatus) {
            byte applicationStatus = (byte)newStatus;
            return ApplicationsData.UpdateStatus(appID, applicationStatus, DateTime.Now);
        }
    }
}
